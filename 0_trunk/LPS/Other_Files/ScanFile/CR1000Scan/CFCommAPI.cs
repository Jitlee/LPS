using System;
using System.Runtime.InteropServices;

namespace Comtop.Terminal.Common
{
	/// <summary>
	/// 
	/// </summary>
	public unsafe class CFCommAPI
	{
		public CFCommAPI()
		{
			// 
			// TODO: 在此处添加构造函数逻辑
			//
		}

        public const int SUCCESS = 1;
        public const int FAILURE = 0;
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_Open(int nSlot);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_Close();
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_ResetCard();
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_ISO_Inventory(int nAFI, byte[] UID, ref int nUID, ref byte nDSFID, ref byte Status);//nAFI=0,1
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_ISO_Inventorys(int nAFI, byte[] Recs, ref int nRec, ref byte Status);//nAFI=0,1
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_ISO_StayQuiet(byte[] UID, int nUID, ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_ISO_ReadSingleBlock(int nTypeCmd, int BlockNum, byte[] UID, int nUID, byte[] pResponse, ref int nLen, ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_ISO_WriteSingleBlock(int nTypeCmd, int BlockNum, byte[] UID, int nUID, byte[] pSend, int nLen, ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_ISO_LockBlock(int nTypeCmd, int BlockNum, byte[] UID, int nUID, ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_ISO_ReadMultiBlock(int nTypeCmd, int BlockNum, byte[] UID, int nUID, int Numbet, byte[] pResponse, ref int nLen, ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_ISO_Select(byte[] UID, int nUID, ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_ISO_ResetToReady(int nTypeCmd, byte[] UID, int nUID, ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_ISO_WriteAFI(int nTypeCmd, byte[] UID, int nUID, int nAFI, ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_ISO_WriteDSFID(int nTypeCmd, byte[] UID, int nUID, int nDSFID, ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_ISO_LockDSFID(int nTypeCmd, byte[] UID, int nUID, ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_ISO_LockAFI(int nTypeCmd, byte[] UID, int nUID, ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_ISO_GetSystemInfo(int nTypeCmd, byte[] UID, int nUID, ref int nResponse, byte[] Response, ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_AF_Scan(byte nTimeOut, string File, ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_AF_InitPowOff(ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_AF_SetRegVal(int RegAddr, byte Val, ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_AF_InitPowOn(ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_SetVICCtype(int nType, int RetryNum, ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_ISO15693(int DataLink, int modulation, int Baud, int Carrer, ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_GetVersion(ref int nData, byte[] Data, ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_DirectCmd(int OperateType, int nCmdLen, byte[] Cmd, ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_Reset(ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_PowerDown(ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_CarryOnOff(ref byte Status, int bOn);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_ISO_Lock_2_Blocks(int nTypeCmd, int BlockNum, byte[] UID, int nUID, ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_ISO_Write_2_Blocks(int nTypeCmd, int BlockNum, byte[] UID, int nUID, int nLen, byte[] Data, ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_ISO_Get_M_BLK_Sec_St(int nTypeCmd, int BlockNum, byte[] UID, int nUID, int Numbet, byte[] pResponse, ref int nLen, ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_ISO_10K_ReadSinglePage(int BlockNum, byte[] pResponse, ref int nLen, ref byte Status, int nTypeCmd, int nUID, byte[] UID);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_ISO_10K_ReadMultiPage(int BlockNum, int Numbet, byte[] pResponse, ref int nLen, ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_ISO_10K_WriteSinglePage(int BlockNum, byte[] pSend, ref byte Status);
        [DllImport("CFCOMM.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        public static extern int CF_AF_AFSTReset(ref byte Status);
	}
}
