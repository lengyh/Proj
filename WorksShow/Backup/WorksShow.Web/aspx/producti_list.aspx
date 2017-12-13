<%@ Page Language="C#" AutoEventWireup="true" Inherits="WorksShow.Web.UI.Page.article_list" ValidateRequest="false" %>
<%@ Import namespace="System.Text" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="WorksShow.Common" %>

<script runat="server">
override protected void OnInit(EventArgs e)
{

	/* 
		This page was created by DTcms Template Engine at 2013/5/2 13:11:04.
		本页面代码由DTcms模板引擎生成于 2013/5/2 13:11:04. 
	*/

	base.OnInit(e);
	StringBuilder templateBuilder = new StringBuilder(220000);
	const int channel_id = 19;

	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n    <meta name=\"keywords\" content=\"");
	templateBuilder.Append(config.webkeyword.ToString());
	templateBuilder.Append("\" />\r\n    <meta name=\"description\" content=\"");
	templateBuilder.Append(config.webdescription.ToString());
	templateBuilder.Append("\" />\r\n    ");
	string category_title = get_category_title(category_id,"产品展示");
	

	templateBuilder.Append("\r\n    <title>");
	templateBuilder.Append(category_title.ToString());
	templateBuilder.Append(" - ");
	templateBuilder.Append(config.webname.ToString());
	templateBuilder.Append("</title>\r\n    <link href=\"");
	templateBuilder.Append(config.templateskin.ToString());
	templateBuilder.Append("/css/index.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n</head>\r\n<body>\r\n    ");

	templateBuilder.Append("<div class=\"head\">\r\n        <div class=\"title\">\r\n            <div class=\"title_zw\">\r\n                <div class=\"logo\">\r\n                    <img src=\"");
	templateBuilder.Append(config.templateskin.ToString());
	templateBuilder.Append("/img/2.gif\" /></div>\r\n                <div class=\"sc\">\r\n                    <a onclick=\"this.style.behavior='url(#default#homepage)';this.setHomePage('");
	templateBuilder.Append(config.weburl.ToString());
	templateBuilder.Append("');\" href=\"#\">设为首页</a>|<a href=\"javascript:window.external.AddFavorite('");
	templateBuilder.Append(config.weburl.ToString());
	templateBuilder.Append("', '重庆工程学院软件与计算机学院有限公司')\")>加入收藏</a>|<a href=\"");
	templateBuilder.Append(linkurl("infomanagement1","lxwm"));

	templateBuilder.Append("\">联系我们</a>\r\n                </div>\r\n                <div class=\"clear\">\r\n                </div>\r\n            </div>\r\n        </div>\r\n        <div id=\"menu\">\r\n            <div class=\"menu\">\r\n                <ul>\r\n                    <li><a href=\"");
	templateBuilder.Append(linkurl("index",""));

	templateBuilder.Append("\">首页</a></li>\r\n                    <li id=\"zx\"></li>\r\n                    <li><a href=\"");
	templateBuilder.Append(linkurl("infomanagement1","qyjj"));

	templateBuilder.Append("\">企业简介</a></li>\r\n                    <li id=\"zx\"></li>\r\n                    <li><a href=\"");
	templateBuilder.Append(linkurl("article_list",0,1));

	templateBuilder.Append("\">新闻中心</a></li>\r\n                    <li id=\"zx\"></li>\r\n                    <li><a href=\"");
	templateBuilder.Append(linkurl("product_list",0,1));

	templateBuilder.Append("\">产品展示</a></li>\r\n                    <li id=\"zx\"></li>\r\n                    <li><a href=\"");
	templateBuilder.Append(linkurl("successfulcase_list",0,1));

	templateBuilder.Append("\">成功案例</a></li>\r\n                    <li id=\"zx\"></li>\r\n                    <li><a href=\"");
	templateBuilder.Append(linkurl("recruitment_list",0,1));

	templateBuilder.Append("\">人才招聘</a></li>\r\n                    <li id=\"zx\"></li>\r\n                    <li><a href=\"feedback.aspx\">留言板</a></li>\r\n                    <li id=\"zx\"></li>\r\n                    <li><a href=\"");
	templateBuilder.Append(linkurl("infomanagement1","lxwm"));

	templateBuilder.Append("\">联系我们</a></li>\r\n                </ul>\r\n            </div>\r\n        </div>\r\n    </div>");


	templateBuilder.Append("\r\n    <div class=\"cont\">\r\n        <div class=\"side\">\r\n            <div class=\"lt\">\r\n                <img src=\"");
	templateBuilder.Append(config.templateskin.ToString());
	templateBuilder.Append("/img/6.jpg\" /></div>\r\n            <div class=\"lx\">\r\n                <div class=\"qq1\"><a href=\"http://wpa.qq.com/msgrd?v=3&uin=1047001218&site=qq&menu=yes\">1047001218</a></div>\r\n                <div class=\"qq2\"><a href=\"http://wpa.qq.com/msgrd?v=3&uin=173668126&site=qq&menu=yes\">173668126</a></div>\r\n                <div class=\"phone\">13996486076</div>\r\n            </div>\r\n            <div class=\"clear\">\r\n            </div>\r\n        </div>\r\n        <div class=\"ny\">\r\n            <div class=\"xx\">\r\n                <img src=\"");
	templateBuilder.Append(config.templateskin.ToString());
	templateBuilder.Append("/img/27.jpg\" /></div>\r\n            <div class=\"side3\">\r\n                <div class=\"lb\">\r\n                    <div class=\"lb_title\">\r\n                        <img src=\"");
	templateBuilder.Append(config.templateskin.ToString());
	templateBuilder.Append("/img/30.jpg\" /></div>\r\n                    <div class=\"lb_cont\">\r\n                        <ul>\r\n                            ");
	DataTable category_list = get_category_list(channel_id,0);
	

	int cdr__loop__id=0;
	foreach(DataRow cdr in category_list.Rows)
	{
		cdr__loop__id++;


	templateBuilder.Append("\r\n                            <li><a href=\"");
	templateBuilder.Append(linkurl("product_list",cdr["id"].ToString().Trim(),1));

	templateBuilder.Append("\">" + cdr["title"].ToString().Trim() + "</a></li>\r\n                            ");
	}	//end loop


	templateBuilder.Append("\r\n                        </ul>\r\n                    </div>\r\n                </div>\r\n                <div class=\"zw\">\r\n                    <div class=\"zw_title\">\r\n                        产品展示<span>/Show</span></div>\r\n                    <div class=\"zw_cont\">\r\n                        ");
	DataTable list = get_article_list(channel_id, category_id, 9, page, "is_lock=0", out totalcount);
	

	templateBuilder.Append("\r\n                        <!--取得一个DataTable-->\r\n                        ");
	string pagelist = get_page_link(9, page, totalcount, "product_list", category_id, "__id__");
	

	templateBuilder.Append("\r\n                        <!--取得分页页码列表-->\r\n                        ");
	int dr__loop__id=0;
	foreach(DataRow dr in list.Rows)
	{
		dr__loop__id++;


	templateBuilder.Append("\r\n                        <div class=\"tt\">\r\n                            <a href=\"");
	templateBuilder.Append(linkurl("product_show",dr["id"].ToString().Trim()));

	templateBuilder.Append("\">\r\n                                <img src=\"" + dr["img_url"].ToString().Trim() + "\" border=\"0\" width=\"190\" height=\"150\" alt=\"" + dr["title"].ToString().Trim() + "\" /><p>\r\n                                    ");
	templateBuilder.Append(Utils.DropHTML(dr["title"].ToString().Trim(),20));

	templateBuilder.Append("</p>\r\n                            </a>\r\n                        </div>\r\n                        ");
	}	//end loop


	templateBuilder.Append("\r\n                        <div class=\"clear\">\r\n                        </div>\r\n                    </div>\r\n                    <div class=\"fy\">\r\n                        ");
	templateBuilder.Append(pagelist.ToString());
	templateBuilder.Append("</div>\r\n                </div>\r\n                <div class=\"clear\">\r\n                </div>\r\n            </div>\r\n            <div class=\"clear\">\r\n            </div>\r\n        </div>\r\n    </div>\r\n        ");

	templateBuilder.Append("<div class=\"footer\">\r\n    <div class=\"foot\">\r\n        <div class=\"bq\">\r\n            <p>\r\n                ");
	templateBuilder.Append(config.webcopyright.ToString());
	templateBuilder.Append(" ");
	templateBuilder.Append(config.webcrod.ToString());
	templateBuilder.Append("</p>\r\n            <p>\r\n                <a href=\"");
	templateBuilder.Append(linkurl("infomanagement1","qyjj"));

	templateBuilder.Append("\">关于我们</a> | <a href=\"");
	templateBuilder.Append(linkurl("recruitment_list",0,1));

	templateBuilder.Append("\">人才招聘</a> | <a\r\n                    href=\"");
	templateBuilder.Append(linkurl("infomanagement1","lxwm"));

	templateBuilder.Append("\">联系我们</a></p>\r\n        </div>\r\n        <span>技术支持：<a href=\"http://www.yoolong.net\">尤隆科技</a></span>\r\n        <div class=\"clear\">\r\n        </div>\r\n    </div>\r\n</div>\r\n");


	templateBuilder.Append("\r\n</body>\r\n</html>\r\n");
	Response.Write(templateBuilder.ToString());
}
</script>
