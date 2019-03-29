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
using Model;
using EntityClass;
using WeifenLuo.WinFormsUI.Docking;

namespace CourseLabSystem
{
    public partial class FrmRecord : DockContent
    {
        DataTable dt;
        //创建BLL类的实例
        RecordBLL recordBLL = new RecordBLL();
        //创建CourseBuilding类的实例
        List<DataTable> list = new List<DataTable>();
        public FrmRecord()
        {

            InitializeComponent();
            dt = new DataTable();
            
        }
        CourseBuild courseBuildModel = new CourseBuild();

        /// <summary>
        /// 窗体加载的时候 加载系别，教师，年级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmRecord_Load(object sender, EventArgs e)
        {
            cmb_Department.Items.Clear();
            cmb_Teacher.Items.Clear();
            cmb_Garde.Items.Clear();
            //通过FormLoad()方法，返回三个表的集合
            //加载系别
            list = recordBLL.FormLoad();
            //遍历这个集合，分别加载到相应的combox中
            for (int i = 0; i < list[0].Rows.Count; i++)
            {
                cmb_Department.Items.Add(list[0].Rows[i]["Department"].ToString());
            }
            // cmb_Department.DataSource = dt;

            //加载年级

            // return recordBLL.FormLoad();
            for (int i = 0; i < list[1].Rows.Count; i++)
            {
                cmb_Garde.Items.Add(list[1].Rows[i]["Garde"].ToString());
            }
            //加载教师

            for (int i = 0; i < list[2].Rows.Count; i++)
            {
                cmb_Teacher.Items.Add(list[2].Rows[i]["TeacherName"].ToString());
            }
        }
        /// <summary>
        /// 当 系别 改变时 加载教室
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_Department_TextChanged(object sender, EventArgs e)
        {
            cmb_Room.Items.Clear();
            cmb_Room.Text = "";
            dt = recordBLL.Department_TextChanged(this.cmb_Department.Text.ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmb_Room.Items.Add(dt.Rows[i]["Name"].ToString());
            }
        }
        /// <summary>
        /// 当 年级 改变的时候 加载 班级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_Garde_TextChanged(object sender, EventArgs e)
        {
            cmb_Class.Items.Clear();
            cmb_Class.Text = "";

            dt = recordBLL.Garde_TextChanged(this.cmb_Garde.Text.ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmb_Class.Items.Add(dt.Rows[i]["Class"].ToString());
            }
        }
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Search_Click(object sender, EventArgs e)
        {
            
            //如果选择的是一，则根据院系和教室来查
            if (radioButton1.Checked == true)
            {
                if (cmb_Department.Text.ToString() == "" && cmb_Room.Text.ToString() == "")
                {
                    MessageBox.Show("请至少选择一种查询方式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (cmb_Department.Text.ToString() != "" && cmb_Room.Text.ToString() == "")
                {
                    courseBuildModel.Department = cmb_Department.Text.ToString();
                    dt = recordBLL.Search(1, courseBuildModel);
                    
                }
                else if(cmb_Department.Text.ToString() != "" && cmb_Room.Text.ToString() !="")
                {
                    courseBuildModel.Department = cmb_Department.Text.ToString();
                    courseBuildModel.Name = cmb_Room.Text.ToString();
                    dt = recordBLL.Search(2, courseBuildModel);
                }

            }
            //如果选择的是二，就按照教师来查
            else if (radioButton2.Checked == true)
            {
                if (cmb_Teacher.Text.ToString() != "")
                {
                    courseBuildModel.Teacher = cmb_Teacher.Text.ToString();
                    dt = recordBLL.Search(3, courseBuildModel);
                }
                else
                {
                    MessageBox.Show("请选择教师", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }
            //如果选择的是三，就按照年级和班级来查
            else if (radioButton3.Checked == true)
            {
                if (cmb_Garde.Text.ToString() == "" && cmb_Class.Text.ToString() == "")
                {
                    MessageBox.Show("请至少选择一种查询方式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (cmb_Garde.Text.ToString() != "" && cmb_Class.Text.ToString() == "")
                {
                    courseBuildModel.Garde = cmb_Garde.Text.ToString();
                    dt = recordBLL.Search(4, courseBuildModel);
                }
                else if(cmb_Garde.Text.ToString() != "" && cmb_Class.Text.ToString() != "")
                {
                    courseBuildModel.Garde = cmb_Garde.Text.ToString();
                    courseBuildModel.Class = cmb_Class.Text.ToString();
                   // MessageBox.Show(cmb_Garde.Text.ToString(), cmb_Class.Text.ToString());
                    dt = recordBLL.Search(5, courseBuildModel);
                }
            }
            else
            {
                MessageBox.Show("请至少选择一种查询方式", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dgv_Record.DataSource = dt;
            groupBox6.Text = " 有 " + dt.Rows.Count + " 条 记 录 ";
        }

        /// <summary>
        /// Excel导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_Excel_Click(object sender, EventArgs e)
        {
            if (this.dgv_Record.Rows.Count == 0)
            {
                MessageBox.Show("未能查到数据！！", "提示");
                return;
            }
            recordBLL.DtToExcel(dt);
        }
        /// <summary>
        /// 选择类型一
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmb_Teacher.Text))
            {
                cmb_Teacher.Text = "";
            }
            if (!string.IsNullOrWhiteSpace(cmb_Garde.Text))
            {
                cmb_Garde.Text = "";
            }
            if (!string.IsNullOrWhiteSpace(cmb_Class.Text))
            {
                cmb_Class.Text = "";
            }
        }
        /// <summary>
        /// 选择类型二
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cmb_Department.Text))
            {
                cmb_Department.Text = "";
            }
            if (!string.IsNullOrWhiteSpace(cmb_Room.Text))
            {
                cmb_Room.Text = "";
            }
            if (!string.IsNullOrWhiteSpace(cmb_Garde.Text))
            {
                cmb_Garde.Text = "";
            }
            if (!string.IsNullOrWhiteSpace(cmb_Class.Text))
            {
                cmb_Class.Text = "";
            }
        }
        /// <summary>
        /// 选择类型三
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton3_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrWhiteSpace(cmb_Department.Text))
            {
                cmb_Department.Text = "";
            }
            if (!string.IsNullOrWhiteSpace(cmb_Room.Text))
            {
                cmb_Room.Text = "";
            }
            if (!string.IsNullOrWhiteSpace(cmb_Teacher.Text))
            {
                cmb_Teacher.Text = "";
            }

        }
        /// <summary>
        /// 如果未选择 院系，就点击 教室 提示：先选择系别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_Room_Click(object sender, EventArgs e)
        {
            if(cmb_Department.Text=="")
            {
                MessageBox.Show("请先选择系别！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// 如果未选择年级，就点击班级 提示：先选择年级
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmb_Class_Click(object sender, EventArgs e)
        {
            if(cmb_Garde.Text=="")
            {
                MessageBox.Show("请先选择年级！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
