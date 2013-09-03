using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Runtime.InteropServices;
using Comtop.Terminal.Interface;

namespace Comtop.Terminal.Common
{
    class It700ScanKeyMapping
    {
        private IntPtr _hTrigger = IntPtr.Zero;
        private bool _bCheck = false;

        [DllImport("coredll.dll", EntryPoint = "CreateEvent", SetLastError = true)]
        private static extern IntPtr CECreateEvent(IntPtr lpEventAttributes, int bManualReset, int bInitialState, string lpName);

        [DllImport("coredll.dll", EntryPoint = "CloseHandle", SetLastError = true)]
        private static extern int CECloseHandle(IntPtr hObject);

        [DllImport("coredll.dll", EntryPoint = "WaitForSingleObject", SetLastError = true)]
        private static extern int CEWaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

        [DllImport("SysIOAPI.dll")]
        private static extern bool TriggerKeyStatus(int key);

        public It700ScanKeyMapping()
        {

        }

        public bool KeyMapInit()
        {
            bool result = true;
            try
            {
                if (!_bCheck)
                {
                    _hTrigger = CECreateEvent(IntPtr.Zero, 0, 0, "KeybdTriggerChangeEvent");
                    if (_hTrigger == IntPtr.Zero)
                    {
                        LogUtility.Write("It700ScanKeyMapping->创建触发器事件失败!");
                        return false;
                    }
                    _bCheck = true;
                    ThreadPool.QueueUserWorkItem(new WaitCallback(TriggerThread));
                }
            }
            catch (Exception ex)
            {
                LogUtility.Write("It700ScanKeyMapping->创建触发器事件失败!"+ex.Message);
                result = false;
            }
            return result;
        }

        public void KeyMapClose()
        {
            if (_bCheck)
            {
                _bCheck = false;
                CECloseHandle(_hTrigger);
            }
        }

        private void TriggerThread(object state)
        {
            EventHandler ehDown = new EventHandler(OnDown);
            EventHandler ehUp = new EventHandler(OnUp);

            while (_bCheck)
            {
                if (CEWaitForSingleObject(_hTrigger, 1000) == 0x00000000)
                {
                    if (TriggerKeyStatus(1))
                    {
                        //Left keydown
                        ehDown(null, null);
                    }
                    else if (TriggerKeyStatus(2))
                    {
                        //Right keydown
                        ehDown(null, null);
                    }
                    else
                    {
                        //Key_Up
                        ehUp(null,null);
                    }
                }
            }
        }

        private void OnDown(object obj, EventArgs e)
        {
            return;
        }

        private void DoThread(object data)
        {
            if (RfidScan.StaticInstance.OpenScanDeviceSucceed)
            {
                RfidScan.StaticInstance.OnScannerTrigger();
            }
        }

        private void OnUp(object obj, EventArgs e)
        {
            //康利达的硬件按钮这这里触发扫描事件
            if (RfidScan.StaticInstance.OpenScanDeviceSucceed)
            {
                RfidScan.StaticInstance.OnScannerTrigger();
            }
            //ThreadPool.QueueUserWorkItem(new WaitCallback(DoThread));        
            return;
        }
    }
}
