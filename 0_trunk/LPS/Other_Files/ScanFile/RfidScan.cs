using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Comtop.Terminal.Common
{
    /// <summary>
    /// RFIDɨ����࣬���⹫����Ψһɨ����
    /// </summary>
    class RfidScan:IDisposable
    {
        #region ----------���Զ��弰���쾲̬ʵ��------------------

        /// <summary>
        /// ɨ��ͷ��ݼ��¼�
        /// </summary>
        public delegate void ScanKeyPressHandler(string strData, string strSymbolType);
        public static event ScanKeyPressHandler ScanKeyPressEvent;

        protected bool _scanInitSucceed = false;
        /// <summary>
        /// ɨ�������Ƿ��ѳ�ʼ��
        /// </summary>
        public bool ScanInitSucceed
        {
            get { return _scanInitSucceed; }
        }

        protected bool m_bOpenFlag = false;
        /// <summary>
        /// ɨ���豸�Ƿ��Ѵ�
        /// </summary>
        public bool OpenScanDeviceSucceed
        {
            get { return m_bOpenFlag; }
        }

        protected RfidScan()
        {
         
        }

        /// <summary>
        /// ɨ��ͷ��̬ʵ��
        /// </summary>
        private static RfidScan _instance = null;
        public static RfidScan StaticInstance
        {
            get
            {
                if (_instance == null)
                {
                    //ʵ��������
                    if (string.IsNullOrEmpty(CustomConfig.ScanningHeadType))
                    {
                        
                        _instance = new Bip6000RfidScan();
                    }
                    else
                    {
                        switch ((EnumUtility.ScanningHeadType)Enum.Parse(typeof(EnumUtility.ScanningHeadType), CustomConfig.ScanningHeadType, true))
                        {
                            case EnumUtility.ScanningHeadType.LogicScan:
                                _instance = new KldIt700RfidScan();
                                break;
                            case EnumUtility.ScanningHeadType.Socket:
                                _instance = new HpX11RfidScan();
                                break;
                            case EnumUtility.ScanningHeadType.CR1000:
                                _instance = new CR1000RfidScan();
                                break;
                            case EnumUtility.ScanningHeadType.Bluebird:
                            default:
                                _instance = new Bip6000RfidScan();
                                break;
                        }
                    }
                }
                return _instance;
            }
        }

        #endregion

        #region -------------ɨ���������------------------

        /// <summary>
        /// ��ʼ��ɨ��ͷ����
        /// </summary>
        /// <returns></returns>
        public virtual bool ScanStart()
        {
            bool result = true;
            //�������û����д����Ĭ��Ϊɨ��������
            //���ں�����豸���ж�
            _scanInitSucceed = true;
            return result;
        }

        /// <summary>
        /// �ر�ɨ��ͷ����
        /// </summary>
        /// <returns></returns>
        public virtual bool ScanClose()
        {
            bool result = true;
            _scanInitSucceed = false;
            return result;
        }

        /// <summary>
        /// ��ɨ���豸
        /// </summary>
        /// <returns></returns>
        public virtual bool OpenScanDevice()
        {
            bool result = true;
            m_bOpenFlag = true;
            return result;
        }

        /// <summary>
        /// �ر�ɨ���豸
        /// </summary>
        /// <returns></returns>
        public virtual bool CloseScanDevice()
        {
            bool result = true;
            m_bOpenFlag = false;
            return result;
        }

        /// <summary>
        /// ע��ɨ������ʵ������
        /// </summary>
        /// <returns></returns>
        public virtual void ScanDisPose()
        {
            _instance = null;
        }

        /// <summary>
        /// �豸ɨ�败��
        /// </summary>
        /// <returns></returns>
        public virtual bool OnScannerTrigger()
        {
            bool result = true;
            return result;
        }

        /// <summary>
        /// ����ɨ�谴ť�����¼�
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pSymbolType"></param>
        protected virtual void OnScanKeyPress(string pData, string pSymbolType)
        {
            if (pData != "" && ScanKeyPressEvent != null)
            {
                //���������������ļ���ʽ������wav�����������ļ���WM5��WM6�Ͽ��ܲ����ڻ�Ч����ͬ
                if (Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor < 2)
                {
                    SoundPlayer.PlaySound("notify", IntPtr.Zero, PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_SYNC);
                }
                else
                {
                    SoundPlayer.PlaySound("Alarm5", IntPtr.Zero, PlaySoundFlags.SND_FILENAME | PlaySoundFlags.SND_SYNC);
                }
                ScanKeyPressEvent(pData, pSymbolType);
            }
        }

        #endregion

        #region IDisposable ��Ա

        public virtual void Dispose()
        {           
        }

        void IDisposable.Dispose()
        {
        }

        #endregion
    }
}
