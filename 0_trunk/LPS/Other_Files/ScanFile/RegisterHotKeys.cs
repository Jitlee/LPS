using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Comtop.Terminal.Common
{
    public class RegisterHotKeys
    {
        //声明api
        [DllImport("coredll.dll")]
        private static extern bool UnregisterFunc1(
        uint fsModifiers, //组合键的键值
        uint vk //热键键值
        );

        [DllImport("coredll.dll")]
        private static extern bool RegisterHotKey(
         IntPtr hWnd, //要注册的窗体的句柄 
         int id, // 热键的键值
         uint fsModifiers, //组合键的键值 
         uint vk // virtual-key code （虚拟键的编码，这里和第二个参数一样）
        );

        [DllImport("coredll.dll")]
        private static extern bool UnregisterHotKey(
         IntPtr hWnd, //要注册的窗体的句柄
         int id //热键的键值
        );

        //注册热键，封装了UnregisterFunc1和RegisterHotKey
        private static bool _mRegisterHotKey(IntPtr hwnd, int id, uint vk)
        {
            bool re = UnregisterFunc1(KeyModifers.MOD_WIN, vk);
            bool re1 = RegisterHotKey(hwnd, id, KeyModifers.MOD_WIN, vk);
            return re && re1;
        }

        public static bool RegisterHotKey(IntPtr hwnd, bool isRegAll)
        {
            bool re = true;
            //仅需注册Hardware5、Hardware6，后续应该改成配置方式
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
            //仅需注册Hardware5、Hardware6，后续应该改成配置方式
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