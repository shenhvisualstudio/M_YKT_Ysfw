//
//文件名：    GetMyComplainList.aspx.cs
//功能描述：  获取我的投诉列表
//创建时间：  2017/10/08
//作者：      
//修改时间：  
//修改描述：  暂无
//
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using ServiceInterface.Common;
using Leo.Oracle;
using Leo;

namespace M_YKT_Ysfw.Service.Complain
{
    public partial class GetMyComplainList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //身份校验
            if (!InterfaceTool.IdentityVerify(Request))
            {
                Json = JsonConvert.SerializeObject(new DicPackage(false, null, "身份认证错误").DicInfo());
                return;
            }

            //数据起始行
            var strStartRow = Request.Params["StartRow"];
            //数据结束行
            var strEndRow = Request.Params["EndRow"];
            //账户
            string strAccount = Request.Params["Account"];

            try
            {
                if (strAccount == null)
                {
                    Json = JsonConvert.SerializeObject(new DicPackage(false, null, "参数错误，获取我的投诉列表数据失败").DicInfo());
                    return;
                }

                //获取我的投诉列表
                string strSql =
                    string.Format(@"select a.id,a.type_mark,c.complain_name,b.department,a.vehicle,a.driverphone,to_char(a.createtime, 'yyyy/mm/dd') as createtime,a.anonymous_mark,a.finish_mark,a.title,a.detail,a.adjust_time,a.deal_time,a.evaluate_time,e.complain_name as complain_name_org,d.department as department_org
                                    from SER_COMPLAIN a
                                    left join HARBOR.V_SYS_DEPART_CONVERT b on a.code_company=b.code_department
                                    left join SER_CODE_COMPLAIN c on a.code_complain=c.code_complain
                                    left join HARBOR.V_SYS_DEPART_CONVERT d on a.code_company_org=d.code_department
                                    left join SER_CODE_COMPLAIN e on a.code_complain_org=e.code_complain
                                    where a.type_mark='0' and a.account='{0}' and a.finish_mark='0'
                                    order by a.createtime desc",
                                    strAccount);
                var dt = new Leo.Oracle.DataAccess(RegistryKey.KeyPathCGate).ExecuteTable(strSql, Convert.ToInt32(strStartRow), Convert.ToInt32(strEndRow)); 
                if (dt.Rows.Count <= 0)
                {
                    Json = JsonConvert.SerializeObject(new DicPackage(true, null, null).DicInfo());
                    return;
                }

                string[,] strArray = new string[dt.Rows.Count, 12];
                for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
                {
                    strArray[iRow, 0] = Convert.ToString(dt.Rows[iRow]["id"]);
                    string strType = Convert.ToString(dt.Rows[iRow]["type_mark"]).Equals("0") == true ? "投诉" : "问题";
                    strArray[iRow, 1] = strType;
                    string strComplain_Name = Convert.ToString(dt.Rows[iRow]["complain_name_org"]);
                    string strDepartment = Convert.ToString(dt.Rows[iRow]["department_org"]);
                    if (!string.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[iRow]["complain_name"])))
                    {
                        strComplain_Name = Convert.ToString(dt.Rows[iRow]["complain_name"]);
                        strDepartment = Convert.ToString(dt.Rows[iRow]["department"]);
                    }
                    strArray[iRow, 2] = strComplain_Name;
                    strArray[iRow, 3] = strDepartment;
                    strArray[iRow, 4] = Convert.ToString(dt.Rows[iRow]["vehicle"]);
                    strArray[iRow, 5] = Convert.ToString(dt.Rows[iRow]["driverphone"]);
                    strArray[iRow, 6] = Convert.ToString(dt.Rows[iRow]["createtime"]);
                    string strAnonymous = Convert.ToString(dt.Rows[iRow]["anonymous_mark"]).Equals("0") == true ? "" : "匿名";
                    strArray[iRow, 7] = strAnonymous;
                    string strState = string.Empty;
                    if (!string.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[iRow]["evaluate_time"])))
                    {
                        strState = "已评价";
                    }
                    else if (!string.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[iRow]["deal_time"])))
                    {
                        strState = "已解决";
                    }
                    else if (!string.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[iRow]["adjust_time"])))
                    {
                        strState = "已受理";
                    }
                    else {
                        strState = "待受理";
                    }

                    strArray[iRow, 8] = strState;
                    strArray[iRow, 9] = Convert.ToString(dt.Rows[iRow]["title"]);
                    strArray[iRow, 10] = Convert.ToString(dt.Rows[iRow]["detail"]);
                }

                Json = JsonConvert.SerializeObject(new DicPackage(true, strArray, null).DicInfo());
            }
            catch (Exception ex)
            {
                Json = JsonConvert.SerializeObject(new DicPackage(false, null, string.Format("{0}：获取我的投诉列表数据发生异常。{1}", ex.Source, ex.Message)).DicInfo());
            }
        }

        protected string Json;
    }
}