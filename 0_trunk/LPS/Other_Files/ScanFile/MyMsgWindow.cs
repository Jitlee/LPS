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
        private FormBase form = null; //FormBase�ȼ�Ҫע���Ӧ��������
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
                //����ֱ��������ֱ�Ӵ���ɨ�裬�����õ��ô��庯��
               this.clickHardWareButton(msg.WParam.ToInt32());
              return;
          }
          base.WndProc(ref msg);
        }

        /// <summary>
        /// Ӳ����ť�¼�
        /// </summary>
        /// <param name="value"></param>
        private void clickHardWareButton(int value)
        {
            //HP iPAQ 212����ȼ�ΪHardware6�������ͺ�PDA��HP iPAQ hx2000ϵ�С����񡢿����ΪKeysHardware.Hardware5
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
