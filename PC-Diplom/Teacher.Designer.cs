﻿namespace PC_Diplom
{
    partial class Teacher
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
            this.buttonTest = new System.Windows.Forms.Button();
            this.buttonResult = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonDownPDF = new System.Windows.Forms.Button();
            this.textBoxNameTest = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(9, 51);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(102, 23);
            this.buttonTest.TabIndex = 0;
            this.buttonTest.Text = "Создать тесты";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // buttonResult
            // 
            this.buttonResult.Location = new System.Drawing.Point(9, 80);
            this.buttonResult.Name = "buttonResult";
            this.buttonResult.Size = new System.Drawing.Size(222, 23);
            this.buttonResult.TabIndex = 1;
            this.buttonResult.Text = "Проверить результаты студентов";
            this.buttonResult.UseVisualStyleBackColor = true;
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(12, 109);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonDownPDF
            // 
            this.buttonDownPDF.Location = new System.Drawing.Point(129, 51);
            this.buttonDownPDF.Name = "buttonDownPDF";
            this.buttonDownPDF.Size = new System.Drawing.Size(102, 23);
            this.buttonDownPDF.TabIndex = 34;
            this.buttonDownPDF.Text = "Загрузить PDF";
            this.buttonDownPDF.UseVisualStyleBackColor = true;
            this.buttonDownPDF.Click += new System.EventHandler(this.buttonDownPDF_Click);
            // 
            // textBoxNameTest
            // 
            this.textBoxNameTest.Location = new System.Drawing.Point(9, 25);
            this.textBoxNameTest.Name = "textBoxNameTest";
            this.textBoxNameTest.Size = new System.Drawing.Size(222, 20);
            this.textBoxNameTest.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Название теста";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Teacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 179);
            this.Controls.Add(this.buttonDownPDF);
            this.Controls.Add(this.textBoxNameTest);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonResult);
            this.Controls.Add(this.buttonTest);
            this.Name = "Teacher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.Teacher_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Button buttonResult;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonDownPDF;
        private System.Windows.Forms.TextBox textBoxNameTest;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}