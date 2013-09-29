using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LPS.Model.Pur
{
    public class FarmerRfidOR : EntityObject
    {
        // 保存烟农ID
        private string _farmerId;

        /// <summary>
        /// 获取或设置烟农ID
        /// </summary>
        public string FarmerId
        {
            get
            {
                return _farmerId;
            }
            set
            {
                _farmerId = value;
                RaisePropertyChanged("FarmerId");
            }
        }

        private string _Rfid;
        /// <summary>
        /// 
        /// </summary>
        public string Rfid
        {
            get { return _Rfid; }
            set { _Rfid = value; RaisePropertyChanged("Rfid"); }
        }


    }
}
