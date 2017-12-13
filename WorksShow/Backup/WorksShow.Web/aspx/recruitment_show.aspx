<%@ Page Language="C#" AutoEventWireup="true" Inherits="WorksShow.Web.UI.Page.article_show" ValidateRequest="false" %>
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
	const int channel_id = 18;

	templateBuilder.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n    <meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" />\r\n    <meta name=\"keywords\" content=\"");
	templateBuilder.Append(config.webkeyword.ToString());
	templateBuilder.Append("\" />\r\n    <meta name=\"description\" content=\"");
	templateBuilder.Append(config.webdescription.ToString());
	templateBuilder.Append("\" />\r\n    ");
	string category_title = get_category_title(model.category_id,"人才招聘");
	

	templateBuilder.Append("\r\n    <title>");
	templateBuilder.Append(model.title.ToString());
	templateBuilder.Append(" - ");
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
	templateBuilder.Append("/img/31.jpg\" /></div>\r\n                    <div class=\"lb_cont\">\r\n                        <ul>\r\n                            ");
	DataTable category_list = get_category_list(model.channel_id,0);
	

	int cdr__loop__id=0;
	foreach(DataRow cdr in category_list.Rows)
	{
		cdr__loop__id++;


	templateBuilder.Append("\r\n                            <li><a href=\"");
	templateBuilder.Append(linkurl("recruitment_list",cdr["id"].ToString().Trim(),1));

	templateBuilder.Append("\">" + cdr["title"].ToString().Trim() + "</a></li>\r\n                            ");
	}	//end loop


	templateBuilder.Append("\r\n                        </ul>\r\n                    </div>\r\n                </div>\r\n                <div class=\"zw\">\r\n                    <div class=\"zw_title\">\r\n                        人才招聘<span>/Talents</span></div>\r\n                    <div class=\"zw_cont\">\r\n                        <div class=\"zw_bt\">\r\n                            <h3>\r\n                                ");
	templateBuilder.Append(model.title.ToString());
	templateBuilder.Append("</h3>\r\n                            <p>\r\n                                更新时间：");
	templateBuilder.Append(model.add_time.ToString());
	templateBuilder.Append(" 新闻来源：");
	templateBuilder.Append(model.form.ToString());
	templateBuilder.Append("</p>\r\n                        </div>\r\n                        <div class=\"zw_wz\">\r\n                            ");
	templateBuilder.Append(model.content.ToString());
	templateBuilder.Append("\r\n                        </div>\r\n                        <div class=\"fp\">\r\n                    ");
	string strFirst = "";
	

	string strlast = "";
	

	                    int tempid=GetArticleId("is_lock=0 and category_id=" + model.category_id + " and id<" + model.id);
	                    string temptitle=GetArticleTitle("is_lock=0 and category_id=" + model.category_id + " and id<" + model.id);
	                    if (tempid > 0)
	                    {
	                        strFirst="上一篇：<a href='"+linkurl("recruitment_show",tempid)+"'>"+(temptitle.Length>10?temptitle.Substring(0,10)+"...":temptitle)+"</a>";
	                    }else
	                    {
	                        strFirst="这是本分类下第一篇文章...";
	                    }
	
	                    int tempid2=GetArticleId("is_lock=0 and category_id=" + model.category_id + " and id>" + model.id);
	                    string temptitle2=GetArticleTitle("is_lock=0 and category_id=" + model.category_id + " and id>" + model.id);
	                    if (tempid2 > 0)
	                    {
	                        strlast="下一篇：<a href='"+linkurl("recruitment_show",tempid2)+"'>"+(temptitle2.Length>10?temptitle2.Substring(0,10)+"...":temptitle2)+"</a>";
	                    }else
	                    {
	                        strlast="这是本分类下最后一篇文章...";
	                    }
	                    

	templateBuilder.Append(" \r\n                            <div class=\"sy\">\r\n                                ");
	templateBuilder.Append(strFirst.ToString());
	templateBuilder.Append("</div>\r\n                            <div class=\"sy\">\r\n                                ");
	templateBuilder.Append(strlast.ToString());
	templateBuilder.Append("</div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n                <div class=\"clear\">\r\n                </div>\r\n            </div>\r\n            <div class=\"clear\">\r\n            </div>\r\n        </div>\r\n    </div>\r\n        ");

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
