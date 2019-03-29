using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace CourseLabSystem
{
    public partial class FrmADD : DockContent
    {
        int Role;
        public FrmADD(int role)
        {
            Role = role;
            InitializeComponent();
        }

        private void bt_Lesson_Click(object sender, EventArgs e)
        {
            FrmAddLesson frmlesson = new FrmAddLesson();
            frmlesson.updatelist2 += new UpdateEventHandler2(updata);
            frmlesson.ShowDialog();
        }

        private void bt_Class_Click(object sender, EventArgs e)
        {
            FrmAddClass frmclass = new FrmAddClass();
            frmclass.updatelist1 += new UpdateEventHandler(updata);
            frmclass.ShowDialog();
            
        }
        AddBLL addbll = new AddBLL();
        DataTable dt = new DataTable();
        private void FrmADD_Load(object sender, EventArgs e)//窗体加载
        {
            if (Role == 2)
            {
                bt_Class.Enabled = false;
                bt_ReviceClass.Enabled = false;
                bt_DeleteClass.Enabled = false;
                bt_DeleteLesson.Enabled = false;
                bt_ReviceLesson.Enabled = false;
                bt_Lesson.Enabled = false;
            }
           dt= addbll.upData();
           dgv_Class.DataSource = dt;
           groupBox2.Text = "现 有 " + dt.Rows.Count + " 班 级";
           dgv_Class.RowTemplate.Height = 30;
           dgv_Class.Columns[0].Width = 150;
           dgv_Class.Columns[1].Width = 150;
           dgv_Class.Columns[2].Width = 150;
           dgv_Class.Columns[3].Width = 150;

           dt= addbll.upDataL();
           dgv_Lesson.DataSource = dt;
           groupBox3.Text = "现 有 " + dt.Rows.Count + "  课程";
           dgv_Lesson.RowTemplate.Height = 30;
           dgv_Lesson.Columns[0].Width = 150;
           dgv_Lesson.Columns[1].Width = 150;
           dgv_Lesson.Columns[2].Width = 150;
           
            this.KeyPreview = true;
        }

        private void FrmADD_KeyDown(object sender, KeyEventArgs e)//绑定键盘
        {
            switch (e.KeyCode)
            { 
                case Keys.F1:
                    bt_Class_Click(sender, e);
                    break;
                case Keys.F2:
                    bt_Lesson_Click(sender, e);
                    break;
            }
        }

        private void bt_ReviceClass_Click(object sender, EventArgs e)
        {
            
            int rows = dgv_Class.CurrentRow.Index;            //得到行
            int column = dgv_Class.CurrentCell.ColumnIndex+1;     //得到列
            
            string Grade = dgv_Class.Rows[rows].Cells[2].Value.ToString();

            string ClassID = dgv_Class.Rows[rows].Cells[1].Value.ToString();
            string Class = dgv_Class.Rows[rows].Cells[0].Value.ToString();
            string Department = dgv_Class.Rows[rows].Cells[3].Value.ToString();
            
            int key=1;
            FrmAddClass revice = new FrmAddClass(Grade,ClassID,Class,Department,key);
            
            revice.updatelist1 += new UpdateEventHandler(updata);  //调用委托
            revice.ShowDialog();
            //MessageBox.Show(Department);
            //MessageBox.Show(dgv_Class.CurrentRow.Index.ToString());   //选中行的索引
            //MessageBox.Show(dgv_Class.CurrentCell.Value.ToString());  //选中单元格的值
        }
        

        private void bt_DeleteClass_Click(object sender, EventArgs e)
        {
            int rows = dgv_Class.CurrentRow.Index;
            int ClassID = Convert.ToInt32(dgv_Class.Rows[rows].Cells[1].Value);
            if ((MessageBox.Show("是否删除", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK))
            {
                if (addbll.DeleteClass(ClassID))
                {
                    MessageBox.Show("删除成功");
                    updata();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
            else
            {
                return;
            }
        }

        private void bt_ReviceLesson_Click(object sender, EventArgs e)
        {
            int rows = dgv_Lesson.CurrentRow.Index;            //得到行
            int column = dgv_Lesson.CurrentCell.ColumnIndex + 1;     //得到列
            string Course = dgv_Lesson.Rows[rows].Cells[0].Value.ToString();
            int Course_Id = Convert.ToInt32(dgv_Lesson.Rows[rows].Cells[1].Value);
            string Department = dgv_Lesson.Rows[rows].Cells[2].Value.ToString();
            int key = 1;
            FrmAddLesson revice = new FrmAddLesson(Course,Course_Id,Department,key);
            revice.updatelist2 += new UpdateEventHandler2(updata);
            revice.ShowDialog();
        }

        private void bt_DeleteLesson_Click(object sender, EventArgs e)
        {
            int rows = dgv_Lesson.CurrentRow.Index;
            int Course_Id = Convert.ToInt32(dgv_Lesson.Rows[rows].Cells[1].Value);
            if ((MessageBox.Show("是否删除", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK))
            {
                if (addbll.DeleteLesson(Course_Id))
                {
                    MessageBox.Show("删除成功");
                    updata();
                }
                else
                {
                    MessageBox.Show("删除失败");
                }
            }
            else
            {
                return;
            }
        }
        public void updata()
        {
            dt = addbll.upData();
            dgv_Class.DataSource = dt;
            dt = addbll.upDataL();
            dgv_Lesson.DataSource = dt;
        }
    }
}
