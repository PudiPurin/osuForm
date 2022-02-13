using Microsoft.Azure.Management.Compute.Fluent.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace osuForm
{
    public partial class Form1 : Form
       
    {
        SqlConnection con;
        public Form1()
        {
            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // string cn = "server = LAPTOP-79NLGEPR; database = osuSimulation; UID = LAPTOP-79NLGEPR\\User; password = ;";
                string cn = @"Server=LAPTOP-79NLGEPR;Database=osuSimulation;UID=LAPTOP-79NLGEPR\User;Password=;Integrated Security=true;";
                con = new SqlConnection(cn);
                con.Open();
                MessageBox.Show("Connected");
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password1 = textBox2.Text;
            string password2 = textBox3.Text;

            if (password1 == password2)
            {
                Create();
            }
            else
            {
                MessageBox.Show("Passwords don't match, please re-enter password correctly.");

            }
        }

        public void Create()
        {

            try
            {

               
                string username = textBox1.Text;
                string password = textBox2.Text;
                string salt = Guid.NewGuid().ToString().ToUpper();
                String insert = "insert into osuSimulation.users.Account (username, password, salt, IsActive, IsDeleted)";
                string values = "values('" + textBox1.Text + "', '" + textBox2.Text + "', '" + "test12" + "', 1, 0);";
                String Query = insert + values;
                con.Open();
                SqlCommand command = new SqlCommand(Query, con);
                command.ExecuteNonQuery();
                MessageBox.Show("Insert Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        
                }
    }
}
