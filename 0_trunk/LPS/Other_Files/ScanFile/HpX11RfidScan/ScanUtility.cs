using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SocketCommunications.Scan;
using System.Windows.Forms;

namespace Comtop.Terminal.Common
{
    /// <summary>
    /// 扫描头实体类
    /// 启动扫描驱动步骤：
    /// 1.先初始化扫描头驱动；2.再在另一个事件或进程中打开扫描设备
    /// 在同一个函数内同时初始化驱动和打开扫描设备，测试结果失败
    /// </summary>
    class ScanUtility:IDisposable
    {
        private bool bCHSEnabled = false;
        private Thread threadWaitTrigger;
        private NamedEvent appShutdown;
        protected Scanner socketScanner;
        private NamedEvent myNamedEvent;

        /// <summary>
        /// 扫描头快捷键事件
        /// </summary>
        public delegate void ScanKeyPressHandler(string strData, string strSymbolType);
        public static event ScanKeyPressHandler ScanKeyPressEvent;

        /// <summary>
        /// 用于扫描头快捷键的异步调用委托
        /// </summary>
        private delegate bool TriggerDelegate();
        private TriggerDelegate triggerClick;

        private bool _scanInitSucceed = false;
        /// <summary>
        /// 扫描驱动是否已初始化
        /// </summary>
        public bool ScanInitSucceed
        {
            get { return _scanInitSucceed; }
        }

        private bool _openScanDeviceSucceed = false;
        /// <summary>
        /// 扫描设备是否已打开
        /// </summary>
        public bool OpenScanDeviceSucceed
        {
            get { return _openScanDeviceSucceed; }
        }

        /// <summary>
        /// 实例化
        /// </summary>
        private ScanUtility()
        {
            try
            {
                socketScanner = new Scanner();
            }
            catch (Exception SSExp)
            {
                LogUtility.Write("扫描驱动初始化失败(ScanUtility) -> " + SSExp.Message);
            }
        }

        /// <summary>
        /// 初始化扫描头驱动
        /// </summary>
        public bool ScanStart()
        {
            bool result = true;
            try
            {
                _scanInitSucceed=InitializeScanner();
                //_scanInitSucceed = true;
                //triggerClick = new TriggerDelegate(OnScannerTrigger); //启用异步委托,用于热键支持
                //EnableHotKeySupport(); //启用热键支持
            }
            catch (Exception SSExp)
            {
                LogUtility.Write("扫描驱动初始化失败(ScanStart) -> " + SSExp.Message);
                _scanInitSucceed = false;
                result = false;
            }
            return result;
        }

