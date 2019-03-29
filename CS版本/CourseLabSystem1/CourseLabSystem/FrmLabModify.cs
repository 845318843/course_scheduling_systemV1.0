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
    public partial class FrmLabModify : Form
    {
        Classroom Model = new Classroom();
        LabBLL labbll = new LabBLL();
        public FrmLabModify(string []str)
        {
            InitializeComponent();
             textBox1_building.Text= str[0].ToString();           
            textBox2_name.Text= str[1].ToString();
            textBox3_classroomId.Text = str[2].ToString();
            textBox4_people.Text = str[3].ToString();
            textBox5_manager.Text = str[4].ToString();
            richTextBox1.Text = str[5].ToString();

        }

        private void button1_OK_Click(object sender, EventArgs e)
        {
            Model._Building_Id = textBox1_building.Text.ToString();
            Model._Classroom_Id = textBox3_classroomId.Text.ToString();
            Model._Name = textBox2_name.Text.ToString();
            Model._People = Convert.ToInt32(textBox4_people.Text.ToString());
            Model._manager = textBox5_manager.Text.ToString();
            Model._Descride = richTextBox1.Text.ToString();
            if (!string.IsNullOrEmpty(Model._Building_Id) && !string.IsNullOrEmpty(Model._Classroom_Id) && !string.IsNullOrEmpty(Model._Name) && !string.IsNullOrEmpty(Model._People.ToString()) && !string.IsNullOrEmpty(Model._manager) && !string.IsNullOrEmpty(Model._Descride))
            {
                labbll.modify(Model._Building_Id, Model._Name, Model._Classroom_Id, Model._People.ToString(), Model._manager, Model._Descride);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请把想要修改的数据填满！", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }

        }

        private void FrmLabModify_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter: button1_OK_Click(sender, e); break;
                case Keys.Escape:button2_Cancel_Click(sender, e);break;
            }
        }

        private void FrmLabModify_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
        }

        private void button2_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
