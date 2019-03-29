using BLL;
using Model;
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
    public delegate void UpdateEventHandler2();//外面写委托
    public partial class FrmAddLesson : Form
    {
        public event UpdateEventHandler2 updatelist2;
        string Course = null;
        int Course_ID=0;
        string Department = null;
        int Key = 0;
        public FrmAddLesson()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 参数构造函数
        /// </summary>
        /// <param name="str"></param>
        /// <param name="Id"></param>
        /// <param name="count"></param>
        public FrmAddLesson(string course,int course_id,string department,int key)
        {
            Course = course;
            Course_ID = course_id;
            Department = department;
            Key = key;
            InitializeComponent();
        }

        /// <summary>
        /// 加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAddClass_Load(object sender, EventArgs e)
        {
            tbCourse.Text = Course;
            if (Course_ID != 0)
            {
                tbCourse_Id.Text = Course_ID.ToString();
            }
            tbDepartment.Text = Department;
            this.KeyPreview = true;
        }
        AddCourse addCourse = new AddCourse();
        AddBLL addBll = new AddBLL();
        /// <summary>
        /// 确定添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbCourse_Id.Text))
            {
                MessageBox.Show("课程代码不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(tbCourse.Text))
            {
                MessageBox.Show("课程名称不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(tbDepartment.Text))
            {
                MessageBox.Show("院系不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                addCourse.Course_Id = Convert.ToInt32(tbCourse_Id.Text);
                addCourse.Course = tbCourse.Text;
                addCourse.Department = tbDepartment.Text;
                if (Key == 1)
                {
                    if (addBll.UpdateLesson(Course_ID, Course, Department, addCourse))
                    {
                        MessageBox.Show("修改成功！");
                        updatelist2();
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("课程代号有冲突！请重试填写");
                    }
                }
                else
                {
                    if (addBll.AddLesson(addCourse))
                    {
                        MessageBox.Show("插入成功！");
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        updatelist2();
                    }
                    else
                    {
                        MessageBox.Show("课程代号有冲突！请重试填写");
                    }
                }
            }
        }

        /// <summary>
        /// 取消添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAddLesson_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Enter:btOk_Click(sender, e);break;
                case Keys.Escape:btCancel_Click(sender, e);break;
            }
        }
    }
}