        /// <summary>
        ///反初始化扫描头 
        /// </summary>
        public bool ScanClose()
        {
            bool result = true;
            try
            {
                if (threadWaitTrigger != null)
                {
                    if (appShutdown != null)
                    {
                        appShutdown.Set();
                    }
                }

                if (myNamedEvent!=null && myNamedEvent.Handle != IntPtr.Zero)
                {
                    myNamedEvent.Close();
                }

                if (socketScanner != null)
                {
                    if (bCHSEnabled)
                        this.EnableDisableCHS();
                    socketScanner.ScanDeinit();
                    _scanInitSucceed = false;
                }
            }
            catch (Exception SSExp)
            {
                LogUtility.Write("反初始化扫描头失败(ScanClose) -> " + SSExp.Message);
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 注销扫描驱动实例对象
        /// </summary>
        /// <returns></returns>
        public bool ScanDisPose()
        {
            bool result = true;
            try
            {
                if (socketScanner != null)
                {
                    socketScanner.Dispose();
                }
            }
            catch (Exception SSExp)
            {
                LogUtility.Write("注销扫描驱动实例对象失败(ScanDisPose) -> " + SSExp.Message);
                result = false;
            }
            return result;
        }

        /// <summary>
        ///打开扫描设备
        /// </summary>
        public bool OpenScanDevice() 
        {
            bool result = true;
            try
            {
                socketScanner.ScanOpenDevice();
                _openScanDeviceSucceed = true;
            }
            catch (Exception SSExp)
            {
                LogUtility.Write("打开扫描设备失败(OpenScanDevice) -> " + SSExp.Message);
                _openScanDeviceSucceed = false;
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 关闭扫描设备
        /// </summary>
        public bool CloseScanDevice()
        {
            bool result = true;
            try
            {
                if (socketScanner != null)
                {
                    if (socketScanner.IsScannerConnected())
                    {
                        socketScanner.ScanCloseDevice();
                        _openScanDeviceSucceed = false;
                    }
                }
            }
            catch (Exception SSExp)
            {
                LogUtility.Write("关闭扫描设备失败(CloseScanDevice) -> " + SSExp.Message);
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 初始化扫描驱动
        /// </summary>
        protected bool InitializeScanner()
        {
            bool result = true;
            try
            {
                socketScanner.ScanInit();            
                socketScanner.ScannerInsertion += new ScannerInsertionEventHandler(OnScannerInsertion);
                socketScanner.ScannerData += new ScannerDataEventHandler(OnScannerData);
                socketScanner.ScannerCHSEvent += new ScannerCHSEventHandler(OnScannerCHSEvent);
                socketScanner.ScannerRemoval += new ScannerRemovalEventHandler(OnScannerRemoval);
            }
            catch (Exception SSExp)
            {
                LogUtility.Write("初始化扫描驱动失败(InitializeScanner) -> " + SSExp.Message);
                result = false;
            }
            return result;
        }

        /// <summary>
        /// 启动热键支持
        /// </summary>
        internal void EnableHotKeySupport()
        {
            try
            {
                myNamedEvent = NamedEvent.OpenExisting("ScktMyEventSckt");
                myNamedEvent.Set();
                myNamedEvent.Close();
            }
            catch (System.ComponentModel.Win32Exception exp)
            {
                threadWaitTrigger = new Thread(new ThreadStart(NamedEventThreadProc));
                appShutdown = new NamedEvent("SocketCSharpSampleShudown", false, false);
                threadWaitTrigger.Start();
            }
        }

        /// <summary>
        /// 扫描头静态实例
        /// </summary>
        private static ScanUtility _instance = null;
        public static ScanUtility StaticInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ScanUtility();
                }
                return _instance;
            }
        }

        public void EnableDisableCHS()
        {
            if (bCHSEnabled)
            {
                socketScanner.ScanDisableCHS();
                bCHSEnabled = false;
            }
            else
            {
                socketScanner.ScanEnableCHS();
                bCHSEnabled = true;
            }
        }

        /// <summary>
        /// 热键事件监听器
        /// </summary>
        public void NamedEventThreadProc()
        {
            myNamedEvent = new NamedEvent("ScktMyEventSckt", false, false);//wait to get signaled
            IntPtr[] waitHandles = new IntPtr[2];
            waitHandles[0] = myNamedEvent.Handle;
            waitHandles[1] = appShutdown.Handle;

            while (true)
            {
                uint ret = 0;
                try
                {
                    ret = NamedEvent.WaitForMultipleObjects(waitHandles, false, 0xFFFFFFFF);//wait for ever
                }
                catch (System.ComponentModel.Win32Exception exp)
                {
                    string err = exp.ToString();
                }
                if (ret == 1)
                {
                    break;
                }
                else
                {
                    if (ret == 0)
                    {
                        if (socketScanner.IsScannerConnected())
                        {
                            //委托调用，执行扫描函数
                            this.triggerClick.Invoke();
                        }
                    }
                }
            }

        }

        #region SocketScan events
        public void OnScannerInsertion(ScannerEventArgs args)
        {
        }

        private void OnScannerRemoval(ScannerEventArgs args)
        {
            try
            {
                if (socketScanner.IsScannerConnected())
                {
                    socketScanner.ScanCloseDevice();

                }
                if (bCHSEnabled)
                {
                    EnableDisableCHS();
                }
            }
            catch
            { }
        }

        /// <summary>
        /// 获取扫描设备数据
        /// </summary>
        public void OnScannerData()
        {
            try
            {
                string strData = "";
                string SymbolType = "";
                strData = socketScanner.ScanGetData();
                ScanDevInfo DevInfo = socketScanner.ScanGetDevInfo();
                ScanSymbologyType barcodeType = new ScanSymbologyType();
                SymbolType = barcodeType.BarcodeSymbolType(DevInfo.ScannerType, (int)DevInfo.SymbolType);
                //事件触发
                if (ScanKeyPressEvent != null)
                {
                    ScanKeyPressEvent(strData, SymbolType);
                }
            }
            catch (Exception SSExp)
            {
                LogUtility.Write("获取扫描设备数据失败(OnScannerData) -> " + SSExp.Message);
            }
        }

        internal void SampleAppException()
        {
            MessageBox.Show("扫描设备获取数据失败");
        }

        /// <summary>
        /// CHS event handler
        /// </summary>
        /// <param name="args"></param>
        public void OnScannerCHSEvent(ScannerCHSEventArgs args)
        {
            switch (args.EventType)
            {
                case CHSEvents.CHSBTLinkDropped:			// connection to CHS was lost
                    break;
                case CHSEvents.CHSBTLinkReEstablished:	// connection to CHS reestablished
                    break;
                case CHSEvents.CHSBTLinkAborted:		// reconnect attempts aborted by timeout
                    break;
                default:
                    break;
            }
        }
        
        /// <summary>
        /// 设备扫描触发
        /// </summary>
        public bool OnScannerTrigger()
        {
            bool result = true;
            try
            {
                socketScanner.ScanTrigger();
            }
            catch (Exception SSExp)
            {
                LogUtility.Write("设备扫描触发失败(OnScannerTrigger) -> " + SSExp.Message);
                result = false;
            }
            return result;
        }
        #endregion SocketScan events
    
       #region IDisposable 成员

        /// <summary>
        /// 注销扫描驱动实例对象、扫描实体类对象
        /// </summary>
        public void Dispose()
        {
            ScanDisPose();
            _instance = null;
        }

        #endregion

        #region IDisposable 成员

        void IDisposable.Dispose()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
