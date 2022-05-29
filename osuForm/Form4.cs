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
        string selectedsort;

        Boolean isName;
        Boolean isBpm;
        Boolean isSR;
        Boolean isObject;
        Boolean isUpdate;
        List<Map> AllMaps;
        SqlConnection con;
        List<Map> Maps;
        String RowName;
        bool SRcheck;
        string username;
        Map map2;

        public Form4()
        {
            InitializeComponent();
        }

        public Form4(string _username)
        {
            username = _username;
            InitializeComponent();
            userID.Text = username;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Maps = new List<Map>();
            AllMaps = new List<Map>();
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
            try
            {
                AllMaps = new List<Map>();
                con.Open();
                String query = "  select [name], [BPM], [SR], [object_count], [UpdateDate] from [osuSimulation].[maps].[PlayMap]";
                dataGridView1.Rows.Clear();
                dataGridView1.ColumnCount = 5;
                dataGridView1.Columns[0].Name = "Map Name";
                dataGridView1.Columns[1].Name = "BPM";
                dataGridView1.Columns[2].Name = "SR";
                dataGridView1.Columns[3].Name = "Object Count";
                dataGridView1.Columns[4].Name = "Last Updated";
                SqlCommand command = new SqlCommand(query, con);
                SqlDataReader reader;
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Map map = new Map();
                    String name = reader["[name]"].ToString();
                    String BPM = reader["[BPM]"].ToString();
                    String SR = reader["[SR]"].ToString();
                    String objects = reader["object_count]"].ToString();
                    String updateddate = reader["[UpdateDate]"].ToString();

                    map.name = name;
                    map.BPM = int.Parse(BPM);
                    map.SR = float.Parse(SR);
                    map.UpdatedDate = updateddate;
                    map.object_count = int.Parse(objects);

                    String[] rows = new string[]
                    {
                        name, BPM, SR, objects, updateddate
                    };
                    dataGridView1.Rows.Add(rows);
                    AllMaps.Add(map);
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

                map2 = new Map
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
                String query = "  Update [osuSimulation].[maps].[PlayMap] set [name] = '" + MName.Text + "' ,[user_id] = null" + userID.Text + ", [BPM] = " + bpm.Text + ", [object_count] = " + objects.Text + ", [SR] = " + sr.Text + ", [UpdateDate] = cast('" + DateTime.UtcNow + "' as datetime) " + "where [id] = " + ID.Text + ";";

                SqlCommand UpdateCommand = new SqlCommand(query, con);
                con.Open();
                UpdateCommand.ExecuteNonQuery();
                Refresh();

            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete();
        }

        public void Create()
        {

            try
            {


                string name = MName.Text;
                string BPM = bpm.Text;
                string SR = sr.Text;
                string ObjectCount = objects.Text;
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

        private void button4_Click(object sender, EventArgs e)
        {

            Create();
            Refresh();
        }

        public void setUserData(string _username)
        {
            username = _username;

            userID.Text = username;


        }

        private void DataGridViewDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Form5 form5 = new Form5(map2.id, map2.name, map2.BPM, map2.SR);
            form5.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            AllMaps.Where(x => x.name.Contains(textBox1.Text) || x.BPM.ToString().Contains(textBox1.Text) || x.SR.ToString().Contains(textBox1.Text) || x.SR.ToString().Contains(textBox1.Text)).All(x =>
            {

                string[] rows = new string[]
                     {
                           x.name, x.BPM.ToString(), x.SR.ToString(), x.object_count.ToString(), x.UpdatedDate.ToString()
                     };
                dataGridView1.Rows.Add(rows);


                return true;
            });
             
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Map> maps = new List<Map>();
            if (comboBox1.SelectedIndex.Equals(0))
            {
                dataGridView1.Rows.Clear();
                if (isName)
                {
                    maps = AllMaps.OrderByDescending(x => x.name).ToList();
                }
                else if (isBpm)
                {
                    maps = AllMaps.OrderByDescending(x => x.BPM).ToList();
                }
                else if (isSR)
                {
                    maps = AllMaps.OrderByDescending(x => x.SR).ToList();
                }
                else if (isObject)
                {
                    maps = AllMaps.OrderByDescending(x => x.object_count).ToList();
                }
                else if (isUpdate)
                {
                    maps = AllMaps.OrderByDescending(x => x.UpdatedDate).ToList();

                }



                /*    foreach (var item in maps)
                    {
                        string[] rows = new string[]
                        {
                           item.name, item.BPM.ToString(), item.SR.ToString(), item.object_count.ToString(), item.UpdatedDate.ToString()
                        };

                        dataGridView1.Rows.Add(rows);
                    } */

                /*  maps.ForEach(item => 
                   {
                       string[] rows = new string[]
                       {
                           item.name, item.BPM.ToString(), item.SR.ToString(), item.object_count.ToString(), item.UpdatedDate.ToString()
                       };
                       dataGridView1.Rows.Add(rows);

                    }); */

                maps.All(item =>
                {
                    string[] rows = new string[]
                     {
                           item.name, item.BPM.ToString(), item.SR.ToString(), item.object_count.ToString(), item.UpdatedDate.ToString()
                     };
                    dataGridView1.Rows.Add(rows);

                    return true;
                });
                



            } else if (comboBox1.SelectedIndex.Equals(1))
                
                dataGridView1.Rows.Clear();

            if (isName)
            {
                maps = AllMaps.OrderBy(x => x.name).ToList();
            }
            else if (isBpm)
            {
                maps = AllMaps.OrderBy(x => x.BPM).ToList();
            }
            else if (isSR)
            {
                maps = AllMaps.OrderBy(x => x.SR).ToList();
            }
            else if (isObject)
            {
                maps = AllMaps.OrderBy(x => x.object_count).ToList();
            }
            else if (isUpdate)
            {
                maps = AllMaps.OrderBy(x => x.UpdatedDate).ToList();

            }



            foreach (var item in maps)
            {
                string[] rows = new string[]
                {
                       item.name, item.BPM.ToString(), item.SR.ToString(), item.object_count.ToString(), item.UpdatedDate.ToString()
                };

                dataGridView1.Rows.Add(rows);
            }
            {
                
            }
        }



            private void radioButton1_CheckedChanged(object sender, EventArgs e)
            {
            isName = true;
            isBpm = false;
            isSR = false;
            isObject = false;
            isUpdate = false;

            }

            private void radioButton2_CheckedChanged(object sender, EventArgs e)
            {
            isName = false;
            isBpm = true;
            isSR = false;
            isObject = false;
            isUpdate = false;
        }

            private void radioButton3_CheckedChanged(object sender, EventArgs e)
            {
            isName = false;
            isBpm = false;
            isSR = true;
            isObject = false;
            isUpdate = false;
        }

            private void radioButton4_CheckedChanged(object sender, EventArgs e)
            {
            isName = false;
            isBpm = false;
            isSR = false;
            isObject = true;
            isUpdate = false;
        }

            private void radioButton5_CheckedChanged(object sender, EventArgs e)
            {
            isName = false;
            isBpm = false;
            isSR = false;
            isObject = false;
            isUpdate = true;
        }
        }
    }


