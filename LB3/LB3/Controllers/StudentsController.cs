using LB3.Models;
using System.Web.Http;
using System.Web.WebPages;
using System.Linq;
using System;
using System.Net;
using System.Collections.Generic;
using System.Web.Http.Description;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace LB3.Controllers
{

    public class StudentsController : ApiController
    {
        private StudentContext DB = new StudentContext();

        // GET api/students
        [HttpGet]
        [ResponseType(typeof(Student))]
        [Route("api/{path:regex((students)[.](json)|(students)[.](xml))}")]
        public IHttpActionResult GetStudents(
            string path = "students.json",

            string name = null,
            string columns = "",
            string phone = null,

            int offset = 0,
            int limit = 5,

            string globalLike = "",
            string sort = "off",

            int minId = 0,
            int maxId = 10000,
            int page = 1
        )
        {
            var students = new List<Student>();
            var sqlQuery = string.Empty;
            string orderBy;
            var pages = 0;

            bool isStudListFilled = false;

            if (sort.Equals("on")) { orderBy = "NAME"; }
            else { orderBy = "ID"; }

            if (globalLike.IsEmpty())
            {
                
                string sqlName = "";
                if (name != null) { sqlName = $" AND NAME LIKE N'%{name}%' "; }

                string sqlPhone = "";
                if (phone != null) { sqlPhone = $" AND PHONE = {phone} "; }

                sqlQuery = $"SELECT * FROM Students WHERE ID >= {minId} AND ID <= {maxId} {sqlName} {sqlPhone} ORDER BY {orderBy}";

                students = DB.Students.SqlQuery(sqlQuery).ToList();

                students = students.Skip(offset).ToList();
                pages = Decimal.ToInt32(Math.Ceiling(Convert.ToDecimal(students.Count) / Convert.ToDecimal(limit)));

                if (page > 1)
                {
                    students = students.Skip((page - 1) * limit).ToList();
                    if (students.Count < 1)
                    {
                        return Content(
                            HttpStatusCode.BadRequest,
                            new CustomError(4414, Request.RequestUri.GetLeftPart(UriPartial.Authority)));
                    }
                }

                students = students.Take(limit).ToList();

                isStudListFilled = true;
            }
            else
            {
                sqlQuery = "SELECT * FROM Students " +
                    $"WHERE ID >= {minId} AND " +
                    $"ID <= {maxId} " +
                    $"AND UPPER(CONCAT(ID, CONCAT(NAME, PHONE))) LIKE N'%{globalLike.ToUpper()}%' " +
                    "ORDER BY " + orderBy;

                students = DB.Students.SqlQuery(sqlQuery).ToList();

                students = students.Skip(offset).ToList();
                pages = Decimal.ToInt32(Math.Ceiling(Convert.ToDecimal(students.Count) / Convert.ToDecimal(limit)));

                if (page > 1)
                {
                    students = students.Skip((page - 1) * limit).ToList();
                    if (students.Count < 1)
                    {
                        return Content(
                            HttpStatusCode.BadRequest,
                            new CustomError(4414, Request.RequestUri.GetLeftPart(UriPartial.Authority)));
                    }
                }

                students = students.Take(limit).ToList();

                isStudListFilled = true;
            }

            string linkStudents = Request.RequestUri.GetLeftPart(UriPartial.Path);

            students.ForEach(student => student._links =
                new HateoasLinks(linkStudents, linkStudents + student.ID));

            columns = columns?.ToLower();

            if (!string.IsNullOrEmpty(columns))
            {
                if (!columns.Contains("name") && isStudListFilled)
                    students.ForEach(stud => stud.NAME = null);

                if (!columns.Contains("phone") && isStudListFilled)
                    students.ForEach(stud => stud.PHONE = null);

                if (!columns.Contains("id") && isStudListFilled)
                    students.ForEach(stud => stud.ID = 0);
            }

            var currentPages = new List<string>();
            for (int i = 1; i <= pages; i++)
            {
                currentPages.Add((Request.RequestUri.GetLeftPart(UriPartial.Query).Replace($"page={page}", $"page={i}")));
            }

            var currentPage = new Page() { Students = students, _links = new HateoasPageLinks(currentPages, Request.RequestUri.GetLeftPart(UriPartial.Query)) };

            if (path.Equals("students.json")) { return Json(currentPage); }

            return Ok(currentPage);
        }

        // GET api/students/5
        [HttpGet]
        [ResponseType(typeof(Student))]
        [Route("api/{path:regex((students)[.](json)|(students)[.](xml))}/{id}")]
        public IHttpActionResult Get(int? id, string path = "students.json")
        {
            try
            {
                var student = DB.Students.Where(stud => stud.ID == id).FirstOrDefault();
                string linkStudent = Request.RequestUri.GetLeftPart(UriPartial.Path);

                student._links = new HateoasLinks(
                    linkStudent.Substring(0, linkStudent.LastIndexOf("/")), 
                    linkStudent);

                if(path.Equals("students.json")) { return Json(student); }

                return Ok(student);
            }
            catch (Exception)
            {
                return Content(
                    HttpStatusCode.BadRequest, 
                    new CustomError(4404, Request.RequestUri.GetLeftPart(UriPartial.Authority)));
            }
        }

        // POST api/students
        [HttpPost]
        [ResponseType(typeof(Student))]
        [Route("api/{path:regex((students)[.](json)|(students)[.](xml))}")]
        public IHttpActionResult PostStudent(Student student, string path = "students.json")
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, 
                    new CustomError(4444, Request.RequestUri.GetLeftPart(UriPartial.Authority)));
            }

            DB.Students.Add(student);
            DB.SaveChanges();

            string linkStudents = Request.RequestUri.GetLeftPart(UriPartial.Path);
            student._links = new HateoasLinks(linkStudents, linkStudents + student.ID);

            if (path.Equals("students.json")) { return Json(student); }

            return Ok(student);
        }

        // PUT api/students/5
        [HttpPut]
        [ResponseType(typeof(Student))]
        [Route("api/{path:regex((students)[.](json)|(students)[.](xml))}/{id}")]
        public IHttpActionResult PutStudent(int id, Student student, string path = "students.json")
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, 
                    new CustomError(4444, Request.RequestUri.GetLeftPart(UriPartial.Authority)));
            }

            if (id != student.ID)
            {
                return Content(HttpStatusCode.BadRequest, 
                    new CustomError(4404, Request.RequestUri.GetLeftPart(UriPartial.Authority)));
            }

            DB.Entry(student).State = EntityState.Modified;

            try { DB.SaveChanges(); }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return Content(HttpStatusCode.BadRequest, 
                        new CustomError(4404, Request.RequestUri.GetLeftPart(UriPartial.Authority)));
                }
                else { throw; }
            }

            string linkStudents = Request.RequestUri.GetLeftPart(UriPartial.Path);
            student._links = new HateoasLinks(linkStudents, linkStudents + student.ID);

            if (path.Equals("students.json")) { return Json(student); }

            return Ok(student);
        }

        // DELETE api/students/5
        [HttpDelete]
        [ResponseType(typeof(Student))]
        [Route("api/{path:regex((students)[.](json)|(students)[.](xml))}/{id}")]
        public IHttpActionResult DeleteStudent(int id, string path = "students.json")
        {
            Student student = DB.Students.Find(id);
            if (student == null)
            {
                return Content(HttpStatusCode.BadRequest, 
                    new CustomError(4404, Request.RequestUri.GetLeftPart(UriPartial.Authority)));
            }

            DB.Students.Remove(student);
            DB.SaveChanges();

            string linkStudents = Request.RequestUri.GetLeftPart(UriPartial.Path);
            student._links = new HateoasLinks(linkStudents, linkStudents + student.ID);

            if (path.Equals("students.json")) { return Json(student); }

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) { DB.Dispose(); }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return DB.Students.Count(stud => stud.ID == id) > 0;
        }
    }
}
