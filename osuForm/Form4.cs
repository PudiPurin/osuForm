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
    public partial class Form4 : Form
    {
        SqlConnection con;
        List<Map> Maps;
        String RowName;
        bool SRcheck;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Maps = new List<Map>();
            try
            {
                // string cn = "server = LAPTOP-79NLGEPR; database = osuSimulation; UID = LAPTOP-79NLGEPR\\User; password = ;";
                string cn = @"Server=LAPTOP-79NLGEPR;Database=osuSimulation;UID=LAPTOP-79NLGEPR\User;Password=;Integrated Security=true;";
                con = new SqlConnection(cn);
                Refresh();
            


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          

         

        }

        public void Refresh()
        {
            con.Open();
            String query = "  select [name], [BPM], [SR], [UpdateDate] from [osuSimulation].[maps].[PlayMap]";
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Map Name";
            dataGridView1.Columns[1].Name = "BPM";
            dataGridView1.Columns[2].Name = "SR";
            dataGridView1.Columns[3].Name = "Last Updated";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader;
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                String name = reader["[name]"].ToString();
                String BPM = reader["[BPM"].ToString();
                String SR = reader["[SR]"].ToString();
                String updateddate = reader["[UpdateDate]"].ToString();
                    
                String[] rows = new string[]
                {
                        name, BPM, SR, updateddate
                };
                dataGridView1.Rows.Add(rows);
            }
            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                RowName = row.Cells[0].Value.ToString();

            }

            String query = "select * from [osuSimulation].[maps].[PlayMap] where [name] = '" + RowName + "'";
            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader;
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                String id = reader["[id]"].ToString();
                String name = reader["[name]"].ToString();
                String user_id = reader["[user_id]"].ToString();
                String BPM = reader["[BPM]"].ToString();
                String object_count = reader["[object_count]"].ToString();
                String SR = reader["[SR]"].ToString();
                String IsActive = reader["[IsActive]"].ToString();
                String IsDeleted = reader["IsDeleted]"].ToString();
                String createdDate = reader["[createDate]"].ToString();
                String UpdatedDate = reader["[UpdateDate]"].ToString();

                /* Map map = new Map();
                 map.id = int.Parse(id);
                 map.name = name;
                 map.userID = int.Parse(user_id);
                 map.BPM = int.Parse(BPM);
                 map.object_count = int.Parse(object_count);
                 map.SR = float.Parse(SR);
                 map.createdDate = createdDate;
                 map.UpdatedDate = UpdatedDate;*/

                Map map2 = new Map
                {
                    id = int.Parse(id),
                    name = name,
                    userID = string.IsNullOrEmpty(user_id) ? null : int.Parse(user_id),
                    /*   if(user_id == "null")
                {
                    map2.userID = null;
                } 
                else
                {
                    map2.userID = int.Parse(user_id);
                }*/
                    
                    BPM = int.Parse(BPM),
                    object_count = int.Parse(object_count),
                    SR = float.Parse(SR),
                    IsActive = Boolean.Parse(IsActive),
                    IsDelted = Boolean.Parse(IsDeleted),
                    createdDate = createdDate,
                    UpdatedDate = UpdatedDate,
                };
             

                Maps.Add(map2);
              
                ID.Text = map2.id.ToString();
                MName.Text = map2.name;
                userID.Text = map2.userID.ToString();
                bpm.Text = map2.BPM.ToString();
                objects.Text = map2.object_count.ToString();
                sr.Text = map2.SR.ToString();
                cDate.Text = map2.createdDate;
                updatedDate.Text = map2.UpdatedDate;




            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void cDate_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        public void Update()
        {
            try
            {
                String query = "  Update [osuSimulation].[maps].[PlayMap] set [name] = '" + MName.Text + "' ,[user_id] = null" + userID.Text + ", [BPM] = " + bpm.Text + ", [object_count] = " + objects.Text + ", [SR] = " + sr.Text + ", [UpdateDate] = cast('" +  DateTime.UtcNow + "' as datetime) " + "where [id] = " + ID.Text + ";";

                SqlCommand UpdateCommand = new SqlCommand(query, con);
                con.Open();
                UpdateCommand.ExecuteNonQuery();
                Refresh();
           
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Update();
        }

        public void Delete()
        {

            try
            {
                String query = "Delete from [osuSimulation].[maps].[PlayMap] where [id] = " + ID.Text;

                SqlCommand DeleteCommand = new SqlCommand(query, con);
                con.Open();
                DeleteCommand.ExecuteNonQuery();
                MessageBox.Show("Delete Success");
                Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete();
        }
    }
}
