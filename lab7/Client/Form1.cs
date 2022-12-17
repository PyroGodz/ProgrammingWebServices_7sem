using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void rss_button_Click(object sender, EventArgs e)
        {
            string wssUrl = String.Format("http://localhost:8734/Design_Time_Addresses/solution/Feed1/students/{0}/notes?format=rss", textBox1.Text);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(wssUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            richTextBox1.Text = content;
        }

        private void atom_button_Click(object sender, EventArgs e)
        {
            string wssUrl = String.Format("http://localhost:8734/Design_Time_Addresses/solution/Feed1/students/{0}/notes?format=atom", textBox1.Text);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(wssUrl);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            richTextBox1.Text = content;
        }
    }
}
