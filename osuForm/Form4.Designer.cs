
namespace osuForm
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.ID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.MName = new System.Windows.Forms.TextBox();
            this.bpm = new System.Windows.Forms.TextBox();
            this.objects = new System.Windows.Forms.TextBox();
            this.sr = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cDate = new System.Windows.Forms.Label();
            this.updatedDate = new System.Windows.Forms.Label();
            this.userID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(99, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(564, 179);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            this.dataGridView1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Map id : ";
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Location = new System.Drawing.Point(152, 217);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(38, 15);
            this.ID.TabIndex = 2;
            this.ID.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(181, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Map Name : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(426, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "User ID : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(181, 283);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "BPM :  ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(181, 314);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "Obect Count : ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(181, 346);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "SR : ";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(426, 257);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 15);
            this.label10.TabIndex = 10;
            this.label10.Text = "Created Date :  ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(425, 283);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 15);
            this.label11.TabIndex = 11;
            this.label11.Text = "Updated Date : ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(669, 139);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 52);
            this.button1.TabIndex = 17;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(586, 372);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 50);
            this.button2.TabIndex = 18;
            this.button2.Text = "Update";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MName
            // 
            this.MName.Location = new System.Drawing.Point(260, 254);
            this.MName.Name = "MName";
            this.MName.Size = new System.Drawing.Size(129, 23);
            this.MName.TabIndex = 19;
            // 
            // bpm
            // 
            this.bpm.Location = new System.Drawing.Point(261, 283);
            this.bpm.Name = "bpm";
            this.bpm.Size = new System.Drawing.Size(128, 23);
            this.bpm.TabIndex = 21;
            // 
            // objects
            // 
            this.objects.Location = new System.Drawing.Point(261, 314);
            this.objects.Name = "objects";
            this.objects.Size = new System.Drawing.Size(128, 23);
            this.objects.TabIndex = 22;
            // 
            // sr
            // 
            this.sr.Location = new System.Drawing.Point(260, 343);
            this.sr.Name = "sr";
            this.sr.Size = new System.Drawing.Size(128, 23);
            this.sr.TabIndex = 23;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(686, 372);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 50);
            this.button3.TabIndex = 26;
            this.button3.Text = "Delete";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(687, 320);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(84, 46);
            this.button4.TabIndex = 27;
            this.button4.Text = "Insert";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cDate
            // 
            this.cDate.AutoSize = true;
            this.cDate.Location = new System.Drawing.Point(520, 257);
            this.cDate.Name = "cDate";
            this.cDate.Size = new System.Drawing.Size(38, 15);
            this.cDate.TabIndex = 28;
            this.cDate.Text = "label2";
            // 
            // updatedDate
            // 
            this.updatedDate.AutoSize = true;
            this.updatedDate.Location = new System.Drawing.Point(519, 283);
            this.updatedDate.Name = "updatedDate";
            this.updatedDate.Size = new System.Drawing.Size(38, 15);
            this.updatedDate.TabIndex = 29;
            this.updatedDate.Text = "label2";
            // 
            // userID
            // 
            this.userID.AutoSize = true;
            this.userID.Location = new System.Drawing.Point(519, 317);
            this.userID.Name = "userID";
            this.userID.Size = new System.Drawing.Size(38, 15);
            this.userID.TabIndex = 30;
            this.userID.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(288, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 15);
            this.label2.TabIndex = 31;
            this.label2.Text = "Welcome to the mapping panel";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userID);
            this.Controls.Add(this.updatedDate);
            this.Controls.Add(this.cDate);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.sr);
            this.Controls.Add(this.objects);
            this.Controls.Add(this.bpm);
            this.Controls.Add(this.MName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox MName;
        private System.Windows.Forms.TextBox bpm;
        private System.Windows.Forms.TextBox objects;
        private System.Windows.Forms.TextBox sr;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label cDate;
        private System.Windows.Forms.Label updatedDate;
        private System.Windows.Forms.Label userID;
        private System.Windows.Forms.Label label2;
    }
}