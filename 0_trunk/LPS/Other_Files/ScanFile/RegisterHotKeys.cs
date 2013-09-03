using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Comtop.Terminal.Common
{
    public class RegisterHotKeys
    {
        //����api
        [DllImport("coredll.dll")]
        private static extern bool UnregisterFunc1(
        uint fsModifiers, //��ϼ��ļ�ֵ
        uint vk //�ȼ���ֵ
        );

        [DllImport("coredll.dll")]
        private static extern bool RegisterHotKey(
         IntPtr hWnd, //Ҫע��Ĵ���ľ�� 
         int id, // �ȼ��ļ�ֵ
         uint fsModifiers, //��ϼ��ļ�ֵ 
         uint vk // virtual-key code ��������ı��룬����͵ڶ�������һ����
        );

        [DllImport("coredll.dll")]
        private static extern bool UnregisterHotKey(
         IntPtr hWnd, //Ҫע��Ĵ���ľ��
         int id //�ȼ��ļ�ֵ
        );

        //ע���ȼ�����װ��UnregisterFunc1��RegisterHotKey
        private static bool _mRegisterHotKey(IntPtr hwnd, int id, uint vk)
        {
            bool re = UnregisterFunc1(KeyModifers.MOD_WIN, vk);
            bool re1 = RegisterHotKey(hwnd, id, KeyModifers.MOD_WIN, vk);
            return re && re1;
        }

        public static bool RegisterHotKey(IntPtr hwnd, bool isRegAll)
        {
            bool re = true;
            //����ע��Hardware5��Hardware6������Ӧ�øĳ����÷�ʽ
            //re = _mRegisterHotKey(hwnd, (int)KeysHardware.Hardware5, (uint)KeysHardware.Hardware5);
            //re = _mRegisterHotKey(hwnd, (int)KeysHardware.Hardware6, (uint)KeysHardware.Hardware6);
            if (isRegAll)
            {
                for (int i = (int)KeysHardware.Hardware1; i <= (int)KeysHardware.Hardware6; i++)
                {
                    re = _mRegisterHotKey(hwnd, i, (uint)i);
                    if (!re)
                    {
                        break;
                    }
                }
            }
            else
            {
                re = _mRegisterHotKey(hwnd, Convert.ToInt32(CustomConfig.ScanKeyCode), (uint)Convert.ToInt32(CustomConfig.ScanKeyCode));
            }
            return re;
        }

        public static bool UnRegisterHotKey(IntPtr hwnd, bool isUnRegAll)
        {
            bool re = true;
            //����ע��Hardware5��Hardware6������Ӧ�øĳ����÷�ʽ
            //re = UnregisterHotKey(hwnd, (int)KeysHardware.Hardware5);
            //re = UnregisterHotKey(hwnd, (int)KeysHardware.Hardware6);
            if (isUnRegAll)
            {
                for (int i = (int)KeysHardware.Hardware1; i <= (int)KeysHardware.Hardware6; i++)
                {
                    UnregisterHotKey(hwnd, i);
                    if (!re)
                    {
                        break;
                    }
                }
            }
            else
            {
                re = UnregisterHotKey(hwnd, Convert.ToInt32(CustomConfig.ScanKeyCode));
            }
            return re;
        }
    }
}