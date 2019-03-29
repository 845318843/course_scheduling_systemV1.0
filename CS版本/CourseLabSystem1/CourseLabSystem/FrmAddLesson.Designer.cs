namespace CourseLabSystem
{
    partial class FrmAddLesson
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btCancel = new DevComponents.DotNetBar.ButtonX();
            this.btOk = new DevComponents.DotNetBar.ButtonX();
            this.tbDepartment = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.tbCourse = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.tbCourse_Id = new CourseLabSystem.year();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(19, 53);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(121, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "课程代号：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbCourse_Id);
            this.groupBox1.Controls.Add(this.labelX1);
            this.groupBox1.Controls.Add(this.btCancel);
            this.groupBox1.Controls.Add(this.btOk);
            this.groupBox1.Controls.Add(this.tbDepartment);
            this.groupBox1.Controls.Add(this.labelX3);
            this.groupBox1.Controls.Add(this.tbCourse);
            this.groupBox1.Controls.Add(this.labelX2);
            this.groupBox1.Location = new System.Drawing.Point(22, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 474);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "课程";
            // 
            // btCancel
            // 
            this.btCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btCancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCancel.Location = new System.Drawing.Point(253, 259);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(96, 59);
            this.btCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btCancel.TabIndex = 6;
            this.btCancel.Text = "取消(Cancel)";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // btOk
            // 
            this.btOk.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btOk.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btOk.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btOk.Location = new System.Drawing.Point(71, 259);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(105, 59);
            this.btOk.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btOk.TabIndex = 5;
            this.btOk.Text = "确定(Enter)";
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // tbDepartment
            // 
            // 
            // 
            // 
            this.tbDepartment.Border.Class = "TextBoxBorder";
            this.tbDepartment.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbDepartment.Location = new System.Drawing.Point(159, 182);
            this.tbDepartment.Name = "tbDepartment";
            this.tbDepartment.Size = new System.Drawing.Size(199, 25);
            this.tbDepartment.TabIndex = 4;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(65, 182);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(88, 23);
            this.labelX3.TabIndex = 3;
            this.labelX3.Text = "院系：";
            // 
            // tbCourse
            // 
            // 
            // 
            // 
            this.tbCourse.Border.Class = "TextBoxBorder";
            this.tbCourse.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbCourse.Location = new System.Drawing.Point(159, 117);
            this.tbCourse.Name = "tbCourse";
            this.tbCourse.Size = new System.Drawing.Size(199, 25);
            this.tbCourse.TabIndex = 2;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(19, 117);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(121, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "课程名称：";
            // 
            // tbCourse_Id
            // 
            this.tbCourse_Id.Location = new System.Drawing.Point(159, 53);
            this.tbCourse_Id.Name = "tbCourse_Id";
            this.tbCourse_Id.Size = new System.Drawing.Size(199, 25);
            this.tbCourse_Id.TabIndex = 7;
            this.tbCourse_Id.WatermarkText = "不能重复";
            // 
            // FrmAddLesson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 543);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Name = "FrmAddLesson";
            this.ShowIcon = false;
            this.Text = "课程";
            this.Load += new System.EventHandler(this.FrmAddClass_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAddLesson_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX btCancel;
        private DevComponents.DotNetBar.ButtonX btOk;
        private DevComponents.DotNetBar.Controls.TextBoxX tbDepartment;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX tbCourse;
        private DevComponents.DotNetBar.LabelX labelX2;
        private year tbCourse_Id;
    }
}