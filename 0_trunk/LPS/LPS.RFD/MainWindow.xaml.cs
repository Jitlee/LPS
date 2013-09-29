using System;
using System.Configuration;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using LPS.RfidOn.Core.Uitl;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LPS.RfidOn.View;
using LPS.RfidOn.Core.ViewModel;



namespace LPS.RfidOn
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        internal MainViewModel ViewModel { get; set; }

        public MainWindow()
        {
            var loginWindow = new LoginWindow();
            if (loginWindow.ShowDialog() == true)
            {
                InitializeComponent();
                ViewModel = MainViewModel.Instance;
                ViewModel.MianPage = this;
                this.DataContext = ViewModel;
                this.Loaded += new RoutedEventHandler(MetroWindow_Loaded);                
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
        
        private void lbItem_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is FrameworkElement)
            {
                var element = e.OriginalSource as FrameworkElement;
                
            }
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
             
        }

        #region 热键处理
        HotKey hotKey = null;
        public void HeadHotkey(string strHotkey)
        {
            Console.WriteLine(strHotkey);

            if (!string.IsNullOrWhiteSpace(strHotkey) && strHotkey.IndexOf("+")>0)
            {
                string[] keyarr = strHotkey.Split('+');
                if (keyarr.Length >= 2)
                {
                    HotKey.KeyFlags control= HotKey.KeyFlags.MOD_CONTROL;
                    for (int i = 0; i < keyarr.Length - 1; i++)
                    {
                        if (!"shift ctrl alt".Contains(keyarr[i].ToLower()))
                        {
                            Console.WriteLine("错误的热键！");
                            return;
                        }
                        if (i == 0)
                            control = GetControlKey(keyarr[i]);
                        else
                            control = control | GetControlKey(keyarr[i]);
                    }
                    System.Windows.Forms.Keys mkey = new HotKeyCollection().GetKeys(keyarr[keyarr.Length - 1]);
                    if (hotKey != null)
                    {
                        hotKey.UnHotKey();
                    }
                    hotKey = new HotKey(this, control, mkey);
                    hotKey.OnHotKey += new HotKey.OnHotKeyEventHandler(hotKey_OnHotKey);
                }
                else
                {
                    Console.WriteLine("热键长度不足");
                }
            }
        }
        private HotKey.KeyFlags GetControlKey(string str)
        {
            HotKey.KeyFlags keyControl;
            switch (str.ToLower())
            {
                case "shift":
                    keyControl = HotKey.KeyFlags.MOD_SHIFT;
                    break;
                case "alt":
                    keyControl = HotKey.KeyFlags.MOD_ALT;
                    break;                    
                default:
                    keyControl = HotKey.KeyFlags.MOD_CONTROL;
                    break;
            }
            return keyControl;
        }
        #endregion

        #region 显示隐藏处理
        protected ShowStaus mShowStatus { get; set; }
        private void hotKey_OnHotKey()
        {
            Console.WriteLine("hotKey_OnHotKey");
            if (this.mShowStatus == ShowStaus.Show)
            {
                this.mShowStatus = ShowStaus.Hide;
                this.Hide();
            }
            else
            {
                this.Show();
                this.mShowStatus = ShowStaus.Show;
            }
        }
        #endregion

        private void Window_Closed(object sender, EventArgs e)
        {
            
        }

        #region 公共方法
        private void ShowErrorMsg(string msg)
        {
            MessageBox.Show(msg, "出错啦!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        #endregion
    }
    public enum ShowStaus { Show, Hide }
}
