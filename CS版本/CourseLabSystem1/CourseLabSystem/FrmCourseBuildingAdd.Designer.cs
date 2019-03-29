namespace CourseLabSystem
{
    partial class FrmCourseBuildingAdd
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCourseBuildingAdd));
            this.Teacher = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Course = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label7 = new System.Windows.Forms.Label();
            this.Teacher1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.Building_id = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label6 = new System.Windows.Forms.Label();
            this.Building = new System.Windows.Forms.TextBox();
            this.ClassRoom = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.Major1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Week = new CourseLabSystem.year();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Teacher
            // 
            this.Teacher.Dock = System.Windows.Forms.DockStyle.Left;
            this.Teacher.ImageIndex = 0;
            this.Teacher.ImageList = this.imageList1;
            this.Teacher.Location = new System.Drawing.Point(0, 0);
            this.Teacher.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Teacher.Name = "Teacher";
            this.Teacher.SelectedImageIndex = 0;
            this.Teacher.Size = new System.Drawing.Size(303, 548);
            this.Teacher.TabIndex = 0;
            this.Teacher.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Teacher_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "院系");
            this.imageList1.Images.SetKeyName(1, "老师");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Week);
            this.groupBox1.Controls.Add(this.Course);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.Teacher1);
            this.groupBox1.Controls.Add(this.Building_id);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Building);
            this.groupBox1.Controls.Add(this.ClassRoom);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.buttonX2);
            this.groupBox1.Controls.Add(this.buttonX1);
            this.groupBox1.Controls.Add(this.Major1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(303, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(574, 548);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "添加";
            // 
            // Course
            // 
            this.Course.DisplayMember = "Text";
            this.Course.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Course.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Course.FormattingEnabled = true;
            this.Course.ItemHeight = 22;
            this.Course.Location = new System.Drawing.Point(269, 311);
            this.Course.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Course.Name = "Course";
            this.Course.Size = new System.Drawing.Size(197, 28);
            this.Course.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Course.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(144, 261);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 19);
            this.label7.TabIndex = 16;
            this.label7.Text = "老师专业：";
            // 
            // Teacher1
            // 
            // 
            // 
            // 
            this.Teacher1.Border.Class = "TextBoxBorder";
            this.Teacher1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Teacher1.Enabled = false;
            this.Teacher1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Teacher1.Location = new System.Drawing.Point(269, 209);
            this.Teacher1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Teacher1.Name = "Teacher1";
            this.Teacher1.Size = new System.Drawing.Size(197, 28);
            this.Teacher1.TabIndex = 15;
            // 
            // Building_id
            // 
            this.Building_id.DisplayMember = "Text";
            this.Building_id.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.Building_id.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Building_id.FormattingEnabled = true;
            this.Building_id.ItemHeight = 22;
            this.Building_id.Location = new System.Drawing.Point(269, 102);
            this.Building_id.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Building_id.Name = "Building_id";
            this.Building_id.Size = new System.Drawing.Size(197, 28);
            this.Building_id.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.Building_id.TabIndex = 14;
            this.Building_id.SelectionChangeCommitted += new System.EventHandler(this.Building_id_SelectionChangeCommitted);
            this.Building_id.SelectedValueChanged += new System.EventHandler(this.Building_id_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(184, 112);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 19);
            this.label6.TabIndex = 13;
            this.label6.Text = "系楼";
            // 
            // Building
            // 
            this.Building.Enabled = false;
            this.Building.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Building.Location = new System.Drawing.Point(269, 46);
            this.Building.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Building.Name = "Building";
            this.Building.Size = new System.Drawing.Size(197, 28);
            this.Building.TabIndex = 12;
            // 
            // ClassRoom
            // 
            this.ClassRoom.DisplayMember = "Text";
            this.ClassRoom.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ClassRoom.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClassRoom.FormattingEnabled = true;
            this.ClassRoom.ItemHeight = 22;
            this.ClassRoom.Location = new System.Drawing.Point(269, 158);
            this.ClassRoom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ClassRoom.Name = "ClassRoom";
            this.ClassRoom.Size = new System.Drawing.Size(197, 28);
            this.ClassRoom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ClassRoom.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(184, 49);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "系院：";
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX2.Location = new System.Drawing.Point(404, 450);
            this.buttonX2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(113, 48);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 0;
            this.buttonX2.Text = "取消";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonX1.Location = new System.Drawing.Point(240, 450);
            this.buttonX1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(119, 48);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 9;
            this.buttonX1.Text = "添加(Enter)";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // Major1
            // 
            // 
            // 
            // 
            this.Major1.Border.Class = "TextBoxBorder";
            this.Major1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.Major1.Enabled = false;
            this.Major1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Major1.Location = new System.Drawing.Point(271, 259);
            this.Major1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Major1.Name = "Major1";
            this.Major1.Size = new System.Drawing.Size(197, 28);
            this.Major1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(184, 372);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "周次：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(144, 220);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "任课老师：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(184, 320);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "课程：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(184, 168);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "教室：";
            // 
            // Week
            // 
            this.Week.Location = new System.Drawing.Point(273, 371);
            this.Week.Name = "Week";
            this.Week.Size = new System.Drawing.Size(195, 25);
            this.Week.TabIndex = 18;
            this.Week.WatermarkText = "格式为1,2,3";
            // 
            // FrmCourseBuildingAdd
            // 
            this.AcceptButton = this.buttonX1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 548);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Teacher);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmCourseBuildingAdd";
            this.Text = "添加课程";
            this.Load += new System.EventHandler(this.FrmCourseBuildingAdd_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCourseBuildingAdd_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView Teacher;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.TextBoxX Major1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx ClassRoom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox Building;
        private DevComponents.DotNetBar.Controls.ComboBoxEx Building_id;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private DevComponents.DotNetBar.Controls.TextBoxX Teacher1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx Course;
        private year Week;
    }
}