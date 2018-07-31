//
//文件名：    GetMyEvaluate_Handled_Of_Problem.aspx.cs
//功能描述：  获取我的评价（问题处理结果）
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

namespace M_YKT_Ysfw.Service.Problem
{
    public partial class GetMyEvaluate_Handled_Of_Problem : System.Web.UI.Page
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
            //strId = "88";

            try
            {
                if (strId == null)
                {
                    Json = JsonConvert.SerializeObject(new DicPackage(false, null, "参数错误，获取我的评价数据失败").DicInfo());
                    return;
                }

                //获取我的评价（问题处理结果）
                string strSql =
                    string.Format(@"select evaluate,index_satisfy,to_char(evaluate_time, 'yyyy/mm/dd hh24:mi:ss') as evaluate_time 
                                    from ser_complain  
                                    where id='{0}'",
                                    strId);
                var dt = new Leo.Oracle.DataAccess(RegistryKey.KeyPathCGate).ExecuteTable(strSql);
                if (dt.Rows.Count <= 0)
                {
                    Json = JsonConvert.SerializeObject(new DicPackage(true, null, null).DicInfo());
                    return;
                }

                string[] strArray = new string[3];

                strArray[0] = Convert.ToString(dt.Rows[0]["evaluate"]);
                string strIndex_satisfy = string.IsNullOrWhiteSpace(Convert.ToString(dt.Rows[0]["index_satisfy"])) == true ? string.Empty : GetChineseEvaluate(Convert.ToInt16(dt.Rows[0]["index_satisfy"]));
                strArray[1] = strIndex_satisfy;
                strArray[2] = Convert.ToString(dt.Rows[0]["evaluate_time"]);    

                Json = JsonConvert.SerializeObject(new DicPackage(true, strArray, null).DicInfo());
            }
            catch (Exception ex)
            {
                Json = JsonConvert.SerializeObject(new DicPackage(false, null, string.Format("{0}：获取我的评价数据发生异常。{1}", ex.Source, ex.Message)).DicInfo());
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