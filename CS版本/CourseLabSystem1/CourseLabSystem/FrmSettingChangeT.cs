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
    public partial class FrmSettingChangeT : Form
    {
        public FrmSettingChangeT()
        {
            InitializeComponent();
        }

        public FrmSettingChangeT(string[] str)
        {
            InitializeComponent();
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            textBox4.Text = str[3];
        }

        private void SettingChangeT_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            string name = textBox2.Text;
            string department = textBox3.Text;
            string major = textBox4.Text;
            int id = Convert.ToInt32(textBox1.Text);
            SettingBLL stb = new SettingBLL();
            if (stb.ChangeTea(id, name, department, major))
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
