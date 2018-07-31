//
//文件名：    ReleaseEvaluate_Handled_Of_Complain.aspx.cs
//功能描述：  发布评价（投诉处理结果）
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

namespace M_YKT_Ysfw.Service.Problem
{
    public partial class ReleaseEvaluate_Handled_Of_Complain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //身份校验
            if (!InterfaceTool.IdentityVerify(Request))
            {
                Json = JsonConvert.SerializeObject(new DicPackage(false, null, "身份认证错误").DicInfo());
                return;
            }

            //账户
            string strAccount = Request.Params["Account"];
            //ID
            string strId = Request.Params["Id"];
            //处理结果评价
            string strHandleResult_Evaluate = Request.Params["HandleResult_Evaluate"];
            //处理结果评分
            string strHandleResult_Score = Request.Params["HandleResult_Score"];


            AppLog log = new AppLog(Request);
            log.strBehavior = "发布评价";
            log.strBehaviorURL = "/Service/Complain/ReleaseEvaluate_Handled_Of_Complain.aspx";
            log.strAccount = strAccount;

            try
            {
                if (strAccount == null || strId == null || strHandleResult_Evaluate == null || strHandleResult_Score == null)
                {
                    Json = JsonConvert.SerializeObject(new DicPackage(false, null, "参数错误，发布评价失败").DicInfo());
                    return;
                }

                //投诉处理结果发布评价
                string strSql = string.Format(@"update SER_COMPLAIN t 
                                                set t.Evaluate='{0}',t.index_satisfy='{1}',t.evaluate_time=sysdate 
                                                where id='{2}'",
                                                strHandleResult_Evaluate, strHandleResult_Score, strId);
                new Leo.Oracle.DataAccess(RegistryKey.KeyPathCGate).ExecuteNonQuery(strSql);

                Json = JsonConvert.SerializeObject(new DicPackage(true, null, "发布成功").DicInfo());
                log.LogCatalogSuccess();
            }
            catch (Exception ex)
            {
                Json = JsonConvert.SerializeObject(new DicPackage(false, null, string.Format("{0}：发布评价发生异常。{1}", ex.Source, ex.Message)).DicInfo());
                log.LogCatalogFailure(string.Format("{0}：发布评价发生异常。{1}", ex.Source, ex.Message));
            }
        }

        protected string Json;
    }
}