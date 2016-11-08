using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SplitString
    {
        public static DataTable SplitDT(DataTable oldDt)
        {
            DataTable newDt = new DataTable();

            DataColumn tea_id = new DataColumn("tea_id");
            DataColumn course = new DataColumn("course");
            DataColumn week_range = new DataColumn("week_range");
            DataColumn time = new DataColumn("time");
            DataColumn stu_name = new DataColumn("stu_id");
            DataColumn week = new DataColumn("week");
            newDt.Columns.Add(tea_id);
            newDt.Columns.Add(course);
            newDt.Columns.Add(week_range);
            newDt.Columns.Add(time);
            newDt.Columns.Add(stu_name);
            newDt.Columns.Add(week);

            for (int i = 0; i < oldDt.Rows.Count; i++)
            {
                DataRow dr = newDt.NewRow();
                dr["tea_id"] = getID(oldDt.Rows[i][1].ToString());
                dr["course"] = getCourses(oldDt.Rows[i][3].ToString());
                dr["week_range"] = getWeekRange(oldDt.Rows[i][2].ToString());
                dr["week"] = getWeek(oldDt.Rows[i][2].ToString());
                dr["time"] = getTime(oldDt.Rows[i][2].ToString());
                dr["stu_id"] = oldDt.Rows[i][9].ToString();
                newDt.Rows.Add(dr);
            }

            return newDt;
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
    }
}

