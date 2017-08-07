using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Text;
using WorksShow.Common;

namespace WorksShow.Web.UI.Page
{
    public partial class anlifirst : Web.UI.BasePage
    {
        protected int page;         //当前页码
        protected string keyword = string.Empty; //关健字
        protected int totalcount;   //OUT数据总数
        /// <summary>
        /// 重写虚方法,此方法将在Init事件前执行
        /// </summary>
        protected override void ShowPage()
        {
            
        }

     
    }
}
