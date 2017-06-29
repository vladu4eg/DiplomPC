using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PC_Diplom
{
    public partial class ResultTest : Form
    {
        List<string> TaskList = new List<string>();
        int indexAnswer = 1;
        public int IdTakeTest;
        public int IdStudent;
        public ResultTest()
        {
            InitializeComponent();
            button2.Enabled = false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listView1.Clear();
            button2.Enabled = false;
            var list = listBox1.SelectedItem as Test;
            if (list != null)
            {
                IdTakeTest = list.ID;
                GetStudentList();
            }
        }

        private void ResultTest_Load(object sender, EventArgs e)
        {
            GetTakeNameTest();
        }

        public void GetTakeNameTest()
        {
            try
            {
                string connsqlstring = "Database=u0354899_diplom;Data Source=31.31.196.162;User Id=u0354899_vlad;Password=vlad19957;charset=utf8";
                MySqlConnection sqlconn = new MySqlConnection(connsqlstring);
                sqlconn.Open();
                DataSet tickets = new DataSet();
                string queryString = string.Format("SELECT id,NameTest FROM tests WHERE idteacher = '{0}'", Main.IdTeacher);
                MySqlDataAdapter adapter = new MySqlDataAdapter(queryString, sqlconn);
                adapter.Fill(tickets);
                foreach (DataRow row in tickets.Tables[0].Rows)
                {
                    int id = Convert.ToInt32(row["id"]);
                    string name = Convert.ToString(row["NameTest"]);
                    listBox1.Items.Add(new Test(id, name));
                }
                sqlconn.Close();
            }
            catch (Exception e)
            {
            }
        }

        private class FIOid
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public FIOid(string fn, string ln, string mn, int idstudent)
            {
                Name = fn + " " + ln + " " + mn;
                ID = idstudent;
            }

            public override string ToString()
            {
                return Name;
            }
        }

        private class Test
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public Test(int id, string name)
            {
                ID = id;
                Name = name;
            }
            public override string ToString()
            {
                return Name;
            }
        }

        public void GetStudentListAnswer()
        {
            List<string> vopros = new List<string>();
            try
            {
                string connsqlstring = "Database=u0354899_diplom;Data Source=31.31.196.162;User Id=u0354899_vlad;Password=vlad19957;charset=utf8";
                MySqlConnection sqlconn = new MySqlConnection(connsqlstring);
                sqlconn.Open();
                DataSet tickets = new DataSet();
                string queryString = string.Format("SELECT test_history.false_quest, test_history.true_quest, test_history.id, test_history.ocenka FROM test_history WHERE test_history.idstudent = '{0}' AND test_history.idtest = '{1}'", IdStudent, IdTakeTest);
                MySqlDataAdapter adapter = new MySqlDataAdapter(queryString, sqlconn);
                adapter.Fill(tickets, "Item");
                foreach (DataRow row in tickets.Tables["Item"].Rows)
                {
                    vopros.Add(row[0].ToString());
                    vopros.Add(row[1].ToString());
                    vopros.Add(row[2].ToString());
                    vopros.Add(row[3].ToString());
                }
                listView1.View = View.Details;
                listView1.Columns.Add("Кол. неправильных ответов", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Кол. правильных ответов", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Общие количество", 100, HorizontalAlignment.Left);
                listView1.Columns.Add("Оценка", 100, HorizontalAlignment.Left);

                listView1.Items.Add(vopros[0].ToString());
                listView1.Items[0].SubItems.Add(vopros[1].ToString());
                listView1.Items[0].SubItems.Add(Convert.ToString(Convert.ToInt32(vopros[1]) + Convert.ToInt32(vopros[0])));
                listView1.Items[0].SubItems.Add(vopros[3].ToString());

                sqlconn.Close();
            }
            catch (Exception e)
            {
            }
        }

        public void GetStudentAnswerTask()
        {
            try
            {
                TaskList.Clear();
                string connsqlstring = "Database=u0354899_diplom;Data Source=31.31.196.162;User Id=u0354899_vlad;Password=vlad19957;charset=utf8";
                MySqlConnection sqlconn = new MySqlConnection(connsqlstring);
                sqlconn.Open();
                DataSet tickets = new DataSet();
                string queryString = string.Format("SELECT DISTINCT task_history.answer FROM task_history,test_history WHERE test_history.idtest = '{0}' AND task_history.idstudent = '{1}'", IdTakeTest, IdStudent);
                MySqlDataAdapter adapter = new MySqlDataAdapter(queryString, sqlconn);
                adapter.Fill(tickets, "Item");
                foreach (DataRow row in tickets.Tables["Item"].Rows)
                {
                    TaskList.Add(row[0].ToString());
                }
                sqlconn.Close();
                label5.Text = TaskList[0];
            }
            catch (Exception e)
            {
            }
        }

        public void GetStudentList()
        {
            try
            {
                string connsqlstring = "Database=u0354899_diplom;Data Source=31.31.196.162;User Id=u0354899_vlad;Password=vlad19957;charset=utf8";
                MySqlConnection sqlconn = new MySqlConnection(connsqlstring);
                sqlconn.Open();
                DataSet tickets = new DataSet();
                string queryString = string.Format("SELECT DISTINCT Student.LastName,Student.FirstName,Student.MiddleName,Student.id FROM Student,test_history WHERE test_history.idtest = '{0}' AND test_history.idstudent = Student.id", IdTakeTest);
                MySqlDataAdapter adapter = new MySqlDataAdapter(queryString, sqlconn);
                adapter.Fill(tickets);
                foreach (DataRow row in tickets.Tables[0].Rows)
                {
                    string FN = Convert.ToString(row["LastName"]);
                    string LN = Convert.ToString(row["FirstName"]);
                    string MD = Convert.ToString(row["MiddleName"]);
                    int idstudent = Convert.ToInt32(row["id"]);
                    listBox2.Items.Add(new FIOid(FN, LN, MD, idstudent));
                }
                sqlconn.Close();
            }
            catch (Exception e)
            {
            }
        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            listView1.Clear();
            var test2 = listBox2.SelectedItem as FIOid;
            if (test2 != null)
            {
                IdStudent = test2.ID;
                GetStudentListAnswer();
                GetStudentAnswerTask();
            }
            button2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher();
            teacher.Show();
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 59) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string Connect = "Database=u0354899_diplom;Data Source=31.31.196.162;User Id=u0354899_vlad;Password=vlad19957;charset=cp1251";
                MySql.Data.MySqlClient.MySqlConnection myConnection = new MySql.Data.MySqlClient.MySqlConnection(Connect);
                MySql.Data.MySqlClient.MySqlCommand myCommand = new MySql.Data.MySqlClient.MySqlCommand();
                myConnection.Open();
                myCommand.Connection = myConnection;
                myCommand.CommandText = string.Format("UPDATE test_history SET ocenka = '{0}' WHERE idstudent = '{1}' AND idtest = '{2}'", textBox1.Text, IdStudent, IdTakeTest);
                myCommand.Prepare();//подготавливает строку
                myCommand.ExecuteNonQuery();//выполняет запрос
                myConnection.Close();
            }
            catch (Exception ex)
            {
            }
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (TaskList.Count > indexAnswer)
            {
                label5.Text = TaskList[indexAnswer];
                indexAnswer++;
            }
            else
            {
                label5.Text = "Больше нет ответов на задачи!";
                indexAnswer = 0;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
