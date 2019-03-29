namespace CourseLabSystem
{
    partial class FrmCourseBuilding
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_课表 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.Department = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.term = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.comboItem3 = new DevComponents.Editors.ComboItem();
            this.Clear = new DevComponents.DotNetBar.ButtonX();
            this.year = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Class = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.Garde = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.Add = new DevComponents.DotNetBar.ButtonX();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_课表)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_课表);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(0, 148);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1674, 526);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "排课操作";
            // 
            // dgv_课表
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgv_课表.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_课表.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgv_课表.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.dgv_课表.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_课表.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_课表.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_课表.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_课表.Location = new System.Drawing.Point(4, 22);
            this.dgv_课表.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgv_课表.Name = "dgv_课表";
            this.dgv_课表.ReadOnly = true;
            this.dgv_课表.RowTemplate.Height = 23;
            this.dgv_课表.Size = new System.Drawing.Size(1666, 500);
            this.dgv_课表.TabIndex = 2;
            this.dgv_课表.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_课表_CellContentClick);
            this.dgv_课表.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_课表_CellDoubleClick_1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 674);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 18, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1674, 25);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(69, 20);
            this.toolStripStatusLabel1.Text = "操作员：";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(0, 20);
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Margin = new System.Windows.Forms.Padding(70, 0, 0, 0);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(54, 25);
            this.toolStripStatusLabel3.Text = "权限：";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(0, 20);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Department);
            this.panel1.Controls.Add(this.term);
            this.panel1.Controls.Add(this.Clear);
            this.panel1.Controls.Add(this.year);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Class);
            this.panel1.Controls.Add(this.Garde);
            this.panel1.Controls.Add(this.Add);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1674, 148);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(922, 34);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "院系：";
            // 
            // Department
            // 
            this.Department.DisplayMember = "Text";
            this.Department.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Department.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Department.FormattingEnabled = true;
            this.Department.ItemHeight = 22;
            this.Department.Location = new System.Drawing.Point(999, 33);
            this.Department.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Department.Name = "Department";
            this.Department.Size = new System.Drawing.Size(150, 28);
            this.Department.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Department.TabIndex = 19;
            this.Department.SelectedIndexChanged += new System.EventHandler(this.Department_SelectedIndexChanged);
            // 
            // term
            // 
            this.term.DisplayMember = "Text";
            this.term.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.term.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.term.FormattingEnabled = true;
            this.term.ItemHeight = 22;
            this.term.Items.AddRange(new object[] {
            this.comboItem2,
            this.comboItem3});
            this.term.Location = new System.Drawing.Point(394, 34);
            this.term.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.term.Name = "term";
            this.term.Size = new System.Drawing.Size(150, 28);
            this.term.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.term.TabIndex = 16;
            this.term.SelectedIndexChanged += new System.EventHandler(this.term_SelectedIndexChanged);
            this.term.SelectionChangeCommitted += new System.EventHandler(this.term_SelectionChangeCommitted);
            this.term.SelectedValueChanged += new System.EventHandler(this.term_SelectedValueChanged);
            this.term.TextChanged += new System.EventHandler(this.term_TextChanged);
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "1";
            // 
            // comboItem3
            // 
            this.comboItem3.Text = "2";
            // 
            // Clear
            // 
            this.Clear.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Clear.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Clear.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Clear.Location = new System.Drawing.Point(810, 84);
            this.Clear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(140, 60);
            this.Clear.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Clear.TabIndex = 7;
            this.Clear.Text = "删除(C)";
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // year
            // 
            this.year.DisplayMember = "Text";
            this.year.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.year.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.year.FormattingEnabled = true;
            this.year.ItemHeight = 22;
            this.year.Location = new System.Drawing.Point(89, 34);
            this.year.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(150, 28);
            this.year.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.year.TabIndex = 15;
            this.year.SelectedIndexChanged += new System.EventHandler(this.year_SelectedIndexChanged);
            this.year.SelectionChangeCommitted += new System.EventHandler(this.year_SelectionChangeCommitted);
            this.year.SelectedValueChanged += new System.EventHandler(this.year_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(330, 34);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "学期：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(24, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "学年：";
            // 
            // Class
            // 
            this.Class.DisplayMember = "Text";
            this.Class.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Class.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Class.FormattingEnabled = true;
            this.Class.ItemHeight = 22;
            this.Class.Location = new System.Drawing.Point(1295, 34);
            this.Class.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Class.Name = "Class";
            this.Class.Size = new System.Drawing.Size(150, 28);
            this.Class.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Class.TabIndex = 11;
            this.Class.SelectedIndexChanged += new System.EventHandler(this.Class_SelectedIndexChanged);
            this.Class.SelectionChangeCommitted += new System.EventHandler(this.Class_SelectionChangeCommitted);
            this.Class.SelectedValueChanged += new System.EventHandler(this.Class_SelectedValueChanged);
            this.Class.SizeChanged += new System.EventHandler(this.Class_SizeChanged);
            // 
            // Garde
            // 
            this.Garde.DisplayMember = "Text";
            this.Garde.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Garde.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Garde.FormattingEnabled = true;
            this.Garde.ItemHeight = 22;
            this.Garde.Location = new System.Drawing.Point(679, 34);
            this.Garde.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Garde.Name = "Garde";
            this.Garde.Size = new System.Drawing.Size(150, 28);
            this.Garde.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Garde.TabIndex = 9;
            this.Garde.SelectedIndexChanged += new System.EventHandler(this.comboBoxEx1_SelectedIndexChanged);
            this.Garde.SelectionChangeCommitted += new System.EventHandler(this.Garde_SelectionChangeCommitted);
            this.Garde.SelectedValueChanged += new System.EventHandler(this.Garde_SelectedValueChanged);
            // 
            // Add
            // 
            this.Add.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Add.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.Add.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Add.Location = new System.Drawing.Point(357, 84);
            this.Add.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(140, 60);
            this.Add.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Add.TabIndex = 6;
            this.Add.Text = "保存";
            this.Add.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(615, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "年级：";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(1237, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "班级:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-218, 72);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(502, 115);
            this.dataGridView1.TabIndex = 3;
            // 
            // FrmCourseBuilding
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1674, 699);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmCourseBuilding";
            this.Text = "实验室排课";
            this.Load += new System.EventHandler(this.FrmCourseBuilding_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCourseBuilding_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_课表)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DevComponents.DotNetBar.ButtonX Clear;
        private DevComponents.DotNetBar.ButtonX Add;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public DevComponents.DotNetBar.Controls.ComboBoxEx Class;
        public DevComponents.DotNetBar.Controls.DataGridViewX dgv_课表;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.Editors.ComboItem comboItem3;
        public DevComponents.DotNetBar.Controls.ComboBoxEx term;
        public DevComponents.DotNetBar.Controls.ComboBoxEx year;
        private System.Windows.Forms.Label label2;
        public DevComponents.DotNetBar.Controls.ComboBoxEx Department;
        public DevComponents.DotNetBar.Controls.ComboBoxEx Garde;

    }
}

