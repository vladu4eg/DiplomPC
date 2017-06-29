using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace PC_Diplom
{
    public partial class CreatTest : Form
    {
        string urlName, url, fileName;
        int idvoprosa, TrueOtvet = 0;
        bool CheckJPEG = false;

        public CreatTest()
        {
            InitializeComponent();
            if(Teacher.TaskIs)
            {
                buttonQR.Text = "Создать задачи";
            }
            else
                buttonQR.Text = "Закончить создание тестов";
        }

        private void radioButtonOtvetA_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOtvetA.Checked == true)
            {
                radioButtonOtvetB.Checked = false;
                radioButtonOtvetV.Checked = false;
                radioButtonOtvetG.Checked = false;
            }
        }

        private void radioButtonOtvetB_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOtvetB.Checked == true)
            {
                radioButtonOtvetA.Checked = false;
                radioButtonOtvetV.Checked = false;
                radioButtonOtvetG.Checked = false;
            }
        }

        private void radioButtonOtvetV_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOtvetV.Checked == true)
            {
                radioButtonOtvetB.Checked = false;
                radioButtonOtvetA.Checked = false;
                radioButtonOtvetG.Checked = false;
            }
        }

        private void radioButtonOtvetG_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonOtvetG.Checked == true)
            {
                radioButtonOtvetB.Checked = false;
                radioButtonOtvetV.Checked = false;
                radioButtonOtvetA.Checked = false;
            }
        }

        private void buttonSendTest_Click(object sender, EventArgs e)
        {
            try
            {
                string Vopros = textBoxVopros.Text;
                string OtvetA = textBoxOtvetA.Text;
                string OtvetB = textBoxOtvetB.Text;
                string OtvetV = textBoxOtvetV.Text;
                string OtvetG = textBoxOtvetG.Text;
                if (radioButtonOtvetA.Checked == true)
                    TrueOtvet = 1;
                else if (radioButtonOtvetB.Checked == true)
                    TrueOtvet = 2;
                else if (radioButtonOtvetV.Checked == true)
                    TrueOtvet = 3;
                else if (radioButtonOtvetG.Checked == true)
                    TrueOtvet = 4;
                else MessageBox.Show("Выберите правильный ответ!");

                if (TrueOtvet != 0)
                {
                    string Connect = "Database=u0354899_diplom;Data Source=31.31.196.162;User Id=u0354899_vlad;Password=vlad19957;charset=cp1251";
                    MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection(Connect);
                    MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
                    myConnection.Open();
                    myCommand.Connection = myConnection;

                    myCommand.CommandText = string.Format("SELECT id FROM tests WHERE NameTest='{0}'", Teacher.NameTest);
                    myCommand.Prepare();//подготавливает строку
                    myCommand.ExecuteNonQuery();//выполняет запрос
                    Teacher.idtests = (int)myCommand.ExecuteScalar();//результат запроса

                    myCommand.CommandText = string.Format("INSERT INTO vopros (name,var1,var2,var3,var4,answer,idtest) " +
                                                                               "VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
                                                                               Vopros, OtvetA, OtvetB, OtvetV, OtvetG, TrueOtvet, Teacher.idtests);
                    myCommand.Prepare();//подготавливает строку
                    myCommand.ExecuteNonQuery();//выполняет запрос
                    idvoprosa = (int)myCommand.LastInsertedId;//результат запроса
                    if (CheckJPEG == true)
                    {
                        checkFolderFtp(url);
                        // читаем файл в строку
                        //string fileText = System.IO.File.ReadAllText(filename);
                        WebClient myWebClient = new WebClient();
                        Uri ftp_path = new Uri("ftp://u0354899_vlad:vlad19957@31.31.196.162" + url + fileName); // file.txt - файл, который будет в конечном итоге залит; FTPLOGIN - логин к FTP; PASSWORD - пароль к FTP; LOGIN и PASSWORD разделяются двоеточием.
                        myWebClient.UploadFile(ftp_path, urlName); // anyfile.txt - загружаемый файл на FTP; C:/Files... - путь к загружаемому файлу; ftp_path - конечный путь и имя файла, которое будет на FTP сервере.

                        string urlFileJPEG = "http://www.imtis.ru/jpeg/" + Main.LoginGlobal + "/" + fileName;
                        myCommand.CommandText = string.Format("UPDATE vopros SET pic = '{0}' WHERE id = '{1}'", urlFileJPEG, idvoprosa);
                        myCommand.Prepare();//подготавливает строку
                        myCommand.ExecuteNonQuery();//выполняет запрос
                        CheckJPEG = false;
                    }
                    myConnection.Close();
                }
            }
            catch (Exception ex)
            {
                labelError.Text = ex.Message;
            }
            textBoxVopros.Text = String.Empty;
            textBoxOtvetA.Text = String.Empty;
            textBoxOtvetB.Text = String.Empty;
            textBoxOtvetV.Text = String.Empty;
            textBoxOtvetG.Text = String.Empty;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "JPEG";
            openFileDialog1.Filter = "jpeg files (*.jpeg)|*.jpeg";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            urlName = openFileDialog1.FileName;
            fileName = Path.GetFileName(urlName);
            url = "/www/imtis.ru/jpeg/" + Main.LoginGlobal + "/";
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

        private void buttonQR_Click(object sender, EventArgs e)
        {
            if (Teacher.TaskIs)
            {
                Task task = new Task();
                task.Show();
                this.Hide();
            }
            else
            {
                QR qr = new QR();
                qr.Show();
                this.Hide();
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {
        }

        private void folderBrowserDialog1_HelpRequest_1(object sender, EventArgs e)
        {
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }


        private void buttonDownJPEG_Click(object sender, EventArgs e)
        {
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
        }

        private void buttonTask_Click(object sender, EventArgs e)
        {
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
        }

        private void CreatTest_Load(object sender, EventArgs e)
        {
        }

        private void textBoxVopros_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
