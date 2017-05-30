using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_Diplom
{
    public partial class Teacher : Form
    {
        static public string NameTest;
        static public int idtests;
        string urlName, url, fileName;
        bool CheckPDF = false;
        public Teacher()
        {
            InitializeComponent();
        }

        private void Teacher_Load(object sender, EventArgs e)
        {

        }


        private void buttonExit_Click(object sender, EventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
            this.Close();
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

        private void buttonTest_Click(object sender, EventArgs e)
        {
            NameTest = textBoxNameTest.Text;

            string Connect = "Database=u0354899_diplom;Data Source=31.31.196.162;User Id=u0354899_vlad;Password=vlad19957;charset=cp1251";
            MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection(Connect);
            MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();

            myConnection.Open();
            myCommand.Connection = myConnection;

            myCommand.CommandText = string.Format("SELECT id FROM teacher WHERE login='{0}'", Main.LoginGlobal);
            myCommand.Prepare();//подготавливает строку
            myCommand.ExecuteNonQuery();//выполняет запрос
            int idtecher = (int)myCommand.ExecuteScalar();//результат запроса

            myCommand.CommandText = string.Format("INSERT INTO tests (idteacher,NameTest) " + "VALUES('{0}','{1}')", idtecher, NameTest);
            myCommand.Prepare();//подготавливает строку
            myCommand.ExecuteNonQuery();//выполняет запрос
            idtests = (int)myCommand.LastInsertedId;//получаем id
            if(CheckPDF == true)
            {
                checkFolderFtp(url);
                // читаем файл в строку
                //string fileText = System.IO.File.ReadAllText(filename);
                WebClient myWebClient = new WebClient();
                //myWebClient.UploadFileCompleted += new UploadFileCompletedEventHandler(UploadFileCallback2); // типо прогресс загрузки
                // myWebClient.UploadProgressChanged += new UploadProgressChangedEventHandler(UploadProgressCallback);
                Uri ftp_path = new Uri("ftp://u0354899_vlad:vlad19957@31.31.196.162" + url + fileName); // file.txt - файл, который будет в конечном итоге залит; FTPLOGIN - логин к FTP; PASSWORD - пароль к FTP; LOGIN и PASSWORD разделяются двоеточием.
                myWebClient.UploadFile(ftp_path, urlName); // anyfile.txt - загружаемый файл на FTP; C:/Files... - путь к загружаемому файлу; ftp_path - конечный путь и имя файла, которое будет на FTP сервере.

                string urlFile = "http://www.imtis.ru/pdf/" + Main.LoginGlobal + "/" + fileName;

                myCommand.CommandText = string.Format("UPDATE tests SET pdf = '{0}' WHERE id = '{1}'", urlFile, idtests);
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос
            }

            myConnection.Close();
            CreatTest test = new CreatTest();
            test.Show();
            this.Hide();
        }

        private void buttonDownPDF_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "PDF";
            openFileDialog1.Filter = "pdf files (*.pdf)|*.pdf";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            urlName = openFileDialog1.FileName;
            fileName = Path.GetFileName(urlName);
            url = "/www/imtis.ru/pdf/" + Main.LoginGlobal + "/";

            buttonDownPDF.Visible = false;
            CheckPDF = true;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
