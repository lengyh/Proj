<%@ Page Language="C#" AutoEventWireup="true" Inherits="WorksShow.Web.UI.Page.index" ValidateRequest="false" %>
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

	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n    <meta name=\"keywords\" content=\"");
	templateBuilder.Append(config.webkeyword.ToString());
	templateBuilder.Append("\" />\r\n    <meta name=\"description\" content=\"");
	templateBuilder.Append(config.webdescription.ToString());
	templateBuilder.Append("\" />\r\n    <title>");
	templateBuilder.Append(config.webtitle.ToString());
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
	templateBuilder.Append("/img/6.jpg\" /></div>\r\n            <div class=\"lx\">\r\n                <div class=\"qq1\"><a href=\"http://wpa.qq.com/msgrd?v=3&uin=1047001218&site=qq&menu=yes\">1047001218</a></div>\r\n                <div class=\"qq2\"><a href=\"http://wpa.qq.com/msgrd?v=3&uin=173668126&site=qq&menu=yes\">173668126</a></div>\r\n                <div class=\"phone\">13996486076</div>\r\n            </div>\r\n            <div class=\"clear\">\r\n            </div>\r\n        </div>\r\n        <div class=\"side1\">\r\n            <div class=\"gong\">\r\n                <div class=\"more\">\r\n                    <a href=\"");
	templateBuilder.Append(linkurl("infomanagement1","zxgg"));

	templateBuilder.Append("\">更多>></a></div>\r\n                <div class=\"gong_cont\">\r\n                    <img src=\"");
	templateBuilder.Append(config.templateskin.ToString());
	templateBuilder.Append("/img/11.jpg\" /><p>\r\n                        ");
	string hunbohuititle = get_content("zxgg");
	

	templateBuilder.Append(Utils.DropHTML(hunbohuititle,162));

	templateBuilder.Append("\r\n                    </p>\r\n                </div>\r\n                <div class=\"gong_b\">\r\n                    <img src=\"");
	templateBuilder.Append(config.templateskin.ToString());
	templateBuilder.Append("/img/9.jpg\" /></div>\r\n            </div>\r\n            <div class=\"tp\">\r\n                <div class=\"tp_title\">\r\n                    <a href=\"");
	templateBuilder.Append(linkurl("successfulcase_list",0,1));

	templateBuilder.Append("\">更多>></a></div>\r\n                <div class=\"tp_cont\">\r\n                    ");
	int totalcount_anli = 0;
	

	DataTable list_anli = get_article_list(20,0,4,1, "is_lock=0 and is_top=1", out totalcount_anli);
	

	templateBuilder.Append("\r\n                    <!--取得一个DataTable-->\r\n                    ");
	int dr_anli__loop__id=0;
	foreach(DataRow dr_anli in list_anli.Rows)
	{
		dr_anli__loop__id++;


	templateBuilder.Append("\r\n                    <div class=\"images\">\r\n                        <a href=\"");
	templateBuilder.Append(linkurl("successfulcase_show",dr_anli["id"].ToString().Trim()));

	templateBuilder.Append("\">\r\n                            <img src=\"" + dr_anli["img_url"].ToString().Trim() + "\" border=\"0\" width=\"151\" height=\"183\" /><p>\r\n                                ");
	templateBuilder.Append(Utils.DropHTML(dr_anli["title"].ToString().Trim(),12));

	templateBuilder.Append("</p>\r\n                        </a>\r\n                    </div>\r\n                    ");
	}	//end loop


	templateBuilder.Append("\r\n                    <div class=\"clear\">\r\n                    </div>\r\n                </div>\r\n                <div class=\"tp_b\">\r\n                    <img src=\"");
	templateBuilder.Append(config.templateskin.ToString());
	templateBuilder.Append("/img/13.jpg\" /></div>\r\n            </div>\r\n            <div class=\"clear\">\r\n            </div>\r\n        </div>\r\n        <div class=\"side2\">\r\n            <div class=\"about\">\r\n                <div class=\"about_title\">\r\n                    公司简介<span>/Company</span></div>\r\n                <div class=\"about_cont\">\r\n                    <img src=\"");
	templateBuilder.Append(config.templateskin.ToString());
	templateBuilder.Append("/img/17.jpg\" />\r\n                    <div class=\"about_wz\">\r\n                        <p>\r\n                            ");
	string gsjjcontent = get_content("qyjj");
	

	                            string qyjjcontentsub=gsjjcontent.Length>153?(gsjjcontent.Substring(0,153)+"..."):gsjjcontent;
	                            

	templateBuilder.Append("\r\n                            ");
	templateBuilder.Append(qyjjcontentsub.ToString());
	templateBuilder.Append("<a href=\"");
	templateBuilder.Append(linkurl("infomanagement1","qyjj"));

	templateBuilder.Append("\">[查看详细]</a></p>\r\n                    </div>\r\n                    <div class=\"clear\">\r\n                    </div>\r\n                </div>\r\n                <div class=\"about_b\">\r\n                    <img src=\"");
	templateBuilder.Append(config.templateskin.ToString());
	templateBuilder.Append("/img/16.jpg\" /></div>\r\n            </div>\r\n            <div class=\"news\">\r\n                <div class=\"about_title\">\r\n                    新闻动态<span>/News</span></div>\r\n                <div class=\"new_cont\">\r\n                    ");
	DataTable article_list1 = get_article_list(17, 0, 1, "is_lock=0 and is_top=1");
	

	int adr1__loop__id=0;
	foreach(DataRow adr1 in article_list1.Rows)
	{
		adr1__loop__id++;


	templateBuilder.Append("\r\n                    <div id=\"ts\">\r\n                        <img src=\"" + adr1["img_url"].ToString().Trim() + "\" width=\"118\" height=\"76\" />\r\n                        <div class=\"ts_wz\">\r\n                            <h3>\r\n                                <a href=\"");
	templateBuilder.Append(linkurl("article_show",adr1["id"].ToString().Trim()));

	templateBuilder.Append("\">\r\n                                    ");
	templateBuilder.Append(Utils.DropHTML(adr1["title"].ToString().Trim(),24));

	templateBuilder.Append("</a></h3>\r\n                            <p>\r\n                                ");
	templateBuilder.Append(Utils.DropHTML(adr1["zhaiyao"].ToString().Trim(),108));

	templateBuilder.Append("<a href=\"");
	templateBuilder.Append(linkurl("article_show",adr1["id"].ToString().Trim()));

	templateBuilder.Append("\">[查看详细]</a></p>\r\n                            <div class=\"clear\">\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                    ");
	}	//end loop


	templateBuilder.Append("\r\n                    <ul>\r\n                        ");
	DataTable article_list5 = get_article_list(17, 0, 3, "is_lock=0 and is_top=0");
	

	int adr5__loop__id=0;
	foreach(DataRow adr5 in article_list5.Rows)
	{
		adr5__loop__id++;


	templateBuilder.Append("\r\n                            <li><a href=\"");
	templateBuilder.Append(linkurl("article_show",adr5["id"].ToString().Trim()));

	templateBuilder.Append("\">");
	templateBuilder.Append(Utils.DropHTML(adr5["title"].ToString().Trim(),28));

	templateBuilder.Append("</a><span>[");	templateBuilder.Append(Utils.ObjectToDateTime(adr5["add_time"].ToString().Trim()).ToString("yyyy-MM-dd"));

	templateBuilder.Append("]</span></li>\r\n                        ");
	}	//end loop


	templateBuilder.Append("\r\n                    </ul>\r\n                </div>\r\n                <div class=\"new_b\">\r\n                    <img src=\"");
	templateBuilder.Append(config.templateskin.ToString());
	templateBuilder.Append("/img/16.jpg\" /></div>\r\n            </div>\r\n            <div class=\"clear\">\r\n            </div>\r\n        </div>\r\n    </div>\r\n    ");

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
