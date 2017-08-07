using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.OleDb;
using WorksShow.DBUtility;
using WorksShow.Common;

namespace WorksShow.DAL
{
    /// <summary>
    /// 数据访问类:内容模块
    /// </summary>
    public partial class contents
    {
        public contents()
        { }
        #region  Method
        /// <summary>
        /// 得到最前的内容页
        /// </summary>
        public string GetCallIndex()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 call_index from dt_contents");
            strSql.Append(" order by sort_id asc,id desc");
            object obj = DbHelperOleDb.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return obj.ToString();
            }
            return null;
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_contents");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string call_index)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(0) from dt_contents");
            strSql.Append(" where call_index=@call_index ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@call_index", OleDbType.VarChar,50)};
            parameters[0].Value = call_index;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.contents model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dt_contents(");
            strSql.Append("channel_id,title,category_id,call_index,link_url,img_url,seo_title,seo_keywords,seo_description,content,sort_id,click,is_msg,is_red,is_lock,add_time,digg_good,digg_act)");
            strSql.Append(" values (");
            strSql.Append("@channel_id,@title,@category_id,@call_index,@link_url,@img_url,@seo_title,@seo_keywords,@seo_description,@content,@sort_id,@click,@is_msg,@is_red,@is_lock,@add_time,@digg_good,@digg_act)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@channel_id", OleDbType.Integer,4),
					new OleDbParameter("@title", OleDbType.VarChar,100),
					new OleDbParameter("@category_id", OleDbType.Integer,4),
					new OleDbParameter("@call_index", OleDbType.VarChar,50),
					new OleDbParameter("@link_url", OleDbType.VarChar,255),
					new OleDbParameter("@img_url", OleDbType.VarChar,255),
					new OleDbParameter("@seo_title", OleDbType.VarChar,255),
					new OleDbParameter("@seo_keywords", OleDbType.VarChar,255),
					new OleDbParameter("@seo_description", OleDbType.VarChar,255),
					new OleDbParameter("@content", OleDbType.VarChar),
					new OleDbParameter("@sort_id", OleDbType.Integer,4),
					new OleDbParameter("@click", OleDbType.Integer,4),
					new OleDbParameter("@is_msg", OleDbType.Integer,4),
					new OleDbParameter("@is_red", OleDbType.Integer,4),
					new OleDbParameter("@is_lock", OleDbType.Integer,4),
					new OleDbParameter("@add_time", OleDbType.Date),
                    new OleDbParameter("@digg_good", OleDbType.Integer,4),
					new OleDbParameter("@digg_act", OleDbType.Integer,4)};
            parameters[0].Value = model.channel_id;
            parameters[1].Value = model.title;
            parameters[2].Value = model.category_id;
            parameters[3].Value = model.call_index;
            parameters[4].Value = model.link_url;
            parameters[5].Value = model.img_url;
            parameters[6].Value = model.seo_title;
            parameters[7].Value = model.seo_keywords;
            parameters[8].Value = model.seo_description;
            parameters[9].Value = model.content;
            parameters[10].Value = model.sort_id;
            parameters[11].Value = model.click;
            parameters[12].Value = model.is_msg;
            parameters[13].Value = model.is_red;
            parameters[14].Value = model.is_lock;
            parameters[15].Value = model.add_time;
            parameters[16].Value = model.digg_good;
            parameters[17].Value = model.digg_act;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_contents set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.contents model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_contents set ");
            strSql.Append("channel_id=@channel_id,");
            strSql.Append("title=@title,");
            strSql.Append("category_id=@category_id,");
            strSql.Append("call_index=@call_index,");
            strSql.Append("link_url=@link_url,");
            strSql.Append("img_url=@img_url,");
            strSql.Append("seo_title=@seo_title,");
            strSql.Append("seo_keywords=@seo_keywords,");
            strSql.Append("seo_description=@seo_description,");
            strSql.Append("content=@content,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("click=@click,");
            strSql.Append("is_msg=@is_msg,");
            strSql.Append("is_red=@is_red,");
            strSql.Append("is_lock=@is_lock,");
            strSql.Append("add_time=@add_time,");
            strSql.Append("digg_good=@digg_good,");
            strSql.Append("digg_act=@digg_act");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@channel_id", OleDbType.Integer,4),
					new OleDbParameter("@title", OleDbType.VarChar,100),
					new OleDbParameter("@category_id", OleDbType.Integer,4),
					new OleDbParameter("@call_index", OleDbType.VarChar,50),
					new OleDbParameter("@link_url", OleDbType.VarChar,255),
					new OleDbParameter("@img_url", OleDbType.VarChar,255),
					new OleDbParameter("@seo_title", OleDbType.VarChar,255),
					new OleDbParameter("@seo_keywords", OleDbType.VarChar,255),
					new OleDbParameter("@seo_description", OleDbType.VarChar,255),
					new OleDbParameter("@content", OleDbType.VarChar),
					new OleDbParameter("@sort_id", OleDbType.Integer,4),
					new OleDbParameter("@click", OleDbType.Integer,4),
					new OleDbParameter("@is_msg", OleDbType.Integer,4),
					new OleDbParameter("@is_red", OleDbType.Integer,4),
					new OleDbParameter("@is_lock", OleDbType.Integer,4),
					new OleDbParameter("@add_time", OleDbType.Date),
                    new OleDbParameter("@digg_good", OleDbType.Integer,4),
					new OleDbParameter("@digg_act", OleDbType.Integer,4),
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = model.channel_id;
            parameters[1].Value = model.title;
            parameters[2].Value = model.category_id;
            parameters[3].Value = model.call_index;
            parameters[4].Value = model.link_url;
            parameters[5].Value = model.img_url;
            parameters[6].Value = model.seo_title;
            parameters[7].Value = model.seo_keywords;
            parameters[8].Value = model.seo_description;
            parameters[9].Value = model.content;
            parameters[10].Value = model.sort_id;
            parameters[11].Value = model.click;
            parameters[12].Value = model.is_msg;
            parameters[13].Value = model.is_red;
            parameters[14].Value = model.is_lock;
            parameters[15].Value = model.add_time;
            parameters[16].Value = model.digg_good;
            parameters[17].Value = model.digg_act;
            parameters[18].Value = model.id;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int channel_id, int id)
        {
            Hashtable sqllist = new Hashtable();

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete from dt_comment ");
            strSql2.Append(" where channel_id=@channel_id and content_id=@content_id");
            OleDbParameter[] parameters2 = {
					new OleDbParameter("@channel_id", OleDbType.Integer,4),
                    new OleDbParameter("@content_id", OleDbType.Integer,4)};
            parameters2[0].Value = channel_id;
            parameters2[1].Value = id;
            sqllist.Add(strSql2.ToString(), parameters2);

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from dt_contents ");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;
            sqllist.Add(strSql.ToString(), parameters);

            bool result = DbHelperOleDb.ExecuteSqlTran(sqllist);
            return result;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.contents GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,channel_id,title,category_id,call_index,link_url,img_url,seo_title,seo_keywords,seo_description,content,sort_id,click,digg_good,digg_act,is_msg,is_red,is_lock,add_time from dt_contents ");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            WorksShow.Model.contents model = new WorksShow.Model.contents();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["channel_id"] != null && ds.Tables[0].Rows[0]["channel_id"].ToString() != "")
                {
                    model.channel_id = int.Parse(ds.Tables[0].Rows[0]["channel_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["title"] != null && ds.Tables[0].Rows[0]["title"].ToString() != "")
                {
                    model.title = ds.Tables[0].Rows[0]["title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["category_id"] != null && ds.Tables[0].Rows[0]["category_id"].ToString() != "")
                {
                    model.category_id = int.Parse(ds.Tables[0].Rows[0]["category_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["call_index"] != null && ds.Tables[0].Rows[0]["call_index"].ToString() != "")
                {
                    model.call_index = ds.Tables[0].Rows[0]["call_index"].ToString();
                }
                if (ds.Tables[0].Rows[0]["link_url"] != null && ds.Tables[0].Rows[0]["link_url"].ToString() != "")
                {
                    model.link_url = ds.Tables[0].Rows[0]["link_url"].ToString();
                }
                if (ds.Tables[0].Rows[0]["img_url"] != null && ds.Tables[0].Rows[0]["img_url"].ToString() != "")
                {
                    model.img_url = ds.Tables[0].Rows[0]["img_url"].ToString();
                }
                if (ds.Tables[0].Rows[0]["seo_title"] != null && ds.Tables[0].Rows[0]["seo_title"].ToString() != "")
                {
                    model.seo_title = ds.Tables[0].Rows[0]["seo_title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["seo_keywords"] != null && ds.Tables[0].Rows[0]["seo_keywords"].ToString() != "")
                {
                    model.seo_keywords = ds.Tables[0].Rows[0]["seo_keywords"].ToString();
                }
                if (ds.Tables[0].Rows[0]["seo_description"] != null && ds.Tables[0].Rows[0]["seo_description"].ToString() != "")
                {
                    model.seo_description = ds.Tables[0].Rows[0]["seo_description"].ToString();
                }
                if (ds.Tables[0].Rows[0]["content"] != null && ds.Tables[0].Rows[0]["content"].ToString() != "")
                {
                    model.content = ds.Tables[0].Rows[0]["content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sort_id"] != null && ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["click"] != null && ds.Tables[0].Rows[0]["click"].ToString() != "")
                {
                    model.click = int.Parse(ds.Tables[0].Rows[0]["click"].ToString());
                }
                if (ds.Tables[0].Rows[0]["digg_good"] != null && ds.Tables[0].Rows[0]["digg_good"].ToString() != "")
                {
                    model.digg_good = int.Parse(ds.Tables[0].Rows[0]["digg_good"].ToString());
                }
                if (ds.Tables[0].Rows[0]["digg_act"] != null && ds.Tables[0].Rows[0]["digg_act"].ToString() != "")
                {
                    model.digg_act = int.Parse(ds.Tables[0].Rows[0]["digg_act"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_msg"] != null && ds.Tables[0].Rows[0]["is_msg"].ToString() != "")
                {
                    model.is_msg = int.Parse(ds.Tables[0].Rows[0]["is_msg"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_red"] != null && ds.Tables[0].Rows[0]["is_red"].ToString() != "")
                {
                    model.is_red = int.Parse(ds.Tables[0].Rows[0]["is_red"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_lock"] != null && ds.Tables[0].Rows[0]["is_lock"].ToString() != "")
                {
                    model.is_lock = int.Parse(ds.Tables[0].Rows[0]["is_lock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_time"] != null && ds.Tables[0].Rows[0]["add_time"].ToString() != "")
                {
                    model.add_time = DateTime.Parse(ds.Tables[0].Rows[0]["add_time"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.contents GetModel(string call_index)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id from dt_contents");
            strSql.Append(" where call_index=@call_index");
            OleDbParameter[] parameters = {
					new OleDbParameter("@call_index", OleDbType.VarChar,50)};
            parameters[0].Value = call_index;

            object obj = DbHelperOleDb.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
            {
                return GetModel(Convert.ToInt32(obj));
            }
            return null;
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,channel_id,title,category_id,call_index,link_url,img_url,seo_title,seo_keywords,seo_description,content,sort_id,click,digg_good,digg_act,is_msg,is_red,is_lock,add_time ");
            strSql.Append(" FROM dt_contents ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperOleDb.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM dt_contents");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperOleDb.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperOleDb.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #endregion  Method
    }
}