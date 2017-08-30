document.write("<div class=\"navbar\">");
document.write("<div class=\"navbarBox\">");
document.write("        <div class=\"schoolName\">");
// <!-- <img width="255px" height="60px" src="images/school_name.png"> -->
document.write("        </div>");
document.write("        <div class=\"navTitle\"><p style='clear:right;'>玩命加载中...</p></div>");
document.write("    </div>");
document.write("</div>");
document.write("<script>");
document.write("   $(function () {");
// document.write("        //获取平台名称");
document.write("$(\".navTitle p\").html(this.title);");
document.write("  })");
document.write("</script>");