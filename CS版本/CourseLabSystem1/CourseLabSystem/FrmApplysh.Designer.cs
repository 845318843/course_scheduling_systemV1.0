namespace CourseLabSystem
{
    partial class FrmApplysh
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.dgv_seach = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.bt_seach = new DevComponents.DotNetBar.ButtonX();
            this.bt_true = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmb_BuildingId = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmb_Classroom = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmb_Week = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmb_WeekDay = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.comboItem4 = new DevComponents.Editors.ComboItem();
            this.comboItem5 = new DevComponents.Editors.ComboItem();
            this.comboItem6 = new DevComponents.Editors.ComboItem();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_seach)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(71, 33);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 34);
            this.labelX1.TabIndex = 3;
            this.labelX1.Text = "教学楼";
            // 
            // labelX5
            // 
            this.labelX5.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX5.Location = new System.Drawing.Point(887, 38);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(34, 27);
            this.labelX5.TabIndex = 17;
            this.labelX5.Text = "周";
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.Location = new System.Drawing.Point(987, 36);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(57, 34);
            this.labelX4.TabIndex = 16;
            this.labelX4.Text = "周几";
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(708, 33);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(36, 34);
            this.labelX3.TabIndex = 15;
            this.labelX3.Text = "第";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(383, 33);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(62, 34);
            this.labelX2.TabIndex = 14;
            this.labelX2.Text = "教室";
            // 
            // dgv_seach
            // 
            this.dgv_seach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_seach.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_seach.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv_seach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_seach.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_seach.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_seach.Location = new System.Drawing.Point(6, 24);
            this.dgv_seach.Name = "dgv_seach";
            this.dgv_seach.ReadOnly = true;
            this.dgv_seach.RowTemplate.Height = 27;
            this.dgv_seach.Size = new System.Drawing.Size(1734, 573);
            this.dgv_seach.TabIndex = 21;
            // 
            // bt_seach
            // 
            this.bt_seach.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_seach.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_seach.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_seach.Location = new System.Drawing.Point(1373, 21);
            this.bt_seach.Name = "bt_seach";
            this.bt_seach.Size = new System.Drawing.Size(153, 42);
            this.bt_seach.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_seach.TabIndex = 22;
            this.bt_seach.Text = "寻找(ENTER)";
            this.bt_seach.Click += new System.EventHandler(this.bt_seach_Click);
            // 
            // bt_true
            // 
            this.bt_true.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_true.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_true.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_true.Location = new System.Drawing.Point(1373, 80);
            this.bt_true.Name = "bt_true";
            this.bt_true.Size = new System.Drawing.Size(153, 42);
            this.bt_true.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_true.TabIndex = 23;
            this.bt_true.Text = "确认申请";
            this.bt_true.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1740, 147);
            this.panel1.TabIndex = 24;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmb_WeekDay);
            this.groupBox1.Controls.Add(this.cmb_Week);
            this.groupBox1.Controls.Add(this.cmb_Classroom);
            this.groupBox1.Controls.Add(this.cmb_BuildingId);
            this.groupBox1.Controls.Add(this.labelX1);
            this.groupBox1.Controls.Add(this.bt_true);
            this.groupBox1.Controls.Add(this.labelX2);
            this.groupBox1.Controls.Add(this.bt_seach);
            this.groupBox1.Controls.Add(this.labelX4);
            this.groupBox1.Controls.Add(this.labelX5);
            this.groupBox1.Controls.Add(this.labelX3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1740, 140);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "搜索操作";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_seach);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(0, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1740, 593);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "搜索结果";
            // 
            // cmb_BuildingId
            // 
            this.cmb_BuildingId.DisplayMember = "Text";
            this.cmb_BuildingId.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_BuildingId.FormattingEnabled = true;
            this.cmb_BuildingId.ItemHeight = 22;
            this.cmb_BuildingId.Location = new System.Drawing.Point(152, 35);
            this.cmb_BuildingId.Name = "cmb_BuildingId";
            this.cmb_BuildingId.Size = new System.Drawing.Size(140, 28);
            this.cmb_BuildingId.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmb_BuildingId.TabIndex = 24;
            this.cmb_BuildingId.TextChanged += new System.EventHandler(this.comboBoxEx1_TextChanged);
            // 
            // cmb_Classroom
            // 
            this.cmb_Classroom.DisplayMember = "Text";
            this.cmb_Classroom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_Classroom.FormattingEnabled = true;
            this.cmb_Classroom.ItemHeight = 22;
            this.cmb_Classroom.Location = new System.Drawing.Point(451, 35);
            this.cmb_Classroom.Name = "cmb_Classroom";
            this.cmb_Classroom.Size = new System.Drawing.Size(140, 28);
            this.cmb_Classroom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmb_Classroom.TabIndex = 25;
            // 
            // cmb_Week
            // 
            this.cmb_Week.DisplayMember = "Text";
            this.cmb_Week.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_Week.FormattingEnabled = true;
            this.cmb_Week.ItemHeight = 22;
            this.cmb_Week.Location = new System.Drawing.Point(750, 35);
            this.cmb_Week.Name = "cmb_Week";
            this.cmb_Week.Size = new System.Drawing.Size(120, 28);
            this.cmb_Week.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmb_Week.TabIndex = 26;
            // 
            // cmb_WeekDay
            // 
            this.cmb_WeekDay.DisplayMember = "Text";
            this.cmb_WeekDay.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmb_WeekDay.FormattingEnabled = true;
            this.cmb_WeekDay.ItemHeight = 22;
            this.cmb_WeekDay.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2,
            this.comboItem3,
            this.comboItem4,
            this.comboItem5,
            this.comboItem6,
            this.comboItem7});
            this.cmb_WeekDay.Location = new System.Drawing.Point(1050, 37);
            this.cmb_WeekDay.Name = "cmb_WeekDay";
            this.cmb_WeekDay.Size = new System.Drawing.Size(140, 28);
            this.cmb_WeekDay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmb_WeekDay.TabIndex = 27;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "一";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "二";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "三";
            // 
            // comboItem4
            // 
            this.comboItem4.Text = "四";
            // 
            // comboItem5
            // 
            this.comboItem5.Text = "五";
            // 
            // comboItem6
            // 
            this.comboItem6.Text = "六";
            // 
            // comboItem7
            // 
            this.comboItem7.Text = "日";
            // 
            // FrmApplysh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1740, 740);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Name = "FrmApplysh";
            this.ShowIcon = false;
            this.Text = "学生申请";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmApplysh_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_seach)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_seach;
        private DevComponents.DotNetBar.ButtonX bt_seach;
        private DevComponents.DotNetBar.ButtonX bt_true;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmb_BuildingId;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmb_WeekDay;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmb_Week;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmb_Classroom;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        private DevComponents.Editors.ComboItem comboItem4;
        private DevComponents.Editors.ComboItem comboItem5;
        private DevComponents.Editors.ComboItem comboItem6;
        private DevComponents.Editors.ComboItem comboItem7;
    }
}