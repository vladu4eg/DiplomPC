using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace PC_Diplom
{
    public partial class QR : Form
    {
        public QR()
        {
            InitializeComponent();
        }

        private void QR_Load(object sender, EventArgs e)
        {
            QRCodeWriter qrEncode = new QRCodeWriter(); //создание QR кода
            Dictionary<EncodeHintType, object> hints = new Dictionary<EncodeHintType, object>();    //для колекции поведений
            hints.Add(EncodeHintType.CHARACTER_SET, "utf-8");   //добавление в коллекцию кодировки utf-8
            BitMatrix qrMatrix = qrEncode.encode(   //создание матрицы QR
                Teacher.idtests.ToString(),                 //кодируемая строка
                BarcodeFormat.QR_CODE,  //формат кода, т.к. используется QRCodeWriter применяется QR_CODE
                300,                    //ширина
                300,                    //высота
                hints);                 //применение колекции поведений
            BarcodeWriter qrWrite = new BarcodeWriter();    //класс для кодирования QR в растровом файле
            Bitmap qrImage = qrWrite.Write(qrMatrix);   //создание изображения
            pictureBox1.Image = qrImage;
            SaveFileDialog save = new SaveFileDialog();
            save.CreatePrompt = true;
            save.OverwritePrompt = true;
            save.FileName = "QR";
            save.Filter = "PNG|*.png|JPEG|*.jpg|BMP|*.bmp|GIF|*.gif";
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.Image.Save(save.FileName);
                save.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Teacher teach = new Teacher();
            teach.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
