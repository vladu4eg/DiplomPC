using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PC_Diplom
{
    public partial class ResultTest : Form
    {
        List<string> vopros = new List<string>();

        public int IdTakeTest;
        public int IdStudent;
        public ResultTest()
        {
            InitializeComponent();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            var product = listBox1.SelectedItem as Test;
            IdTakeTest = product.ID;
            GetStudentList();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ResultTest_Load(object sender, EventArgs e)
        {
            GetTakeNameTest();
        }

        public void GetTakeNameTest()
        {
            //List<string> vopros = new List<string>();

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

        private class Test2
        {
            public int ID { get; set; }
            public string name { get; set; }

            public Test2(string fn, string ln, string mn, int idstudent)
            {
                name = fn + " " + ln + " " + mn;
                ID = idstudent;
            }

            public override string ToString()
            {
                return name;
            }
        }

        private class Test
        {
            public int ID { get; set; }
            public string Name { get; set; }
            //перегрузку добавь!


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


            try
            {
                string connsqlstring = "Database=u0354899_diplom;Data Source=31.31.196.162;User Id=u0354899_vlad;Password=vlad19957;charset=utf8";
                MySqlConnection sqlconn = new MySqlConnection(connsqlstring);
                sqlconn.Open();
                DataSet tickets = new DataSet();
                string queryString = string.Format("SELECT test_history.ocenka, test_history.true_quest, test_history.id FROM test_history WHERE test_history.idstudent = '{0}' AND test_history.idtest = '{1}'", IdStudent, IdTakeTest);
                MySqlDataAdapter adapter = new MySqlDataAdapter(queryString, sqlconn);
                adapter.Fill(tickets, "Item");

                foreach (DataRow row in tickets.Tables["Item"].Rows)
                {
                    vopros.Add(row[0].ToString());
                    vopros.Add(row[1].ToString());
                    vopros.Add(row[2].ToString());
                }
                // Set to details view.
                listView1.View = View.Details;
                // Add a column with width 20 and left alignment.
                listView1.Columns.Add("Оценка", 50, HorizontalAlignment.Left);
                listView1.Columns.Add("Кол. правильных ответов", 100, HorizontalAlignment.Left);
                //listView1.Columns.Add("ID", 50, HorizontalAlignment.Left);

                //vopros.ForEach(test => listView1.Items.Add(test));

                listView1.Items.Add(vopros[0].ToString()); //первый столбец listview1
                listView1.Items[0].SubItems.Add(vopros[1].ToString());
               // listView1.Items[0].SubItems.Add(vopros[2].ToString());

                sqlconn.Close();
            }
            catch (Exception e)
            {

            }
        }

        public void GetStudentAnswerTask()
        {
            ///НУЖНО ДОДЕЛАТЬ!
            try
            {
                string connsqlstring = "Database=u0354899_diplom;Data Source=31.31.196.162;User Id=u0354899_vlad;Password=vlad19957;charset=utf8";
                MySqlConnection sqlconn = new MySqlConnection(connsqlstring);
                sqlconn.Open();
                DataSet tickets = new DataSet();
                string queryString = string.Format("SELECT task_history.answer FROM task_history,test_history WHERE test_history.idtest = '{0}' AND test_history.idstudent = '{1}'", IdTakeTest, IdStudent);
                MySqlDataAdapter adapter = new MySqlDataAdapter(queryString, sqlconn);
                adapter.Fill(tickets);
                foreach (DataRow row in tickets.Tables[0].Rows)
                {
                    string FN = Convert.ToString(row["FirstName"]);
                    string LN = Convert.ToString(row["LastName"]);
                    string MD = Convert.ToString(row["MiddleName"]);

                    int idstudent = Convert.ToInt32(row["id"]);

                    listBox2.Items.Add(new Test2(FN, LN, MD, idstudent));
                }

                sqlconn.Close();
            }
            catch (Exception e)
            {

            }
        }


        public void GetStudentList()
        {
            //List<string> vopros = new List<string>();

            try
            {
                string connsqlstring = "Database=u0354899_diplom;Data Source=31.31.196.162;User Id=u0354899_vlad;Password=vlad19957;charset=utf8";
                MySqlConnection sqlconn = new MySqlConnection(connsqlstring);
                sqlconn.Open();
                DataSet tickets = new DataSet();
                string queryString = string.Format("SELECT DISTINCT Student.FirstName,Student.LastName,Student.MiddleName,Student.id FROM Student,test_history WHERE test_history.idtest = '{0}' AND test_history.idstudent = Student.id", IdTakeTest);
                MySqlDataAdapter adapter = new MySqlDataAdapter(queryString, sqlconn);
                adapter.Fill(tickets);
                foreach (DataRow row in tickets.Tables[0].Rows)
                {
                    string FN = Convert.ToString(row["FirstName"]);
                    string LN = Convert.ToString(row["LastName"]);
                    string MD = Convert.ToString(row["MiddleName"]);

                    int idstudent = Convert.ToInt32(row["id"]);

                    listBox2.Items.Add(new Test2(FN, LN, MD, idstudent));
                }

                sqlconn.Close();
            }
            catch (Exception e)
            {

            }
        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            var product = listBox2.SelectedItem as Test2;
            IdStudent = product.ID;
            GetStudentListAnswer();
            GetStudentAnswerTask();
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher();
            teacher.Show();
            this.Close();
        }
    }
}
