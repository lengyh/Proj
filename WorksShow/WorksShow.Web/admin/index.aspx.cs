﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorksShow.Common;
using System.Configuration;

namespace WorksShow.Web.admin
{
    public partial class index : Web.UI.ManagePage
    {
        protected Model.manager admin_info;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string name = ConfigurationManager.AppSettings["IndexName"].ToString();
                this.logoName.Text = name;
                admin_info = GetAdminInfo();
            }
            
        }

        //安全退出
        protected void lbtnExit_Click(object sender, EventArgs e)
        {
            Session[DTKeys.SESSION_ADMIN_INFO] = null;
            Utils.WriteCookie("AdminName", "DTcms", -14400);
            Utils.WriteCookie("AdminPwd", "DTcms", -14400);
            Response.Redirect("login.aspx");
        }
    }
}