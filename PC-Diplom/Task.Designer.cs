namespace PC_Diplom
{
    partial class Task
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonJPEG = new System.Windows.Forms.Button();
            this.textBoxVopros = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonSendTest = new System.Windows.Forms.Button();
            this.buttonQR = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // buttonJPEG
            // 
            this.buttonJPEG.Location = new System.Drawing.Point(68, 160);
            this.buttonJPEG.Name = "buttonJPEG";
            this.buttonJPEG.Size = new System.Drawing.Size(147, 23);
            this.buttonJPEG.TabIndex = 24;
            this.buttonJPEG.Text = "Загрузить картинку";
            this.buttonJPEG.UseVisualStyleBackColor = true;
            this.buttonJPEG.Click += new System.EventHandler(this.buttonJPEG_Click);
            // 
            // textBoxVopros
            // 
            this.textBoxVopros.Location = new System.Drawing.Point(67, 12);
            this.textBoxVopros.Multiline = true;
            this.textBoxVopros.Name = "textBoxVopros";
            this.textBoxVopros.Size = new System.Drawing.Size(431, 142);
            this.textBoxVopros.TabIndex = 23;
            this.textBoxVopros.TextChanged += new System.EventHandler(this.textBoxVopros_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(17, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Задача";
            // 
            // buttonSendTest
            // 
            this.buttonSendTest.Location = new System.Drawing.Point(67, 189);
            this.buttonSendTest.Name = "buttonSendTest";
            this.buttonSendTest.Size = new System.Drawing.Size(146, 23);
            this.buttonSendTest.TabIndex = 21;
            this.buttonSendTest.Text = "Отправить задачу";
            this.buttonSendTest.UseVisualStyleBackColor = true;
            this.buttonSendTest.Click += new System.EventHandler(this.buttonSendTest_Click);
            // 
            // buttonQR
            // 
            this.buttonQR.Location = new System.Drawing.Point(69, 218);
            this.buttonQR.Name = "buttonQR";
            this.buttonQR.Size = new System.Drawing.Size(146, 37);
            this.buttonQR.TabIndex = 25;
            this.buttonQR.Text = "Закончить создание задач";
            this.buttonQR.UseVisualStyleBackColor = true;
            this.buttonQR.Click += new System.EventHandler(this.buttonQR_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Task
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PC_Diplom.Properties.Resources.BG_SJ;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(510, 266);
            this.Controls.Add(this.buttonQR);
            this.Controls.Add(this.buttonJPEG);
            this.Controls.Add(this.textBoxVopros);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSendTest);
            this.Name = "Task";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Task";
            this.Load += new System.EventHandler(this.Task_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonJPEG;
        private System.Windows.Forms.TextBox textBoxVopros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonSendTest;
        private System.Windows.Forms.Button buttonQR;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}