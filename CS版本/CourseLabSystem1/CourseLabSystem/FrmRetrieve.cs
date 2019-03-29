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

namespace CourseLabSystem
{
    public partial class FrmRetrieve : Form
    {
        private string LoginId;
        public FrmRetrieve(string loginId)
        {
            InitializeComponent();
            this.LoginId = loginId;
        }
        UsersModel user = new UsersModel();
        LoginBLL loginBll = new LoginBLL();

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRetrieve_Load(object sender, EventArgs e)
        {
            if(LoginId!="")
            {
                tb_LoginId.Text = LoginId;
            }
            this.KeyPreview = true;
        }
        /// <summary>
        /// 确定 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Confirm_Click(object sender, EventArgs e)
        {
            if(tb_Confirm.Text=="")
            {
                MessageBox.Show("请确认密码！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if(tb_Confirm.Text!=tb_Modify.Text)
            {
                MessageBox.Show("两次输入的密码不一致，请重新输入！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            user.id = Convert.ToInt32(tb_Id.Text);
            user.UsersName = tb_LoginId.Text;
            user.PassWord = loginBll.GetMd5Hash(tb_Modify.Text);
            if(loginBll.BackPwd(user))
            {
                MessageBox.Show("密码找回成功,前往去登录!!", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("找回失败!!");
            }
        }
        /// <summary>
        /// 取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
        /// <summary>
        /// 绑定键盘事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRetrieve_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                bt_Confirm_Click(sender, e);
            else if (e.KeyCode == Keys.Cancel)
                bt_Cancel_Click(sender, e);
        }
    }
}
