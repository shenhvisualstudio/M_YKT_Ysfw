//
//文件名：    SubmitComplain.aspx.cs
//功能描述：  提交投诉
//创建时间：  2017/10/04
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
    public partial class SubmitComplain : System.Web.UI.Page
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
            //反馈类型
            string strFeedbackType = Request.Params["FeedbackType"];
            //反馈对象编码
            string strCodeFeedbackObject = Request.Params["CodeFeedbackObject"];
            //公司名称编码
            string strCodeCompany = Request.Params["CodeCompany"];
            //反馈标题
            string strFeedBackTitle = Request.Params["FeedBackTitle"];
            //反馈说明
            string strFeedBackExplain = Request.Params["FeedBackExplain"];
            //电话号码
            string strPhoneNum = Request.Params["PhoneNum"];
            //匿名标志
            string strAnonymous = Request.Params["Anonymous"];


            AppLog log = new AppLog(Request);
            log.strBehavior = "提交投诉";
            log.strBehaviorURL = "/Service/Complain/SubmitComplain.aspx";
            log.strAccount = strAccount;

            try
            {
                if (strAccount == null || strFeedbackType == null || strCodeFeedbackObject == null || strCodeCompany == null || strFeedBackTitle == null || strFeedBackExplain == null || strPhoneNum == null || strAnonymous == null)
                {
                    Json = JsonConvert.SerializeObject(new DicPackage(false, null, "参数错误，提交投诉失败").DicInfo());
                    return;
                }


                //手机号验证
                if (!TokenTool.VerifyMobile(strPhoneNum) && !string.IsNullOrWhiteSpace(strPhoneNum))
                {
                    Json = JsonConvert.SerializeObject(new DicPackage(false, null, "手机号错误").DicInfo());
                    log.LogCatalogFailure("手机号错误");
                    return;
                }

                //部门
                string strCodeDepartment = string.Empty;
                //车号
                string strVehicle = string.Empty;

                //匿名，手机号和车号加密
                if (strAnonymous.Equals("1")){

                }

                //默认公司编码
                //公路港——2
                if (strCodeFeedbackObject.Equals("1")){
                    strCodeCompany = "2";
                }
                //港区卡口——21
                if (strCodeFeedbackObject.Equals("3"))
                {
                    strCodeCompany = "21";
                }

                //提交投诉
                string strSql = 
                    string.Format(@"insert into SER_COMPLAIN (type_mark,code_complain_org,code_company_org,vehicle,driverphone,anonymous_mark,title,detail,account) 
                                    values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                                    strFeedbackType, strCodeFeedbackObject, strCodeCompany, strVehicle, strPhoneNum, strAnonymous, strFeedBackTitle, strFeedBackExplain, strAccount);

                new Leo.Oracle.DataAccess(RegistryKey.KeyPathCGate).ExecuteNonQuery(strSql);


                Json = JsonConvert.SerializeObject(new DicPackage(true, null, "提交成功").DicInfo());
                log.LogCatalogSuccess();
            }
            catch (Exception ex)
            {
                Json = JsonConvert.SerializeObject(new DicPackage(false, null, string.Format("{0}：提交投诉发生异常。{1}", ex.Source, ex.Message)).DicInfo());
                log.LogCatalogFailure(string.Format("{0}：提交投诉发生异常。{1}", ex.Source, ex.Message));
            }
        }

        protected string Json;
    }
}