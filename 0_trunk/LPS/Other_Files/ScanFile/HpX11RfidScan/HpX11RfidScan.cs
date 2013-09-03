using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using SocketCommunications.Scan;

namespace Comtop.Terminal.Common
{
    /// <summary>
    /// ɨ��ͷʵ����
    /// ����ɨ���������裺
    /// 1.�ȳ�ʼ��ɨ��ͷ������2.������һ���¼�������д�ɨ���豸
    /// ��ͬһ��������ͬʱ��ʼ�������ʹ�ɨ���豸�����Խ��ʧ��
    /// </summary>
    class HpX11RfidScan : RfidScan
    {
        private bool bCHSEnabled = false;
        private Thread threadWaitTrigger;
        private NamedEvent appShutdown;
        protected Scanner socketScanner;
        private NamedEvent myNamedEvent;

        /// <summary>
        /// ����ɨ��ͷ��ݼ����첽����ί��
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
                LogUtility.Write("ɨ��������ʼ��ʧ��(ScanUtility) -> " + SSExp.Message);
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
                //triggerClick = new TriggerDelegate(OnScannerTrigger); //�����첽ί��,�����ȼ�֧��
                //EnableHotKeySupport(); //�����ȼ�֧��
            }
            catch (Exception SSExp)
            {
                LogUtility.Write("ɨ��������ʼ��ʧ��(ScanStart) -> " + SSExp.Message);
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
                LogUtility.Write("����ʼ��ɨ��ͷʧ��(ScanClose) -> " + SSExp.Message);
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
                LogUtility.Write("��ɨ���豸ʧ��(OpenScanDevice) -> " + SSExp.Message);
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
                LogUtility.Write("�ر�ɨ���豸ʧ��(CloseScanDevice) -> " + SSExp.Message);
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
                LogUtility.Write("ע��ɨ������ʵ������ʧ��(ScanDisPose) -> " + SSExp.Message);
                base.ScanDisPose();//��Ƽ���
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
                LogUtility.Write("�豸ɨ�败��ʧ��(OnScannerTrigger) -> " + SSExp.Message);
                result = false;
            }
            return result;
        }

        #region ------ɨ�踨��������--------------
        /// <summary>
        /// ��ʼ��ɨ������
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
                LogUtility.Write("��ʼ��ɨ������ʧ��(InitializeScanner) -> " + SSExp.Message);
                result = false;
            }
            return result;
        }

        /// <summary>
        /// �����ȼ�֧��
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
        /// �ȼ��¼�������
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
                            //ί�е��ã�ִ��ɨ�躯��
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
        /// ��ȡɨ���豸����
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
                //�¼�����
                this.OnScanKeyPress(strData, SymbolType);
            }
            catch (Exception SSExp)
            {
                LogUtility.Write("��ȡɨ���豸����ʧ��(OnScannerData) -> " + SSExp.Message);
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