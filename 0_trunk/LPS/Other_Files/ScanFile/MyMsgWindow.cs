using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsCE.Forms;
using Comtop.Terminal.Interface;

namespace Comtop.Terminal.Common
{
    public class MyMsgWindow : MessageWindow
    {
        public const int WM_HOTKEY = 0x0312;
        private FormBase form = null; //FormBase热键要注册的应用主窗体
        public MyMsgWindow(FormBase form)
        {
           this.form = form;
        }

        protected override void WndProc(ref Message msg)
        {
          switch (msg.Msg)
          {
            case WM_HOTKEY:
               //form.clickHardWareButton(msg.WParam.ToInt32());
                //可以直接在这里直接触发扫描，而不用调用窗体函数
               this.clickHardWareButton(msg.WParam.ToInt32());
              return;
          }
          base.WndProc(ref msg);
        }

        /// <summary>
        /// 硬件按钮事件
        /// </summary>
        /// <param name="value"></param>
        private void clickHardWareButton(int value)
        {
            //HP iPAQ 212左侧热键为Hardware6，其他型号PDA（HP iPAQ hx2000系列、蓝鸟、康利达）为KeysHardware.Hardware5
            if (value == Convert.ToInt32(CustomConfig.ScanKeyCode))
            {
                if (RfidScan.StaticInstance.OpenScanDeviceSucceed)
                {
                    RfidScan.StaticInstance.OnScannerTrigger();
                }
            }
        }
    }
}
