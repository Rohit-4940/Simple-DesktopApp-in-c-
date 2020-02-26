using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace datagrid
{
    public partial class Form1 : Form
    {
        int ID = 0;//use for the delete and update the data in datagrid and server
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)//to insert the value which have been inserted by the user into the textbox filled the result can been seen inside the datagridview
        {
            string connectionstring = "data source=DESKTOP-G5EM3AS ;initial catalog=ismt;integrated security=true";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                using (SqlCommand cm = new SqlCommand())
                {
                    cm.Connection = con;
                    cm.CommandType = CommandType.Text;

                    cm.CommandText = "select * from employee";
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cm))
                    {
                        da.Fill(dt);
                        gvuser.DataSource = dt;

                    }
                }
            }

        }
        public void Result()//to view the result in datagridview at the same time when the save button is clicked
        {
            string connectionstring = "data source=DESKTOP-G5EM3AS ;initial catalog=ismt;integrated security=true";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                using (SqlCommand cm = new SqlCommand())
                {
                    cm.Connection = con;
                    cm.CommandType = CommandType.Text;

                    cm.CommandText = "select * from employee";
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cm))
                    {
                        da.Fill(dt);
                        gvuser.DataSource = dt;


                    }
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
        }

        private void Btnsave_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void Btnupdate_Click(object sender, EventArgs e)//update the data
        {
            string connectionstring = "data source=DESKTOP-G5EM3AS ;initial catalog=ismt;integrated security=true";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = "update employee set Username=@username,Email=@email where ID=@id";
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@username", txtusername.Text);
                    cmd.Parameters.AddWithValue("@email", txtemail.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Data have been update sucessfully!");
                    Result();
                    ID = 0;
                    txtusername.Text = " ";
                    txtemail.Text = " ";


                }
            }
        }

        private void Btnsave_Click(object sender, EventArgs e)//save the record insert by the users
        {
            if (txtusername.Text != " " && txtemail.Text != " ")
            {
                string connectionstring = "data source=DESKTOP-G5EM3AS ;initial catalog=ismt;integrated security=true";
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;

                        cmd.CommandText = "insert into employee (username, email)values(@username,@email)";
                        cmd.Parameters.AddWithValue("@username", txtusername.Text);
                        cmd.Parameters.AddWithValue("@email", txtemail.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Data have been inserted sucessfully");
                        txtusername.Text = " ";
                        txtemail.Text = " ";
                        Result();
                    }
                }

            }
            else
            {
                MessageBox.Show("you must fill up the user name and password!");
            }

        }

        private void Btndelete_Click(object sender, EventArgs e)//delete record
        {
            if (ID != 0)
            {
                string connectionstring = "data source=DESKTOP-G5EM3AS ;initial catalog=ismt;integrated security=true";
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;

                        cmd.CommandText = "Delete employee where ID=@id";
                        cmd.Parameters.AddWithValue("@id", ID);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Data has been delete sucessfully!");
                        Result();
                        txtusername.Text = " ";
                        txtemail.Text = " ";
                        ID = 0;
                    }

                }
            }
        }

        private void Gvuser_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ID = Convert.ToInt32(gvuser.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtusername.Text = gvuser.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtemail.Text = gvuser.Rows[e.RowIndex].Cells[2].Value.ToString();
        }

        private void Txtsearch_TextChanged(object sender, EventArgs e)//serach text box
        {

            string connectionstring = "data source=DESKTOP-G5EM3AS ;initial catalog=ismt;integrated security=true";
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                con.Open();
                using (SqlCommand cm = new SqlCommand())
                {
                    cm.Connection = con;
                    cm.CommandType = CommandType.Text;
                    cm.CommandText = "select * from employee where Username like  '" + txtsearch.Text + "%'";
                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cm))
                    {
                        da.Fill(dt);
                        gvuser.DataSource = dt;
                    }

                }
            }
        }
    }
}


    



