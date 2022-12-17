using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WDSModel;

namespace Client
{
    public partial class WebForm1 : Page
    {
        private WDSEntities entities;
        protected void Page_Load(object sender, EventArgs e)
        {
            entities = new WDSEntities(new Uri("http://localhost:51172/DataServices/WDS.svc/"));
        }

        protected void request_Click(object sender, EventArgs e)
        {
            content.InnerText = "";

            foreach (var student in entities.Students.AsEnumerable())
            {
                content.InnerText += string.Format("Student: {0} (id={1})\n", student.Name, student.Id);
            }
        }

        protected void request2_Click(object sender, EventArgs e)
        {
            content2.InnerText = "";
            IEnumerable<Notes> notes = entities.Notes.Where(n => n.NoteValue % 2 != 0).OrderBy(n => n.Subj).AsEnumerable();

            foreach (var note in notes)
            {
                content2.InnerText += string.Format("Notet: {0} (subj={1})\n", note.NoteValue, note.Subj);
            }
        }
    }
}