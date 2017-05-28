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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }


        private void Registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxStudent.Checked == true)
            {
                label8.Text = "Ранк";
                label9.Visible = false;
                textBoxZachetka.Visible = false;
            }
            else
            {
                label8.Text = "Группа";
                label9.Visible = true;
                textBoxZachetka.Visible = true;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string login = textBoxLogin.Text;
            string pass1 = textBoxPassword1.Text;
            string pass2 = textBoxPassword2.Text;
            string LastName = textBoxLastName.Text;
            string FirstName = textBoxFirstName.Text;
            string otch = textBoxOtchestvo.Text;
            string GRorRank = textBoxGRorKAF.Text;
            string zacketka = textBoxZachetka.Text;
            if (pass1 != pass2)
                labelError.Text = "Пароль не совпадает!";
            else if (FirstName == String.Empty)
                labelError.Text = "Введите Имя";
            else if (LastName == String.Empty)
                labelError.Text = "Введите Фамилию";
            else if (otch == String.Empty)
                labelError.Text = "Введите Отчество";
            else if (GRorRank == String.Empty)
            {
                if (checkBoxStudent.Checked == true)
                {
                    labelError.Text = "Введите Ранк";
                }
                else
                {
                    labelError.Text = "Введите Группу";
                }
            }
            else if (checkBoxStudent.Checked == false && zacketka == String.Empty)
                labelError.Text = "Введите номер зачетки";
            else
            {

                try
                {
                    string Connect = "Database=u0354899_diplom;Data Source=31.31.196.162;User Id=u0354899_vlad;Password=vlad19957;charset=cp1251";
                    MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection(Connect);
                    MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
                    myConnection.Open();
                    myCommand.Connection = myConnection;
                    if (checkBoxStudent.Checked == true)
                    {
                        myCommand.CommandText = string.Format("INSERT INTO teacher (FirstName,LastName,MiddleName,rank,login,password) " +
                                                             "VALUES('{0}','{1}','{2}','{3}','{4}','{5}')", LastName, FirstName, otch, GRorRank, login, pass1);
                    }
                    else
                    {
                        myCommand.CommandText = string.Format("INSERT INTO Student (FirstName,LastName,MiddleName,groups,login,password,zachetka) " +
                                                             "VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", LastName, FirstName, otch, GRorRank, login, pass1, zacketka);
                    }
                    myCommand.Prepare();//подготавливает строку
                    myCommand.ExecuteNonQuery();//выполняет запрос
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    labelError.Text = ex.Message;
                }
                this.Close();
                MessageBox.Show("Регистрация прошла удачно!");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
