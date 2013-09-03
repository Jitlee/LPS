using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace Comtop.Terminal.Common
{
    /// <summary>
    /// 康利达It700扫描类
    /// </summary>
    class KldIt700RfidScan:RfidScan
    {
        It700ScanKeyMapping it700ScanKeyMapping;
        private byte m_bytePort = 2;
        private bool b_KeyInit = false;

        public KldIt700RfidScan()
        {
            it700ScanKeyMapping = new It700ScanKeyMapping();
            m_bOpenFlag = false;
        }

        public override bool ScanStart()
        {
            return base.ScanStart();
        }

        public override bool ScanClose()
        {
            return base.ScanClose();
        }

        public override bool OpenScanDevice()
        {
            bool result = true;
            try
            {
                if (!b_KeyInit)
                {
                    if (!it700ScanKeyMapping.KeyMapInit())
                    {
                        b_KeyInit = false;
                        m_bOpenFlag = false;
                        return false;
                    }
                    b_KeyInit = true;
                }
                if (!m_bOpenFlag)
                {                    
                    if (!ConnectToReader())
                    {
                        m_bOpenFlag = false;
                        return false;
                    }
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
                if (b_KeyInit)
                {
                    it700ScanKeyMapping.KeyMapClose();
                    b_KeyInit = false;
                }
                if (m_bOpenFlag)
                {
                    DisconnectToReader();
                    m_bOpenFlag = false;
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
            this.CloseScanDevice();
            base.ScanDisPose();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
        #region --------------读取电子标签值

        public override bool OnScannerTrigger()
        {
            bool result = true;
            if (RDINT.RDINT_WorkingType(m_bytePort, RDINT.WORKING_TYPE.WT_ISO15693) == 0)
            {
                ReadTagUID();
            }
            return result;
        }

        private delegate void UpdateUIDDelegate(string strData, string strSymbolType);
        bool IsOperEnd = true;

        /// <summary>
        /// 读取标签UID
        /// </summary>
        public void ReadTagUID()
        {
            #region code

            if (!m_bOpenFlag)
                return;

            byte[] byteMask = new byte[9];
            byte[] byteData = new byte[1024];
            byte byteDsfid = 0;

            string strData = "";
            string SymbolType = "";

            for (int i = 0; i < 9; i++)
            {
                byteMask[i] = 0xFF;
            }

            for (int i = 0; i < 3; i++)
            {
                if (RDINT.RDINT_ISO15693Inventory(m_bytePort, 0x26, 0, 0, ref byteMask[0], out  byteDsfid, out byteData[0]) == 0)
                {
                    strData=Method.ByteArrayToString(byteData, 8);
                    break;
                }
            }

            //事件触发
            this.OnScanKeyPress(strData, SymbolType);
            #endregion
        }

        #endregion

        #region ----------------扫描辅助函数-------------



        private bool ConnectToReader()
        {
            byte bytePort = 0;
            uint u32Baudrate = 0;
            string strAccessCode = "00000000";

            if (GetCOMPort(out bytePort))
            {
                if (RDINT.RDINTsys_OpenReader(bytePort, 19200, strAccessCode, RDINT.TURN_ON_OFF.TURN_ON, 700, out u32Baudrate) == 0)
                {
                    m_bytePort = bytePort;
                    return true;
                }
            }

            for (int i = 1; i < 10; i++)
            {
                if (RDINT.RDINTsys_OpenReader(Convert.ToByte(i), 19200, strAccessCode, RDINT.TURN_ON_OFF.TURN_ON, 700, out u32Baudrate) == 0)
                {
                    m_bytePort = Convert.ToByte(i);
                    SetCOMPort(Convert.ToByte(i));
                    return true;
                }
            }
            return false;
        }

        private void DisconnectToReader()
        {
            RDINT.RDINTsys_CloseReader(m_bytePort);
        }

        private bool GetCOMPort(out byte bytePort)
        {
            RegistryKey rKey = Registry.LocalMachine.OpenSubKey("Software\\RFID_HF", true);

            if (rKey != null)
            {
                string[] value = rKey.GetValueNames();

                foreach (string data in value)
                {
                    if (data.ToUpper().Equals("COMPORT"))
                    {
                        bytePort = Convert.ToByte(rKey.GetValue(data));
                        rKey.Close();
                        return true;
                    }
                }
                bytePort = 0;
                rKey.Close();
                return false;
            }
            else
            {
                bytePort = 0;
                return false;
            }
        }

        private bool SetCOMPort(byte bytePort)
        {
            RegistryKey rKey = Registry.LocalMachine.CreateSubKey("Software\\RFID_HF");
            if (rKey != null)
            {
                rKey.SetValue("COMPort", bytePort);
                rKey.Close();
                return true;
            }
            rKey.Close();
            return false;
        }

        #endregion
    }
}
