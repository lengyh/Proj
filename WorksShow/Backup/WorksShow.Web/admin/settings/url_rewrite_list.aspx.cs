﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorksShow.Common;

namespace WorksShow.Web.admin.settings
{
    public partial class url_rewrite_list : WorksShow.Web.UI.ManagePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("sys_config", ActionEnum.View.ToString()); //检查权限
                RptBind();
            }
        }

        #region 绑定数据=============================================
        private void RptBind()
        {
            //绑定URL配置列表
            rptList.DataSource = new BLL.url_rewrite().GetList("");
            rptList.DataBind();
        }
        #endregion

        //删除操作
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BLL.url_rewrite bll = new BLL.url_rewrite();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                string urlName = ((HiddenField)rptList.Items[i].FindControl("hideName")).Value;
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Remove("name", urlName);
                }
            }
            JscriptMsg("URL规则删除成功啦！", "url_rewrite_list.aspx", "Success");
        }

    }
}