using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using EntityClass;
using WeifenLuo.WinFormsUI.Docking;

namespace CourseLabSystem
{
    public partial class FrmLab : DockContent
    {
        int Role;
        public FrmLab(int role)
        {
            Role = role;
            InitializeComponent();     
        }
        LabBLL labbll = new LabBLL();
        public static DataTable update()
        {
            return LabBLL.update();
        }
        private void button1_Add_Click(object sender, EventArgs e)
        {
            FrmLabAdd labadd = new FrmLabAdd();
            if (labadd.ShowDialog() == DialogResult.OK)
            {
                dataGridViewX1.DataSource = update();
                dataGridViewX1.AllowUserToAddRows = false;
            }
        }

        private void FrmLab_Load(object sender, EventArgs e)
        {
            if (Role == 2)
            {
                buttonX1.Enabled = false;
                buttonX2.Enabled = false;
                buttonX3.Enabled = false;
            }
            dataGridViewX1.DataSource = update();
            dataGridViewX1.AllowUserToAddRows = false;
            dataGridViewX1.RowTemplate.Height = 30;
            dataGridViewX1.Columns[0].Width = 150;
            dataGridViewX1.Columns[1].Width = 150;
            dataGridViewX1.Columns[2].Width = 150;
            dataGridViewX1.Columns[3].Width = 150;
            dataGridViewX1.Columns[4].Width = 150;
            dataGridViewX1.Columns[5].Width = 150;
            this.KeyPreview = true;
        }

        private void button2_Modify_Click(object sender, EventArgs e)
        {
            int n = dataGridViewX1.CurrentRow.Index;
            string [] str = { dataGridViewX1.CurrentRow.Cells[0].Value.ToString(), dataGridViewX1.CurrentRow.Cells[1].Value.ToString(), dataGridViewX1.CurrentRow.Cells[2].Value.ToString(), dataGridViewX1.CurrentRow.Cells[3].Value.ToString(), dataGridViewX1.CurrentRow.Cells[4].Value.ToString(), dataGridViewX1.CurrentRow.Cells[5].Value.ToString() };
            FrmLabModify labmodify = new FrmLabModify(str);
            if (labmodify.ShowDialog() == DialogResult.OK)
            {
                dataGridViewX1.DataSource = update();
                dataGridViewX1.AllowUserToAddRows = false;
                dataGridViewX1.CurrentCell = dataGridViewX1[0,n];
            }

        }

        private void button3_Delete_Click(object sender, EventArgs e)
        {
            int n = dataGridViewX1.CurrentRow.Index;
            DialogResult dr;       
            dr=MessageBox.Show("确认要删除所选中行的教室以及其附带的数据吗？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK) 
            {
                labbll.delete(dataGridViewX1.CurrentRow.Cells[2].Value.ToString());
                dataGridViewX1.DataSource = update();
                dataGridViewX1.AllowUserToAddRows = false;
                dataGridViewX1.CurrentCell = dataGridViewX1[0, n == 0 ? 0:n-1];
            }
        }


        private void FrmLab_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.F2:button1_Add_Click(sender, e);break;
                case Keys.F3:button2_Modify_Click(sender, e);break;
                case Keys.F4:button3_Delete_Click(sender, e);break;
            }
        }
    }
}
