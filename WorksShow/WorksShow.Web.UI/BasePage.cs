using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Configuration;
using WorksShow.Common;

namespace WorksShow.Web.UI
{
    public partial class BasePage : System.Web.UI.Page
    {
        protected internal Model.siteconfig config = new BLL.siteconfig().loadConfig(Utils.GetXmlMapPath(DTKeys.FILE_SITE_XML_CONFING), true);

        /// <summary>
        /// 父类的构造函数
        /// </summary>
        public BasePage()
        {
            ShowPage();
        }

        /// <summary>
        /// 页面处理虚方法
        /// </summary>
        protected virtual void ShowPage()
        {
            //是否关闭网站
            if (config.webstatus == 0)
            {
                HttpContext.Current.Response.Redirect(config.webpath + "error.aspx?msg=" + Utils.UrlEncode(config.webclosereason));
            }
            return;
        }

        #region 页面基本处理方法=====================================================
        /// <summary>
        /// 返回URL重写统一链接地址
        /// </summary>
        protected string linkurl(string _key, params object[] _params)
        {
            Hashtable ht = new BLL.url_rewrite().GetList();
            Model.url_rewrite model = ht[_key] as Model.url_rewrite;
            if (model == null)
            {
                return "";
            }
            try
            {
                string _result = string.Empty;
                string _rewriteurl = string.Format(model.path, _params);
                switch (config.staticstatus)
                {
                    case 1: //URL重写
                        _result = config.webpath + _rewriteurl;
                        break;
                    case 2: //全静态
                        _rewriteurl = _rewriteurl.Substring(0, _rewriteurl.LastIndexOf(".") + 1);
                        _result = config.webpath + DTKeys.DIRECTORY_REWRITE_HTML + "/" + _rewriteurl + config.staticextension;
                        break;
                    default: //不开启
                        string _originalurl = model.page;
                        if (!string.IsNullOrEmpty(model.querystring))
                        {
                            _originalurl = model.page + "?" + Regex.Replace(_rewriteurl, model.pattern, model.querystring, RegexOptions.None | RegexOptions.IgnoreCase);
                        }
                        _result = config.webpath + _originalurl;
                        break;
                }
                return _result;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// 返回分页字符串
        /// </summary>
        /// <param name="pagesize">页面大小</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="totalcount">记录总数</param>
        /// <param name="_key">URL映射Name名称</param>
        /// <param name="_params">传输参数</param>
        protected string get_page_link(int pagesize, int pageindex, int totalcount, string _key, params object[] _params)
        {
            return Utils.OutPageList(pagesize, pageindex, totalcount, linkurl(_key, _params), 8);
        }

        /// <summary>
        /// 返回分页字符串
        /// </summary>
        /// <param name="pagesize">页面大小</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="totalcount">记录总数</param>
        /// <param name="linkurl">链接地址</param>
        protected string get_page_link(int pagesize, int pageindex, int totalcount, string linkurl)
        {
            return Utils.OutPageList(pagesize, pageindex, totalcount, linkurl, 8);
        }
        #endregion

        #region 插件调用方法=========================================================
        /// <summary>
        /// 利用反射调用插件方法
        /// </summary>
        /// <param name="className">类名</param>
        /// <param name="methodName">方法名</param>
        /// <param name="objParas">参数</param>
        /// <returns>DataTable</returns>
        public DataTable get_plugin_method(string assemblyName, string className, string methodName, params object[] objParas)
        {
            DataTable dt = new DataTable();
            try
            {
                Assembly assembly = Assembly.Load(assemblyName);
                object obj = assembly.CreateInstance(assemblyName + "." + className);
                Type t = obj.GetType();
                //查找匹配的方法
                foreach (MethodInfo m in t.GetMethods(BindingFlags.Instance | BindingFlags.Public))
                {
                    if (m.Name == methodName && m.GetParameters().Length == objParas.Length)
                    {
                        object obj2 = m.Invoke(obj, objParas);
                        dt = obj2 as DataTable;
                        return dt;
                    }
                }
            }
            catch
            {
                //插件方法获取失败
            }
            return dt;
        }
        #endregion

        #region 类别调用方法=========================================================
        /// <summary>
        /// 返回当前类别名称
        /// </summary>
        /// <param name="category_id">类别ID</param>
        /// <returns>String</returns>
        protected string get_category_title(int category_id, string default_value)
        {
            BLL.category bll = new BLL.category();
            if (bll.Exists(category_id))
            {
                return bll.GetTitle(category_id);
            }
            return default_value;
        }

        /// <summary>
        /// 递归找到父节点
        /// </summary>
        private void LoopChannelMenu(StringBuilder strTxt, string urlKey, int category_id)
        {
            BLL.category bll = new BLL.category();
            int parentId = bll.GetParentId(category_id);
            if (parentId > 0)
            {
                this.LoopChannelMenu(strTxt, urlKey, parentId);
            }
            strTxt.Append("&nbsp;&gt;&nbsp;<a href=\"" + linkurl(urlKey, category_id, 1) + "\">" + bll.GetTitle(category_id) + "</a>");
        }

        /// <summary>
        /// 返回类别导航面包屑
        /// </summary>
        /// <param name="urlKey">URL重写Name</param>
        /// <param name="category_id">类别ID</param>
        /// <returns>String</returns>
        protected string get_category_menu(string urlKey, int category_id)
        {
            StringBuilder strTxt = new StringBuilder();
            if (category_id > 0)
            {
                LoopChannelMenu(strTxt, urlKey, category_id);
            }
            return strTxt.ToString();
        }

        /// <summary>
        /// 返回类别列表
        /// </summary>
        /// <param name="parent_id">父类别ID</param>
        /// <param name="channel_id">频道ID</param>
        /// <returns>DataTable</returns>
        protected DataTable get_category_list(int channel_id, int parent_id)
        {
            return new BLL.category().GetList(parent_id, channel_id);
        }

        //返回类别UL列表
        //protected string get_category_list(int parent_id, int channel_id)
        //{

        //}
        #endregion

        #region 资讯查询列表=========================================================
        /// <summary>
        /// 资讯列表
        /// </summary>
        /// <param name="channel_id">频道ID</param>
        /// <param name="top">显示条数</param>
        /// <param name="strwhere">查询条件</param>
        /// <returns>DataTable</returns>
        protected DataTable get_article_list(int channel_id, int category_id, int top, string strwhere)
        {
            DataTable dt = new DataTable();
            if (channel_id > 0)
            {
                string _where = "channel_id=" + channel_id;
                if (category_id > 0)
                {
                    _where += " and category_id in(select id from dt_category where channel_id=" + channel_id + " and class_list like '%," + category_id + ",%')";
                }
                if (!string.IsNullOrEmpty(strwhere))
                {
                    _where += " and " + strwhere;
                }
                dt = new BLL.article().GetList(top, _where, "sort_id asc,add_time desc").Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 资讯列表
        /// </summary>
        /// <param name="channel_id">频道ID</param>
        /// <param name="top">显示条数</param>
        /// <param name="strwhere">查询条件</param>
        /// <returns>DataTable</returns>
        protected DataTable get_article_list(int channel_id, int category_id, int top, string strwhere, string orderby)
        {
            DataTable dt = new DataTable();
            if (channel_id > 0)
            {
                string _where = "channel_id=" + channel_id;
                if (category_id > 0)
                {
                    _where += " and category_id in(select id from dt_category where channel_id=" + channel_id + " and class_list like '%," + category_id + ",%')";
                }
                if (!string.IsNullOrEmpty(strwhere))
                {
                    _where += " and " + strwhere;
                }
                dt = new BLL.article().GetList(top, _where, orderby).Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 资讯分页列表
        /// </summary>
        /// <param name="channel_id">频道ID</param>
        /// <param name="page_size">页面大小</param>
        /// <param name="page_index">当前页码</param>
        /// <param name="strwhere">查询条件</param>
        /// <param name="totalcount">总记录数</param>
        /// <returns>DateTable</returns>
        protected DataTable get_article_list(int channel_id, int category_id, int page_size, int page_index, string strwhere, out int totalcount)
        {
            DataTable dt = new DataTable();
            if (channel_id > 0)
            {
                string _where = "channel_id=" + channel_id;
                if (category_id > 0)
                {
                    _where += " and category_id in(select id from dt_category where channel_id=" + channel_id + " and class_list like '%," + category_id + ",%')";
                }
                if (!string.IsNullOrEmpty(strwhere))
                {
                    _where += " and " + strwhere;
                }
                dt = new BLL.article().GetList(page_size, page_index, _where, "sort_id asc,add_time desc", out totalcount).Tables[0];
            }
            else
            {
                totalcount = 0;
            }
            return dt;
        }
        #endregion

        #region 图文查询列表=========================================================
        /// <summary>
        /// 图文列表
        /// </summary>
        /// <param name="channel_id">频道ID</param>
        /// <param name="top">显示条数</param>
        /// <param name="strwhere">查询条件</param>
        /// <returns>DataTable</returns>
        protected DataTable get_photo_list(int channel_id, int category_id, int top, string strwhere)
        {
            DataTable dt = new DataTable();
            if (channel_id > 0)
            {
                string _where = "channel_id=" + channel_id;
                if (category_id > 0)
                {
                    _where += " and category_id in(select id from dt_category where channel_id=" + channel_id + " and class_list like '%," + category_id + ",%')";
                }
                if (!string.IsNullOrEmpty(strwhere))
                {
                    _where += " and " + strwhere;
                }
                dt = new BLL.photo().GetList(top, _where, "sort_id asc,add_time desc").Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 图文列表
        /// </summary>
        /// <param name="channel_id">频道ID</param>
        /// <param name="top">显示条数</param>
        /// <param name="strwhere">查询条件</param>
        /// <returns>DataTable</returns>
        protected DataTable get_photo_list(int channel_id, int category_id, int top, string strwhere, string orderby)
        {
            DataTable dt = new DataTable();
            if (channel_id > 0)
            {
                string _where = "channel_id=" + channel_id;
                if (category_id > 0)
                {
                    _where += " and category_id in(select id from dt_category where channel_id=" + channel_id + " and class_list like '%," + category_id + ",%')";
                }
                if (!string.IsNullOrEmpty(strwhere))
                {
                    _where += " and " + strwhere;
                }
                dt = new BLL.photo().GetList(top, _where, orderby).Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 图文分页列表
        /// </summary>
        /// <param name="channel_id">频道ID</param>
        /// <param name="page_size">页面大小</param>
        /// <param name="page_index">当前页码</param>
        /// <param name="strwhere">查询条件</param>
        /// <param name="totalcount">总记录数</param>
        /// <returns>DateTable</returns>
        protected DataTable get_photo_list(int channel_id, int category_id, int page_size, int page_index, string strwhere, out int totalcount)
        {
            DataTable dt = new DataTable();
            if (channel_id > 0)
            {
                string _where = "channel_id=" + channel_id;
                if (category_id > 0)
                {
                    _where += " and category_id in(select id from dt_category where channel_id=" + channel_id + " and class_list like '%," + category_id + ",%')";
                }
                if (!string.IsNullOrEmpty(strwhere))
                {
                    _where += " and " + strwhere;
                }
                dt = new BLL.photo().GetList(page_size, page_index, _where, "sort_id asc,add_time desc", out totalcount).Tables[0];
            }
            else
            {
                totalcount = 0;
            }
            return dt;
        }
        #endregion

        #region 下载查询列表=========================================================
        /// <summary>
        /// 下载列表
        /// </summary>
        /// <param name="channel_id">频道ID</param>
        /// <param name="top">显示条数</param>
        /// <param name="strwhere">查询条件</param>
        /// <returns>DataTable</returns>
        protected DataTable get_download_list(int channel_id, int category_id, int top, string strwhere)
        {
            DataTable dt = new DataTable();
            if (channel_id > 0)
            {
                string _where = "channel_id=" + channel_id;
                if (category_id > 0)
                {
                    _where += " and category_id in(select id from dt_category where channel_id=" + channel_id + " and class_list like '%," + category_id + ",%')";
                }
                if (!string.IsNullOrEmpty(strwhere))
                {
                    _where += " and " + strwhere;
                }
                dt = new BLL.download().GetList(top, _where, "sort_id asc,add_time desc").Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 下载列表
        /// </summary>
        /// <param name="channel_id">频道ID</param>
        /// <param name="top">显示条数</param>
        /// <param name="strwhere">查询条件</param>
        /// <returns>DataTable</returns>
        protected DataTable get_download_list(int channel_id, int category_id, int top, string strwhere, string orderby)
        {
            DataTable dt = new DataTable();
            if (channel_id > 0)
            {
                string _where = "channel_id=" + channel_id;
                if (category_id > 0)
                {
                    _where += " and category_id in(select id from dt_category where channel_id=" + channel_id + " and class_list like '%," + category_id + ",%')";
                }
                if (!string.IsNullOrEmpty(strwhere))
                {
                    _where += " and " + strwhere;
                }
                dt = new BLL.download().GetList(top, _where, orderby).Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 下载分页列表
        /// </summary>
        /// <param name="channel_id">频道ID</param>
        /// <param name="page_size">页面大小</param>
        /// <param name="page_index">当前页码</param>
        /// <param name="strwhere">查询条件</param>
        /// <param name="totalcount">总记录数</param>
        /// <returns>DateTable</returns>
        protected DataTable get_download_list(int channel_id, int category_id, int page_size, int page_index, string strwhere, out int totalcount)
        {
            DataTable dt = new DataTable();
            if (channel_id > 0)
            {
                string _where = "channel_id=" + channel_id;
                if (category_id > 0)
                {
                    _where += " and category_id in(select id from dt_category where channel_id=" + channel_id + " and class_list like '%," + category_id + ",%')";
                }
                if (!string.IsNullOrEmpty(strwhere))
                {
                    _where += " and " + strwhere;
                }
                dt = new BLL.download().GetList(page_size, page_index, _where, "sort_id asc,add_time desc", out totalcount).Tables[0];
            }
            else
            {
                totalcount = 0;
            }
            return dt;
        }
        #endregion

        #region 内容查询列表=========================================================
        /// <summary>
        /// 根据调用标识取得内容页内容
        /// </summary>
        /// <param name="call_index">调用标识</param>
        /// <returns></returns>
        protected string get_content(string call_index)
        {
            if (string.IsNullOrEmpty(call_index))
                return "";
            WorksShow.BLL.contents bll = new WorksShow.BLL.contents();
            if (bll.Exists(call_index))
            {
                return bll.GetModel(call_index).content;
            }
            return "";
        }

        /// <summary>
        /// 内容列表
        /// </summary>
        /// <param name="channel_id">频道ID</param>
        /// <param name="top">显示条数</param>
        /// <param name="strwhere">查询条件</param>
        /// <returns>DataTable</returns>
        protected DataTable get_content_list(int channel_id, int category_id, int top, string strwhere)
        {
            DataTable dt = new DataTable();
            if (channel_id > 0)
            {
                string _where = "channel_id=" + channel_id;
                if (category_id > 0)
                {
                    _where += " and category_id in(select id from dt_category where channel_id=" + channel_id + " and class_list like '%," + category_id + ",%')";
                }
                if (!string.IsNullOrEmpty(strwhere))
                {
                    _where += " and " + strwhere;
                }
                dt = new BLL.contents().GetList(top, _where, "sort_id asc,add_time desc").Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 内容列表
        /// </summary>
        /// <param name="channel_id">频道ID</param>
        /// <param name="top">显示条数</param>
        /// <param name="strwhere">查询条件</param>
        /// <returns>DataTable</returns>
        protected DataTable get_content_list(int channel_id, string category_id_str, int top, string strwhere)
        {
            DataTable dt = new DataTable();
            int category_id = int.Parse(category_id_str);
            if (channel_id > 0)
            {
                string _where = "channel_id=" + channel_id;
                if (category_id > 0)
                {
                    _where += " and category_id in(select id from dt_category where channel_id=" + channel_id + " and class_list like '%," + category_id + ",%')";
                }
                if (!string.IsNullOrEmpty(strwhere))
                {
                    _where += " and " + strwhere;
                }
                dt = new BLL.contents().GetList(top, _where, "sort_id asc,add_time desc").Tables[0];
            }
            return dt;
        }


        /// <summary>
        /// 内容列表
        /// </summary>
        /// <param name="channel_id">频道ID</param>
        /// <param name="top">显示条数</param>
        /// <param name="strwhere">查询条件</param>
        /// <returns>DataTable</returns>
        protected DataTable get_content_list(int channel_id, int category_id, int top, string strwhere, string orderby)
        {
            DataTable dt = new DataTable();
            if (channel_id > 0)
            {
                string _where = "channel_id=" + channel_id;
                if (category_id > 0)
                {
                    _where += " and category_id in(select id from dt_category where channel_id=" + channel_id + " and class_list like '%," + category_id + ",%')";
                }
                if (!string.IsNullOrEmpty(strwhere))
                {
                    _where += " and " + strwhere;
                }
                dt = new BLL.contents().GetList(top, _where, orderby).Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 内容分页列表
        /// </summary>
        /// <param name="channel_id">频道ID</param>
        /// <param name="page_size">页面大小</param>
        /// <param name="page_index">当前页码</param>
        /// <param name="strwhere">查询条件</param>
        /// <param name="totalcount">总记录数</param>
        /// <returns>DateTable</returns>
        protected DataTable get_content_list(int channel_id, int category_id, int page_size, int page_index, string strwhere, out int totalcount)
        {
            DataTable dt = new DataTable();
            if (channel_id > 0)
            {
                string _where = "channel_id=" + channel_id;
                if (category_id > 0)
                {
                    _where += " and category_id in(select id from dt_category where channel_id=" + channel_id + " and class_list like '%," + category_id + ",%')";
                }
                if (!string.IsNullOrEmpty(strwhere))
                {
                    _where += " and " + strwhere;
                }
                dt = new BLL.contents().GetList(page_size, page_index, _where, "sort_id asc,add_time desc", out totalcount).Tables[0];
            }
            else
            {
                totalcount = 0;
            }
            return dt;
        }
        #endregion

        #region 评论查询列表=========================================================
        /// <summary>
        /// 评论数据总数
        /// </summary>
        /// <param name="channel_id">频道ID</param>
        /// <param name="content_id">信息ID</param>
        /// <param name="strwhere">查询条件</param>
        /// <returns>Int</returns>
        protected int get_comment_count(int channel_id, int content_id, string strwhere)
        {
            int count = 0;
            if (channel_id > 0 && content_id > 0)
            {
                string _where = string.Format("channel_id={0} and content_id={1}", channel_id, content_id);
                if (!string.IsNullOrEmpty(strwhere))
                {
                    _where += " and " + strwhere;
                }
                count = new BLL.comment().GetCount(_where);
            }
            return count;
        }

        /// <summary>
        /// 评论列表
        /// </summary>
        /// <param name="channel_id">频道ID</param>
        /// <param name="content_id">信息ID</param>
        /// <param name="top">显示条数</param>
        /// <param name="strwhere">查询条件</param>
        /// <returns>DateTable</returns>
        protected DataTable get_comment_list(int channel_id, int content_id, int top, string strwhere)
        {
            DataTable dt = new DataTable();
            if (channel_id > 0 && content_id > 0)
            {
                string _where = string.Format("channel_id={0} and content_id={1}", channel_id, content_id);
                if (!string.IsNullOrEmpty(strwhere))
                {
                    _where += " and " + strwhere;
                }
                dt = new BLL.comment().GetList(top, _where, "add_time desc").Tables[0];
            }
            return dt;
        }

        /// <summary>
        /// 评论分页列表
        /// </summary>
        /// <param name="channel_id">频道ID</param>
        /// <param name="content_id">信息ID</param>
        /// <param name="page_size">页面大小</param>
        /// <param name="page_index">当前页码</param>
        /// <param name="strwhere">查询条件</param>
        /// <param name="totalcount">总记录数</param>
        /// <returns>DateTable</returns>
        protected DataTable get_comment_list(int channel_id, int content_id, int page_size, int page_index, string strwhere, out int totalcount)
        {
            DataTable dt = new DataTable();
            if (channel_id > 0 && content_id > 0)
            {
                string _where = string.Format("channel_id={0} and content_id={1}", channel_id, content_id);
                if (!string.IsNullOrEmpty(strwhere))
                {
                    _where += " and " + strwhere;
                }
                dt = new BLL.comment().GetList(page_size, page_index, _where, "add_time desc", out totalcount).Tables[0];
            }
            else
            {
                totalcount = 0;
            }
            return dt;
        }
        #endregion

        /// <summary>
        /// 返回资讯的ID，用于上一条或下一条链接
        /// </summary>
        protected string GetArticleTitle(string _where)
        {
            WorksShow.BLL.article bll = new BLL.article();
            DataSet ds = bll.GetList(1, _where, "Id desc");
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["title"].ToString();
            }
            return "";
        }
        /// <summary>
        /// 返回资讯的ID，用于上一条或下一条链接
        /// </summary>
        protected int GetArticleId(string _where)
        {
            WorksShow.BLL.article bll = new BLL.article();
            DataSet ds = bll.GetList(1, _where, "Id desc");
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
            }
            return -1;
        }
        protected string GetBigImgUrl(int id)
        {
            string sql = "select big_img from dt_photo_album where photo_id=" + id;
            return DBUtility.DbHelperOleDb.GetSingle(sql).ToString();

        }
        protected string GetJiuPinPinTai()
        {
            StringBuilder sbOutPut = new StringBuilder();
            var TiaoMuList = get_photo_list(11, 39, 30, "", " add_time desc");
            foreach (DataRow item in TiaoMuList.Rows)
            {
                string sql = "select * from dt_photo_attribute_value where photo_id=" + item["id"].ToString();
                var dt_jibendetail = DBUtility.DbHelperOleDb.Query(sql).Tables[0];
                sbOutPut.Append("<tr><td>" + (dt_jibendetail.Select("title='酒品代码'").Length == 0 ? "&nbsp;" : dt_jibendetail.Select("title='酒品代码'")[0]["content"].ToString()) + "</td>");
                sbOutPut.Append("<td><a href='#' title='" + item["title"].ToString() + "'>" + (item["title"].ToString().Length > 4 ? item["title"].ToString().Substring(0, 4) : item["title"].ToString()) + "</td>");
                sbOutPut.Append("<td>" + (dt_jibendetail.Select("title='最新价'").Length == 0 ? "&nbsp;" : dt_jibendetail.Select("title='最新价'")[0]["content"].ToString()) + "</td>");
                sbOutPut.Append("<td>" + (dt_jibendetail.Select("title='涨跌'").Length == 0 ? "&nbsp;" : dt_jibendetail.Select("title='涨跌'")[0]["content"].ToString()) + "</td>");
                sbOutPut.Append("<td>" + (dt_jibendetail.Select("title='成交量'").Length == 0 ? "&nbsp;" : dt_jibendetail.Select("title='成交量'")[0]["content"].ToString()) + "</td>");
                sbOutPut.Append("<td>" + (dt_jibendetail.Select("title='成交金额'").Length == 0 ? "&nbsp;" : dt_jibendetail.Select("title='成交金额'")[0]["content"].ToString()) + "</td>");
                sbOutPut.Append("<td>" + (dt_jibendetail.Select("title='库存量'").Length == 0 ? "&nbsp;" : dt_jibendetail.Select("title='库存量'")[0]["content"].ToString()) + "</td>");
                sbOutPut.Append("<td>" + (dt_jibendetail.Select("title='厂方指导价'").Length == 0 ? "&nbsp;" : dt_jibendetail.Select("title='厂方指导价'")[0]["content"].ToString()) + "</td>");
                sbOutPut.Append("</tr>");
            }
            return sbOutPut.ToString();
        }
        protected string GetShouYePic()
        {
            var TiaoMuList = get_photo_list(9, 38, 3, "");
            List<string> li = new List<string>();
            int count = 0;
            foreach (DataRow item in TiaoMuList.Rows)
            {
                if (count == 2)
                {
                    break;
                }
                string sql = "select top 1 big_img from dt_photo_album where photo_id=" + item["id"].ToString() + " order by id";
                string imgurl = DBUtility.DbHelperOleDb.GetSingle(sql).ToString();
                li.Add(imgurl);
                count++;
            }
            string str1 = @"<div class='p-home-banner p-selected-view' id='p-banner-1'>
							<div class='p-banner1-1-1'>
								<h1><a href='#'><img src='" + (li.Count >= 1 ? li[0] : "") + @"' alt='' class='p-banner-wenzi' ></a></h1>
								<p class='p-subtittle'><em></em></p>
							</div>
    						</div>";
            string str2 = @"<div class='p-home-banner p-alternate' id='p-banner-2'>
							<div class='p-banner1-1-1'>
								<h2><a href='#'><img src='" + (li.Count >= 2 ? li[1] : "") + @"' alt='' class='p-banner-wenzi' /></a></h2>
								<p class='p-subtittle'><em></em></p>
							</div>    
						</div>";
            string str3 = @"<div class='p-home-banner' id='p-banner-3'>
							<div class='p-banner1-1-1'>
								<h2><a href='#'><img src='" + (li.Count >= 3 ? li[2] : "") + @"' alt='' class='p-banner-wenzi'></a></h2>
								<p class='p-subtittle'><em><span></span></em></p>
							</div>    
						</div>";

            string output = (li.Count >= 1 ? str1 : "") + (li.Count >= 2 ? str2 : "") + (li.Count >= 3 ? str3 : "");
            return output.ToString();
        }

        protected string GetShouYePic2()
        {
            var TiaoMuList = get_photo_list(9, 38, 3, "");
            List<string> li1 = new List<string>();
            List<string> li2 = new List<string>();
            int count = 0;
            foreach (DataRow item in TiaoMuList.Rows)
            {
                if (count == 2)
                {
                    break;
                }
                string sql = "select top 1 small_img,big_img from dt_photo_album where photo_id=" + item["id"].ToString() + " order by id";
                DataTable dt = DBUtility.DbHelperOleDb.Query(sql).Tables[0];
                li1.Add(dt.Rows[0]["big_img"].ToString()); li2.Add(dt.Rows[0]["small_img"].ToString());
                count++;
            }
            string str1 = @"#p-banner-1{background: #EDEDED url(" + (li1.Count >= 1 ? li1[0] : "") + @") repeat-x 50% 0px;}
                                   #p-top-banner .p-banner-small-1{background: url(" + (li1.Count >= 1 ? li2[0] : "") + @") no-repeat 0 80%;}";
            string str2 = @"#p-banner-2{background: #EDEDED url(" + (li1.Count >= 2 ? li1[1] : "") + @") repeat-x 50% 0px ;}
                               #p-top-banner .p-banner-small-2{background: url(" + (li1.Count >= 2 ? li2[1] : "") + @") no-repeat 0px 80%;}";
            string str3 = @"#p-banner-3{background: #EDEDED url(" + (li1.Count >= 3 ? li1[2] : "") + @") repeat-x 50% 0px;}
                                  #p-top-banner .p-banner-small-3{background: url(" + (li1.Count >= 3 ? li2[2] : "") + @") no-repeat 0px 50%;}";

            string output = str1 + str2 + str3;
            return output.ToString();
        }

        protected string GetShouYePic3(out string strOutPut2)
        {
            strOutPut2 = "";
            var TiaoMuList = get_photo_list(9, 38, 3, "");
            List<string> li = new List<string>();
            int count = 0;
            foreach (DataRow item in TiaoMuList.Rows)
            {
                if (count == 3)
                {
                    break;
                }
                string sql = "select top 1 big_img from dt_photo_album where photo_id=" + item["id"].ToString() + " order by id";
                string imgurl = DBUtility.DbHelperOleDb.GetSingle(sql).ToString();
                li.Add(imgurl);
                count++;
            }
            string outPut = "";
            int countOutPut = 0;
            foreach (string item2 in li)
            {
                outPut += @"<a href='#'>
                            <img src='" + item2 + "' alt='' width='1000' height='263' /></a>";
                strOutPut2 += @"$('#btnlistID li :eq(" + countOutPut + ")').width(90).height(51).html(\"<img src='" + item2 + "' width='90' height='51'>\");";
                countOutPut++;
            }
            return outPut;
        }

        protected List<string> GetJingPinPics(int id)
        {
            List<string> li = new List<string>();
            string sql = "select big_img from dt_photo_album where photo_id=" + id + " order by id";
            DataTable imgurl_dt = DBUtility.DbHelperOleDb.Query(sql).Tables[0];
            foreach (DataRow item_img in imgurl_dt.Rows)
            {
                li.Add(item_img["big_img"].ToString());
            }
            return li;
        }
        protected Dictionary<string,string> GetAnLiPics()
        {
            var TiaoMuList = get_photo_list(14, 46, 99, "","id asc ,add_time asc");
            Dictionary<string, string> li = new Dictionary<string, string>();
            
            string sql1 = "select big_img from dt_photo_album where photo_id=" + 68 + " order by id";
            DataTable imgurl_dt1 = DBUtility.DbHelperOleDb.Query(sql1).Tables[0];
            foreach (DataRow item_img in imgurl_dt1.Rows)
            {
                li.Add(item_img["big_img"].ToString(), "../anlifirst.aspx");
            }
            
            foreach (DataRow item in TiaoMuList.Rows)
            {
                if (item["id"].ToString() =="68")
                {
                    continue;
                }
                string sql = "select big_img from dt_photo_album where photo_id=" + item["id"].ToString() + " order by id";
                DataTable imgurl_dt = DBUtility.DbHelperOleDb.Query(sql).Tables[0];
                foreach (DataRow item_img in imgurl_dt.Rows)
                {
                    li.Add(item_img["big_img"].ToString(), item["link_url"].ToString());
                }
            }
            return li;
        }
        protected string GetPicContent(int id)
        {
            string sql = "select content from dt_photo where id=" + id + " order by id";
            object obj = DBUtility.DbHelperOleDb.GetSingle(sql);
            return obj == null ? "" : obj.ToString();
        }
        protected Dictionary<string, string> GetShouYePics()
        {
            var TiaoMuList = get_photo_list(14, 52, 99, "", "id asc ,add_time asc");
            Dictionary<string, string> li = new Dictionary<string, string>();

            foreach (DataRow item in TiaoMuList.Rows)
            {
                string sql = "select big_img from dt_photo_album where photo_id=" + item["id"].ToString() + " order by id";
                DataTable imgurl_dt = DBUtility.DbHelperOleDb.Query(sql).Tables[0];
                foreach (DataRow item_img in imgurl_dt.Rows)
                {
                    li.Add(item_img["big_img"].ToString(), item["link_url"].ToString());
                }
            }
            return li;
        }
    }
}
