using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using LPS.RfidOn.LPSSer;

namespace LPS.RfidOn.Core.ViewModel
{
    public class LoginViewModel
    {
        private static readonly LoginViewModel _instance = new LoginViewModel();
        public static LoginViewModel Instance { get { return _instance; } }

       
        public bool Login(string userid, string password,out string errorMsg)
        {
            errorMsg = string.Empty;
            using (var client = new LPSServiceClient())
            {
                EmpolyeeOR EmpObj = null;  
                try
                {
                    EmpObj =  client.Login(userid, password);
                    if (EmpObj.Result != 0)
                    {
                        errorMsg = EmpObj.ResultMsg;
                        return false;
                    }
                }
                catch (EndpointNotFoundException exEnd)
                {
                    errorMsg = "配置Web服务不存在！";
                    return false;
                }
                catch (Exception ex)
                {
                    errorMsg = "登录失败！";
                    return false;
                }
				
				GlobalData.CurrentUser = EmpObj;
            }
            return true;
        }
    }
}
