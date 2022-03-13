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
            String query = "  select [name] from [osuSimulation].[maps].[PlayMap]";
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "Map Name";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader;
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                String name = reader["[name]"].ToString();

                String[] rows = new string[]
                {
                        name
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
    }
}
