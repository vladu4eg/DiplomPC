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

namespace PC_Diplom
{
    public partial class Task : Form
    {
        string urlName, url, fileName;
        bool CheckJPEG = false;
        private void buttonSendTest_Click(object sender, EventArgs e)
        {
            string Connect = "Database=u0354899_diplom;Data Source=31.31.196.162;User Id=u0354899_vlad;Password=vlad19957;charset=cp1251";
            MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection(Connect);
            MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
            myConnection.Open();
            myCommand.Connection = myConnection;

            if(CheckJPEG == true)
            {
                checkFolderFtp(url);
                // читаем файл в строку
                //string fileText = System.IO.File.ReadAllText(filename);
                WebClient myWebClient = new WebClient();
                Uri ftp_path = new Uri("ftp://u0354899_vlad:vlad19957@31.31.196.162" + url + fileName); // file.txt - файл, который будет в конечном итоге залит; FTPLOGIN - логин к FTP; PASSWORD - пароль к FTP; LOGIN и PASSWORD разделяются двоеточием.
                myWebClient.UploadFile(ftp_path, urlName); // anyfile.txt - загружаемый файл на FTP; C:/Files... - путь к загружаемому файлу; ftp_path - конечный путь и имя файла, которое будет на FTP сервере.

                string urlFileJPEG = "http://www.imtis.ru/task/jpeg/" + Main.LoginGlobal + "/" + fileName;
                myCommand.CommandText = string.Format("INSERT INTO task (TextTask,PicTask,idtest) VALUES('{0}','{1}','{2}')", textBoxVopros.Text, urlFileJPEG, Teacher.idtests);
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос

                CheckJPEG = false;
            }
            else
            {
                myCommand.CommandText = string.Format("INSERT INTO task (TextTask,idtest) VALUES('{0}','{1}')", textBoxVopros.Text, Teacher.idtests);
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос
            }
            textBoxVopros.Text = "";
            myConnection.Close();
        }

        public Task()
        {
            InitializeComponent();
        }

        private void textBoxVopros_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonQR_Click(object sender, EventArgs e)
        {
            QR qr = new QR();
            qr.Show();
            this.Hide();
        }

        private void Task_Load(object sender, EventArgs e)
        {

        }

        private void buttonJPEG_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "JPEG";
            openFileDialog1.Filter = "jpeg files (*.jpeg)|*.jpeg";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            urlName = openFileDialog1.FileName;
            fileName = Path.GetFileName(urlName);
            url = "/www/imtis.ru/task/jpeg/" + Main.LoginGlobal + "/";
            CheckJPEG = true;
        }
        private void checkFolderFtp(string ftpFolderPath)
        {
            string ftpHost = "31.31.196.162";
            string ftpFullPath = "ftp://" + ftpHost + ftpFolderPath;
            FtpWebRequest ftp;
            try
            {
                ftp = (FtpWebRequest)FtpWebRequest.Create(ftpFullPath);
                ftp.Credentials = new NetworkCredential("u0354899_vlad", "vlad19957");
                ftp.KeepAlive = false;
                ftp.UseBinary = true;
                ftp.Proxy = null;
                ftp.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse resp = (FtpWebResponse)ftp.GetResponse();
                resp.Close();
            }
            catch
            {
                ftp = (FtpWebRequest)FtpWebRequest.Create(ftpFullPath);
                ftp.Credentials = new NetworkCredential("u0354899_vlad", "vlad19957");
                ftp.KeepAlive = false;
                ftp.UseBinary = true;
                ftp.Proxy = null;
                ftp.Method = WebRequestMethods.Ftp.MakeDirectory;
                FtpWebResponse resp = (FtpWebResponse)ftp.GetResponse();
                resp.Close();
            }
        }
    }
}
