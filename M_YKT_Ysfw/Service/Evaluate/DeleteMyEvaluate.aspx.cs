//
//文件名：    DeleteMyFeedback.aspx.cs
//功能描述：  删除我的评估
//创建时间：  2017/10/09
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
    public partial class DeleteMyEvaluate : System.Web.UI.Page
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
            //Id
            string strId = Request.Params["Id"];


            AppLog log = new AppLog(Request);
            log.strBehavior = "删除我的评估";
            log.strBehaviorURL = "/Service/Evaluate/DeleteMyEvaluate.aspx";
            log.strAccount = strAccount;

            try
            {
                if (strAccount == null || strId == null)
                {
                    Json = JsonConvert.SerializeObject(new DicPackage(false, null, "参数错误，删除我的评估失败").DicInfo());
                    return;
                }

                //删除我的评估
                string strSql =
                    string.Format(@"delete
                                    from SER_EVALUATE 
                                    where id='{0}'",
                                    strId);
                new Leo.Oracle.DataAccess(RegistryKey.KeyPathCGate).ExecuteNonQuery(strSql);

                Json = JsonConvert.SerializeObject(new DicPackage(true, null, "删除成功").DicInfo());
                log.LogCatalogSuccess();
            }
            catch (Exception ex)
            {
                Json = JsonConvert.SerializeObject(new DicPackage(false, null, string.Format("{0}删除我的评估发生异常。{1}", ex.Source, ex.Message)).DicInfo());
                log.LogCatalogFailure(string.Format("{0}：删除我的评估发生异常。{1}", ex.Source, ex.Message));
            }
        }

        protected string Json;
    }
}