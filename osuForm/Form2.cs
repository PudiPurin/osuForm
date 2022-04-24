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
    public partial class Form2 : Form
    {
        SqlConnection con;
        public Form2()
        {

            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            
            try
            {
                // string cn = "server = LAPTOP-79NLGEPR; database = osuSimulation; UID = LAPTOP-79NLGEPR\\User; password = ;";
                string cn = @"Server=LAPTOP-79NLGEPR;Database=osuSimulation;UID=LAPTOP-79NLGEPR\User;Password=;Integrated Security=true;";
                con = new SqlConnection(cn);
                con.Open();
                MessageBox.Show("Connected");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }

        public void Login(String username, String password)
        {
            Boolean Checklogin = false;
            try
            {
                string query = "select count(id) from osuSimulation.users.Account where username = '" + username +"' and password = '" + password + "';";

                con.Open();
                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader reader;
                reader = command.ExecuteReader();

                while (reader.Read())
                {

                    String read = reader[0].ToString();
                   

                    if (read == "1")
                    {
                    
                        Checklogin = true;
                    }

                }
                if(Checklogin == true)
                {

                    MessageBox.Show("Login Success");
                    this.Hide();
                    Form4 form4 = new Form4(username);
                    //form4.setUserData(username);
                    form4.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Login Failed");
                }

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
          

       
         


        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            String password = textBox2.Text;
            Login(username, password);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
