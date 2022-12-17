
namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.result = new System.Windows.Forms.TextBox();
            this.getNotes = new System.Windows.Forms.Button();
            this.getStudents = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(70, 201);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(304, 27);
            this.result.TabIndex = 0;
            this.result.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // getNotes
            // 
            this.getNotes.Location = new System.Drawing.Point(296, 63);
            this.getNotes.Name = "getNotes";
            this.getNotes.Size = new System.Drawing.Size(94, 29);
            this.getNotes.TabIndex = 1;
            this.getNotes.Text = "button1";
            this.getNotes.UseVisualStyleBackColor = true;
            // 
            // getStudents
            // 
            this.getStudents.Location = new System.Drawing.Point(93, 63);
            this.getStudents.Name = "getStudents";
            this.getStudents.Size = new System.Drawing.Size(94, 29);
            this.getStudents.TabIndex = 2;
            this.getStudents.Text = "button2";
            this.getStudents.UseVisualStyleBackColor = true;
            this.getStudents.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.getStudents);
            this.Controls.Add(this.getNotes);
            this.Controls.Add(this.result);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Button getNotes;
        private System.Windows.Forms.Button getStudents;
    }
}

