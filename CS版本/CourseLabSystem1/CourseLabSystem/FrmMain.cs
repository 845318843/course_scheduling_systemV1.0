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
    public partial class FrmMain : Form
    {
        int Role;
        public FrmMain(int role)
        {
            Role = role;
            InitializeComponent();
        }
        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //this.WindowState = FormWindowState.Normal;
            //this.StartPosition = FormStartPosition.CenterScreen;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            FrmADD add = new FrmADD(Role);
            if (checkDockContent(dockPanel2, bt_Add.Text))
                add.Show(this.dockPanel2, DockState.Document);
        }

        /// <summary>
        /// 实验室管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Lab_Click(object sender, EventArgs e)
        {
            FrmLab lab = new FrmLab(Role);
            if (checkDockContent(dockPanel2, bt_Lab.Text))
                lab.Show(this.dockPanel2, DockState.Document);
        }

        /// <summary>
        /// 实验室排课
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_CourseBuild_Click(object sender, EventArgs e)
        {
            FrmCourseBuilding courseBuild = new FrmCourseBuilding(Role);
            if (checkDockContent(dockPanel2, bt_CourseBuild.Text))
                courseBuild.Show(this.dockPanel2, DockState.Document);
        }

        /// <summary>
        /// 排课记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Record_Click(object sender, EventArgs e)
        {
            FrmRecord record = new FrmRecord();
            if (checkDockContent(dockPanel2, bt_Record.Text))
                record.Show(this.dockPanel2, DockState.Document);
        }

        /// <summary>
        /// 学生申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Apply_Click(object sender, EventArgs e)
        {
            FrmApplysh apply = new FrmApplysh();
            if (checkDockContent(dockPanel2, bt_Apply.Text))
                apply.Show(this.dockPanel2, DockState.Document);
        }

        /// <summary>
        /// 系统设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Setting_Click(object sender, EventArgs e)
        {

            FrmSetting setting = new FrmSetting(Role);
            if (checkDockContent(dockPanel2, bt_Setting.Text))
                setting.Show(this.dockPanel2, DockState.Document);
        }

        /// <summary>
        /// 注销登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();
            this.Visible = false;
            if (login.ShowDialog() == DialogResult.OK)
            {
                this.Close();
            }
        }

        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Exit_Click_1(object sender, EventArgs e)
        {

            if (MessageBox.Show("确认退出系统吗？？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }


        /// <summary>
        ///  检查DockPanel中是否存在窗体dockcontent
        /// </summary>
        /// <param name="dp">DockPanel容器</param>
        /// <param name="btnDc">管理类型</param>
        /// <returns>返回bool类型数据</returns>     
        private bool checkDockContent(DockPanel dp, string btnDc)
        {
            bool Bool = true;
            foreach (DockContent document in dp.Contents)
            {
                if (document.Text == btnDc)
                {
                    document.Activate();
                    Bool = false;
                    break;
                }
            }
            return Bool;
        }

        /// <summary>
        /// 退出事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult r = MessageBox.Show("是否确定退出？", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (r != DialogResult.OK)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
            
        }    
    }
}
