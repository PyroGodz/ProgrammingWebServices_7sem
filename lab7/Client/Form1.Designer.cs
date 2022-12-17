
namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.rss_button = new System.Windows.Forms.Button();
            this.atom_button = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 75);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(249, 370);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // rss_button
            // 
            this.rss_button.Location = new System.Drawing.Point(267, 75);
            this.rss_button.Name = "rss_button";
            this.rss_button.Size = new System.Drawing.Size(75, 23);
            this.rss_button.TabIndex = 1;
            this.rss_button.Text = "rss";
            this.rss_button.UseVisualStyleBackColor = true;
            this.rss_button.Click += new System.EventHandler(this.rss_button_Click);
            // 
            // atom_button
            // 
            this.atom_button.Location = new System.Drawing.Point(267, 104);
            this.atom_button.Name = "atom_button";
            this.atom_button.Size = new System.Drawing.Size(75, 23);
            this.atom_button.TabIndex = 2;
            this.atom_button.Text = "atom";
            this.atom_button.UseVisualStyleBackColor = true;
            this.atom_button.Click += new System.EventHandler(this.atom_button_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(267, 133);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(75, 22);
            this.textBox1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.atom_button);
            this.Controls.Add(this.rss_button);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button rss_button;
        private System.Windows.Forms.Button atom_button;
        private System.Windows.Forms.TextBox textBox1;
    }
}

