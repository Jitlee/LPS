using System;
using System.Collections.Generic;
using System.Text;


namespace Comtop.Terminal.Common
{
    /// <summary>
    /// ����BIP6000Sɨ����
    /// </summary>
    class Bip6000RfidScan:RfidScan
    {

        #region ---------������------------

        const int m_nBufSize = 255;
        RFIDCommand m_RFIDCommand;
        string m_strPortName;           
        byte m_byDetectMode;            
        uint m_dwBaudRate;
        byte m_byProtocol;

        byte[] m_abyUID;
        byte[] m_abyBuf;
        int m_nNumBytes;

        BbScanKeyMapping bbScanKeyMapping;

        #endregion

        /// <summary>
        /// ʵ�������󣬸��౻����
        /// </summary>
        public Bip6000RfidScan()
        {
            try
            {
                bbScanKeyMapping = new BbScanKeyMapping();
                bbScanKeyMapping.KeyMapInit();
                bbScanKeyMapping.SetKeyMappingToScan();

                m_RFIDCommand = new RFIDCommand();
                m_bOpenFlag = false;
                m_strPortName = "COM5:";
                m_byDetectMode = 1;
                m_dwBaudRate = 9600;
                m_byProtocol = 1;

                m_abyUID = new byte[10];
                m_abyBuf = new byte[m_nBufSize];
                m_nNumBytes = 0;
            }
            catch (Exception SSExp)
            {
                LogUtility.Write("ɨ��������ʼ��ʧ��(Bip6000RfidScan) -> " + SSExp.Message);
            }
        }

        /// <summary>
        /// ����ɨ��
        /// </summary>
        /// <returns></returns>
        public override bool OnScannerTrigger()
        {
            bool result = true;
            if (m_bOpenFlag)
            {
                CommandISO15693();
            }
            return result;
        }

        #region -------------ɨ����������----------------------
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
                if (!m_bOpenFlag)
                {
                    if (m_RFIDCommand.OpenDevice(m_strPortName, m_byDetectMode, m_dwBaudRate, m_byProtocol))
                    {
                        m_bOpenFlag = true;
                    }
                    else
                    {
                        m_bOpenFlag = false;
                        result = false;
                    }
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
                    m_RFIDCommand.SAMOnOff(false, m_abyBuf, ref m_nNumBytes);
                    m_RFIDCommand.CloseDevice();
                    m_strPortName = "COM6:";
                    m_byDetectMode = 1;
                    m_bOpenFlag = false;
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
                bbScanKeyMapping.SetKeyMappingDefault();
                bbScanKeyMapping.KeyMapClose();
                bbScanKeyMapping = null;
                base.ScanDisPose();
            }
            catch (Exception SSExp)
            {
                LogUtility.Write("ע��ɨ������ʵ������ʧ��(ScanDisPose) -> " + SSExp.Message);
                bbScanKeyMapping = null;
                base.ScanDisPose();
            }
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        #endregion

        #region -----------��������˽�к���

        private void CommandISO15693()
        {
            if (this.ChangeDataCodingMode())
            {
                this.InventoryRequest();
            }
        }

        private bool ChangeDataCodingMode()
        {
            byte byMode = 0x00;	// 0x00 = Standard Mode
            if (m_RFIDCommand.SetTagType(0x64, m_abyBuf, ref m_nNumBytes))
            {
            }
            if (m_RFIDCommand.ChangeDataCodingMode(byMode, m_abyBuf, ref m_nNumBytes))
            {
                return true;
            }
            return false;
        }

        private bool InventoryRequest()
        {
            byte bySlot = 0x01;
            byte byAFIF = 0x01;
            byte byAFIV = 0x00;
            byte byMSKL = 0x00;
            byte[] abyMSKV = new byte[8];
            string strData = "";
            string SymbolType = "";
            if (m_RFIDCommand.InventoryRequest(bySlot, byAFIF, byAFIV, byMSKL, abyMSKV, m_abyBuf, ref m_nNumBytes))
            {
                strData = BufStringHex(m_abyBuf, m_nNumBytes + 1);
                //�¼�����
                this.OnScanKeyPress(strData, SymbolType);

                Array.Copy(m_abyBuf, 4, m_abyUID, 0, 8);
                return true;
            }
            Array.Clear(m_abyUID, 0, 8);
            return false;
        }

        private string BufStringHex(byte[] abyBuf, int nLength)
        {
            string str = "";
            Array.Reverse(abyBuf, 1, abyBuf[0]);
            if (nLength < 9)
            {
                return str;
            }
            if (nLength > 9)
            {
                nLength = 9;
            }
            for (int i = 1; i < nLength; i++)
            {
                //ȫ���ֽ�Ϊ˫λ��0-F ֵ��Ҫ��ǰ�油0������0E           
                string sgl = String.Format("{0:X2}", abyBuf[i]);
                str += sgl;
            }
            return str;
        }

        private bool WarningMsgBox(String strMsg)
        {
            LogUtility.Write(strMsg);
            return true;
        }

        #endregion
    }
}
