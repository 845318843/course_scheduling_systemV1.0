namespace CourseLabSystem
{
    partial class FrmADD
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bt_Lesson = new DevComponents.DotNetBar.ButtonX();
            this.bt_Class = new DevComponents.DotNetBar.ButtonX();
            this.dgv_Class = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_DeleteLesson = new DevComponents.DotNetBar.ButtonX();
            this.bt_ReviceLesson = new DevComponents.DotNetBar.ButtonX();
            this.bt_DeleteClass = new DevComponents.DotNetBar.ButtonX();
            this.bt_ReviceClass = new DevComponents.DotNetBar.ButtonX();
            this.dgv_Lesson = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Class)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Lesson)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_Lesson
            // 
            this.bt_Lesson.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_Lesson.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_Lesson.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Lesson.Location = new System.Drawing.Point(850, 59);
            this.bt_Lesson.Margin = new System.Windows.Forms.Padding(4);
            this.bt_Lesson.Name = "bt_Lesson";
            this.bt_Lesson.Size = new System.Drawing.Size(136, 42);
            this.bt_Lesson.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_Lesson.TabIndex = 0;
            this.bt_Lesson.Text = "添加课程(F2)";
            this.bt_Lesson.Click += new System.EventHandler(this.bt_Lesson_Click);
            // 
            // bt_Class
            // 
            this.bt_Class.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_Class.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_Class.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Class.Location = new System.Drawing.Point(50, 59);
            this.bt_Class.Margin = new System.Windows.Forms.Padding(4);
            this.bt_Class.Name = "bt_Class";
            this.bt_Class.Size = new System.Drawing.Size(136, 42);
            this.bt_Class.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_Class.TabIndex = 0;
            this.bt_Class.Text = "添加班级(F1)";
            this.bt_Class.Click += new System.EventHandler(this.bt_Class_Click);
            // 
            // dgv_Class
            // 
            this.dgv_Class.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Class.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Class.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Class.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_Class.Location = new System.Drawing.Point(8, 25);
            this.dgv_Class.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Class.Name = "dgv_Class";
            this.dgv_Class.ReadOnly = true;
            this.dgv_Class.RowTemplate.Height = 23;
            this.dgv_Class.Size = new System.Drawing.Size(710, 559);
            this.dgv_Class.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_DeleteLesson);
            this.groupBox1.Controls.Add(this.bt_ReviceLesson);
            this.groupBox1.Controls.Add(this.bt_DeleteClass);
            this.groupBox1.Controls.Add(this.bt_ReviceClass);
            this.groupBox1.Controls.Add(this.bt_Class);
            this.groupBox1.Controls.Add(this.bt_Lesson);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(13, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1572, 147);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请选择您要添加的类型";
            // 
            // bt_DeleteLesson
            // 
            this.bt_DeleteLesson.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_DeleteLesson.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_DeleteLesson.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_DeleteLesson.Location = new System.Drawing.Point(1350, 59);
            this.bt_DeleteLesson.Name = "bt_DeleteLesson";
            this.bt_DeleteLesson.Size = new System.Drawing.Size(136, 42);
            this.bt_DeleteLesson.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_DeleteLesson.TabIndex = 4;
            this.bt_DeleteLesson.Text = "删除课程";
            this.bt_DeleteLesson.Click += new System.EventHandler(this.bt_DeleteLesson_Click);
            // 
            // bt_ReviceLesson
            // 
            this.bt_ReviceLesson.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_ReviceLesson.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_ReviceLesson.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_ReviceLesson.Location = new System.Drawing.Point(1100, 59);
            this.bt_ReviceLesson.Name = "bt_ReviceLesson";
            this.bt_ReviceLesson.Size = new System.Drawing.Size(136, 42);
            this.bt_ReviceLesson.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_ReviceLesson.TabIndex = 3;
            this.bt_ReviceLesson.Text = "修改课程";
            this.bt_ReviceLesson.Click += new System.EventHandler(this.bt_ReviceLesson_Click);
            // 
            // bt_DeleteClass
            // 
            this.bt_DeleteClass.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_DeleteClass.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_DeleteClass.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_DeleteClass.Location = new System.Drawing.Point(550, 59);
            this.bt_DeleteClass.Name = "bt_DeleteClass";
            this.bt_DeleteClass.Size = new System.Drawing.Size(136, 42);
            this.bt_DeleteClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_DeleteClass.TabIndex = 2;
            this.bt_DeleteClass.Text = "删除班级";
            this.bt_DeleteClass.Click += new System.EventHandler(this.bt_DeleteClass_Click);
            // 
            // bt_ReviceClass
            // 
            this.bt_ReviceClass.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_ReviceClass.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_ReviceClass.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_ReviceClass.Location = new System.Drawing.Point(300, 59);
            this.bt_ReviceClass.Name = "bt_ReviceClass";
            this.bt_ReviceClass.Size = new System.Drawing.Size(136, 42);
            this.bt_ReviceClass.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_ReviceClass.TabIndex = 1;
            this.bt_ReviceClass.Text = "修改班级";
            this.bt_ReviceClass.Click += new System.EventHandler(this.bt_ReviceClass_Click);
            // 
            // dgv_Lesson
            // 
            this.dgv_Lesson.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Lesson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Lesson.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Lesson.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dgv_Lesson.Location = new System.Drawing.Point(8, 26);
            this.dgv_Lesson.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_Lesson.Name = "dgv_Lesson";
            this.dgv_Lesson.ReadOnly = true;
            this.dgv_Lesson.RowTemplate.Height = 23;
            this.dgv_Lesson.Size = new System.Drawing.Size(710, 559);
            this.dgv_Lesson.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_Class);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(13, 159);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(726, 592);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "现 有 班 级";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_Lesson);
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(859, 166);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(726, 592);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "现 有 课 程";
            // 
            // FrmADD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1712, 804);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmADD";
            this.ShowIcon = false;
            this.Text = "添加";
            this.Load += new System.EventHandler(this.FrmADD_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmADD_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Class)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Lesson)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX bt_Lesson;
        private DevComponents.DotNetBar.ButtonX bt_Class;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_Class;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dgv_Lesson;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private DevComponents.DotNetBar.ButtonX bt_DeleteLesson;
        private DevComponents.DotNetBar.ButtonX bt_ReviceLesson;
        private DevComponents.DotNetBar.ButtonX bt_DeleteClass;
        private DevComponents.DotNetBar.ButtonX bt_ReviceClass;
    }
}