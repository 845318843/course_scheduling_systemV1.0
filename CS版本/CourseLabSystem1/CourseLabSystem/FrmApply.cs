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
    public partial class FrmApply : Form
    {
        string B_ID;      //教学楼
        string CM;        //教室
        string WK;        //几周
        string WY;        //周几
        //string sections = null;
        //string[] Num = null;
        ApplyBLL bll = new ApplyBLL();
        CourseBuild model = new CourseBuild();
        public FrmApply(string b_id,string cm,string wk,string wy)
        {
            B_ID =b_id;
            CM = cm;
            WK = wk;
            WY = wy;
            InitializeComponent();
        }

        private void FrmApply_Load(object sender, EventArgs e)
        {
            tb_Building_Id.Text = B_ID;     //textbox显示
            tb_Classroom.Text = CM;
            tb_Week.Text = WK;
            tb_WeekDay.Text = WY;
            
            //this.WindowState = FormWindowState.Maximized;//全屏显示
        }

        private void bt_true_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_ActivityNm.Text) || string.IsNullOrWhiteSpace(tb_ApplyMm.Text) || string.IsNullOrWhiteSpace(tb_ApplyPe.Text) || string.IsNullOrWhiteSpace(tb_Department.Text) || string.IsNullOrWhiteSpace(tb_Teacher.Text) || string.IsNullOrWhiteSpace(cmb_Top.Text) || string.IsNullOrWhiteSpace(cmb_Down.Text) || string.IsNullOrWhiteSpace(rtb_reason.Text) || string.IsNullOrWhiteSpace(tb_Class.Text) || string.IsNullOrWhiteSpace(tb_Garde.Text))
            {
                MessageBox.Show("存在空项");
                return;
            }
            if (Convert.ToInt32(cmb_Top.Text) > Convert.ToInt32(cmb_Down.Text))          //如果选择节次前大于后
            {
                MessageBox.Show("节次选择不合理");
                return;
            }
            model.Building_Id = B_ID;
            model.Name = CM;
            model.Week = WK;
            model.Weekday = WY;
            if (!bll.SelectSection(cmb_Top.Text,cmb_Down.Text,model))     //搜出节次，选择节次区间内包含已有课程
            {
                MessageBox.Show("存在课程冲突,请重新选择节次");
                return;
            }
            string sections=null;                                         //得到节次
            for (int i = Convert.ToInt32(cmb_Top.Text); i < Convert.ToInt32(cmb_Down.Text); i++)
            {
                sections = sections+i+",";
            }
            
            sections += Convert.ToInt32(cmb_Down.Text);
            int DateYear = DateTime.Now.Year;  //得到本年
            int DateMonth = DateTime.Now.Month;//得到本月
            if (DateMonth >= 3 && DateMonth <= 8)    //如果在下学期
            {
                model.Term = "2";                         //学期
                int LastYear = DateYear - 1;
                model.Year = LastYear + "-" + DateYear;   //2016-2017
            }
            else
            {
                model.Term = "1";                         //学期
                int NextYear = DateYear + 1;              
                model.Year = DateYear + "-" + NextYear;   //2017-2018
            }
            //MessageBox.Show(model.Year);
            model.Course = tb_ActivityNm.Text;            //课程名称为活动名称
            model.Garde = tb_Garde.Text;                  //年级
            model.Department = tb_Department.Text;        //院系
            model.Class = tb_Class.Text;                  //申请人为哪个班
            model.Teacher = tb_Teacher.Text;              //签名老师
            model.reason = rtb_reason.Text;               //原因
            model.Section = sections;                     //节次
            //插入
            if (bll.InsertApply(model))                   
            {
                bll.ToWord(model, tb_ApplyMm.Text, tb_ApplyPe.Text);
                MessageBox.Show("申请成功");
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show("申请失败");
            }
            

        }

        private void FrmApply_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.bt_true_Click(sender, e);
        }
        
    }
}
