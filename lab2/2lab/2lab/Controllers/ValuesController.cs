using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Text.Json;
using System.Web.Mvc;
using System.Linq;

namespace _2lab.Controllers
{
    public class ValuesController : ApiController
    {
        int result; 
        Stack<int> stack;
        public ValuesController()
        {
            result = HttpContext.Current.Application["result"] == null ? 0 : (int)HttpContext.Current.Application["result"];
            stack = (Stack<int>)HttpContext.Current.Application["stack"] == null ? new Stack<int>() : (Stack<int>)HttpContext.Current.Application["stack"];
        }

        // GET api/values
        public IHttpActionResult Get()
        {
            int topValue = 0;
            if (stack.Count() != 0)
                topValue = stack.Peek();
            return Json(new { RESULT = result + topValue, STACK = JsonSerializer.Serialize(stack) });
        }

        // POST api/values
        public void Post(int result)
        {
            this.result = result;
            HttpContext.Current.Application["result"] = result;
        }

        // PUT api/values/5
        public void Put(int add)
        {
            stack.Push(add);
            HttpContext.Current.Application["stack"] = stack;
        }

        // DELETE api/values/5
        public void Delete()
        {
            if (stack.Count > 0)
            {
                stack.Pop();
            }
            HttpContext.Current.Application["stack"] = stack;
        }
    }
}
