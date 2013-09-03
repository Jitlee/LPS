using System;
using System.Collections.Generic;
using System.Text;

namespace Comtop.Terminal.Common
{
    /// <summary>
    /// ����BIP-6000 S RFID�Ķ���-������
    /// </summary>
    class ScanForBip6000s
    {
        #region ---------������
        const int m_nBufSize = 255;
        RFIDCommand m_RFIDCommand;
        bool m_bOpenFlag;               // device state : Open/Close
        string m_strPortName;           // com port name : "COM6"
        byte m_byDetectMode;            // detect mode : 1(autodetect), 0(detect)
        uint m_dwBaudRate;
        byte m_byProtocol;

        byte[] m_abyUID;
        byte[] m_abyBuf;
        int m_nNumBytes;

        BbScanKeyMapping bbScanKeyMapping;

        /// <summary>
        /// ɨ��ͷ��ݼ��¼�
        /// </summary>
        public delegate void ScanKeyPressHandler(string strData, string strSymbolType);
        public static event ScanKeyPressHandler ScanKeyPressEvent;

        /// <summary>
        /// ɨ���豸�Ƿ��Ѵ�
        /// </summary>
        public bool OpenScanDeviceSucceed
        {
            get { return m_bOpenFlag; }
        }

        #endregion

        #region ---------���쾲̬ʵ����
        /// <summary>
        /// ��ʼ����̬ʵ����
        /// </summary>
        private ScanForBip6000s()
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
                LogUtility.Write("ɨ��������ʼ��ʧ��(ScanForBip6000s) -> " + SSExp.Message);
            }
        }

        /// <summary>
        /// ɨ��ͷ��̬ʵ��
        /// </summary>
        private static ScanForBip6000s _instance = null;
        public static ScanForBip6000s StaticInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ScanForBip6000s();
                }
                return _instance;
            }
        }

        #endregion

        #region ---------ɨ�����

        /// <summary>
        ///��ɨ���豸
        /// </summary>
        public bool OpenScanDevice()
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

        /// <summary>
        /// �ر�ɨ���豸
        /// </summary>
        public bool CloseScanDevice()
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

        /// <summary>
        /// ע��ɨ������ʵ������
        /// </summary>
        /// <returns></returns>
        public void ScanDisPose()
        {
            try
            {
                this.CloseScanDevice();
                bbScanKeyMapping.SetKeyMappingDefault();
                bbScanKeyMapping.KeyMapClose();
                bbScanKeyMapping = null;
                _instance = null;
            }
            catch (Exception SSExp)
            {
                LogUtility.Write("ע��ɨ������ʵ������ʧ��(ScanDisPose) -> " + SSExp.Message);
            }
        }

        /// <summary>
        /// �豸ɨ�败��
        /// </summary>
        public bool OnScannerTrigger()
        {
            bool result = true;
            if (m_bOpenFlag)
            {
                CommandISO15693();
            }
            return result;
        }
        #endregion

        #region -----------��������˽�к���

        private void CommandISO15693()
        {
            if (this.ChangeDataCodingMode())
                this.InventoryRequest();
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
                strData=BufStringHex(m_abyBuf, m_nNumBytes + 1);
                //�¼�����
                if (strData!="" && ScanKeyPressEvent != null)
                {
                    ScanKeyPressEvent(strData, SymbolType);
                }

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
                return str;
            if (nLength > 9)
            {
                nLength = 9;
            }
            for (int i = 1; i < nLength; i++)
            {
                //ȫ���ֽ�Ϊ˫λ��0-F ֵ��Ҫ��ǰ�油0������0E           
                string sgl = String.Format("{0:X}", abyBuf[i]);
                if (sgl.Length == 1)
                {
                    sgl = "0" + sgl;
                }
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
