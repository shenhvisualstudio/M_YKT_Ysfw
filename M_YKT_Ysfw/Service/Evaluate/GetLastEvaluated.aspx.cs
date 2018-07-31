//
//文件名：    GetLastEvaluated.aspx.cs
//功能描述：  获取上一个已评价
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
    public partial class GetLastEvaluated : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////身份校验
            //if (!InterfaceTool.IdentityVerify(Request))
            //{
            //    Json = JsonConvert.SerializeObject(new DicPackage(false, null, "身份认证错误").DicInfo());
            //    return;
            //}

            try
            {
                //获取上一个已评价
                string strSql =
                    string.Format(@"select b.id from SER_EVALUATE a, HARBOR.TB_PRO_CONSIGNVEHICLE b 
                                    where a.createtime=(select max(createtime) from ser_evaluate) and a.veh_attest_no=b.ingateno");
                var dt = new Leo.Oracle.DataAccess(RegistryKey.KeyPathCGate).ExecuteTable(strSql);
                if (dt.Rows.Count <= 0)
                {
                    Json = JsonConvert.SerializeObject(new DicPackage(true, null, null).DicInfo());
                    return;
                }

                string strId = Convert.ToString(dt.Rows[0]["id"]);

                Json = JsonConvert.SerializeObject(new DicPackage(true, strId, null).DicInfo());
            }
            catch (Exception ex)
            {
                Json = JsonConvert.SerializeObject(new DicPackage(false, null, string.Format("{0}：获取上一个已评价数据发生异常。{1}", ex.Source, ex.Message)).DicInfo());
            }
        }

        protected string Json;
    }
}