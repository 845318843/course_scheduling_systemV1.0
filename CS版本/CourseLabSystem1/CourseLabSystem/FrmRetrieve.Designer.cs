namespace CourseLabSystem
{
    partial class FrmRetrieve
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
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.tb_LoginId = new System.Windows.Forms.TextBox();
            this.tb_Modify = new System.Windows.Forms.TextBox();
            this.tb_Confirm = new System.Windows.Forms.TextBox();
            this.bt_Confirm = new DevComponents.DotNetBar.ButtonX();
            this.bt_Cancel = new DevComponents.DotNetBar.ButtonX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.tb_Id = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(73, 56);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 32);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "账号";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(32, 207);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(121, 38);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "修改密码";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(32, 265);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(116, 39);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "确认密码";
            // 
            // tb_LoginId
            // 
            this.tb_LoginId.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_LoginId.Location = new System.Drawing.Point(195, 54);
            this.tb_LoginId.Name = "tb_LoginId";
            this.tb_LoginId.Size = new System.Drawing.Size(233, 34);
            this.tb_LoginId.TabIndex = 6;
            // 
            // tb_Modify
            // 
            this.tb_Modify.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Modify.Location = new System.Drawing.Point(195, 197);
            this.tb_Modify.Name = "tb_Modify";
            this.tb_Modify.Size = new System.Drawing.Size(233, 34);
            this.tb_Modify.TabIndex = 7;
            // 
            // tb_Confirm
            // 
            this.tb_Confirm.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Confirm.Location = new System.Drawing.Point(195, 265);
            this.tb_Confirm.Name = "tb_Confirm";
            this.tb_Confirm.Size = new System.Drawing.Size(233, 34);
            this.tb_Confirm.TabIndex = 8;
            // 
            // bt_Confirm
            // 
            this.bt_Confirm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_Confirm.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_Confirm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Confirm.Location = new System.Drawing.Point(195, 337);
            this.bt_Confirm.Name = "bt_Confirm";
            this.bt_Confirm.Size = new System.Drawing.Size(122, 50);
            this.bt_Confirm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_Confirm.TabIndex = 9;
            this.bt_Confirm.Text = "确定(Enter)";
            this.bt_Confirm.Click += new System.EventHandler(this.bt_Confirm_Click);
            // 
            // bt_Cancel
            // 
            this.bt_Cancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bt_Cancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.bt_Cancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bt_Cancel.Location = new System.Drawing.Point(343, 337);
            this.bt_Cancel.Name = "bt_Cancel";
            this.bt_Cancel.Size = new System.Drawing.Size(125, 50);
            this.bt_Cancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bt_Cancel.TabIndex = 10;
            this.bt_Cancel.Text = "取消(Cancel)";
            this.bt_Cancel.Click += new System.EventHandler(this.bt_Cancel_Click);
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX4.Location = new System.Drawing.Point(73, 126);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 38);
            this.labelX4.TabIndex = 11;
            this.labelX4.Text = "工号";
            // 
            // tb_Id
            // 
            this.tb_Id.Font = new System.Drawing.Font("宋体", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tb_Id.Location = new System.Drawing.Point(195, 126);
            this.tb_Id.Name = "tb_Id";
            this.tb_Id.Size = new System.Drawing.Size(233, 34);
            this.tb_Id.TabIndex = 12;
            // 
            // FrmRetrieve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 439);
            this.Controls.Add(this.tb_Id);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.bt_Cancel);
            this.Controls.Add(this.bt_Confirm);
            this.Controls.Add(this.tb_Confirm);
            this.Controls.Add(this.tb_Modify);
            this.Controls.Add(this.tb_LoginId);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Name = "FrmRetrieve";
            this.ShowIcon = false;
            this.Text = "retrieve";
            this.Load += new System.EventHandler(this.FrmRetrieve_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmRetrieve_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.TextBox tb_LoginId;
        private System.Windows.Forms.TextBox tb_Modify;
        private System.Windows.Forms.TextBox tb_Confirm;
        private DevComponents.DotNetBar.ButtonX bt_Confirm;
        private DevComponents.DotNetBar.ButtonX bt_Cancel;
        private DevComponents.DotNetBar.LabelX labelX4;
        private System.Windows.Forms.TextBox tb_Id;
    }
}