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
    public delegate void UpdateEventHandler();   //外面写委托
    public partial class FrmAddClass :Form
    {
        public FrmAddClass()
        {
            InitializeComponent();
        }
        
        string Class=null;
        string ClassID=null;
        string Grade=null;
        string Department=null;
        int Key=0;
        //static int Up=0 ; 
        /// <summary>
        /// 含参构造函数
        /// </summary>
        /// <param name="Classs"></param>
        /// <param name="classID"></param>
        /// <param name="grade"></param>
        /// <param name="department"></param>
        public FrmAddClass(string grade,string classID,string Classs,string department,int key)
        {
            Key = key;
            Class = Classs;
            ClassID = classID;
            Grade = grade;
            Department = department;
            InitializeComponent();
        }

        /// <summary>
        /// 加载窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            tbGrade.Text = Grade;
            tbDepartment.Text = Department;
            tbClassId.Text = ClassID;
            tbClass.Text = Class;
            this.KeyPreview = true;
        }
        AddBLL addBll = new AddBLL();
        
        public event UpdateEventHandler updatelist1;    //里面写事件
        /// <summary>
        /// 确定添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btOk_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbGrade.Text))
            {
                MessageBox.Show("年级不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(tbClass.Text))
            {
                MessageBox.Show("班级不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrWhiteSpace(tbClassId.Text))
            {
                MessageBox.Show("班级代号不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(string.IsNullOrWhiteSpace(tbDepartment.Text))
            {
                MessageBox.Show("院系不能为空！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                Basic_Information basic = new Basic_Information();
                basic.Garde = tbGrade.Text.ToString();
                basic.ClassId = Convert.ToInt32(tbClassId.Text.ToString());
                basic.Class = tbClass.Text.ToString();
                basic.Department = tbDepartment.Text.ToString();
                if (Key == 1)
                {
                    string oldGarde = Grade;
                    int oldClassId = Convert.ToInt32(ClassID);
                    string oldClass = Class;
                    string oldDepartment = Department;
                    if (addBll.UpdateClass(oldGarde, oldClassId, oldClass, oldDepartment, basic))
                    {
                        MessageBox.Show("修改成功");
                        updatelist1();
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("修改过程课程代号冲突！请重试");
                    }

                }
                else
                {
                    if (addBll.AddClass(basic))
                    {
                        MessageBox.Show("插入成功！");
                        updatelist1();
                        DialogResult = System.Windows.Forms.DialogResult.OK;
                        
                    }
                    else
                    {
                        MessageBox.Show("插入过程课程代号冲突！请重试");
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
        private void FrmAddClass_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Enter: btOk_Click(sender, e);break;
                case Keys.Escape:btCancel_Click(sender, e);break;
            }
        }
    }
}
