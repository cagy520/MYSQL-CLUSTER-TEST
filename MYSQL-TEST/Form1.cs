using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace MYSQL_TEST
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        Thread th;
        private void button1_Click(object sender, EventArgs e)
        {
            th = new Thread(insert);
            th.Start();
            Thread th1 = new Thread(reada);
            th1.Start();

            Thread th2 = new Thread(readb);
            th2.Start();

            Thread th3 = new Thread(readc);
            th3.Start();

            Thread th4 = new Thread(readd);
            th4.Start();
        }
        bool istop = true;
        private void insert()
        {
            while (istop)
            {
                MySqlConnection sqlCnn = new MySqlConnection();
                sqlCnn.ConnectionString = "Database=tx;Data Source=172.16.108.110;Port=3306;User Id=root;Password=1;Charset=utf8;";
                MySqlCommand sqlCmd = new MySqlCommand();
                sqlCmd.Connection = sqlCnn;
                sqlCmd.CommandText = "INSERT INTO ttxx(NAME) VALUES('dfhsdjkhfjkasdhfjkhsdjk');INSERT INTO ttxx(NAME) VALUES('dfhsdjkhfjkasdhfjkhsdjk');INSERT INTO ttxx(NAME) VALUES('dfhsdjkhfjkasdhfjkhsdjk');INSERT INTO ttxx(NAME) VALUES('dfhsdjkhfjkasdhfjkhsdjk');";

                try
                {
                    sqlCnn.Open();
                    int row = sqlCmd.ExecuteNonQuery();
                    sqlCnn.Close();
                }
                catch (Exception ex)
                {
                    textBox1.Text += "插入失败:"+ex.Message+"\r\n";
                    sqlCnn.Close();
                }
                Thread.Sleep(Convert.ToInt32(textBox2.Text));
            }

        }


        private void reada()
        {
            while (true)
            {
                MySqlConnection sqlCnn = new MySqlConnection();
                sqlCnn.ConnectionString = "Database=tx;Data Source=172.16.108.71;Port=3306;User Id=root;Password=1;Charset=utf8;";
                MySqlCommand sqlCmd = new MySqlCommand();
                sqlCmd.Connection = sqlCnn;
                sqlCmd.CommandText = "select count(*) from ttxx;";

                try
                {
                    sqlCnn.Open();
                    int row = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    sqlCnn.Close();
                    lbla.Text = row.ToString() + "条数据";
                    label1.BackColor = Color.Green;
                }
                catch (Exception ex)
                {
                    textBox1.Text += "读取71失败:" + ex.Message + "\r\n";
                    label1.BackColor = Color.Red;
                    sqlCnn.Close();
                }
                Thread.Sleep(50);
            }
        }
        private void readb()
        {
            while (true)
            {
                MySqlConnection sqlCnn = new MySqlConnection();
                sqlCnn.ConnectionString = "Database=tx;Data Source=172.16.108.73;Port=3306;User Id=root;Password=1;Charset=utf8;";
                MySqlCommand sqlCmd = new MySqlCommand();
                sqlCmd.Connection = sqlCnn;
                sqlCmd.CommandText = "select count(*) from ttxx;";

                try
                {
                    sqlCnn.Open();
                    int row = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    sqlCnn.Close();
                    lblb.Text = row.ToString() + "条数据";
                    label2.BackColor = Color.Green;
                }
                catch (Exception ex)
                {
                    textBox1.Text += "读取73失败:" + ex.Message + "\r\n";
                    label2.BackColor = Color.Red;
                    sqlCnn.Close();
                }
                Thread.Sleep(50);
            }
        }
        private void readc()
        {
            while (true)
            {
                MySqlConnection sqlCnn = new MySqlConnection();
                sqlCnn.ConnectionString = "Database=tx;Data Source=172.16.108.72;Port=3306;User Id=root;Password=1;Charset=utf8;";
                MySqlCommand sqlCmd = new MySqlCommand();
                sqlCmd.Connection = sqlCnn;
                sqlCmd.CommandText = "select count(*) from ttxx;";

                try
                {
                    sqlCnn.Open();
                    int row = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    sqlCnn.Close();
                    lblc.Text = row.ToString() + "条数据";
                    label3.BackColor = Color.Green;
                }
                catch (Exception ex)
                {
                    textBox1.Text += "读取72失败:" + ex.Message + "\r\n";
                    label3.BackColor = Color.Red;
                    sqlCnn.Close();
                }
                Thread.Sleep(50);
            }
        }
        private void readd()
        {
            while (true)
            {
                MySqlConnection sqlCnn = new MySqlConnection();
                sqlCnn.ConnectionString = "Database=tx;Data Source=172.16.108.92;Port=3306;User Id=root;Password=1;Charset=utf8;";
                MySqlCommand sqlCmd = new MySqlCommand();
                sqlCmd.Connection = sqlCnn;
                sqlCmd.CommandText = "select count(*) from ttxx;";

                try
                {
                    sqlCnn.Open();
                    int row = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    sqlCnn.Close();
                    lbld.Text = row.ToString() + "条数据";
                    label4.BackColor = Color.Green;
                }
                catch (Exception ex)
                {
                    textBox1.Text += "读取92失败:" + ex.Message + "\r\n";
                    label4.BackColor = Color.Red;
                    sqlCnn.Close();
                }
                Thread.Sleep(50);
                if (textBox1.Text.Length > 1000) textBox1.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                istop = false;
                th.Abort();
            }
            catch (Exception)
            {

                th.Abort();
            }
           
        }
    }
}
