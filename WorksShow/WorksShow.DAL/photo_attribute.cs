using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.OleDb;
using WorksShow.DBUtility;
namespace WorksShow.DAL
{
    /// <summary>
    /// 数据访问类:图文属性模型
    /// </summary>
    public partial class photo_attribute
    {
        public photo_attribute()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_photo_attribute");
            strSql.Append(" where id=@id ");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            return DbHelperOleDb.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(WorksShow.Model.photo_attribute model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dt_photo_attribute(");
            strSql.Append("channel_id,title,remark,type,default_value,sort_id,add_time)");
            strSql.Append(" values (");
            strSql.Append("@channel_id,@title,@remark,@type,@default_value,@sort_id,@add_time)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@channel_id", OleDbType.Integer,4),
					new OleDbParameter("@title", OleDbType.VarChar,100),
					new OleDbParameter("@remark", OleDbType.VarChar,500),
					new OleDbParameter("@type", OleDbType.Integer,4),
					new OleDbParameter("@default_value", OleDbType.VarChar,500),
					new OleDbParameter("@sort_id", OleDbType.Integer,4),
					new OleDbParameter("@add_time", OleDbType.Date)};
            parameters[0].Value = model.channel_id;
            parameters[1].Value = model.title;
            parameters[2].Value = model.remark;
            parameters[3].Value = model.type;
            parameters[4].Value = model.default_value;
            parameters[5].Value = model.sort_id;
            parameters[6].Value = model.add_time;

            int rows = DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WorksShow.Model.photo_attribute model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_photo_attribute set ");
            strSql.Append("channel_id=@channel_id,");
            strSql.Append("title=@title,");
            strSql.Append("remark=@remark,");
            strSql.Append("type=@type,");
            strSql.Append("default_value=@default_value,");
            strSql.Append("sort_id=@sort_id,");
            strSql.Append("add_time=@add_time");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@channel_id", OleDbType.Integer,4),
					new OleDbParameter("@title", OleDbType.VarChar,100),
					new OleDbParameter("@remark", OleDbType.VarChar,500),
					new OleDbParameter("@type", OleDbType.Integer,4),
					new OleDbParameter("@default_value", OleDbType.VarChar,500),
					new OleDbParameter("@sort_id", OleDbType.Integer,4),
					new OleDbParameter("@add_time", OleDbType.Date),
                    new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = model.channel_id;
            parameters[1].Value = model.title;
            parameters[2].Value = model.remark;
            parameters[3].Value = model.type;
            parameters[4].Value = model.default_value;
            parameters[5].Value = model.sort_id;
            parameters[6].Value = model.add_time;
            parameters[7].Value = model.id;

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
        public bool Delete(int id)
        {
            Hashtable sqllist = new Hashtable();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from dt_photo_attribute_value ");
            strSql.Append(" where attribute_id=@attribute_id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@attribute_id", OleDbType.Integer,4)};
            parameters[0].Value = id;
            sqllist.Add(strSql.ToString(), parameters);

            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("delete from dt_photo_attribute ");
            strSql2.Append(" where id=@id");
            OleDbParameter[] parameters2 = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters2[0].Value = id;
            sqllist.Add(strSql2.ToString(), parameters2);

            bool result = DbHelperOleDb.ExecuteSqlTran(sqllist);
            return result;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WorksShow.Model.photo_attribute GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,channel_id,title,remark,type,default_value,sort_id,add_time from dt_photo_attribute ");
            strSql.Append(" where id=@id");
            OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
            parameters[0].Value = id;

            WorksShow.Model.photo_attribute model = new WorksShow.Model.photo_attribute();
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
                model.title = ds.Tables[0].Rows[0]["title"].ToString();
                model.remark = ds.Tables[0].Rows[0]["remark"].ToString();
                if (ds.Tables[0].Rows[0]["type"].ToString() != "")
                {
                    model.type = int.Parse(ds.Tables[0].Rows[0]["type"].ToString());
                }
                model.default_value = ds.Tables[0].Rows[0]["default_value"].ToString();
                if (ds.Tables[0].Rows[0]["sort_id"].ToString() != "")
                {
                    model.sort_id = int.Parse(ds.Tables[0].Rows[0]["sort_id"].ToString());
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
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,channel_id,title,remark,type,default_value,sort_id,add_time ");
            strSql.Append(" FROM dt_photo_attribute ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by sort_id asc,add_time desc");
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
            strSql.Append(" id,channel_id,title,remark,type,default_value,sort_id,add_time ");
            strSql.Append(" FROM dt_photo_attribute ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperOleDb.Query(strSql.ToString());
        }

        #endregion  Method
    }
}