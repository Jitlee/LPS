using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Comtop.Terminal.Common
{
    /// <summary>
    /// RFID扫描基类，对外公布的唯一扫描类
    /// </summary>
    class RfidScan:IDisposable
    {
        #region ----------属性定义及构造静态实例------------------

        /// <summary>
        /// 扫描头快捷键事件
        /// </summary>
        public delegate void ScanKeyPressHandler(string strData, string strSymbolType);
        public static event ScanKeyPressHandler ScanKeyPressEvent;

        protected bool _scanInitSucceed = false;
        /// <summary>
        /// 扫描驱动是否已初始化
        /// </summary>
        public bool ScanInitSucceed
        {
            get { return _scanInitSucceed; }
        }

        protected bool m_bOpenFlag = false;
        /// <summary>
        /// 扫描设备是否已打开
        /// </summary>
        public bool OpenScanDeviceSucceed
        {
            get { return m_bOpenFlag; }
        }

        protected RfidScan()
        {
         
        }

        /// <summary>
        /// 扫描头静态实例
        /// </summary>
        private static RfidScan _instance = null;
        public static RfidScan StaticInstance
        {
            get
            {
                if (_instance == null)
                {
                    //实例化子类
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

        #region -------------扫描操作流程------------------

        /// <summary>
        /// 初始化扫描头驱动
        /// </summary>
        /// <returns></returns>
        public virtual bool ScanStart()
        {
            bool result = true;
            //如果子类没有重写，则默认为扫描驱动打开
            //用于后面打开设备的判断
            _scanInitSucceed = true;
            return result;
        }

        /// <summary>
        /// 关闭扫描头驱动
        /// </summary>
        /// <returns></returns>
        public virtual bool ScanClose()
        {
            bool result = true;
            _scanInitSucceed = false;
            return result;
        }

        /// <summary>
        /// 打开扫描设备
        /// </summary>
        /// <returns></returns>
        public virtual bool OpenScanDevice()
        {
            bool result = true;
            m_bOpenFlag = true;
            return result;
        }

        /// <summary>
        /// 关闭扫描设备
        /// </summary>
        /// <returns></returns>
        public virtual bool CloseScanDevice()
        {
            bool result = true;
            m_bOpenFlag = false;
            return result;
        }

        /// <summary>
        /// 注销扫描驱动实例对象
        /// </summary>
        /// <returns></returns>
        public virtual void ScanDisPose()
        {
            _instance = null;
        }

        /// <summary>
        /// 设备扫描触发
        /// </summary>
        /// <returns></returns>
        public virtual bool OnScannerTrigger()
        {
            bool result = true;
            return result;
        }

        /// <summary>
        /// 触发扫描按钮按下事件
        /// </summary>
        /// <param name="pData"></param>
        /// <param name="pSymbolType"></param>
        protected virtual void OnScanKeyPress(string pData, string pSymbolType)
        {
            if (pData != "" && ScanKeyPressEvent != null)
            {
                //播放铃声，声音文件格式必须是wav，部分声音文件在WM5、WM6上可能不存在或效果不同
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

        #region IDisposable 成员

        public virtual void Dispose()
        {           
        }

        void IDisposable.Dispose()
        {
        }

        #endregion
    }
}
