using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WorksShow.Web.admin.photo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<string> data = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string testid = string.IsNullOrEmpty(Request["id"]) ? "" : Request["id"];
                if (testid == "")
                {

                }
                string sql1 = "select title from dt_photo where id=" + testid;
                string sql2 = "select * from dt_photo_attribute_value where  photo_id=" + testid;
                data.Add(DBUtility.DbHelperOleDb.GetSingle(sql1).ToString());
                var dt = DBUtility.DbHelperOleDb.Query(sql2).Tables[0];
                data.Add(dt.Select("title='性别'")[0]["content"].ToString());
                data.Add(dt.Select("title='年龄'")[0]["content"].ToString());
                data.Add(dt.Select("title='身份证号码'")[0]["content"].ToString());
                data.Add(dt.Select("title='联系电话'")[0]["content"].ToString());
                data.Add(dt.Select("title='详细地址'")[0]["content"].ToString());
                data.Add(dt.Select("title='开户行全称'")[0]["content"].ToString());
                data.Add(dt.Select("title='开户行网银'")[0]["content"].ToString());
                data.Add(dt.Select("title='银行账号'")[0]["content"].ToString());

                string sql3 = "select big_img from dt_photo_album where photo_id=" + testid+" order by id";
                var dt_img = DBUtility.DbHelperOleDb.Query(sql3).Tables[0];
                foreach (DataRow item in dt_img.Rows)
                {
                    data.Add(item["big_img"].ToString());
                }



            }
        }
    }
}