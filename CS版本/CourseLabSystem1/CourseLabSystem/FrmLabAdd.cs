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

namespace CourseLabSystem
{
    public partial class FrmLabAdd : Form
    {
        public FrmLabAdd()
        {
            InitializeComponent();
        }
        LabBLL labbll = new LabBLL();
        private void button1_OK_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBox1_building.Text)&& !string.IsNullOrEmpty(textBox2_name.Text) && !string.IsNullOrEmpty(textBox3_classroomId.Text) && !string.IsNullOrEmpty(textBox4_people.Text) && !string.IsNullOrEmpty(textBox1_manager.Text) && !string.IsNullOrEmpty(richTextBox1.Text))
            {
                labbll.add(textBox1_building.Text.ToString(), textBox2_name.Text.ToString(), textBox3_classroomId.Text.ToString(), textBox4_people.Text.ToString(), textBox1_manager.Text.ToString(), richTextBox1.Text.ToString());
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请完善没有填入的信息！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void FrmLabAdd_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Enter:button1_OK_Click(sender, e);break;
                case Keys.Escape:button2_cancel_Click(sender, e);break;
            }
        }

        private void FrmLabAdd_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }
    }
}
