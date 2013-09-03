using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SocketCommunications.Scan;

namespace Comtop.Terminal.Common
{
    /// <summary>
    /// 扫描头实体类
    /// 启动扫描驱动步骤：
    /// 1.先初始化扫描头驱动；2.再在另一个事件或进程中打开扫描设备
    /// 在同一个函数内同时初始化驱动和打开扫描设备，测试结果失败
    /// </summary>
    class HpX11RfidScan : RfidScan
    {
        private bool bCHSEnabled = false;
        private Thread threadWaitTrigger;
        private NamedEvent appShutdown;
        protected Scanner socketScanner;
        private NamedEvent myNamedEvent;

        /// <summary>
        /// 用于扫描头快捷键的异步调用委托
        /// </summary>
        private delegate bool TriggerDelegate();
        private TriggerDelegate triggerClick;

        public HpX11RfidScan()
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

        public override bool ScanStart()
        {
            bool result = true;
            try
            {
                if (!_scanInitSucceed)
                {
                    _scanInitSucceed = InitializeScanner();
                }
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

        public override bool ScanClose()
        {
            bool result = true;
            try
            {
                if (_scanInitSucceed)
                {
                    if (threadWaitTrigger != null)
                    {
                        if (appShutdown != null)
                        {
                            appShutdown.Set();
                        }
                    }

                    if (myNamedEvent != null && myNamedEvent.Handle != IntPtr.Zero)
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
            }
            catch (Exception SSExp)
            {
                LogUtility.Write("反初始化扫描头失败(ScanClose) -> " + SSExp.Message);
                result = false;
            }
            return result;
        }

        public override bool OpenScanDevice()
        {
            bool result = true;
            try
            {
                if (!m_bOpenFlag)
                {
                    socketScanner.ScanOpenDevice();
                    m_bOpenFlag = true;
                }
            }
            catch (Exception SSExp)
            {
                LogUtility.Write("打开扫描设备失败(OpenScanDevice) -> " + SSExp.Message);
                m_bOpenFlag = false;
                result = false;
            }
            return result;
        }

        public override bool CloseScanDevice()
        {
            bool result = true;
            try
            {
                if (m_bOpenFlag)
                {
                    if (socketScanner != null)
                    {
                        if (socketScanner.IsScannerConnected())
                        {
                            socketScanner.ScanCloseDevice();
                            m_bOpenFlag = false;
                        }
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

        public override void ScanDisPose()
        {
            try
            {
                this.CloseScanDevice();
              //  this.ScanClose();
                if (socketScanner != null)
                {
                    socketScanner.Dispose();
                }
                base.ScanDisPose();
            }
            catch (Exception SSExp)
            {
                LogUtility.Write("注销扫描驱动实例对象失败(ScanDisPose) -> " + SSExp.Message);
                base.ScanDisPose();//旭科加入
            }
        }

        public override void Dispose()
        {
            this.ScanDisPose();
          //  base.Dispose(); //xuke
        }

        public override bool OnScannerTrigger()
        {
            bool result = true;
            try
            {
                if (m_bOpenFlag)
                {
                    socketScanner.ScanTrigger();
                }
            }
            catch (Exception SSExp)
            {
                LogUtility.Write("设备扫描触发失败(OnScannerTrigger) -> " + SSExp.Message);
                result = false;
            }
            return result;
        }

        #region ------扫描辅助处理函数--------------
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
                //ScanDevInfo DevInfo = socketScanner.ScanGetDevInfo();
                //ScanSymbologyType barcodeType = new ScanSymbologyType();
                //SymbolType = barcodeType.BarcodeSymbolType(DevInfo.ScannerType, (int)DevInfo.SymbolType);
                //事件触发
                this.OnScanKeyPress(strData, SymbolType);
            }
            catch (Exception SSExp)
            {
                LogUtility.Write("获取扫描设备数据失败(OnScannerData) -> " + SSExp.Message);
            }
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

        #endregion
    }
}