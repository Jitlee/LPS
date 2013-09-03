using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Comtop.Terminal.Common
{
    class CR1000RfidScan : RfidScan
    {
        public override bool OpenScanDevice()
        {
            bool result = true;
            try
            {
                if (!m_bOpenFlag)
                {
                    int nRet = CFCommAPI.CF_Open(1);
                    if (nRet == CFCommAPI.SUCCESS)
                    {
                        m_bOpenFlag = true;
                    }
                    else
                    {
                        m_bOpenFlag = false;
                        MessageBoxForm.Show(null, "打开CF卡出错，请检查扫描头是否正常!","错误","确定",70,MessageBoxIcon.Hand);                                               
                    }
                }
            }
            catch (Exception SSExp)
            {
                LogUtility.Write("打开扫描设备失败(OpenScanDevice) -> " + SSExp.Message);
                m_bOpenFlag = false;
                result = false;
            }
            return result;
        }

        public override bool OnScannerTrigger()
        {
            bool result = false;
            try
            {
                if (m_bOpenFlag)
                {
                    result = Inventory();
                }
            }
            catch (Exception SSExp)
            {
                MessageBoxForm.Show(null, "设备扫描触发失败!", "错误", "确定", 70, MessageBoxIcon.Hand);                
                LogUtility.Write("设备扫描触发失败(OnScannerTrigger) -> " + SSExp.Message);
                result = false;
            }
            return result;
        }

        public override bool CloseScanDevice()
        {
            bool result = true;
            try
            {
                if (m_bOpenFlag)
                {
                    CFCommAPI.CF_Close();
                    m_bOpenFlag = false;
                }
            }
            catch (Exception SSExp)
            {
                LogUtility.Write("关闭扫描设备失败(CloseScanDevice) -> " + SSExp.Message);
                result = false;
                base.ScanDisPose();//旭科修改
            }
            return result;
        }

        public override void ScanDisPose()
        {
            this.CloseScanDevice();
            base.ScanDisPose();
        }

        private bool Inventory()
        {
            bool result = false;
            byte[] Recs = new byte[256];
            int nRec = 0;
            byte Status = 0;
            string strData;

            try
            {
                int nRet = CFCommAPI.CF_ISO_Inventorys(0, Recs, ref nRec, ref Status);
                if (nRet == CFCommAPI.SUCCESS)
                {
                    for (int j = 0; j < nRec; j++)
                    {
                        strData = "";
                        Array.Reverse(Recs, 1, 8);
                        for (int k = 0; k < 8; k++)
                        {
                            strData += Recs[j * 9 + k + 1].ToString("X2");
                        }

                        //事件触发
                        this.OnScanKeyPress(strData, "");
                        result = true;
                    }
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception SSExp)
            {
                MessageBoxForm.Show(null, "扫描出现异常：" + SSExp.Message, "错误", "确定", 70, MessageBoxIcon.Hand);                
                LogUtility.Write("扫描出现异常 -> " + SSExp.Message);
                result = false;
            }

            return result;
        }
    }
}