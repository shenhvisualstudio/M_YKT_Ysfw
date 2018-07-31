//
//文件名：    GetEvaluateDetail.aspx.cs
//功能描述：  获取评价详情
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

namespace M_YKT_Ysfw.Service.Evaluate
{
    public partial class GetEvaluateDetail : System.Web.UI.Page
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
            //strId = "211";

            try
            {
                if (strId == null)
                {
                    Json = JsonConvert.SerializeObject(new DicPackage(false, null, "参数错误，获取评价详情数据失败").DicInfo());
                    return;
                }

                //获取待评价详情
                string strSql =
                    string.Format(@"select t.id,t.veh_attest_no,t.driverphone,t.finish_mark,t.evaluate_hall,t.evaluate_dock,t.evaluate_gate,t.index_attitude,t.index_audit,t.index_make,t.index_overall,to_char(t.createtime, 'yyyy/mm/dd hh24:ss:mi') as evaluatetime,
                                    t.hall_comment,to_char(t.hall_time, 'yyyy/mm/dd hh24:mi:ss') as hall_time,t.dock_comment,to_char(t.dock_time, 'yyyy/mm/dd hh24:ss:mi') as dock_time,t.gate_comment,to_char(t.gate_time, 'yyyy/mm/dd hh24:ss:mi') as gate_time 
                                    from ser_evaluate t where t.id='{0}'",
                                    strId);
                var dt = new Leo.Oracle.DataAccess(RegistryKey.KeyPathCGate).ExecuteTable(strSql);
                if (dt.Rows.Count <= 0)
                {
                    Json = JsonConvert.SerializeObject(new DicPackage(true, null, null).DicInfo());
                    return;
                }

                string[] strArray = new string[18];

                strArray[0] = Convert.ToString(dt.Rows[0]["id"]);
                strArray[1] = Convert.ToString(dt.Rows[0]["veh_attest_no"]);
                strArray[2] = Convert.ToString(dt.Rows[0]["driverphone"]);
                string strExplain = string.Empty;
                if (!string.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["hall_time"])) || !string.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["dock_time"])) || !string.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["gate_time"])))
                {
                    strExplain = "有说明";
                }
                strArray[3] = strExplain;
                strArray[4] = Convert.ToString(dt.Rows[0]["evaluate_hall"]);
                strArray[5] = Convert.ToString(dt.Rows[0]["evaluate_dock"]);
                strArray[6] = Convert.ToString(dt.Rows[0]["evaluate_gate"]);
                strArray[7] = GetChineseEvaluate(Convert.ToInt16(dt.Rows[0]["index_attitude"]));
                strArray[8] = GetChineseEvaluate(Convert.ToInt16(dt.Rows[0]["index_audit"]));
                strArray[9] = GetChineseEvaluate(Convert.ToInt16(dt.Rows[0]["index_make"]));
                strArray[10] = GetChineseEvaluate(Convert.ToInt16(dt.Rows[0]["index_overall"]));
                strArray[11] = Convert.ToString(dt.Rows[0]["evaluatetime"]);
                strArray[12] = Convert.ToString(dt.Rows[0]["hall_comment"]);
                strArray[13] = Convert.ToString(dt.Rows[0]["hall_time"]);
                strArray[14] = Convert.ToString(dt.Rows[0]["dock_comment"]);
                strArray[15] = Convert.ToString(dt.Rows[0]["dock_time"]);
                strArray[16] = Convert.ToString(dt.Rows[0]["gate_comment"]);
                strArray[17] = Convert.ToString(dt.Rows[0]["gate_time"]);

                Json = JsonConvert.SerializeObject(new DicPackage(true, strArray, null).DicInfo());
            }
            catch (Exception ex)
            {
                Json = JsonConvert.SerializeObject(new DicPackage(false, null, string.Format("{0}：获取评价详情数据发生异常。{1}", ex.Source, ex.Message)).DicInfo());
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