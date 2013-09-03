using System;
using System.Collections.Generic;
using System.Text;
using Bluebird.KeyMapping;

namespace Comtop.Terminal.Common
{
    /// <summary>
    /// 硬件按钮映射类-在BIP6000扫描类里被调用
    /// </summary>
    class BbScanKeyMapping
    {
        private BBKeyMapping m_KeyMap = null;
        private const int MAX_BUFFER = 20;
        private int nKeyCnt = 0;

        public BbScanKeyMapping()
        {
            m_KeyMap = new BBKeyMapping();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void KeyMapInit()
        {
            if (m_KeyMap == null)
            {
                m_KeyMap = new BBKeyMapping();
            }
            m_KeyMap.Init();
            m_KeyMap.SetDefaultKey();
            nKeyCnt = m_KeyMap.GetKeyCount();
        }

        /// <summary>
        /// 关闭硬件映射
        /// </summary>
        public void KeyMapClose()
        {
            if (m_KeyMap != null)
            {
                m_KeyMap.Close();
                m_KeyMap = null;
            }
        }

        /// <summary>
        /// 设置扫描映射
        /// </summary>
        public void SetKeyMappingToScan()
        {
            if (m_KeyMap != null)
            {
                ushort usKeyCode = 0;
                ushort usKeyType = 0;
                StringBuilder strBuffer = new StringBuilder(MAX_BUFFER);
                if (nKeyCnt > 0)
                {
                    int i = 0;
                    for (i = 0; i < nKeyCnt; i++)
                    {
                        m_KeyMap.GetKeyData(i, ref usKeyCode, ref usKeyType, strBuffer, MAX_BUFFER);
                        if (strBuffer.ToString().CompareTo("Lside_key") == 0)
                        {
                            if (m_KeyMap.SetKeyData(i, BBKeyCode.VK_APP5, BBKeyType.KEY_TYPE_ONETIME))
                            {
                                break;
                            }
                            else
                            {
                                LogUtility.Write("设置扫描映射失败(SetKeyMappingToScan)");
                            }
                        }
                    }
                    if (i == nKeyCnt)
                    {
                        LogUtility.Write("设置扫描映射失败(SetKeyMappingToScan)");
                    }
                }
            }

        }

        /// <summary>
        /// 还原默认设置
        /// </summary>
        public void SetKeyMappingDefault()
        {
            if (m_KeyMap != null)
            {
                m_KeyMap.SetDefaultKey();
            }
        }
    }
}
