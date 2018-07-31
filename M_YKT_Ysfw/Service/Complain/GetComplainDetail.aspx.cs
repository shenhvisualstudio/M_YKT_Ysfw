//
//文件名：    GetComplainDetail.aspx.cs
//功能描述：  获取投诉详情
//创建时间：  2017/9/26
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
    public partial class GetComplainDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //身份校验
            if (!InterfaceTool.IdentityVerify(Request))
            {
                Json = JsonConvert.SerializeObject(new DicPackage(false, null, "身份认证错误").DicInfo());
                return;
            }

            //ID
            string strId = Request.Params["Id"];
            //strId = "6";

            try
            {
                if (strId == null)
                {
                    Json = JsonConvert.SerializeObject(new DicPackage(false, null, "参数错误，获取投诉详情数据失败").DicInfo());
                    return;
                }

                //获取投诉详情
                string strSql =
                    string.Format(@"select a.id,a.type_mark,c.complain_name,b.department,a.vehicle,a.driverphone,to_char(a.createtime, 'yyyy/mm/dd hh24:mi:ss') as createtime,a.anonymous_mark,a.finish_mark,a.title,a.detail,a.deal_result,to_char(a.deal_time, 'yyyy/mm/dd hh24:ss:mi') as deal_time,a.evaluate,a.index_satisfy,to_char(a.evaluate_time, 'yyyy/mm/dd hh24:mi:ss') as evaluate_time,a.adjust_time,e.complain_name as complain_name_org,d.department as department_org
                                    from SER_COMPLAIN a
                                    left join HARBOR.V_SYS_DEPART_CONVERT b on a.code_company=b.code_department
                                    left join SER_CODE_COMPLAIN c on a.code_complain=c.code_complain
                                    left join HARBOR.V_SYS_DEPART_CONVERT d on a.code_company_org=d.code_department
                                    left join SER_CODE_COMPLAIN e on a.code_complain_org=e.code_complain
                                    where a.id='{0}'
                                    order by a.finish_mark asc,a.createtime desc",
                                    strId);
                var dt = new Leo.Oracle.DataAccess(RegistryKey.KeyPathCGate).ExecuteTable(strSql);
                if (dt.Rows.Count <= 0)
                {
                    Json = JsonConvert.SerializeObject(new DicPackage(true, null, null).DicInfo());
                    return;
                }

                string[] strArray = new string[16];

                strArray[0] = Convert.ToString(dt.Rows[0]["id"]);
                string strType = Convert.ToString(dt.Rows[0]["type_mark"]).Equals("0") == true ? "投诉" : "问题";
                strArray[1] = strType;
                string strComplain_Name = Convert.ToString(dt.Rows[0]["complain_name_org"]);
                string strDepartment = Convert.ToString(dt.Rows[0]["department_org"]);
                if (!string.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["complain_name"])))
                {
                    strComplain_Name = Convert.ToString(dt.Rows[0]["complain_name"]);
                    strDepartment = Convert.ToString(dt.Rows[0]["department"]);
                }
                strArray[2] = strComplain_Name;
                strArray[3] = strDepartment;
                strArray[4] = Convert.ToString(dt.Rows[0]["vehicle"]);
                strArray[5] = Convert.ToString(dt.Rows[0]["driverphone"]);
                strArray[6] = Convert.ToString(dt.Rows[0]["createtime"]);
                string strAnonymous = Convert.ToString(dt.Rows[0]["anonymous_mark"]).Equals("0") == true ? "" : "匿名";
                strArray[7] = strAnonymous;
                string strState = string.Empty;
                if (!string.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["evaluate_time"])))
                {
                    strState = "已评价";
                }
                else if (!string.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["deal_time"])))
                {
                    strState = "已解决";
                }
                else if (!string.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["adjust_time"])))
                {
                    strState = "已受理";
                }
                else {
                    strState = "待受理";
                }

                strArray[8] = strState;
                strArray[9] = Convert.ToString(dt.Rows[0]["title"]);
                strArray[10] = Convert.ToString(dt.Rows[0]["detail"]);
                strArray[11] = Convert.ToString(dt.Rows[0]["deal_result"]);
                strArray[12] = Convert.ToString(dt.Rows[0]["deal_time"]);
                strArray[13] = Convert.ToString(dt.Rows[0]["evaluate"]);
                string strIndex_satisfy = string.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["index_satisfy"])) == true ? string.Empty : GetChineseEvaluate(Convert.ToInt16(dt.Rows[0]["index_satisfy"]));
                strArray[14] = strIndex_satisfy;
                strArray[15] = Convert.ToString(dt.Rows[0]["evaluate_time"]);

                Json = JsonConvert.SerializeObject(new DicPackage(true, strArray, null).DicInfo());
            }
            catch (Exception ex)
            {
                Json = JsonConvert.SerializeObject(new DicPackage(false, null, string.Format("{0}：获取投诉详情数据发生异常。{1}", ex.Source, ex.Message)).DicInfo());
            }
        }

        protected string Json;

        /// <summary>
        /// 获取中文评分
        /// </summary>
        /// <param name="indexEvaluate">数字评分</param>
        /// <returns>中文评分</returns>
        private string GetChineseEvaluate(int indexEvaluate)
        {

            string strChineseEvaluate = string.Empty;
            switch (indexEvaluate)
            {
                case 1:
                    strChineseEvaluate = "差评";
                    break;
                case 2:
                case 3:
                    strChineseEvaluate = "中评";
                    break;
                case 4:
                case 5:
                    strChineseEvaluate = "好评";
                    break;
                default:
                    strChineseEvaluate = "好评";
                    break;
            }

            return strChineseEvaluate;
        }
    }
}