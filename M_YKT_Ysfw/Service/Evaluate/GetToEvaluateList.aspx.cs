//
//文件名：    GetToEvaluateList.aspx.cs
//功能描述：  获取待评价列表
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
    public partial class GetToEvaluateList : System.Web.UI.Page
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
            //strAccount = "18936578716";

            try
            {
                if (strStartRow == null || strEndRow == null || strAccount == null)
                {
                    Json = JsonConvert.SerializeObject(new DicPackage(false, null, "参数错误，获取待评价列表数据失败").DicInfo());
                    return;
                }

                //获取待评价列表数据
                string strSql =
                    string.Format(@"select a.id,a.ingateno,b.fullorempty,b.vessel,b.cargo,a.vehicle,to_char(a.submittime, 'yyyy/mm/dd hh24:mi') as submittime,b.department 
                                    from TB_PRO_CONSIGNVEHICLE a, V_CONSIGN_QUICK b 
                                    where a.cgno=b.cgno and a.driverphone='{0}' and a.delete_mark_ser_evaluate='0'
                                    order by a.submittime desc",
                                    strAccount);
                var dt = new Leo.Oracle.DataAccess(RegistryKey.KeyPathHarbor).ExecuteTable(strSql, Convert.ToInt32(strStartRow), Convert.ToInt32(strEndRow)); ;
                if (dt.Rows.Count <= 0)
                {
                    Json = JsonConvert.SerializeObject(new DicPackage(true, null, null).DicInfo());
                    return;
                }

                string[,] strArray = new string[dt.Rows.Count, 7];
                for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
                {
                    strArray[iRow, 0] = Convert.ToString(dt.Rows[iRow]["id"]);
                    strArray[iRow, 1] = Convert.ToString(dt.Rows[iRow]["ingateno"]);
                    strArray[iRow, 2] = Convert.ToString(dt.Rows[iRow]["department"]);
                    strArray[iRow, 3] = Convert.ToString(dt.Rows[iRow]["vessel"]);
                    strArray[iRow, 4] = Convert.ToString(dt.Rows[iRow]["cargo"]);
                    strArray[iRow, 5] = Convert.ToString(dt.Rows[iRow]["vehicle"]);
                    strArray[iRow, 6] = Convert.ToString(dt.Rows[iRow]["submittime"]);
                }



                ////获取待评价列表数据
                //string strSql =
                //    string.Format(@"select a.id,a.ingateno,a.vehicle,to_char(a.submittime, 'yyyy/mm/dd hh24:mi') as submittime,a.cgno 
                //                    from TB_PRO_CONSIGNVEHICLE a
                //                    where a.driverphone='{0}' and a.delete_mark_ser_evaluate='0'
                //                    order by a.submittime desc",
                //                    strAccount);
                //var dt = new Leo.Oracle.DataAccess(RegistryKey.KeyPathHarbor).ExecuteTable(strSql); ;
                //if (dt.Rows.Count <= 0)
                //{
                //    Json = JsonConvert.SerializeObject(new DicPackage(true, null, null).DicInfo());
                //    return;
                //}

                //List<List<string>> listArray = new List<List<string>>();
                //for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
                //{
                //    strSql =
                //        string.Format(@"select b.fullorempty,b.vessel,b.cargo
                //                        from V_CONSIGN_QUICK b 
                //                        where  b.cgno='{0}'",
                //                        Convert.ToString(dt.Rows[iRow]["cgno"]));
                //    var dt1 = new Leo.Oracle.DataAccess(RegistryKey.KeyPathHarbor).ExecuteTable(strSql);
                //    if (dt1.Rows.Count > 0)
                //    {
                //        List<string> list = new List<string>();
                //        list.Add(Convert.ToString(dt.Rows[iRow]["id"]));
                //        list.Add(Convert.ToString(dt.Rows[iRow]["ingateno"]));
                //        list.Add(Convert.ToString(dt1.Rows[0]["fullorempty"]));
                //        list.Add(Convert.ToString(dt1.Rows[0]["vessel"]));
                //        list.Add(Convert.ToString(dt1.Rows[0]["cargo"]));
                //        list.Add(Convert.ToString(dt.Rows[iRow]["vehicle"]));
                //        list.Add(Convert.ToString(dt.Rows[iRow]["submittime"]));
                //        listArray.Add(list);
                //    }
                //}

                Json = JsonConvert.SerializeObject(new DicPackage(true, strArray, null).DicInfo());
            }
            catch (Exception ex)
            {
                Json = JsonConvert.SerializeObject(new DicPackage(false, null, string.Format("{0}：获取待评价列表数据发生异常。{1}", ex.Source, ex.Message)).DicInfo());
            }
        }

        protected string Json;
    }
}