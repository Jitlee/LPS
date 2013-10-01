using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.ComponentModel;
using LPS.LeafWeigh.LPSSer;

namespace LPS.LeafWeigh.Core.ViewModel
{
    internal  class WinWeighViewModel: EntityObject
    {
        #region 属性

        private static readonly WinWeighViewModel _instance = new WinWeighViewModel();
        public static WinWeighViewModel Instance { get { return _instance; } }

        private readonly DelegateCommand<string> _command;
        public DelegateCommand<string> Command { get { return _command; } }

        WinWeighViewModel _Page;
        
        /// <summary>
        /// 主页，用于切换
        /// </summary>
        public WinWeighViewModel MianPage { set { _Page = value; } }

        ObservableCollection<FarmerRfidOR> _FarmRfidListOR = null;
        /// <summary>
        ///  RFID列表。
        /// </summary>
        public ObservableCollection<FarmerRfidOR> FarmRfidListOR
        {
            get { return _FarmRfidListOR; }
        }
        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
		public string EmpolyeeNo { get; set; }

        /// <summary>
        /// 烟农姓名
        /// </summary>
        public string FarmerName { get; set; }

        /// <summary>
        /// 烟农卡号
        /// </summary>
        public string FarmerCard { get; set; }

        private string _BtnStart_StopRedRfidText;
        
        
        #endregion

        #region 构造函数
        private WinWeighViewModel()
        {
            _command = new DelegateCommand<string>(Excute);
            if (GlobalData.CurrentUser != null)
            {
                LoginName = GlobalData.CurrentUser.EmpolyeeName;
                EmpolyeeNo = GlobalData.CurrentUser.UserId;
            }
		

            _FarmRfidListOR = new ObservableCollection<FarmerRfidOR>();
            RaisePropertyChanged("FarmRfidListOR");
        }
        
        #endregion
        #region 事件处理
        private void Excute(string parameter)
        {
            if (parameter == "Weigh")
            {
                    
            }
        }
        #endregion

        private int GetTimeLen(DateTime Start, DateTime EndTime)
        {
            int TimeLen = 0;
            TimeSpan t = EndTime - Start;
            TimeLen = (t.Hours * 60 * 60) + t.Minutes * 60 + t.Seconds;
            return TimeLen;
        }

         
    } 
}