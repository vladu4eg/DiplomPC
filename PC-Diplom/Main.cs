using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PC_Diplom
{
    public partial class Main : Form
    {


        static public string LoginGlobal;
        static public int IdTeacher;
        public Main()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string login = textBoxLogin.Text;
                string pass = textBoxPassword.Text;
                string Connect = "Database=u0354899_diplom;Data Source=31.31.196.162;User Id=u0354899_vlad;Password=vlad19957;charset=cp1251";
                MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection(Connect);
                MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = string.Format("SELECT login FROM Student WHERE login='{0}' AND password='{1}' ", login, pass);//запрос: если есть такой логин в таблице
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос
                LoginGlobal = (string)myCommand.ExecuteScalar();//результат запроса
                if (LoginGlobal == login)
                    MessageBox.Show("Вы зашли как студент! Скачайте мобильное приложение для студентов.");
                else if (LoginGlobal != login)
                {
                    myCommand.CommandText = string.Format("SELECT login FROM teacher WHERE login='{0}' AND password='{1}' ", login, pass);//запрос: если есть такой логин в таблице
                    myCommand.Prepare();//подготавливает строку
                    myCommand.ExecuteNonQuery();//выполняет запрос
                    LoginGlobal = (string)myCommand.ExecuteScalar();//результат запроса
                    if (LoginGlobal == login)
                    {
                        myCommand.CommandText = string.Format("SELECT id FROM teacher WHERE login='{0}' AND password='{1}' ", login, pass);//запрос: если есть такой логин в таблице
                        myCommand.Prepare();//подготавливает строку
                        myCommand.ExecuteNonQuery();//выполняет запрос
                        IdTeacher = (int)myCommand.ExecuteScalar();//результат запроса

                        MessageBox.Show("Вы зашли как преподаватель");
                        Teacher teacher = new Teacher();
                        teacher.Show();
                        this.Hide();
                    }

                    else
                        MessageBox.Show("Логин или пароль не совпадают");
                }
                myConnection.Close();
            }
            catch (Exception ex)
            {
                labelError.Text = ex.Message;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration newMDIChild = new Registration();
            //newMDIChild.MdiParent = this;
            newMDIChild.ShowDialog();
            //this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
