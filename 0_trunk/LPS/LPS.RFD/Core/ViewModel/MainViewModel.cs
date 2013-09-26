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
        #endregion

        #region 构造函数
        private MainViewModel()
        {

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
