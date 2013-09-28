using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using LPS.DAL.Sys;
using LPS.Model.Sys;

namespace LPS.Services
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“LPSService”。
    public class LPSService : ILPSService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public EmpolyeeOR Login(string UserCode, string userPWD)
        {
            try
            {
                return new EmpolyeeDA().sp_UserLogin(UserCode, userPWD);
            }
            catch (Exception ex)
            {
                return new EmpolyeeOR() { ResultMsg=ex.Message, Result=1 };
            }
        }
    }
}
