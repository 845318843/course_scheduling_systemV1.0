namespace CourseLabSystem
{
    partial class FrmRecord
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_Excel = new DevComponents.DotNetBar.ButtonX();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.bt_Search = new DevComponents.DotNetBar.ButtonX();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cmb_Department = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cmb_Room = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cmb_Teacher = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmb_Class = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.cmb_Garde = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dgv_Record = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Record)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_Excel);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.bt_Search);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1337, 147);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请选择查找类型";
            // 
            // bt_Excel
            // 
            this.bt_Excel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_Excel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_Excel.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Excel.Location = new System.Drawing.Point(1176, 60);
            this.bt_Excel.Name = "bt_Excel";
            this.bt_Excel.Size = new System.Drawing.Size(135, 42);
            this.bt_Excel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_Excel.TabIndex = 1;
            this.bt_Excel.Text = "Excel导出";
            this.bt_Excel.Click += new System.EventHandler(this.bt_Excel_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton3.Location = new System.Drawing.Point(795, 27);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(87, 23);
            this.radioButton3.TabIndex = 3;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "类型三";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.Click += new System.EventHandler(this.radioButton3_Click);
            // 
            // bt_Search
            // 
            this.bt_Search.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_Search.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_Search.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Search.Location = new System.Drawing.Point(1007, 60);
            this.bt_Search.Name = "bt_Search";
            this.bt_Search.Size = new System.Drawing.Size(135, 43);
            this.bt_Search.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_Search.TabIndex = 0;
            this.bt_Search.Text = "查 找";
            this.bt_Search.Click += new System.EventHandler(this.bt_Search_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cmb_Department);
            this.groupBox3.Controls.Add(this.labelX1);
            this.groupBox3.Controls.Add(this.labelX2);
            this.groupBox3.Controls.Add(this.cmb_Room);
            this.groupBox3.Location = new System.Drawing.Point(6, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(259, 93);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // cmb_Department
            // 
            this.cmb_Department.DisplayMember = "Text";
            this.cmb_Department.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_Department.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_Department.FormattingEnabled = true;
            this.cmb_Department.ItemHeight = 22;
            this.cmb_Department.Location = new System.Drawing.Point(76, 13);
            this.cmb_Department.Name = "cmb_Department";
            this.cmb_Department.Size = new System.Drawing.Size(177, 28);
            this.cmb_Department.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmb_Department.TabIndex = 2;
            this.cmb_Department.TextChanged += new System.EventHandler(this.cmb_Department_TextChanged);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(15, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(56, 34);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "院系";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(15, 46);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(55, 39);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "教室";
            // 
            // cmb_Room
            // 
            this.cmb_Room.DisplayMember = "Text";
            this.cmb_Room.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_Room.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_Room.FormattingEnabled = true;
            this.cmb_Room.ItemHeight = 22;
            this.cmb_Room.Location = new System.Drawing.Point(76, 52);
            this.cmb_Room.Name = "cmb_Room";
            this.cmb_Room.Size = new System.Drawing.Size(176, 28);
            this.cmb_Room.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmb_Room.TabIndex = 1;
            this.cmb_Room.Click += new System.EventHandler(this.cmb_Room_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelX3);
            this.groupBox4.Controls.Add(this.cmb_Teacher);
            this.groupBox4.Location = new System.Drawing.Point(406, 48);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(185, 93);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(6, 13);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(77, 28);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "教 师";
            // 
            // cmb_Teacher
            // 
            this.cmb_Teacher.DisplayMember = "Text";
            this.cmb_Teacher.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_Teacher.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_Teacher.FormattingEnabled = true;
            this.cmb_Teacher.ItemHeight = 22;
            this.cmb_Teacher.Location = new System.Drawing.Point(6, 46);
            this.cmb_Teacher.Name = "cmb_Teacher";
            this.cmb_Teacher.Size = new System.Drawing.Size(176, 28);
            this.cmb_Teacher.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmb_Teacher.TabIndex = 2;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(441, 27);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(87, 23);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "类型二";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.Click += new System.EventHandler(this.radioButton2_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cmb_Class);
            this.groupBox5.Controls.Add(this.labelX5);
            this.groupBox5.Controls.Add(this.cmb_Garde);
            this.groupBox5.Controls.Add(this.labelX4);
            this.groupBox5.Location = new System.Drawing.Point(730, 48);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(235, 93);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            // 
            // cmb_Class
            // 
            this.cmb_Class.DisplayMember = "Text";
            this.cmb_Class.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_Class.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_Class.FormattingEnabled = true;
            this.cmb_Class.ItemHeight = 22;
            this.cmb_Class.Location = new System.Drawing.Point(56, 52);
            this.cmb_Class.Name = "cmb_Class";
            this.cmb_Class.Size = new System.Drawing.Size(176, 28);
            this.cmb_Class.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmb_Class.TabIndex = 4;
            this.cmb_Class.Click += new System.EventHandler(this.cmb_Class_Click);
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX5.Location = new System.Drawing.Point(6, 48);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(56, 34);
            this.labelX5.TabIndex = 4;
            this.labelX5.Text = "班级";
            // 
            // cmb_Garde
            // 
            this.cmb_Garde.DisplayMember = "Text";
            this.cmb_Garde.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_Garde.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmb_Garde.FormattingEnabled = true;
            this.cmb_Garde.ItemHeight = 22;
            this.cmb_Garde.Location = new System.Drawing.Point(56, 11);
            this.cmb_Garde.Name = "cmb_Garde";
            this.cmb_Garde.Size = new System.Drawing.Size(176, 28);
            this.cmb_Garde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmb_Garde.TabIndex = 3;
            this.cmb_Garde.TextChanged += new System.EventHandler(this.cmb_Garde_TextChanged);
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.Location = new System.Drawing.Point(6, 13);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(56, 34);
            this.labelX4.TabIndex = 3;
            this.labelX4.Text = "年级";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioButton1.Location = new System.Drawing.Point(97, 27);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(87, 23);
            this.radioButton1.TabIndex = 11;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "类型一";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Click += new System.EventHandler(this.radioButton1_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dgv_Record);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox6.Location = new System.Drawing.Point(0, 147);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1337, 508);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = " 有 条记录 ";
            // 
            // dgv_Record
            // 
            this.dgv_Record.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_Record.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Record.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Record.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Record.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_Record.Location = new System.Drawing.Point(3, 24);
            this.dgv_Record.Name = "dgv_Record";
            this.dgv_Record.Size = new System.Drawing.Size(1331, 481);
            this.dgv_Record.TabIndex = 0;
            // 
            // FrmRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 655);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "FrmRecord";
            this.ShowIcon = false;
            this.Text = "排课记录";
            this.Load += new System.EventHandler(this.FrmRecord_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Record)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.GroupBox groupBox5;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.RadioButton radioButton1;
        private DevComponents.DotNetBar.ButtonX bt_Excel;
        private DevComponents.DotNetBar.ButtonX bt_Search;
        private System.Windows.Forms.GroupBox groupBox4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_Record;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmb_Department;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmb_Room;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmb_Teacher;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmb_Class;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmb_Garde;
    }
}