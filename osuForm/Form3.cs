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

namespace osuForm
{
    public partial class Form3 : Form
    {
        SqlConnection con;
        public Form3()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                // string cn = "server = LAPTOP-79NLGEPR; database = osuSimulation; UID = LAPTOP-79NLGEPR\\User; password = ;";
                string cn = @"Server=LAPTOP-79NLGEPR;Database=osuSimulation;UID=LAPTOP-79NLGEPR\User;Password=;Integrated Security=true;";
                con = new SqlConnection(cn);
                con.Open();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
        }


        public void Create()
        {

            try
            {


                string name = textBox1.Text;
                string BPM = numericUpDown1.Value.ToString();
                string SR = numericUpDown2.Value.ToString();
                string ObjectCount = numericUpDown3.Value.ToString();
                DateTime CreateDate = DateTime.UtcNow;
                DateTime UpdateDate = DateTime.UtcNow;
                



                String insert = "insert into osuSimulation.maps.PlayMap (name, BPM, object_count, SR, createDate, UpdateDate, IsActive , IsDeleted)";
                string values = "values('" + name + "', " + BPM + ", " + ObjectCount + ", " + SR + ", '" + CreateDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', '" + UpdateDate.ToString("yyyy-MM-dd HH:mm:ss.fff") + "', " + 1 + ", " + 0 + ");";
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

        private void button1_Click(object sender, EventArgs e)
        {
            Create();
        }
    }
}
