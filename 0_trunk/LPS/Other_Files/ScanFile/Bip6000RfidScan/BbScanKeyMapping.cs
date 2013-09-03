using System;
using System.Collections.Generic;
using System.Text;
using Bluebird.KeyMapping;

namespace Comtop.Terminal.Common
{
    /// <summary>
    /// Ӳ����ťӳ����-��BIP6000ɨ�����ﱻ����
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
        /// ��ʼ��
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
        /// �ر�Ӳ��ӳ��
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
        /// ����ɨ��ӳ��
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
                                LogUtility.Write("����ɨ��ӳ��ʧ��(SetKeyMappingToScan)");
                            }
                        }
                    }
                    if (i == nKeyCnt)
                    {
                        LogUtility.Write("����ɨ��ӳ��ʧ��(SetKeyMappingToScan)");
                    }
                }
            }

        }

        /// <summary>
        /// ��ԭĬ������
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
