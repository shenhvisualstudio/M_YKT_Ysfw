//
//文件名：    GetHistoryEvaluateList.aspx.cs
//功能描述：  获取历史评价列表
//创建时间：  2017/9/21
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
    public partial class GetHistoryEvaluateList : System.Web.UI.Page
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
            //strStartRow = "1";
            //strEndRow = "15";
            //strAccount = "13812347543";

            try
            {
                if (strStartRow == null || strEndRow == null || strAccount == null)
                {
                    Json = JsonConvert.SerializeObject(new DicPackage(false, null, "参数错误，获取历史评价列表数据失败").DicInfo());
                    return;
                }

                //获取历史评价列表数据
                string strSql =
                    string.Format(@"select t.id,t.veh_attest_no,t.driverphone,t.finish_mark,to_char(t.createtime, 'yyyy/mm/dd') as createtime,t.evaluate_hall,t.evaluate_dock,t.evaluate_gate,t.index_attitude,t.index_audit,t.index_make,t.index_overall,t.hall_time,t.dock_time,t.gate_time 
                                    from SER_EVALUATE t where t.account='{0}' and t.finish_mark = '1'
                                    order by t.createtime desc",
                                    strAccount);
                var dt = new Leo.Oracle.DataAccess(RegistryKey.KeyPathCGate).ExecuteTable(strSql, Convert.ToInt32(strStartRow), Convert.ToInt32(strEndRow)); ;
                if (dt.Rows.Count <= 0)
                {
                    Json = JsonConvert.SerializeObject(new DicPackage(true, null, null).DicInfo());
                    return;
                }

                string[,] strArray = new string[dt.Rows.Count, 12];
                for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
                {
                    strArray[iRow, 0] = Convert.ToString(dt.Rows[iRow]["id"]);
                    strArray[iRow, 1] = Convert.ToString(dt.Rows[iRow]["veh_attest_no"]);
                    strArray[iRow, 2] = Convert.ToString(dt.Rows[iRow]["driverphone"]);
                    string strExplain = string.Empty;
                    if (!string.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[iRow]["hall_time"])) || !string.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[iRow]["dock_time"])) || !string.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[iRow]["gate_time"]))) {
                        strExplain = "有说明";
                    }
                    strArray[iRow, 3] = strExplain;
                    strArray[iRow, 4] = Convert.ToString(dt.Rows[iRow]["createtime"]);
                    strArray[iRow, 5] = Convert.ToString(dt.Rows[iRow]["evaluate_hall"]);
                    strArray[iRow, 6] = Convert.ToString(dt.Rows[iRow]["evaluate_dock"]);
                    strArray[iRow, 7] = Convert.ToString(dt.Rows[iRow]["evaluate_gate"]);
                    strArray[iRow, 8] = GetChineseEvaluate(Convert.ToInt16(dt.Rows[iRow]["index_attitude"]));
                    strArray[iRow, 9] = GetChineseEvaluate(Convert.ToInt16(dt.Rows[iRow]["index_audit"]));
                    strArray[iRow, 10] = GetChineseEvaluate(Convert.ToInt16(dt.Rows[iRow]["index_make"]));
                    strArray[iRow, 11] = GetChineseEvaluate(Convert.ToInt16(dt.Rows[iRow]["index_overall"]));
                }

                Json = JsonConvert.SerializeObject(new DicPackage(true, strArray, null).DicInfo());
            }
            catch (Exception ex)
            {
                Json = JsonConvert.SerializeObject(new DicPackage(false, null, string.Format("{0}：获取历史评价列表数据发生异常。{1}", ex.Source, ex.Message)).DicInfo());
            }
        }

        protected string Json;

        /// <summary>
        /// 获取中文评分
        /// </summary>
        /// <param name="indexEvaluate">数字评分</param>
        /// <returns>中文评分</returns>
        private string GetChineseEvaluate(int indexEvaluate) {

            string strChineseEvaluate = string.Empty;
            switch (indexEvaluate) {
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