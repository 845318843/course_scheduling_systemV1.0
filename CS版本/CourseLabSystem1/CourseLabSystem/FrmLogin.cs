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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        //创建LoginBLL的实例
        LoginBLL loginBll = new LoginBLL();

        /// <summary>
        /// 窗体加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // DialogResult = DialogResult.OK;
            this.KeyPreview = true;
        }

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Login_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_user.Text.ToString()) || string.IsNullOrWhiteSpace(tb_pwd.Text.ToString()))
            {
                MessageBox.Show("存在空白项！");
                return;
            }

            string user = tb_user.Text.ToString();
            string pwd = tb_pwd.Text.ToString();
            int role;
            if (loginBll.EXiseUser(user))//用户存在
            {
                if (loginBll.VerifyMd5Hash(pwd, loginBll.UserPwd(user)))
                {

                    role=loginBll.Role(user);
                    string st = "您当前的管理权限为" + role.ToString();
                    MessageBox.Show(st);
                    FrmMain main = new FrmMain(role);
                    this.Visible = false;
                    if(main.ShowDialog()==DialogResult.OK)
                    {
                        this.Close();
                    }

                }
                else
                {
                    MessageBox.Show("密码错误，请重新输入！");
                    tb_pwd.Text = "";
                    return;
                }
            }
            else
            {
                MessageBox.Show("用户名不存在，请重新输入！");
                tb_pwd.Text = "";
                tb_user.Text = "";
                return;
            }
        }
        /// <summary>
        /// 找回密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_back_Click(object sender, EventArgs e)
        {
            FrmRetrieve retrieve = new FrmRetrieve(this.tb_user.Text);
            if(retrieve.ShowDialog()==DialogResult.OK)
            {
                if(tb_user.Text!="")
                {
                    this.tb_pwd.Focus();
                }
                else
                {
                    tb_user.Focus();
                }
            }
        }
        /// <summary>
        /// 绑定键盘事件 快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                bt_Login_Click_1(sender,e);
            }

        }
    }
}
