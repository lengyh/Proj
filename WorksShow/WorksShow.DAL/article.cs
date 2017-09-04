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
    /// 数据访问类:资讯
    /// </summary>
    public partial class article
    {
        public article()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_article");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;
            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dt_article(");
            strSql.Append("channel_id,category_id,title,author,form,zhaiyao,link_url,img_url,seo_title,seo_keywords,seo_description,content,sort_id,click,is_msg,is_top,is_red,is_hot,is_slide,is_lock,add_time,digg_good,digg_act)");
            strSql.Append(" values (");
            strSql.Append("@channel_id,@category_id,@title,@author,@form,@zhaiyao,@link_url,@img_url,@seo_title,@seo_keywords,@seo_description,@content,@sort_id,@click,@is_msg,@is_top,@is_red,@is_hot,@is_slide,@is_lock,@add_time,@digg_good,@digg_act)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@channel_id", OleDbType.Integer,4),
					new OleDbParameter("@category_id", OleDbType.Integer,4),
					new OleDbParameter("@title", OleDbType.VarChar,100),
					new OleDbParameter("@author", OleDbType.VarChar,255),
					new OleDbParameter("@form", OleDbType.VarChar,50),
					new OleDbParameter("@zhaiyao", OleDbType.VarChar,255),
					new OleDbParameter("@link_url", OleDbType.VarChar,255),
					new OleDbParameter("@img_url", OleDbType.VarChar,255),
					new OleDbParameter("@seo_title", OleDbType.VarChar,255),
					new OleDbParameter("@seo_keywords", OleDbType.VarChar,255),
					new OleDbParameter("@seo_description", OleDbType.VarChar,255),
					new OleDbParameter("@content", OleDbType.VarChar),
					new OleDbParameter("@sort_id", OleDbType.Integer,4),
					new OleDbParameter("@click", OleDbType.Integer,4),
					new OleDbParameter("@is_msg", OleDbType.Integer,4),
					new OleDbParameter("@is_top", OleDbType.Integer,4),
					new OleDbParameter("@is_red", OleDbType.Integer,4),
					new OleDbParameter("@is_hot", OleDbType.Integer,4),
					new OleDbParameter("@is_slide", OleDbType.Integer,4),
					new OleDbParameter("@is_lock", OleDbType.Integer,4),
					new OleDbParameter("@add_time", OleDbType.Date),
                    new OleDbParameter("@digg_good", OleDbType.Integer,4),
					new OleDbParameter("@digg_act", OleDbType.Integer,4)};
            parameters[0].Value = model.channel_id;
            parameters[1].Value = model.category_id;
            parameters[2].Value = model.title;
            parameters[3].Value = model.author;
            parameters[4].Value = model.form;
            parameters[5].Value = model.zhaiyao;
            parameters[6].Value = model.link_url;
            parameters[7].Value = model.img_url;
            parameters[8].Value = model.seo_title;
            parameters[9].Value = model.seo_keywords;
            parameters[10].Value = model.seo_description;
            parameters[11].Value = model.content;
            parameters[12].Value = model.sort_id;
            parameters[13].Value = model.click;
            parameters[14].Value = model.is_msg;
            parameters[15].Value = model.is_top;
            parameters[16].Value = model.is_red;
            parameters[17].Value = model.is_hot;
            parameters[18].Value = model.is_slide;
            parameters[19].Value = model.is_lock;
            parameters[20].Value = model.add_time;
            parameters[21].Value = model.digg_good;
            parameters[22].Value = model.digg_act;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_article set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.article model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_article set ");
            strSql.Append("channel_id=@channel_id,");
            strSql.Append("category_id=@category_id,");
            strSql.Append("title=@title,");
            strSql.Append("author=@author,");
            strSql.Append("form=@form,");
            strSql.Append("zhaiyao=@zhaiyao,");
            strSql.Append("link_url=@link_url,");
            strSql.Append("img_url=@img_url,");
            strSql.Append("seo_title=@seo_title,");
            strSql.Append("seo_keywords=@seo_keywords,");
            strSql.Append("seo_description=@seo_description,");
            strSql.Append("content=@content,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("click=@click,");
            strSql.Append("is_msg=@is_msg,");
            strSql.Append("is_top=@is_top,");
            strSql.Append("is_red=@is_red,");
            strSql.Append("is_hot=@is_hot,");
            strSql.Append("is_slide=@is_slide,");
            strSql.Append("is_lock=@is_lock,");
            strSql.Append("add_time=@add_time,");
            strSql.Append("digg_good=@digg_good,");
            strSql.Append("digg_act=@digg_act");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@channel_id", OleDbType.Integer,4),
					new OleDbParameter("@category_id", OleDbType.Integer,4),
					new OleDbParameter("@title", OleDbType.VarChar,100),
					new OleDbParameter("@author", OleDbType.VarChar,255),
					new OleDbParameter("@form", OleDbType.VarChar,50),
					new OleDbParameter("@zhaiyao", OleDbType.VarChar,255),
					new OleDbParameter("@link_url", OleDbType.VarChar,255),
					new OleDbParameter("@img_url", OleDbType.VarChar,255),
					new OleDbParameter("@seo_title", OleDbType.VarChar,255),
					new OleDbParameter("@seo_keywords", OleDbType.VarChar,255),
					new OleDbParameter("@seo_description", OleDbType.VarChar,255),
					new OleDbParameter("@content", OleDbType.VarChar),
					new OleDbParameter("@sort_id", OleDbType.Integer,4),
					new OleDbParameter("@click", OleDbType.Integer,4),
					new OleDbParameter("@is_msg", OleDbType.Integer,4),
					new OleDbParameter("@is_top", OleDbType.Integer,4),
					new OleDbParameter("@is_red", OleDbType.Integer,4),
					new OleDbParameter("@is_hot", OleDbType.Integer,4),
					new OleDbParameter("@is_slide", OleDbType.Integer,4),
					new OleDbParameter("@is_lock", OleDbType.Integer,4),
					new OleDbParameter("@add_time", OleDbType.Date),
                    new OleDbParameter("@digg_good", OleDbType.Integer,4),
					new OleDbParameter("@digg_act", OleDbType.Integer,4),
                    new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = model.channel_id;
            parameters[1].Value = model.category_id;
            parameters[2].Value = model.title;
            parameters[3].Value = model.author;
            parameters[4].Value = model.form;
            parameters[5].Value = model.zhaiyao;
            parameters[6].Value = model.link_url;
            parameters[7].Value = model.img_url;
            parameters[8].Value = model.seo_title;
            parameters[9].Value = model.seo_keywords;
            parameters[10].Value = model.seo_description;
            parameters[11].Value = model.content;
            parameters[12].Value = model.sort_id;
            parameters[13].Value = model.click;
            parameters[14].Value = model.is_msg;
            parameters[15].Value = model.is_top;
            parameters[16].Value = model.is_red;
            parameters[17].Value = model.is_hot;
            parameters[18].Value = model.is_slide;
            parameters[19].Value = model.is_lock;
            parameters[20].Value = model.add_time;
            parameters[21].Value = model.digg_good;
            parameters[22].Value = model.digg_act;
            parameters[23].Value = model.id;

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
            strSql.Append("delete from dt_article ");
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
        public Model.article GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,channel_id,category_id,title,author,form,zhaiyao,link_url,img_url,seo_title,seo_keywords,seo_description,content,sort_id,click,digg_good,digg_act,is_msg,is_top,is_red,is_hot,is_slide,is_lock,add_time from dt_article ");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            Model.article model = new Model.article();
            DataSet ds = DbHelperOleDb.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["channel_id"].ToString() != "")
                {
                    model.channel_id = int.Parse(ds.Tables[0].Rows[0]["channel_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["category_id"].ToString() != "")
                {
                    model.category_id = int.Parse(ds.Tables[0].Rows[0]["category_id"].ToString());
                }
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.author = ds.Tables[0].Rows[0]["author"].ToString();
                model.form = ds.Tables[0].Rows[0]["form"].ToString();
                model.zhaiyao = ds.Tables[0].Rows[0]["zhaiyao"].ToString();
                model.link_url = ds.Tables[0].Rows[0]["link_url"].ToString();
                model.img_url = ds.Tables[0].Rows[0]["img_url"].ToString();
                model.seo_title = ds.Tables[0].Rows[0]["seo_title"].ToString();
                model.seo_keywords = ds.Tables[0].Rows[0]["seo_keywords"].ToString();
                model.seo_description = ds.Tables[0].Rows[0]["seo_description"].ToString();
                model.content = ds.Tables[0].Rows[0]["content"].ToString();
                if (ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["click"].ToString() != "")
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
                if (ds.Tables[0].Rows[0]["is_msg"].ToString() != "")
                {
                    model.is_msg = int.Parse(ds.Tables[0].Rows[0]["is_msg"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_top"].ToString() != "")
                {
                    model.is_top = int.Parse(ds.Tables[0].Rows[0]["is_top"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_red"].ToString() != "")
                {
                    model.is_red = int.Parse(ds.Tables[0].Rows[0]["is_red"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_hot"].ToString() != "")
                {
                    model.is_hot = int.Parse(ds.Tables[0].Rows[0]["is_hot"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_slide"].ToString() != "")
                {
                    model.is_slide = int.Parse(ds.Tables[0].Rows[0]["is_slide"].ToString());
                }
                if (ds.Tables[0].Rows[0]["is_lock"].ToString() != "")
                {
                    model.is_lock = int.Parse(ds.Tables[0].Rows[0]["is_lock"].ToString());
                }
                if (ds.Tables[0].Rows[0]["add_time"].ToString() != "")
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
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(int maxNum,string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            //strSql.Append("select id,channel_id,category_id,title,author,form,zhaiyao,link_url,img_url,seo_title,seo_keywords,seo_description,content,sort_id,click,digg_good,digg_act,is_msg,is_top,is_red,is_hot,is_slide,is_lock,add_time ");
            strSql.Append("SELECT ");
            if (maxNum != 0)
            {
                strSql.Append(" TOP " + maxNum);
            }
            strSql.Append(" T1.id, T1.channel_id, T1.category_id, T1.title, T1.author, T1.form, T1.zhaiyao, T1.link_url, T1.img_url, T1.content,T1.is_top ,T1.sort_id,T1.add_time, T2.title AS levelTitle, T3.title AS termsTitle, T3.content AS termsContent ");
            //strSql.Append(" FROM dt_article ");
            strSql.Append(" FROM ((dt_article T1 LEFT OUTER JOIN dt_category T2 ON T1.category_id = T2.id) LEFT OUTER JOIN dt_category T3 ON T2.parent_id = T3.id) ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where T1." + strWhere);
            }
            strSql.Append(" order by T1.is_top desc,T1.category_id asc,T1.sort_id asc,T1.add_time desc");
            return DbHelperOleDb.Query(strSql.ToString());
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
            strSql.Append(" id,channel_id,category_id,title,author,form,zhaiyao,link_url,img_url,seo_title,seo_keywords,seo_description,content,sort_id,click,digg_good,digg_act,is_msg,is_top,is_red,is_hot,is_slide,is_lock,add_time ");
            strSql.Append(" FROM dt_article ");
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
            strSql.Append("select * FROM dt_article");
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