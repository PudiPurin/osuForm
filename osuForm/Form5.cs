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
    public partial class Form5 : Form
    {
       Dictionary<int, string> buttontypes = new Dictionary<int, string>();
        SqlConnection cnn;
        public Form5()
        {
            InitializeComponent();
        }

        public Form5(int id, string name,  int bpm, float sr)
        {
            InitializeComponent();
            m_id.Text = id.ToString();
            MName.Text = name.ToString();
            BPM.Text = bpm.ToString();
            SR.Text = sr.ToString();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string cn = @"Server=LAPTOP-79NLGEPR;Database=osuSimulation;UID=LAPTOP-79NLGEPR\User;Password=;Integrated Security=true;";
            cnn = new SqlConnection(cn);
            String query = "select [buttontype],[ID] from [osuSimulation].[refs].[ButtonType];";
            SqlCommand command = new SqlCommand(query, cnn);
            cnn.Open();
            SqlDataReader reader;
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                string buttontype = reader["[buttontype]"].ToString();
                string ID = reader["[ID]"].ToString();

                MapDetail mapdetail = new MapDetail();

                mapdetail.buttontype = buttontype;
                mapdetail.id = int.Parse(ID);
                comboBox1.Items.Add(buttontype);

                buttontypes.Add(int.Parse(ID), buttontype);
              
            }
           
            cnn.Close();
            refresh();








        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }


        public void insert()
        {
            try
            {
                int hours = (int)numericUpDown1.Value;
                int minutes = (int)numericUpDown2.Value;
                int seconds = (int)numericUpDown3.Value;
                string time = hours.ToString() + ":" + minutes.ToString() + ":" + seconds.ToString();
                TimeSpan time2 = TimeSpan.Parse(time);
                string receive = comboBox1.SelectedItem.ToString();
                int i = buttontypes.Where(x => x.Value == receive).FirstOrDefault().Key;
                string query = "insert into [osuSimulation].[maps].[PlayMapDetail]";
                string values = "values( " + m_id.Text.ToString() + ", '" + time2 + "' , " + i + ", 1, 0);";
                string insert = query + " " + values;
                cnn.Open();
                
                SqlCommand command = new SqlCommand(insert, cnn);
                command.ExecuteNonQuery();
                MessageBox.Show("Insert success");

                refresh();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            cnn.Close();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            insert();
        }

        public void refresh()
        {
            dataGridView1.ColumnCount = 2;
            dataGridView1.Columns[0].Name = "Drain Length";
            dataGridView1.Columns[1].Name = "Button Type";
            string query = "select * from [osuSimulation].[maps].[PlayMapDetail]";
            cnn.Open();
            SqlCommand command = new SqlCommand(query, cnn);
            SqlDataReader reader;
            reader = command.ExecuteReader();

            while (reader.Read())
            {
              
               
                string drain_length = reader["[drain_length]"].ToString();
                string buttontype = reader["[button_type]"].ToString();

                string[] rows = new string[]
                {
                    drain_length, buttontype
                };
                dataGridView1.Rows.Add(rows);

            }
            cnn.Close();
        }
    }
}
