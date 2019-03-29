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
using Model;
using EntityClass;
namespace CourseLabSystem
{  
    public partial class FrmCourseBuildingAdd : Form
    {
        public FrmCourseBuildingAdd(FrmCourseBuilding FbC)
        {
            building = FbC;
            InitializeComponent();
        }
        string GradeName;//年级名字
        string ClassName;//班级的名字
        int WeekDayNum;  //周几索引
        int sectionNum;   //节次索引
        int GardeNumberNow;//当前选中年级的索引
        int ClassNumberNow;//当前选中班级的索引
        string WeekDay;  //周几
        string section;  //节次
        string Some;//要填入表格的信息
        string whole;//要添加的全部信息
        string oldwhole;//选中的全部信息
        public FrmCourseBuilding building;
        CourseBuildingBLL bll = new CourseBuildingBLL();
        public static List<string> CourseSum = new List<string>();   //数据库中的原有数据
        public static List<string> CourseAdd = new List<string>();   //系统要添加的数据
        private void FrmCourseBuildingAdd_Load(object sender, EventArgs e)
        {
            Building.Text=getbuilding1();
            this.KeyPreview = true;
            try
            {
                GetBuiding();
            }
            catch(Exception)
            {
                return;
            }
        }
        /// <summary>
        /// 获取教学楼id
        /// </summary>
        void GetBuiding()
        {
            DataTable Class = new DataTable();
            CourseBuildingBLL BLL = new CourseBuildingBLL();
            Class = BLL.GETSome();
            Building_id.DataSource = Class;
            Building_id.DisplayMember = "Building_Id";
            treeLoad(Teacher); 
        }
        /// <summary>
        /// 初始化树形导航 将院系课程和老师显示出来
        /// </summary>
        /// <param name="TV"></param>
        public static void treeLoad(TreeView TV)
        {
            DataTable ds;
            CourseBuildingBLL bll = new CourseBuildingBLL();
            ds = bll.GetNode1();
            foreach (DataRow dr in ds.Rows)
            {
                TreeNode newNode = new TreeNode(dr[0].ToString(),0,1);
                TV.Nodes.Add(newNode);
                DataTable dy;
                string name1=dr[0].ToString();
                dy = bll.GetNode2(name1);
                foreach (DataRow du in dy.Rows)
                {
                    TreeNode Node = new TreeNode(du[0].ToString(), 0, 1);
                    newNode.Nodes.Add(Node); 
                }
            }
        }
        /// <summary>
        /// 获取院系
        /// </summary>
        /// <returns></returns>
        public string getbuilding1()
        {
            CourseBuildingBLL bll = new CourseBuildingBLL();
            return bll.getbuilding1(building.Class.Text);
        }
        /// <summary>
        /// 选定 树形导航来填充信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Teacher_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CourseBuildingBLL bll = new CourseBuildingBLL();
            DataTable dt = new DataTable();
            string Major;
            TreeNode SelectNode = Teacher.SelectedNode;   //获取当前选中的节点
            if (SelectNode != null)
            {
                TreeNode ParentNode = SelectNode.Parent;
                if (ParentNode != null)
                {
                    Course.Text = "";
                    dt = bll.GetCourse1(ParentNode.Text);
                    this.Course.DataSource = dt;
                    this.Course.DisplayMember = "Course";
                    this.Course.ValueMember = "Course_Id";
                    Major = bll.GetMajor(SelectNode.Text);
                    this.Teacher1.Text = SelectNode.Text;
                    this.Major1.Text = Major;
                }
                
            }
        }
        /// <summary>
        /// 获得老师专业
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string GetMajor(string name)
        {
            CourseBuildingBLL bll = new CourseBuildingBLL();
            return bll.GetMajor(name);
        }
        /// <summary>
        /// 系楼改变的时候 教室改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Building_id_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                string Class = Building_id.Text;
                CourseBuildingBLL bll = new CourseBuildingBLL();
                dt=bll.SelectSome(Class);
                //dt = bll.SelectSome(Class);
                ClassRoom.DataSource = dt;
                ClassRoom.DisplayMember = "Name";
                ClassRoom.ValueMember = "Classroom_Id";
            }
           catch(Exception)
            {
               return;
           }
          
        }

        private void Building_id_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 初始化基础信息
        /// </summary>
        void Init()
        {
            Basic_Information xx = (Basic_Information)building.Garde.SelectedItem;
             GradeName = xx.Garde;   
             ClassName = building.Class.Text;  
             WeekDayNum = building.dgv_课表.CurrentCell.ColumnIndex;  
             sectionNum = building.dgv_课表.CurrentCell.RowIndex;   
             GardeNumberNow = building.Garde.SelectedIndex;
             ClassNumberNow = building.Class.SelectedIndex;
             WeekDay = building.dgv_课表.Columns[WeekDayNum].HeaderText;  
             section = building.dgv_课表.Rows[sectionNum].Cells[0].Value.ToString();
             Some = Building.Text + "|" + Building_id.Text + "|" + ClassRoom.Text + "|" + Course.Text + "|" + Teacher1.Text + "|" + Week.Text;
             whole = Some + "|" + GradeName + "|" + ClassName + "|" + WeekDay + "|" + section + "|" + building.year.Text + "|" + building.term.Text;
             oldwhole = building.Dt[GardeNumberNow, ClassNumberNow].Rows[sectionNum][WeekDay] + "|" + GradeName + "|" + ClassName + "|" + WeekDay + "|" + section + "|" + building.year.Text + "|" + building.term.Text;
        }
        /// <summary>
        /// 添加的空格无数据
        /// </summary>
        void NotNull()
        {
            int i, P=0;
             string information = "";
                    for (i = 0; i < CourseSum.Count; i++)
                    {
                        string[] name = CourseSum[i].Split('|');
                        if (name[8] == WeekDay && section == name[9] && name[10] == building.year.Text && name[11] == building.term.Text)
                        {
                            information += "&" + CourseSum[i];
                        }
                    }
                    for ( i = 0; i < CourseSum.Count; i++)
                    {
                        if (CourseSum[i]==oldwhole)
                        {
                            P = 1;
                            if (MessageBox.Show("是否保存", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                            {
                                return;
                            }
                            else
                            {
                                if (Look1(GradeName, ClassName, WeekDayNum, sectionNum))
                                {   
                                    bll.delete(FrmCourseBuildingAdd.CourseSum[i]);
                                    bll.insert(Building_id.Text, Building.Text, GradeName, ClassRoom.Text, Week.Text, WeekDay, section, Teacher1.Text, Course.Text, ClassName, building.year.Text, building.term.Text);
                                    building.dgv_课表.CurrentCell.Value = Some;
                                   // break;
                                }
                            }
                        }
                    }
                    if (P == 0)
                    {
                        CourseAdd.Remove(building.dgv_课表.CurrentCell.Value.ToString()+"|" + GradeName + "|" + ClassName + "|" + WeekDay + "|" + section + "|" + building.year.Text + "|" + building.term.Text);
                        CourseAdd.Add(whole);
                        building.dgv_课表.CurrentCell.Value = Some;
                    }
                    this.Close();
        }
        /// <summary>
        /// 排课的逻辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX1_Click(object sender, EventArgs e)
        {
            Init();
            if (Week.Text =="" || Building.Text == "" || Major1.Text == "" || Teacher1.Text==""||building.year.Text==""||building.term.Text=="")
            {

                MessageBox.Show("信息不能为空", "排课失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (building.Dt[GardeNumberNow, ClassNumberNow].Rows[sectionNum][WeekDay].ToString() == "")
                {
                    Look1(GradeName, ClassName, WeekDayNum, sectionNum);
                }

                else
                {
                    NotNull();
                }
            }
        }
        /// <summary>
        /// 判断添加数据库有的
        /// </summary>
        bool Look1(string GradeName, string ClassName, int WeekDayNum, int sectionNum)
        {
            bool Pan = false;
            try
            {
                int i, k, x;
                string information = "";
                int Row = building.dgv_课表.CurrentCell.RowIndex;//当前课表的横坐标位置
                int Colunm = building.dgv_课表.CurrentCell.ColumnIndex;//当前课表的纵坐标位置
                 WeekDay = building.dgv_课表.Columns[WeekDayNum].HeaderText;  //周几
                 section = building.dgv_课表.Rows[sectionNum].Cells[0].Value.ToString();  //节次
                 GardeNumberNow = building.Garde.SelectedIndex;//当前选中年级的索引
                 ClassNumberNow = building.Class.SelectedIndex;//当前选中班级的索引
                string some=Building.Text + "|" + Building_id.Text + "|" + ClassRoom.Text + "|" + Course.Text + "|" + Teacher1.Text + "|" + Week.Text;//添加到课表的数据
                string whole1 = Building.Text + "|" + Building_id.Text + "|" + ClassRoom.Text + "|" + Course.Text + "|" + Teacher1.Text + "|" + Week.Text + "|" + GradeName + "|" + ClassName + "|" + WeekDay + "|" + section + "|" + building.year.Text + "|" + building.term.Text;//添加到数据库的数据
                for (i = 0; i < CourseSum.Count; i++)
                {
                    string[] name = CourseSum[i].Split('|');
                    if (name[8] == WeekDay && section == name[9] && name[10] == building.year.Text && name[11] == building.term.Text)
                    {
                        information += "&" + CourseSum[i];
                    }
                }
                //没有其他信息 直接填入
                if (information == "")
                {
                    building.dgv_课表.CurrentCell.Value = some;
                    CourseAdd.Add(whole1);
                    Pan = true;
                    CourseBuildingBLL.number++;
                }
                else//检测冲突    如果有报错  没有则赋值
                {
                    string[] arr = information.Split('&');  //其他表的位置信息分段
                    string[] time = Week.Text.Split(',');   //填入信息的周次分段
                    for (k = 1; k < arr.Length; k++)
                    {
                        string[] OldTime = arr[k].Split('|');   //其他表的每个周次分段 OldTime[5]   
                        if ((OldTime[5] == Week.Text) && arr[k].Contains(Building_id.Text + "|" + ClassRoom.Text) && arr[k].Contains(Teacher1.Text))
                        {
                            if (MessageBox.Show("教室和教师和学年日期同时冲突，是否继续添加修改为公开课", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                building.dgv_课表.CurrentCell.Value = some;
                                CourseAdd.Add(whole1);
                                CourseBuildingBLL.number++;
                                Pan = true;
                                break;
                            }
                        }
                        for (x = 0; x < time.Length; x++)
                        {
                            if (OldTime[5].Contains(time[x]) && arr[k].Contains(Building_id.Text + "|" + ClassRoom.Text) || OldTime[5].Contains(time[x]) && arr[k].Contains(Teacher1.Text))   //时间和教室       //时间老师
                            {
                                MessageBox.Show("教室或者教师或者学年日期冲突", "排课失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Pan = false;
                                break;
                            }
                        }
                        if (x < time.Length)
                        {
                            break;
                        }
                    }
                    if (k == arr.Length)
                    {
                        building.dgv_课表.CurrentCell.Value = some;
                        CourseAdd.Add(whole1);
                        Pan = true;
                        CourseBuildingBLL.number++;
                    }
                }

                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("请添加数据");
                this.Close();
            }
            return Pan;
        }
        private void FrmCourseBuildingAdd_KeyDown(object sender, KeyEventArgs e)
        {
        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Course_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
