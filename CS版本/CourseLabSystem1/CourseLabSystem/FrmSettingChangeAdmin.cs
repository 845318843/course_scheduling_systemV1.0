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
    public partial class FrmSettingChangeAdmin : Form
    {
        public FrmSettingChangeAdmin()
        {
            InitializeComponent();
        }

        public FrmSettingChangeAdmin(string[] str)
        {
            InitializeComponent();
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = "******";
        }

        private void SettingChangeAdmin_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            string pwd = textBox3.Text;
            int id = Convert.ToInt32(textBox1.Text);
            SettingBLL stb = new SettingBLL();
            if (stb.ChangeAdmin(id, name, pwd))
            {
                MessageBox.Show("修改成功");
                this.Close();
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
