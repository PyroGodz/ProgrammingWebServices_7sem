using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        pws_lab6Model.pws_lab6Entities pws_lab6Entities;
        public Form1()
        {
            pws_lab6Entities = new pws_lab6Model.pws_lab6Entities(new Uri("https://localhost:44357/WcfDataService1.svc/"));

            InitializeComponent();
        }

        private void getStudents_Click(object sender, EventArgs e)
        {
            result.Text = "";
            foreach (var student in pws_lab6Entities.Student.AsEnumerable())
            {
                result.Text += string.Format("Student: '{0}' (id:{1})\n", student.Name, student.Id);
            }
        }

        private void getNotes_Click(object sender, EventArgs e)
        {
            var notes = pws_lab6Entities.Note.Where(n => n.NoteValue >= 4).ToList();

            result.Text = "";
            foreach (var note in notes)
            {
                result.Text += string.Format("Note: {0} on exam {1} (id student:{2})\n", note.NoteValue, note.Subj, note.StudentId);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }

}

