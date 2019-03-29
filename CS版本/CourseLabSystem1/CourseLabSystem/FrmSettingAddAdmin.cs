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

namespace CourseLabSystem
{
    public partial class FrmSettingAddAdmin : Form
    {
        public FrmSettingAddAdmin()
        {
            InitializeComponent();
        }

        private void SettingAddAdmin_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string name = textBox2.Text;
            string pwd = textBox3.Text;
            string role = textBox4.Text;
            if (Convert.ToInt32(textBox4.Text) !=1  && Convert.ToInt32(textBox4.Text) !=2 )
            {
                MessageBox.Show("权限请输入1或2");
                return;
            }
            SettingBLL stb = new SettingBLL();
            if (stb.Addadmin(id, name, pwd,role))
            {
                MessageBox.Show("添加成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("添加失败(ID或用户名冲突)");
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
