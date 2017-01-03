using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SplitString
    {

        public static DataTable SplitDT(DataTable oldDt)
        {
            DataTable dt = SplitDT1(oldDt);
            return SplitDT3(dt);
        }

        private static DataTable SplitDT3(DataTable dt)
        {
            DataTable dt1 = dt.Clone();
            int mm = 0;
            for (int pos = 0; pos < dt.Rows.Count; pos++)
            {
                string current_week = dt.Rows[pos]["current_week"].ToString();
                string week = dt.Rows[pos]["week"].ToString();
                string time = dt.Rows[pos]["time"].ToString();
                string[] current_week1 = current_week.Split(' ');
                string[] week1 = week.Split(' ');
                string[] time1 = time.Split(' ');
                int all = (current_week1.Length - 1) * (week1.Length - 1);

                // 9 10 11 12 13  
                // 星期一 星期三 星期四
                for (int i = 0; i < all; i++)
                {
                    DataRow dr = dt1.NewRow();
                    for (int m = 0; m < dt.Columns.Count; m++)
                    {
                        dr[m] = dt.Rows[pos][m];
                    }
                    dt1.Rows.Add(dr);
                }

                for (int m = 1; m < week1.Length; m++)
                {
                    for (int n = 1; n < current_week1.Length; n++)
                    {
                        dt1.Rows[mm]["current_week"] = current_week1[n];
                        dt1.Rows[mm]["week"] = week1[m];
                        dt1.Rows[mm]["time"] = time1[m];
                        mm++;
                    }
                }
            }
            return dt1;
        }
        public static DataTable SplitDT1(DataTable oldDt)
        {
            DataTable newDt = new DataTable();

            DataColumn teacher_department = new DataColumn("teacher_department");
            DataColumn teacher_id = new DataColumn("teacher_id");
            DataColumn teacher_name = new DataColumn("teacher_name");
            DataColumn current_week = new DataColumn("current_week");
            DataColumn week = new DataColumn("week");
            DataColumn time = new DataColumn("time");
            DataColumn course = new DataColumn("course");
            DataColumn is_attendance = new DataColumn("is_attendance");
            DataColumn area = new DataColumn("area");
            DataColumn class_name = new DataColumn("class_name");
            DataColumn class_department = new DataColumn("class_department");
            DataColumn stu_id = new DataColumn("stu_id");
            DataColumn stu_name = new DataColumn("stu_name");
            DataColumn stu_sex = new DataColumn("stu_sex");
            DataColumn admin_class = new DataColumn("admin_class");
            DataColumn count = new DataColumn("count");

            //DataColumn course = new DataColumn("course");
            //DataColumn week_range = new DataColumn("week_range");
            //DataColumn time = new DataColumn("time");
            //DataColumn stu_name = new DataColumn("stu_id");
            //DataColumn week = new DataColumn("week");


            newDt.Columns.Add(teacher_department);
            newDt.Columns.Add(teacher_id);
            newDt.Columns.Add(teacher_name);
            newDt.Columns.Add(current_week);
            newDt.Columns.Add(week);
            newDt.Columns.Add(time);
            newDt.Columns.Add(course);
            newDt.Columns.Add(is_attendance);
            newDt.Columns.Add(area);
            newDt.Columns.Add(class_name);
            newDt.Columns.Add(class_department);
            newDt.Columns.Add(stu_id);
            newDt.Columns.Add(stu_name);
            newDt.Columns.Add(stu_sex);
            newDt.Columns.Add(admin_class);
            newDt.Columns.Add(count);


            for (int i = 0; i < oldDt.Rows.Count; i++)
            {
                DataRow dr = newDt.NewRow();
                dr["teacher_id"] = getID(oldDt.Rows[i][1].ToString());
                dr["teacher_name"] = getID(oldDt.Rows[i][1].ToString());

                dr["current_week"] = getWeekRange(oldDt.Rows[i][2].ToString());
                dr["week"] = getWeek(oldDt.Rows[i][2].ToString());
                dr["time"] = getTime(oldDt.Rows[i][2].ToString());

                dr["course"] = getCourses(oldDt.Rows[i][3].ToString());
                dr["area"] = getCourses(oldDt.Rows[i][3].ToString());

                dr[0] = oldDt.Rows[i][0].ToString(); //承担单位
                dr[6] = oldDt.Rows[i][3];
                dr[7] = "未考勤"; //初始化
                dr[9] = oldDt.Rows[i][7]; //上课班级
                dr[10] = oldDt.Rows[i][8]; //上课班级所属系部
                dr[11] = oldDt.Rows[i][9]; //学号
                dr[12] = oldDt.Rows[i][10]; //学生姓名
                dr[13] = oldDt.Rows[i][12]; //性别
                dr[14] = oldDt.Rows[i][11]; //行政班级
                dr[15] = "未布置作业";
                newDt.Rows.Add(dr);
            }

            return SplitNewDt2(newDt);
        }

        public static DataTable SplitNewDt2(DataTable dt11)
        {
            DataTable ddtt = dt11;
            DataRow dr = ddtt.NewRow();
            for (int i = 0; i < dt11.Rows.Count; i++)
            {
                string[] current_week = dt11.Rows[i]["current_week"].ToString().Split(' ');
                string[] week = dt11.Rows[i]["week"].ToString().Split(' ');
                string[] time = dt11.Rows[i]["time"].ToString().Split(' ');
                //  MessageBox.Show(dt11.Rows[i]["current_week"] + "\n" + dt11.Rows[i]["week"]);
                //MessageBox.Show(ddtt.Rows[i]["current_week"].ToString() + ddtt.Rows[i]["week"].ToString());
                int all = current_week.Length + week.Length;
                for (int j = 0; j < week.Length; j++)
                {
                    for (int k = 0; k < current_week.Length; k++)
                    {
                        if (j != 0 && k != 0)
                        {
                            for (int m = 0; m < 15; m++)
                            {
                                dr[m] = dt11.Rows[i][m];
                            }
                            dr["current_week"] = current_week[k];
                            dr["week"] = week[j];
                            dr["time"] = time[j];
                            ddtt.Rows.Add(dr);
                            dr = ddtt.NewRow();
                        }
                    }
                }
            }

            return ddtt;
        }


        private static object getTime(string v)
        {
            string time = "";
            string[] weeks = v.Split('@');
            for (int i = 0; i < weeks.Length; i++)
            {
                int pos = weeks[i].LastIndexOf('[');
                string r = "";
                int l = weeks[i].IndexOf('节') - pos;
                r = weeks[i].Substring(pos + 1, l);
                time = time + " " + r;
            }
            return time;
        }

        private static string getWeek(string v)
        {
            string week = "";
            string[] weeks = v.Split('@');
            for (int i = 0; i < weeks.Length; i++)
            {
                int pos = weeks[i].IndexOf(']');
                string r = "";
                int l = weeks[i].LastIndexOf('[') - pos;
                r = weeks[i].Substring(pos + 1, l - 1);
                week = week + " " + r;
            }
            return week;
        }

        private static string getID(string str)
        {
            //[2006013612]邢茹
            string[] id = str.Split(']');
            return id[0].Substring(1, id[0].Length - 1);
        }

        private static string getCourses(string str)
        {
            //[361670]PHP程序设计(4)
            string[] s = str.Split(']');
            // s[1] = PHP程序设计(4)
            string[] s1 = s[1].Split('(');
            // s1[0] =  PHP程序设计 ; s1[1] = 4) ;
            return s1[0];
        }

        private static string getWeekRange(string str)
        {
            string[] two = null;
            string result = "";
            //[11-15周]星期二[1-2节]/E211(05平面1)@[11-15周]星期三[3-4节]/E211(05平面1)@[11-15周]星期三[9-10节]/E202(03程序1)@[11-15周]星期四[7-8节]/E202(03程序1)
            string[] one = str.Split('@');
            // one[0] = [11-15周]星期二[1-2节]/E211(05平面1)
            two = one[0].Split('周');
            string t = one[0].Substring(1, one[0].IndexOf("]") - 1);
            //三个条件
            bool exist1 = t.Contains(",");
            bool exist2 = t.Contains("单");
            bool exist3 = t.Contains("双");
            //类型一
            if (!exist1 && !exist2 && !exist3)
            {
                string range = t.Substring(0, t.IndexOf("周"));
                string[] ranges = range.Split('-');
                int start = Convert.ToInt32(ranges[0]);
                int end = Convert.ToInt32(ranges[1]);
                for (int i = start; i <= end; i++)
                {
                    result = result + " " + i;
                }
            }
            //类型二
            if (exist1 && !exist2 && !exist3)
            {
                string range = t.Substring(0, t.IndexOf("周"));
                string[] ranges = range.Split(',');
                result = WeekBlend(ranges, 0);
            }
            //类型三
            if (!exist1 && exist2 && !exist3)
            {
                string range = t.Substring(0, t.IndexOf("单周"));
                string[] s = range.Split('-');
                int start = Convert.ToInt32(s[0]);
                int end = Convert.ToInt32(s[1]);
                for (int i = start; i <= end; i++)
                {
                    if (i % 2 != 0)
                    {
                        result = result + " " + i;
                    }
                }
            }
            //类型四
            if (exist1 && exist2 && !exist3)
            {
                string range = t.Substring(0, t.IndexOf("单周"));
                string[] ranges = range.Split(',');
                result = WeekBlend(ranges, 1);
            }
            //类型五
            if (exist1 && !exist2 && exist3)
            {
                string range = t.Substring(0, t.IndexOf("双周"));
                string[] ranges = range.Split(',');
                result = WeekBlend(ranges, 2);
            }

            //类型六
            if (!exist1 && !exist2 && exist3)
            {
                string range = t.Substring(0, t.IndexOf("双周"));
                string[] s = range.Split('-');
                int start = Convert.ToInt32(s[0]);
                int end = Convert.ToInt32(s[1]);
                for (int i = start; i <= end; i++)
                {
                    if (i % 2 == 0)
                    {
                        result = result + " " + i;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 周次复杂拆分 合并
        /// </summary>
        /// <param name="ranges"></param>
        /// <param name="flag">单双周判断位</param>
        /// <returns></returns>
        private static string WeekBlend(string[] ranges, int flag)
        {
            string result = "";
            for (int i = 0; i < ranges.Length; i++)
            {
                if (ranges[i].Contains("-"))
                {
                    string[] rs = ranges[i].Split('-');
                    int s = Convert.ToInt32(rs[0]);
                    int e = Convert.ToInt32(rs[1]);
                    for (int j = s; j <= e; j++)
                    {
                        if (flag == 1)
                        {

                            if (j % 2 != 0)
                            {
                                result = result + " " + j;
                            }
                        }
                        else if (flag == 2)
                        {
                            if (j % 2 == 0)
                            {
                                result = result + " " + j;
                            }
                        }
                        else
                        {
                            result = result + " " + j;
                        }
                    }
                }
                else
                {
                    result = result + " " + ranges[i];
                }
            }
            return result;
        }

        /// <summary>
        /// 处理教师信息表，把密码进行MD5加密而已
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataTable SplitTeacher4DT(DataTable dt)
        {
            string strSQL = "select * from TabTeachers where user_id='1'";
            DataTable NewDT = ConnHelper.GetDataTable(strSQL);
            DataRow dr = NewDT.NewRow();
            //进行拆分处理
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int y = 0; y < 6; y++)
                {
                    if (y == 2)
                    {
                        dr[y] = md5(dt.Rows[i][y].ToString());
                    }
                    else
                    {
                        dr[y] = dt.Rows[i][y];
                    }
                }
                NewDT.Rows.Add(dr);
                dr = NewDT.NewRow();
            }

            return NewDT;
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">欲加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string md5(string input)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}

