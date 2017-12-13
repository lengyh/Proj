using System;
using System.Collections.Generic;
using System.Web;
using WorksShow.BLL;
using System.Data;
using System.Text;
using System.Configuration;

namespace WorksShow.Web.Service
{
    /// <summary>
    /// 本类用于向外提供接口数据
    /// </summary>
    public class PData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            //获取参数类型，必须要的参数
            string type = context.Request["t"];
            if (string.IsNullOrEmpty(type)) return;
            string teamId = context.Request["teamId"];
            string levelName = context.Request["levelName"];
            string maxNum = context.Request["maxNum"];
            string workID = context.Request["workID"];
            LitJson.JsonData json = null;
                //根据不同的参数类型，处理不同的数据
                switch (type)
                {
                    case "SecondClassroomTeamList":
                        json = SecondClassroomTeamList();
                        break;
                    case "WorksList":
                        if (string.IsNullOrEmpty(maxNum)) maxNum = "0";
                        if (!string.IsNullOrEmpty(teamId))
                        {
                            if (!string.IsNullOrEmpty(levelName))
                            {
                                json = WorksList(int.Parse(teamId), levelName, int.Parse(maxNum));
                            }
                            else json = WorksList(int.Parse(teamId), int.Parse(maxNum));
                        }
                        else json = WorksList(int.Parse(maxNum));
                        break;
                    case "GetWebIndexName": json = GetWebIndexName();  break;
                    case "LevelList": json = LevelList(int.Parse(teamId)); break;
                    case "GetWorkbyID": json = GetWorkbyID(int.Parse(workID)); break;
                }

            //返回处理结果
            if (json != null)
                context.Response.Write(json.ToJson());

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }


        #region 第二课堂相关的数据

        article artBll = new article();
        category catBll = new category();
        /// <summary>
        /// 获取第二课堂的学期信息，id=59的子类，包括ID、名称、链接图片、文本描述
        /// 特别说明：此列表信息在发布的时候也需要发布成内容
        /// </summary>
        /// <returns>以Json的格式返回 学期 相关的ID、名称、链接图片、文本描述</returns>
        public LitJson.JsonData SecondClassroomTeamList()
        {
            //获取数据,59代表第二课堂信息
            DataSet artDs = catBll.GetTermList("59",true);
            //转换为json并且返回
            return GetJsonByDataset(artDs);
        }

        /// <summary>
        /// 根据作品ID获取作品信息
        /// </summary>
        /// <param name="workID">作品ID</param>
        /// <returns>返回作品信息</returns>
        public LitJson.JsonData GetWorkbyID(int workID)
        {
            DataSet artDs = artBll.GetList("id = "+workID);
            return GetJsonByDataset(artDs);
        }


        /// <summary>
        /// 获取指定ID学期的所有作品信息
        /// </summary>
        /// <param name="teamId">学期ID</param>
        /// <returns>以Json格式返回需要的数据，结果按等级排序，数据包括 ID、名称、链接、描述 等必要的信息</returns>
        public LitJson.JsonData WorksList(int teamId, int maxNum = 0)
        {
            IList<int> level = catBll.GetLevelIDByTermID(teamId.ToString());
            StringBuilder str = new StringBuilder();
            str.Append("(");
            for (int i = 0; i < level.Count-1; i++)
            {
                str.Append(level[i]+",");
            }
            str.Append(level[level.Count-1]+")");

            //channel_id是Parent，它的children包括学期及等级,学期id（65-68）这里的category_id前面不能加空格
            DataSet artDs = artBll.GetList("category_id in " + str,maxNum);

            return GetJsonByDataset(artDs);
        }


        /// <summary>
        /// 获取指定ID学期的指定等级的作品信息
        /// </summary>
        /// <param name="teamId">学期ID</param>
        /// <param name="levelName">等级名称，如一等奖</param>
        /// <returns>以Json格式返回需要的数据，结果按等级排序，数据包括 ID、名称、链接、描述 等必要的信息</returns>
        public LitJson.JsonData WorksList(int teamId, string levelName, int maxNum = 0)
        {
            int id = catBll.GetWorkInfo(teamId.ToString(),levelName);

            //这里的category_id前面不能加空格
            DataSet artDs = artBll.GetList("category_id="+id,maxNum);
            return GetJsonByDataset(artDs);
        }

        /// <summary>
        /// 获取系统中所有的作品信息
        /// </summary>
        /// <returns>以Json格式返回需要的数据，结果按学期和等级排序，数据包括 ID、名称、链接、描述 等必要的信息</returns>
        public LitJson.JsonData WorksList(int maxNum = 30)
        {
            //channel_id=19代表学生作品 这里的channel_id前面不能加空格
            DataSet ds = artBll.GetList("channel_id=19",maxNum);
            return GetJsonByDataset(ds);
        }

        /// <summary>
        /// 获取指定学期的所有等级信息
        /// </summary>
        /// <param name="termId">学期ID</param>
        /// <returns></returns>
        public LitJson.JsonData LevelList(int termId)
        {
            DataSet ds = catBll.GetLevelList(termId.ToString());

            return GetJsonByDataset(ds);
        }

        /// <summary>
        /// 获取网站平台名称
        /// </summary>
        /// <returns></returns>
        public LitJson.JsonData GetWebIndexName()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("{");
            string webIndexName = ConfigurationManager.AppSettings["WebIndexName"].ToString();
            return "{\"WebIndexName\":\"" + webIndexName + "\"}";
            //return string.Format("{'WebIndexName':'"+ConfigurationManager.AppSettings["WebIndexName"].ToString()+"'}");
        }

        /// <summary>
        /// Dataset转换为json
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static string GetJsonByDataset(DataSet ds)
        {
            if (ds == null || ds.Tables.Count <= 0 || ds.Tables[0].Rows.Count <= 0)
            {
                //如果查询到的数据为空则返回标记ok:false
                return "{\"ok\":false}";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("{\"ok\":true,");
            foreach (DataTable dt in ds.Tables)
            {
                sb.Append(string.Format("\"{0}\":[", dt.TableName));

                foreach (DataRow dr in dt.Rows)
                {
                    sb.Append("{");
                    for (int i = 0; i < dr.Table.Columns.Count; i++)
                    {
                        sb.AppendFormat("\"{0}\":\"{1}\",", dr.Table.Columns[i].ColumnName.Replace("\"", "\\\"").Replace("\'", "\\\'"), ObjToStr(dr[i]).Replace("\"", "\\\"").Replace("\'", "\\\'")).Replace(Convert.ToString((char)13), "\\r\\n").Replace(Convert.ToString((char)10), "\\r\\n");
                    }
                    sb.Remove(sb.ToString().LastIndexOf(','), 1);
                    sb.Append("},");
                }

                sb.Remove(sb.ToString().LastIndexOf(','), 1);
                sb.Append("],");
            }
            sb.Remove(sb.ToString().LastIndexOf(','), 1);
            sb.Append("}");
            return sb.ToString();
        }
        /// <summary>
        /// 将object转换成为string
        /// </summary>
        /// <param name="ob">obj对象</param>
        /// <returns></returns>
        public static string ObjToStr(object ob)
        {
            if (ob == null)
            {
                return string.Empty;
            }
            else
                return ob.ToString();
        }
        #endregion
    }
}