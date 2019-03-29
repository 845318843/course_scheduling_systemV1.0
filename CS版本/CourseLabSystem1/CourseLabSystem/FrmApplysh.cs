using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using BLL;
using EntityClass;
using WeifenLuo.WinFormsUI.Docking;

namespace CourseLabSystem
{
    public partial class FrmApplysh : DockContent
    {
        public FrmApplysh()
        {
            InitializeComponent();
        }
        ApplyBLL bll = new ApplyBLL();
        DataTable dt = new DataTable();
        CourseBuild model = new CourseBuild(); 
        /// <summary>
        /// 窗体运行时主动搜出所有的教学楼，在BuildingId里选出来
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            int key = 1;                                       //调用哪条sq1语句
            SqlDataReader sr1 = bll.Building_IdShow(key);      //得到数据流
            while (sr1.Read())
            {

                cmb_BuildingId.Items.Add(sr1.GetDouble(0).ToString());//显示教学楼
                
            }
            sr1.Close();
            for (int i = 1; i < 22; i++)
            {
                cmb_Week.Items.Add(i);
            }
        }
        /// <summary>
        /// 通过BuildingId中的教学楼选出以后各项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxEx1_TextChanged(object sender, EventArgs e)
        {
            cmb_Classroom.Items.Clear();                         //当更换教学楼号数时，item、text clear  
            cmb_Classroom.Text = "";
            int key = 2;                                          //sql语句选择第二句
            bll.srID2 = cmb_BuildingId.SelectedItem.ToString();
            SqlDataReader sr1 = bll.Building_IdShow(key);//找出来
            while (sr1.Read())
            {
                cmb_Classroom.Items.Add(sr1.GetString(0));//显示教室名称
            }
            sr1.Close();
        }
        /// <summary>
        /// 寻找这天这教师的课程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_seach_Click(object sender, EventArgs e)
        {
            //string sqlse = "SELECT Section FROM CourseBuild WHERE Building_Id='" + this.cmb_BuildingId.SelectedItem + "' AND Name='" + this.cmb_Classroom.SelectedItem + "' AND Week LIKE '%" + this.cmb_Week.SelectedItem + "%' AND Weekday='" + this.cmb_WeekDay.SelectedItem + "'";
            if (string.IsNullOrWhiteSpace(cmb_BuildingId.Text)||string.IsNullOrWhiteSpace(cmb_Classroom.Text)||string.IsNullOrWhiteSpace(cmb_Week.Text)||string.IsNullOrWhiteSpace(cmb_WeekDay.Text))
            {
                MessageBox.Show("存在空项");
                return;
            }
            //string B_Id = cmb_BuildingId.SelectedItem.ToString();
            //string CM = cmb_Classroom.SelectedItem.ToString();
            //string WK = cmb_Week.SelectedItem.ToString();
            //string WY = cmb_WeekDay.SelectedItem.ToString();
            model.Building_Id = cmb_BuildingId.SelectedItem.ToString();
            model.Name = cmb_Classroom.SelectedItem.ToString();
            model.Week = cmb_Week.SelectedItem.ToString();
            model.Weekday = cmb_WeekDay.SelectedItem.ToString();
            int key = 1;
            bll.ControlValue(model);                             //传递控件的值
            dt = bll.dtShow(key);                                     //得到表
            this.dgv_seach.DataSource = dt;                        //显示表
            dgv_seach.RowTemplate.Height = 30;
            dgv_seach.Columns[0].Width = 150;
            dgv_seach.Columns[1].Width = 150;
            dgv_seach.Columns[2].Width = 150;
            dgv_seach.Columns[3].Width = 150;
            dgv_seach.Columns[4].Width = 150;
        }
        /// <summary>
        /// 去申请教室的表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmb_BuildingId.Text) || string.IsNullOrWhiteSpace(cmb_Classroom.Text) || string.IsNullOrWhiteSpace(cmb_Week.Text) || string.IsNullOrWhiteSpace(cmb_WeekDay.Text))
            {
                MessageBox.Show("存在空项");
                return;
            }
            FrmApply apply = new FrmApply(cmb_BuildingId.Text,cmb_Classroom.Text,cmb_Week.Text,cmb_WeekDay.Text);
            apply.ShowDialog();                        //显示新建窗体
            bll.ControlValue(model);
        }

        private void FrmApplysh_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
                this.bt_seach_Click(sender, e);
        }
    }
}
