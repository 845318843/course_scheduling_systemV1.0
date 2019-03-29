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
using WeifenLuo.WinFormsUI.Docking;

namespace CourseLabSystem
{
    public partial class FrmSetting : DockContent
    {
        int Role;
        public FrmSetting(int role)
        {
            Role = role;
            InitializeComponent();
        }

        /// <summary>
        /// 导入数据到DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSetting_Load(object sender, EventArgs e)
        {
            if (Role == 2)
            {
                buttonX3.Enabled = false;
                buttonX4.Enabled = false;
                buttonX5.Enabled = false;
                buttonX7.Enabled = false;
                buttonX8.Enabled = false;
                buttonX9.Enabled = false;
            }
            SettingBLL stb = new SettingBLL();
            dataGridViewX1.DataSource = stb.GetTeacher();
            dataGridViewX1.RowTemplate.Height = 30;
            dataGridViewX1.Columns[0].Width = 150;
            dataGridViewX1.Columns[1].Width = 150;
            dataGridViewX1.Columns[2].Width = 150;
            dataGridViewX1.Columns[3].Width = 150;
            
        }
        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string name = textBox2.Text;
            SettingBLL stb = new SettingBLL();
            dataGridViewX1.DataSource = stb.SearchTeacher(id, name);
            dataGridViewX1.RowTemplate.Height = 30;
            dataGridViewX1.Columns[0].Width = 150;
            dataGridViewX1.Columns[1].Width = 150;
            dataGridViewX1.Columns[2].Width = 150;
            dataGridViewX1.Columns[3].Width = 150;
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            FrmSetting_Load(sender, e);
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Columns[0].Name.ToString() == "工号")
            {
                AddTeacher addt = new AddTeacher();
                addt.StartPosition = FormStartPosition.CenterParent;
                addt.ShowDialog();
            }

            FrmSetting_Load(sender, e);
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {

            string[] str;
            if (dataGridViewX1.Rows.Count > 0 && dataGridViewX1.Columns[0].Name.ToString() == "工号")
            {
                int n = dataGridViewX1.CurrentRow.Index;
                str = new string[] { dataGridViewX1.CurrentRow.Cells[0].Value.ToString(), dataGridViewX1.CurrentRow.Cells[1].Value.ToString(), dataGridViewX1.CurrentRow.Cells[2].Value.ToString(), dataGridViewX1.CurrentRow.Cells[3].Value.ToString() };
                FrmSettingChangeT sct = new FrmSettingChangeT(str);
                sct.StartPosition = FormStartPosition.CenterParent;
                sct.ShowDialog();
            }
            FrmSetting_Load(sender, e);
        }

        private void buttonX5_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Columns[0].Name.ToString() == "工号")
            {

                string id = dataGridViewX1.CurrentRow.Cells[0].Value.ToString();
                SettingBLL stb = new SettingBLL();
                stb.Deleteteacher(MessageBox.Show("确定删除吗？", "系统警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK, id);
            }

            FrmSetting_Load(sender, e);
        }

        private void buttonX6_Click(object sender, EventArgs e)
        {
            SettingBLL stb = new SettingBLL();
            dataGridViewX1.DataSource = stb.GetAdmin();
            dataGridViewX1.Columns[0].Visible = false;
            dataGridViewX1.Columns[2].Visible = false;
        }

        private void buttonX7_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Columns[0].Name.ToString() == "ID")
            {
                FrmSettingAddAdmin addt = new FrmSettingAddAdmin();
                addt.StartPosition = FormStartPosition.CenterParent;
                addt.ShowDialog();
            }

            buttonX6_Click(sender, e);
        }

        private void buttonX8_Click(object sender, EventArgs e)
        {
            string[] str;
            if (dataGridViewX1.Rows.Count > 0 && dataGridViewX1.Columns[0].Name.ToString() == "ID")
            {
                int n = dataGridViewX1.CurrentRow.Index;
                str = new string[] { dataGridViewX1.CurrentRow.Cells[0].Value.ToString(), dataGridViewX1.CurrentRow.Cells[1].Value.ToString(), dataGridViewX1.CurrentRow.Cells[2].Value.ToString() };
                FrmSettingChangeAdmin sct = new FrmSettingChangeAdmin(str);
                sct.StartPosition = FormStartPosition.CenterParent;
                sct.ShowDialog();
            }
            buttonX6_Click(sender, e);
        }

        private void buttonX9_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.Columns[0].Name.ToString() == "ID")
            {
                string name = dataGridViewX1.CurrentRow.Cells[1].Value.ToString();
                SettingBLL stb = new SettingBLL();
                stb.Deleteadmin(MessageBox.Show("确定删除吗？", "系统警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK, name);
            }

            buttonX6_Click(sender, e);
        }

       
    }
}
