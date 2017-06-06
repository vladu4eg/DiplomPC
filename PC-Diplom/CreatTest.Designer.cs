namespace PC_Diplom
{
    partial class CreatTest
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
            this.buttonSendTest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxVopros = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxOtvetA = new System.Windows.Forms.TextBox();
            this.textBoxOtvetB = new System.Windows.Forms.TextBox();
            this.textBoxOtvetV = new System.Windows.Forms.TextBox();
            this.textBoxOtvetG = new System.Windows.Forms.TextBox();
            this.radioButtonOtvetA = new System.Windows.Forms.RadioButton();
            this.radioButtonOtvetB = new System.Windows.Forms.RadioButton();
            this.radioButtonOtvetV = new System.Windows.Forms.RadioButton();
            this.radioButtonOtvetG = new System.Windows.Forms.RadioButton();
            this.labelError = new System.Windows.Forms.Label();
            this.buttonJPEG = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.buttonQR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSendTest
            // 
            this.buttonSendTest.Location = new System.Drawing.Point(64, 298);
            this.buttonSendTest.Name = "buttonSendTest";
            this.buttonSendTest.Size = new System.Drawing.Size(146, 23);
            this.buttonSendTest.TabIndex = 0;
            this.buttonSendTest.Text = "Отправить тест";
            this.buttonSendTest.UseVisualStyleBackColor = true;
            this.buttonSendTest.Click += new System.EventHandler(this.buttonSendTest_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Вопрос";
            // 
            // textBoxVopros
            // 
            this.textBoxVopros.Location = new System.Drawing.Point(63, 17);
            this.textBoxVopros.Multiline = true;
            this.textBoxVopros.Name = "textBoxVopros";
            this.textBoxVopros.Size = new System.Drawing.Size(275, 142);
            this.textBoxVopros.TabIndex = 4;
            this.textBoxVopros.TextChanged += new System.EventHandler(this.textBoxVopros_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ответ А";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ответ Б";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Ответ В";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Ответ Г";
            // 
            // textBoxOtvetA
            // 
            this.textBoxOtvetA.Location = new System.Drawing.Point(63, 165);
            this.textBoxOtvetA.Name = "textBoxOtvetA";
            this.textBoxOtvetA.Size = new System.Drawing.Size(146, 20);
            this.textBoxOtvetA.TabIndex = 9;
            // 
            // textBoxOtvetB
            // 
            this.textBoxOtvetB.Location = new System.Drawing.Point(62, 191);
            this.textBoxOtvetB.Name = "textBoxOtvetB";
            this.textBoxOtvetB.Size = new System.Drawing.Size(146, 20);
            this.textBoxOtvetB.TabIndex = 10;
            // 
            // textBoxOtvetV
            // 
            this.textBoxOtvetV.Location = new System.Drawing.Point(62, 217);
            this.textBoxOtvetV.Name = "textBoxOtvetV";
            this.textBoxOtvetV.Size = new System.Drawing.Size(146, 20);
            this.textBoxOtvetV.TabIndex = 11;
            // 
            // textBoxOtvetG
            // 
            this.textBoxOtvetG.Location = new System.Drawing.Point(62, 243);
            this.textBoxOtvetG.Name = "textBoxOtvetG";
            this.textBoxOtvetG.Size = new System.Drawing.Size(146, 20);
            this.textBoxOtvetG.TabIndex = 12;
            // 
            // radioButtonOtvetA
            // 
            this.radioButtonOtvetA.AutoSize = true;
            this.radioButtonOtvetA.Location = new System.Drawing.Point(215, 165);
            this.radioButtonOtvetA.Name = "radioButtonOtvetA";
            this.radioButtonOtvetA.Size = new System.Drawing.Size(120, 17);
            this.radioButtonOtvetA.TabIndex = 13;
            this.radioButtonOtvetA.TabStop = true;
            this.radioButtonOtvetA.Text = "Правильный ответ";
            this.radioButtonOtvetA.UseVisualStyleBackColor = true;
            this.radioButtonOtvetA.CheckedChanged += new System.EventHandler(this.radioButtonOtvetA_CheckedChanged);
            // 
            // radioButtonOtvetB
            // 
            this.radioButtonOtvetB.AutoSize = true;
            this.radioButtonOtvetB.Location = new System.Drawing.Point(214, 191);
            this.radioButtonOtvetB.Name = "radioButtonOtvetB";
            this.radioButtonOtvetB.Size = new System.Drawing.Size(120, 17);
            this.radioButtonOtvetB.TabIndex = 14;
            this.radioButtonOtvetB.TabStop = true;
            this.radioButtonOtvetB.Text = "Правильный ответ";
            this.radioButtonOtvetB.UseVisualStyleBackColor = true;
            this.radioButtonOtvetB.CheckedChanged += new System.EventHandler(this.radioButtonOtvetB_CheckedChanged);
            // 
            // radioButtonOtvetV
            // 
            this.radioButtonOtvetV.AutoSize = true;
            this.radioButtonOtvetV.Location = new System.Drawing.Point(214, 217);
            this.radioButtonOtvetV.Name = "radioButtonOtvetV";
            this.radioButtonOtvetV.Size = new System.Drawing.Size(120, 17);
            this.radioButtonOtvetV.TabIndex = 15;
            this.radioButtonOtvetV.TabStop = true;
            this.radioButtonOtvetV.Text = "Правильный ответ";
            this.radioButtonOtvetV.UseVisualStyleBackColor = true;
            this.radioButtonOtvetV.CheckedChanged += new System.EventHandler(this.radioButtonOtvetV_CheckedChanged);
            // 
            // radioButtonOtvetG
            // 
            this.radioButtonOtvetG.AutoSize = true;
            this.radioButtonOtvetG.Location = new System.Drawing.Point(214, 243);
            this.radioButtonOtvetG.Name = "radioButtonOtvetG";
            this.radioButtonOtvetG.Size = new System.Drawing.Size(120, 17);
            this.radioButtonOtvetG.TabIndex = 16;
            this.radioButtonOtvetG.TabStop = true;
            this.radioButtonOtvetG.Text = "Правильный ответ";
            this.radioButtonOtvetG.UseVisualStyleBackColor = true;
            this.radioButtonOtvetG.CheckedChanged += new System.EventHandler(this.radioButtonOtvetG_CheckedChanged);
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(216, 263);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(85, 13);
            this.labelError.TabIndex = 19;
            this.labelError.Text = "Анализ ошибок";
            // 
            // buttonJPEG
            // 
            this.buttonJPEG.Location = new System.Drawing.Point(63, 269);
            this.buttonJPEG.Name = "buttonJPEG";
            this.buttonJPEG.Size = new System.Drawing.Size(147, 23);
            this.buttonJPEG.TabIndex = 20;
            this.buttonJPEG.Text = "Загрузить картинку";
            this.buttonJPEG.UseVisualStyleBackColor = true;
            this.buttonJPEG.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // buttonQR
            // 
            this.buttonQR.Location = new System.Drawing.Point(62, 357);
            this.buttonQR.Name = "buttonQR";
            this.buttonQR.Size = new System.Drawing.Size(146, 37);
            this.buttonQR.TabIndex = 22;
            this.buttonQR.Text = "Закончить создание тестов";
            this.buttonQR.UseVisualStyleBackColor = true;
            this.buttonQR.Click += new System.EventHandler(this.buttonQR_Click);
            // 
            // CreatTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 406);
            this.Controls.Add(this.buttonQR);
            this.Controls.Add(this.buttonJPEG);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.radioButtonOtvetG);
            this.Controls.Add(this.radioButtonOtvetV);
            this.Controls.Add(this.radioButtonOtvetB);
            this.Controls.Add(this.radioButtonOtvetA);
            this.Controls.Add(this.textBoxOtvetG);
            this.Controls.Add(this.textBoxOtvetV);
            this.Controls.Add(this.textBoxOtvetB);
            this.Controls.Add(this.textBoxOtvetA);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxVopros);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonSendTest);
            this.Name = "CreatTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test";
            this.Load += new System.EventHandler(this.CreatTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSendTest;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxVopros;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxOtvetA;
        private System.Windows.Forms.TextBox textBoxOtvetB;
        private System.Windows.Forms.TextBox textBoxOtvetV;
        private System.Windows.Forms.TextBox textBoxOtvetG;
        private System.Windows.Forms.RadioButton radioButtonOtvetA;
        private System.Windows.Forms.RadioButton radioButtonOtvetB;
        private System.Windows.Forms.RadioButton radioButtonOtvetV;
        private System.Windows.Forms.RadioButton radioButtonOtvetG;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Button buttonJPEG;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button buttonQR;
    }
}