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
using WeifenLuo.WinFormsUI.Docking;
namespace CourseLabSystem
{
    public partial class FrmCourseBuilding : DockContent
    {
        int Role = 0;
        public FrmCourseBuilding(int role)
        {
            Role = role;
            InitializeComponent();
        }
        public DataTable[,] Dt = null;
        public static List<CourseBuild> CourseNow=null;
        DataTable Dc = null;
        CourseBuildingBLL bll = new CourseBuildingBLL();
        List<CourseBuild> CourseBuild = new List<CourseBuild>();
        /// <summary>
        /// 初始化  课表格式
        /// </summary>
        /// <returns></returns>
        DataTable NewinNiTial()
        {
            int j;
            Dc = new DataTable();
            Dc.Columns.Add("节次", typeof(string));
            Dc.Columns.Add("一", typeof(string));
            Dc.Columns.Add("二", typeof(string));
            Dc.Columns.Add("三", typeof(string));
            Dc.Columns.Add("四", typeof(string));
            Dc.Columns.Add("五", typeof(string));
            Dc.Columns.Add("六", typeof(string));
            Dc.Columns.Add("日", typeof(string));
            for (j = 0; j < 5; j++)
            {
                DataRow dr = Dc.NewRow();
                Dc.Rows.Add(dr);
            }
            Dc.Rows[0]["节次"] = "1,2";
            Dc.Rows[1]["节次"] = "3,4";
            Dc.Rows[2]["节次"] = "5,6";
            Dc.Rows[3]["节次"] = "7,8";
            Dc.Rows[4]["节次"] = "9,10";
            return Dc;
        }
        /// <summary>
        /// 改变列表宽度和高度
        /// </summary>
        void ChangeHAndW()
        {
            try
            {
                dgv_课表.Rows[0].Height = 50;
                dgv_课表.Rows[1].Height = 50;
                dgv_课表.Rows[2].Height = 50;
                dgv_课表.Rows[3].Height = 50;
                dgv_课表.Rows[4].Height = 50;


                dgv_课表.Columns[1].Width = 170;
                dgv_课表.Columns[2].Width = 170;
                dgv_课表.Columns[3].Width = 170;
                dgv_课表.Columns[4].Width = 170;
                dgv_课表.Columns[5].Width = 170;
                dgv_课表.Columns[6].Width = 170;
                dgv_课表.Columns[7].Width = 170;
                dgv_课表.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            catch (Exception)
            {
                return;
            }
            
        }
        /// <summary>
        /// 取消标题行的排列效果并且无法改变行列的大小
        /// </summary>
        void NoSort()
        {
            for (int i = 0; i < this.dataGridView1.Columns.Count; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //dgv_课表.AllowUserToResizeColumns = false;
            //dgv_课表.AllowUserToResizeRows = false;
        }

        /// <summary>
        /// 返回数据库中先前排课的记录
        /// </summary>
        /// <returns></returns>
        SqlDataReader getWhole()
        {
            return bll.getWhole1();
        }
        /// <summary>
        /// 初始化  datatable【，】对应院系和班级
        /// </summary>
        void InitDatatabe()
        {
            Dt = new DataTable[10, 10];
            for (int i = 1; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Dc = NewinNiTial();
                    Dt[i, j] = Dc;//初始化每个班级的datatable
                }
            }
        }
        /// <summary>
        /// 获取年级信息
        /// </summary>
        void GetGd()
        {
            try
            {
                List<Basic_Information> information = new List<Basic_Information>();  //创建泛型实体类
                information = bll.GetLoadCobGrd();
                information.Insert(0, new Basic_Information() { Garde = "--全部--" });
                Garde.DataSource = information;
                Garde.DisplayMember = "Garde";
            }
            catch (Exception)
            {
                return;
            }
        }
        /// <summary>
        /// 获取年份
        /// </summary>
        void GetYear()
        {
              int DateYear= DateTime.Now.Year;  //得到本年
              int DateYearOne = DateYear + 1;
              int DateYearTwo = DateYear + 2;
              int DateYearThree = DateYear + 3;
              int DateYearFour = DateYear + 4;
              int DateYearfive = DateYear + 5;
              List<string> Year = new List<string>();
              Year.Add(DateYear.ToString() + "-" + DateYearOne.ToString());
              Year.Add(DateYearOne.ToString() + "-" + DateYearTwo.ToString());
              Year.Add(DateYearTwo.ToString() + "-" + DateYearThree.ToString());
              Year.Add(DateYearThree.ToString() + "-" + DateYearFour.ToString());
              Year.Add(DateYearFour.ToString() + "-" + DateYearfive.ToString());
              year.DataSource = Year;
        }
        /// <summary>
        /// 每一个班级一个datatable的表格  load的时候初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCourseBuilding_Load(object sender, EventArgs e)
        {
            if (Role == 2)
            {
                Add.Enabled = false;
                Clear.Enabled = false;
            }
            this.KeyPreview = true;
           
            GetYear();
            InitDatatabe();
           // NoSort();
            //ChangeHAndW();
            GetGd();//获取年级信息
            GetHistroy();//获取数据库信息
            //MessageBox.Show(FrmCourseBuildingAdd.CourseSum.Count.ToString());
        }
       
        /// <summary>
        /// 将add添加的信息转化为实体类并放入list中
        /// </summary>
        /// <param name="CourseSum"></param>
        /// <returns></returns>
        List<CourseBuild> Convert(List<string> CourseSum)
        {
            
            foreach (string item in CourseSum)
            {
                CourseBuild CourseBuildNow = new CourseBuild();
                string[] Sum=item.Split('|');
                CourseBuildNow.Building_Id = Sum[1];
                CourseBuildNow.Department = Sum[0];
                CourseBuildNow.Garde = Sum[6];
                CourseBuildNow.Name = Sum[2];
                CourseBuildNow.Week = Sum[5];
                CourseBuildNow.Weekday = Sum[8];
                CourseBuildNow.Section = Sum[9];
                CourseBuildNow.Teacher = Sum[4];
                CourseBuildNow.Course = Sum[3];
                CourseBuildNow.Class = Sum[7];
                CourseBuildNow.Year = Sum[10];
                CourseBuildNow.Term = Sum[11];
                CourseBuild.Add(CourseBuildNow);
            }
            return CourseBuild;
        }     
        /// <summary>
        /// 将添加的数据加入数据库并更新还原内存中提取于数据库的数据 
        /// </summary>
        void Save()
        {
            try
            {
                CourseNow = Convert(FrmCourseBuildingAdd.CourseAdd);   //将add添加的信息转化为实体类并放入list中          
                if (CourseNow.Count > 0)
                {
                    if (bll.insert(CourseNow))
                    {
                        MessageBox.Show("插入成功");
                        FrmCourseBuildingAdd.CourseSum.AddRange(FrmCourseBuildingAdd.CourseAdd);
                        //MessageBox.Show(FrmCourseBuildingAdd.CourseAdd.Count.ToString());
                        FrmCourseBuildingAdd.CourseAdd.Clear();
                        CourseNow.Clear();   
                    }
                    else
                    {
                        MessageBox.Show("插入失败");
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
            //FrmCourseBuildingAdd.CourseSum.Clear();
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            Save();
            CourseBuildingBLL.number = 0;
        }
        private void dgv_课表_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        /// <summary>
        /// 清空选中项的值并且清空相应的数据库值和add中的静态变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Clear_Click(object sender, EventArgs e)
        {
            clear();
        }
        /// <summary>
        /// 删除按钮
        /// </summary>
        void clear()
        {
            int k;
            try
            {
                int x = 0;
                int WeekDayNum = dgv_课表.CurrentCell.ColumnIndex;  //周几索引
                int sectionNum = dgv_课表.CurrentCell.RowIndex;   //节次索引
                string WeekDay = dgv_课表.Columns[WeekDayNum].HeaderText;  //周几
                string section = dgv_课表.Rows[sectionNum].Cells[0].Value.ToString();  //节次
                int GardeNumberNow = Garde.SelectedIndex;//当前选中年级的索引
                int ClassNumberNow = Class.SelectedIndex;//当前选中班级的索引
                string select = dgv_课表.CurrentCell.Value.ToString();
                if (select == "")
                {
                    return;
                }
                else
                {
                    for (k = 0; k < FrmCourseBuildingAdd.CourseSum.Count; k++)
                    {
                        string[] name = FrmCourseBuildingAdd.CourseSum[k].Split('|');
                        if (FrmCourseBuildingAdd.CourseSum[k].Contains(select) && WeekDay == name[8] && section == name[9] && year.Text == name[10] && term.Text == name[11])
                        {
                            if (MessageBox.Show("是否删除", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                            {
                                return;
                            }
                            else
                            {
                                bll.delete(FrmCourseBuildingAdd.CourseSum[k]);
                                FrmCourseBuildingAdd.CourseSum.Remove(FrmCourseBuildingAdd.CourseSum[k]);    //清楚班级中表格中的信息
                                x = 1;
                                dgv_课表.CurrentCell.Value = "";
                                break;
                            }
                        }
                    }
                    if (x == 0)
                    {
                        FrmCourseBuildingAdd.CourseAdd.Remove(select + "|" + Garde.Text + "|" + Class.Text + "|" + WeekDay + "|" + section + "|" + year.Text + "|" + term.Text);
                        dgv_课表.CurrentCell.Value = "";
                        CourseBuildingBLL.number--;
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        private void comboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 当年级改变时  搜索院系
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Garde_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Garde.Text.ToString() == "--全部--")
            {
                Department.Text = "";
                Dc = NewinNiTial();//初始化datatable
                dgv_课表.DataSource = null;
                return;
            }
            try
            {
                InitDatatabe();
                Basic_Information information = (Basic_Information)Garde.SelectedItem;
                List<Basic_Information> informationList = new List<Basic_Information>();
                informationList = bll.LoadCmbdt(information);
                Department.DataSource = informationList;
                Department.DisplayMember = "Department";
                //Department.ValueMember = "Department";
                if (CourseBuildingBLL.number == 0)
                {
                    getOne();
                    ChangeHAndW();
                    NoSort();
                    return;
                }
                else
                {
                    if (MessageBox.Show("是否保存", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                    {
                        FrmCourseBuildingAdd.CourseAdd.Clear();
                        CourseBuildingBLL.number = 0;
                        InitDatatabe();
                        getOne();
                        ChangeHAndW();
                        NoSort();
                    }
                    else
                    {
                        buttonX1_Click(sender, e);//Save();
                        //Dt[Garde.SelectedIndex, Class.SelectedIndex] = (DataTable)dgv_课表.DataSource;
                        getOne();
                        ChangeHAndW();
                        NoSort();
                    }
                }

            }
            catch (Exception)
            {
                return;
            }
           
        }
        /// <summary>
        /// 当年级改变时  将对应的班级的datatable显示在datagirdview上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Garde_SelectionChangeCommitted(object sender, EventArgs e)
        { 
        }
        /// <summary>
        /// 当班级改变时  将对应的班级的datatable显示在datagirdview上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Class_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 添加键盘输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCourseBuilding_KeyDown(object sender, KeyEventArgs e)
        {
            Keys k = e.KeyCode;
            switch (k)
            {
                case Keys.C: Clear_Click(sender, e); break;
                    
            }
        }

        private void Class_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {  
                if (CourseBuildingBLL.number == 0)
                {
                    InitDatatabe();
                    getOne();
                    ChangeHAndW();
                    NoSort();
                    return;
                }
                else
                {
                    if (MessageBox.Show("是否保存", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                    {
                        FrmCourseBuildingAdd.CourseAdd.Clear();
                        CourseBuildingBLL.number = 0;
                        InitDatatabe();   
                        getOne();
                        ChangeHAndW();
                        NoSort();
                    }
                    else
                    {
                        buttonX1_Click(sender, e);
                        getOne();
                        ChangeHAndW();
                        NoSort();
                    }
                }
            }
            catch (Exception)
            {
                return;
            } 
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void dgv_课表_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        /// <summary>
        /// 单击任意位置跳出添加框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_课表_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            //如果选中行或列的表头 终止操作，即无反应
            //如果选中第一列，即周次，也应无反应
            if (Role == 1)
            {
                if (string.IsNullOrWhiteSpace(year.Text) || string.IsNullOrWhiteSpace(Garde.Text) || string.IsNullOrWhiteSpace(Class.Text) || string.IsNullOrWhiteSpace(term.Text) || string.IsNullOrWhiteSpace(Department.Text))
                {
                    MessageBox.Show("存在空项");
                    return;
                }
                if (-1 == e.RowIndex || e.ColumnIndex == -1 || e.ColumnIndex == 0)
                {
                    return;
                }
                FrmCourseBuildingAdd Add = new FrmCourseBuildingAdd(this);
                Add.ShowDialog();
                Add.StartPosition = FormStartPosition.CenterParent;
            }
        }
        void JoinList(string name)
        {
                FrmCourseBuildingAdd.CourseSum.Add(name);
        }
        /// <summary>
        /// 获取数据库信息并添加到add的string类中
        /// </summary>
        void GetHistroy()
        {
            FrmCourseBuildingAdd.CourseSum.Clear();
            FrmCourseBuildingAdd.CourseAdd.Clear();
            SqlDataReader dt = getWhole();
            try
            {
                if (dt.HasRows)
                {   
                    while (dt.Read())
                    {
                        string Weekday = dt.GetString(5);
                        string newList = dt.GetString(1) + "|" + dt.GetString(0) + "|" + dt.GetString(3) + "|" + dt.GetString(8) + "|" + dt.GetString(7) + "|" + dt.GetString(4) + "|" + dt.GetString(2) + "|" + dt.GetString(9) + "|" + dt.GetString(5) + "|" + dt.GetString(6)+"|"+dt.GetString(10)+"|"+dt.GetString(11);
                        JoinList(newList);
                    }
                    dt.Close();
                }
            }
            catch (Exception)
            {
                return;
            }
        }
        /// <summary>
        /// 获得一张表的信息并且将表显示出来
        /// </summary>
        void getOne()
        {
            SqlDataReader dt = bll.GetOne(year.Text, term.Text, Garde.Text, Class.Text,Department.Text);
            try
            {
                if (dt.HasRows)
                {
                    while (dt.Read())
                    {
                        string name = "";
                        int section;
                        string Section = dt.GetString(6);
                        if (Section == "1,2")
                        {
                            section = 0;
                        }
                        else if (Section == "3,4")
                        {
                            section = 1;
                        }
                        else if (Section == "5,6")
                        {
                            section = 2;
                        }
                        else if (Section == "7,8")
                        {
                            section = 3;
                        }
                        else
                        {
                            section = 4;
                        }
                        string Weekday = dt.GetString(5);
                        name += dt.GetString(1) + "|" + dt.GetString(0) + "|" + dt.GetString(3) + "|" + dt.GetString(8) + "|" + dt.GetString(7) + "|" + dt.GetString(4);
                        Dt[Garde.SelectedIndex, Class.SelectedIndex].Rows[section][Weekday] = name; 
                    }
                    dt.Close();
                    dgv_课表.DataSource = Dt[Garde.SelectedIndex, Class.SelectedIndex]; 
                }
                else
                {
                    Dc = NewinNiTial();//初始化datatable
                    dgv_课表.DataSource = Dc;
                }
            }
            catch (Exception )
            {
                return;
            }
        }
        private void buttonX1_Click_1(object sender, EventArgs e)
        {   
        }

        private void year_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                InitDatatabe();
                if (CourseBuildingBLL.number == 0)
                {
                    getOne();
                    ChangeHAndW();
                    NoSort();
                    return;
                }
                else
                {
                    if (MessageBox.Show("是否保存", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                    {
                        FrmCourseBuildingAdd.CourseAdd.Clear();
                        CourseBuildingBLL.number = 0;
                        InitDatatabe();
                        getOne();
                        ChangeHAndW();
                        NoSort();
                    }
                    else
                    {
                        buttonX1_Click(sender, e);//Save();
                        getOne();
                        ChangeHAndW();
                        NoSort();
                    }
                }

            }
            catch (Exception)
            {
                return;
            }
        }

        private void term_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void buttonX1_Click_2(object sender, EventArgs e)
        {
            getOne();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void term_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void term_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                InitDatatabe();
                if (CourseBuildingBLL.number == 0)
                {
                    getOne();
                    ChangeHAndW();
                    NoSort();
                    return;
                }
                else
                {
                    if (MessageBox.Show("是否保存", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                    {
                        FrmCourseBuildingAdd.CourseAdd.Clear();
                        CourseBuildingBLL.number = 0;
                        InitDatatabe();
                        getOne();
                        ChangeHAndW();
                        NoSort();
                    }
                    else
                    {
                        buttonX1_Click(sender, e);//Save();
                        getOne();
                        ChangeHAndW();
                        NoSort();
                    }
                }

            }
            catch (Exception)
            {
                return;
            }
        }

        private void term_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

        private void year_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void year_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void Class_SizeChanged(object sender, EventArgs e)
        {
        }

        private void Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Garde.Text == "--全部--")
            {
                Department.Text = "";
                return;
            }
            try
            {   //获取班级信息
                DataTable informationList = new DataTable();
                string garde = Garde.Text;
                string De = Department.Text;
                informationList = bll.LoadCmbCs(garde, De);
                Class.DataSource = informationList;
                Class.DisplayMember = "Class";
                Class.ValueMember = "ClassId";
                if (CourseBuildingBLL.number == 0)
                {
                    InitDatatabe();
                    getOne();
                    ChangeHAndW();
                    NoSort();
                    return;
                }
                else
                {
                    if (MessageBox.Show("是否保存", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                    {
                        FrmCourseBuildingAdd.CourseAdd.Clear();
                        CourseBuildingBLL.number = 0;
                        InitDatatabe();
                        getOne();
                        ChangeHAndW();
                        NoSort();
                    }
                    else
                    {
                        buttonX1_Click(sender, e);
                        getOne();
                        ChangeHAndW();
                        NoSort();
                    }
                }
            }
            catch (Exception)
            {
                return;
            } 
        }
    }
}
