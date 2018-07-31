//
//文件名：    ReleaseEvaluate.aspx.cs
//功能描述：  发布评价
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
    public partial class ReleaseEvaluate : System.Web.UI.Page
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
            //停车办证
            string strParkingCard = Request.Params["ParkingCard"];
            //放行装卸
            string strReleaseCargo = Request.Params["ReleaseCargo"];
            //港区卡口
            string strPortBayonet = Request.Params["PortBayonet"];
            //服务态度
            string strServiceAttitude = Request.Params["ServiceAttitude"];
            //放行速度
            string strReleaseSpeed = Request.Params["ReleaseSpeed"];
            //装卸速度
            string strUninstallSpeed = Request.Params["UninstallSpeed"];
            //总体评价
            string strOverallEvaluation = Request.Params["OverallEvaluation"];


            AppLog log = new AppLog(Request);
            log.strBehavior = "发布评价";
            log.strBehaviorURL = "/Service/Evaluate/ReleaseEvaluate.aspx";
            log.strAccount = strAccount;

            try
            {
                if (strAccount == null || strId == null || strParkingCard == null || strReleaseCargo == null || strPortBayonet == null || strServiceAttitude == null || strReleaseSpeed == null || strUninstallSpeed == null || strOverallEvaluation == null)
                {
                    Json = JsonConvert.SerializeObject(new DicPackage(false, null, "参数错误，发布评价失败").DicInfo());
                    return;
                }

                //运输申报编号
                string strVehicleAttestNo = string.Empty;
                //部门
                string strCodeDepartment = string.Empty;
                //车号
                string strVehicle = string.Empty;
                //内部委托号
                string strCgno = string.Empty;
                //纸面委托号
                string strTaskno = string.Empty;
                //货名
                string strCargo = string.Empty;
                //船名
                string strVessel = string.Empty;
                //集疏运类别
                string strFullorempty = string.Empty;
                //手机号
                string strMobile = string.Empty;
            
                //获取运输申报数据
                string strSql =
                    string.Format(@"select a.ingateno,a.code_department,a.vehicle,a.driverphone,a.cgno,b.taskno,b.cargo,b.vessel,b.fullorempty  
                                    from TB_PRO_CONSIGNVEHICLE a, V_CONSIGN_QUICK b 
                                    where a.cgno=b.cgno and a.id='{0}'",
                                    strId);
                var dt = new Leo.Oracle.DataAccess(RegistryKey.KeyPathHarbor).ExecuteTable(strSql);
                if (dt.Rows.Count > 0)
                {
                    strVehicleAttestNo = Convert.ToString(dt.Rows[0]["ingateno"]);
                    strCodeDepartment = Convert.ToString(dt.Rows[0]["code_department"]);
                    strVehicle = Convert.ToString(dt.Rows[0]["vehicle"]);
                    strCgno = Convert.ToString(dt.Rows[0]["cgno"]);
                    strTaskno = Convert.ToString(dt.Rows[0]["taskno"]);
                    strCargo = Convert.ToString(dt.Rows[0]["cargo"]);
                    strVessel = Convert.ToString(dt.Rows[0]["vessel"]);
                    strFullorempty = Convert.ToString(dt.Rows[0]["fullorempty"]);
                    strMobile = Convert.ToString(dt.Rows[0]["driverphone"]); ;
                }

                //发布评价
                strSql = 
                    string.Format(@"insert into SER_EVALUATE (veh_attest_no,code_company,taskno,fullorempty,vessel,cargo,vehicle,driverphone,cgno,
                                    evaluate_hall,evaluate_dock,evaluate_gate,index_attitude,index_audit,index_make,index_overall,account) 
                                    values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}',{12},{13},{14},{15},'{16}')",
                                    strVehicleAttestNo, strCodeDepartment, strTaskno, strFullorempty, strVessel, strCargo, strVehicle, strMobile, strCargo,
                                    strParkingCard, strReleaseCargo, strPortBayonet, strServiceAttitude, strReleaseSpeed, strUninstallSpeed, strOverallEvaluation, strAccount);
                new Leo.Oracle.DataAccess(RegistryKey.KeyPathCGate).ExecuteNonQuery(strSql);

                //删除我的评估
                strSql =
                    string.Format(@"update TB_PRO_CONSIGNVEHICLE t 
                                    set t.delete_mark_ser_evaluate='1' 
                                    where t.id='{0}'",
                                    strId);
                new Leo.Oracle.DataAccess(RegistryKey.KeyPathHarbor).ExecuteNonQuery(strSql);

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