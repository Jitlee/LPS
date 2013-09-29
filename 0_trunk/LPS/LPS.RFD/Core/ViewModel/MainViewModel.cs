using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LPS.RfidOn.Core.Model;
using System.Windows;
using System.Windows.Media.Imaging;
using LPS.RfidOn.View;
using System.Collections.ObjectModel;
using System.Windows.Threading;

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

        /// <summary>
        /// 登录名
        /// </summary>
        public string LoginName { get; set; }
		public string EmpolyeeNo { get; set; }

		public string BtnStart_StopRedRfidText { get; set; }
		public const string BtnStart_StopRedRfidText_Start = "开始读RFID";
		public const string BtnStart_StopRedRfidText_Stop = "保存RFID";
        #endregion

        #region 构造函数
        private MainViewModel()
        {
            _command = new DelegateCommand<string>(Excute);
			LoginName = GlobalData.CurrentUser.EmpolyeeName;
			EmpolyeeNo = GlobalData.CurrentUser.UserId;

			BtnStart_StopRedRfidText = BtnStart_StopRedRfidText_Start;
        }
        #endregion
        #region 事件处理
        private void Excute(string parameter)
        {
			if (parameter == "BtnStart_StopRedRfid")
            {
				if (BtnStart_StopRedRfidText == BtnStart_StopRedRfidText_Start)
				{
					BtnStart_StopRedRfidText = BtnStart_StopRedRfidText_Stop;
				}
				else
				{
					BtnStart_StopRedRfidText = BtnStart_StopRedRfidText_Start;
				}
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
