using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Imaging;
using LPS.RfidOn.View;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.ComponentModel;
using LPS.RfidOn.LPSSer;

namespace LPS.RfidOn.Core.ViewModel
{
    internal class MainViewModel : EntityObject
    {
        #region 属性

        private static readonly MainViewModel _instance = new MainViewModel();
        public static MainViewModel Instance { get { return _instance; } }

        private readonly DelegateCommand<string> _command;
        public DelegateCommand<string> Command { get { return _command; } }

        MainWindow _Page;
        
        /// <summary>
        /// 主页，用于切换
        /// </summary>
        public MainWindow MianPage { set { _Page = value; } }

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
        /// <summary>
        /// 
        /// </summary>
        public string BtnStart_StopRedRfidText { 
            get { return _BtnStart_StopRedRfidText; } 
            set { _BtnStart_StopRedRfidText = value; RaisePropertyChanged("BtnStart_StopRedRfidText"); }
        }

		public const string BtnStart_StopRedRfidText_Start = "开始读取RFID";
		public const string BtnStart_StopRedRfidText_Stop = "保存RFID";


        private bool _SaveIsEnable;
        /// <summary>
        /// 是否可以保存
        /// </summary>
        public bool SaveIsEnable
        {
            get { return _SaveIsEnable; }
            set { _SaveIsEnable = value; RaisePropertyChanged("SaveIsEnable"); }
        }
        
        #endregion

        #region 构造函数
        private MainViewModel()
        {
            _command = new DelegateCommand<string>(Excute);
            if (GlobalData.CurrentUser != null)
            {
                LoginName = GlobalData.CurrentUser.EmpolyeeName;
                EmpolyeeNo = GlobalData.CurrentUser.UserId;
            }
			BtnStart_StopRedRfidText = BtnStart_StopRedRfidText_Start;

            SaveIsEnable = false;

            _FarmRfidListOR = new ObservableCollection<FarmerRfidOR>();
             
//            RaisePropertyChanged("FarmRfidListOR");
        }
        
        #endregion
        #region 事件处理
        private void Excute(string parameter)
        {
			if (parameter == "BtnStart_StopRedRfid")
            {
                    SaveIsEnable = true;				 
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

    /// <summary>
    /// 用户状态
    /// </summary>
    public enum EmployeeStatus
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal,
        /// <summary>
        /// 暂停
        /// </summary>
        Pause
    }
}
