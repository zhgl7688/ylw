﻿/// 注意：本文件由 FruitBuilder 生成和管理，请误手工更改
using Fruit.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Fruit.Data;
using Fruit.Models;
using Newtonsoft.Json.Linq;

namespace Fruit.Web.Areas.Mms.Controllers
{
    public partial class HdpzcxController : Controller
    {
        public ActionResult Index()
        {
                // 提供搜索下拉框数据源
                List<ComboItem> 照片类型, 经销商审核结果, 总部照片类型, 审核结果;
                using(var db = new SysContext())
                {
                    照片类型 = db.Database.SqlQuery<ComboItem>("select Text Text, Text Value from sys_code where " + string.Format("{0}", "CodeType='zppzlx'")).ToList();
                    经销商审核结果 = db.Database.SqlQuery<ComboItem>("select Text Text, Text Value from sys_code where " + string.Format("{0}", "CodeType='shjg'")).ToList();
                    总部照片类型 = db.Database.SqlQuery<ComboItem>("select Text Text, Text Value from sys_code where " + string.Format("{0}", "CodeType='zppzlx'")).ToList();
                    审核结果 = db.Database.SqlQuery<ComboItem>("select Text Text, Text Value from sys_code where " + string.Format("{0}", "CodeType='shjg'")).ToList();
                }
                return View(new {dataSource = new {照片类型,经销商审核结果,总部照片类型,审核结果}});
        }

    }
    public partial class HdpzcxApiController : ApiController
    {
        public object Get(JObject req)
        {
            using (var db = new LUOLAI1401Context())
            {
                db.Database.Connection.Open();
                try {
                    var cmd = db.Database.Connection.CreateCommand();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "PicsSerch";
                    cmd.Parameters.Add(new SqlParameter("@fieldSort", "活动编号"));
                    var sbCondition = new StringBuilder();
                    sbCondition.Append(string.Format("{0}{1}{2}{3}{4}{5}{6}", "((员工编号 IN (SELECT UserCode FROM dbo.sys_user WHERE OrganizeName LIKE '", System.Web.HttpContext.Current.Session["OrganizeName"], "%')AND 所属公司='", (System.Web.HttpContext.Current.Session["sys_user"] as sys_user).CompCode, "') or ('", (System.Web.HttpContext.Current.Session["sys_user"] as sys_user).UserCode, "'='super'))"));
                    sbCondition.Append(" AND ");
                    SerachCondition.TextBox(sbCondition, "省份", "省份", "");
                    SerachCondition.TextBox(sbCondition, "城市", "城市", "");
                    SerachCondition.TextBox(sbCondition, "经销商编号", "经销商编号", "");
                    SerachCondition.TextBox(sbCondition, "经销商名称", "经销商名称", "");
                    SerachCondition.TextBox(sbCondition, "活动编号", "活动编号", "");
                    SerachCondition.TextBox(sbCondition, "活动名称", "活动名称", "");
                    SerachCondition.Date(sbCondition, "巡店时间", "巡店时间", "");
                    SerachCondition.Dropdown(sbCondition, "照片类型", "照片类型", "");
                    SerachCondition.Dropdown(sbCondition, "经销商审核结果", "经销商审核结果", "");
                    SerachCondition.Date(sbCondition, "总部巡店时间", "总部巡店时间", "");
                    SerachCondition.Dropdown(sbCondition, "总部照片类型", "总部照片类型", "");
                    SerachCondition.Dropdown(sbCondition, "审核结果", "审核结果", "");
                    if(sbCondition.Length > 5)
                    {
                        sbCondition.Length-=5;
                        cmd.Parameters.Add(new SqlParameter("@condition", sbCondition.ToString()));
                    }
                    if (HttpContext.Current.Request.Get("_report_") == "1")
                    {
                        // 报表请求条件合成
                        return sbCondition.ToString();
                    }
                    SqlParameter rowTotalParameter = null;
                    int rowTotal = 0;
                    int.TryParse(HttpContext.Current.Request.Get("total"), out rowTotal);
                    var rq = new PageRequest();
                    if(rq.Page.HasValue)
                    {
                        var pageSize = rq.Rows.HasValue ? rq.Rows.Value : 20;
                        var rowStart = (rq.Page.Value - 1) * pageSize + 1;
                        var rowEnd = rq.Page.Value * pageSize;
                        cmd.Parameters.Add(new SqlParameter("@rowStart", rowStart));
                        cmd.Parameters.Add(new SqlParameter("@rowEnd", rowEnd));
                        if(rowStart == 1)
                        {
                            cmd.Parameters.Add(rowTotalParameter = new SqlParameter("@rowTotal", System.Data.SqlDbType.Int, 8, System.Data.ParameterDirection.Output, true, 0, 0, null, System.Data.DataRowVersion.Default, 0));
                        }
                    }
                    string jsonArrayString = null;
                    using(var reader = cmd.ExecuteReader())
                    {
                        jsonArrayString = reader.ToJsonArrayString();
                    }
                    if (rowTotalParameter != null)
                    {
                        rowTotal = (int)rowTotalParameter.Value;
                    }
                    return JObject.Parse("{rows:" + jsonArrayString + ", total:" + rowTotal + "}");
                } finally {
                    db.Database.Connection.Close();
                }
            }
        }

    }
}
