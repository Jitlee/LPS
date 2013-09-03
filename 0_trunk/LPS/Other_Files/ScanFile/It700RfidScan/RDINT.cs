using System.Runtime.InteropServices;


 class RDINT
{
    #region define enum ============================================================
     public enum SAK
     {
         SAK_ISO14443_3 = 0,
         SAK_ISO14443_4 = 0x20
     }

     public enum ATQA
     {
         ATQA_MIFAER_S50 = 0x0400,
         ATQA_MIFAER_S70 = 0x0200,
         ATQA_ULTRA_LIGHT = 0x4400
     }

    public enum WORKING_TYPE
    {
        WT_ISO14443_TypeA = 0x41,
        WT_ISO14443_TypeB = 0x42,
        WT_ISO15693 = 0x31,
        WT_SR176_SRIX4K = 0x73
    }

    public enum TURN_ON_OFF
    {
        TURN_OFF,
        TURN_ON
    }

     public enum CARD_KEY_TYPE
     {
         CARD_KEY_A = 0,
         CARD_KEY_B = 1,
         CARD_KEY_NONE_OR_FAIL = 3
     }

    public enum ANTENNA_SELECT
    {
        ANTENNA_SELECT_AUTO_POWER_LOW = 8,
        ANTENNA_SELECT_OFF = 0,
        ANTENNA_SELECT_ON = 1,
        ANTENNA_SELECT_POWER_LOW = 0x10
    }

    public enum ANTENNA_SWITCH
    {
        ANTENNA_CLOSE_ALL = 0,
        ANTENNA1 = 1,
        ANTENNA2 = 2,
        ANTENNA3 = 4,
        ANTENNA4 = 8
    }

    public enum ISO15693_DFE
    {
        ISO15693_BLOCK_LEN = 4,
        ISO15693_BLOCK_SECRUTY_LEN = 1,
        ISO15693_MASK_LEN = 8,
        ISO15693_SYSINF_LEN = 14,
        ISO15693_UID_LEN = 8
    }
    #endregion //end define enum


    #region Device Function ========================================================
    [DllImport("RDINT.dll")]
    public static extern int RDINTsys_GetAPIVersion(out uint pu32Version);

    [DllImport("RDINT.dll")]
    public static extern int RDINTsys_GetAPIVersionStringW([Out, MarshalAs(UnmanagedType.LPWStr)] string strVersion);

    [DllImport("RDINT.dll")]
    public static extern int RDINTsys_OpenReader(byte u8COMPort, uint u32Baudrate, [In, MarshalAs(UnmanagedType.LPWStr)] string strAccessCode, TURN_ON_OFF u1SecurityMode, uint u32OpenDelayMs, out uint pu32Baudrate);

    [DllImport("RDINT.dll")]
    public static extern int RDINTsys_CloseReader(byte u8COMPort);

    [DllImport("RDINT.dll")]
    public static extern int RDINTsys_GetErrorStringW(ushort u16ErrorCode, [Out, MarshalAs(UnmanagedType.LPWStr)] string strErrStr, ushort u16LenErrStr, uint u32LocaleID);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_WorkingType(byte u8COMPort, WORKING_TYPE u8Type);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_ReaderInfo(byte u8COMPort, out byte pu8SerialNum, out byte pu8FirmwareVer);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_AntennaControl(byte u8COMPort, ANTENNA_SELECT u8Select);        

    [DllImport("RDINT.dll")]
    public static extern int RDINTsys_MifareCardSNtoStringW(ref uint pu32CardSerial, [Out, MarshalAs(UnmanagedType.LPWStr)] string strHex, [Out, MarshalAs(UnmanagedType.LPWStr)] string strDec);
    #endregion //end Device Function


    #region Genenal Function =======================================================
    [DllImport("RDINT.dll")]
    public static extern int RDINT_GetReturnData(byte u8COMPort, byte u8Indx);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_GetReturnDataArray(byte u8COMPort, byte u8Indx, byte u8Offset, out byte pu8Data);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_AntennaAmount(byte u8COMPort, byte u8AntennaSwitch);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_ISO15693AutoInventoryParam(byte u8COMPort, byte u8Flag, byte u8Afi, byte u8MaskLen, out byte pu8Mask);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_ISO15693AutoInventory4Antennas(byte u8COMPort, out byte pu8GRLUid);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_MifareAutoRequest4Antennas(byte u8COMPort, out byte pu8GRLCS);
    #endregion //end Common  Function


    #region ISO-14443_TypeA  Function ==============================================
    [DllImport("RDINT.dll")]
    public static extern int RDINT_OpenCard(byte u8COMPort, TURN_ON_OFF u1AutoFind, out byte pu8Uid, out byte pu8Atqa, out byte pu8Sak);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_CloseCard(byte u8COMPort);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_WriteDefaultKey(byte u8COMPort, byte u8DefaultKeyIndx, [In] ref byte pu8DefaultKey);
        
    [DllImport("RDINT.dll")]
    public static extern int RDINT_ReadMifareOneBlock(byte u8COMPort, CARD_KEY_TYPE u1KeyType, TURN_ON_OFF u1DefaultKey, byte u8DefaultKeyIndx, byte u8Block, [In] ref byte pu8Key, out byte pu8Data);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_ReadMifareOneSector(byte u8COMPort, CARD_KEY_TYPE u1KeyType, TURN_ON_OFF u1DefaultKey, byte u8DefaultKeyIndx, byte u8Sector, [In] ref byte pu8Key, out byte pu8Data);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_WriteMifareOneBlock(byte u8COMPort, CARD_KEY_TYPE u1KeyType, TURN_ON_OFF u1DefaultKey, byte u8DefaultKeyIndx, byte u8Block, [In] ref byte pu8Key, [In] ref byte pcu8Data);
    
    [DllImport("RDINT.dll")]
    public static extern int RDINT_KeyChange(byte u8COMPort, CARD_KEY_TYPE u1KeyType, TURN_ON_OFF u1DefaultKey, byte u8DefaultKeyIndx, byte u8Sector, [In] ref byte pu8Key, [In] ref byte pu8Data);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_ReadUltraLight(byte u8COMPort, byte u8Block, out byte pu8Data);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_WriteUltraLight(byte u8COMPort, byte u8Block, [In] ref byte pu8CmdData);
    #endregion //end ISO-14443_TypeA  Function


    #region ISO-14443_TypeB  Function ==============================================
    [DllImport("RDINT.dll")]
    public static extern int RDINT_STCardSelect(byte u8COMPort, out byte pu8IDNum);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_STCardIntoDeactive(byte u8COMPort);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_SR176ReadBlock(byte u8COMPort, byte u8BlkNo, out byte pu8Data);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_SR176WriteBlock(byte u8COMPort, byte u8BlkNo, [In] ref byte pu8Data);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_SR176LockBlock(byte u8COMPort, byte u8BlkNo);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_SRIX4KReadBlock(byte u8COMPort, byte u8BlkNo, out byte pu8Data);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_SRIX4KWriteBlock(byte u8COMPort, byte u8BlkNo, [In] ref byte pu8Data);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_SRIX4KAuth(byte u8COMPort, [In] ref byte pu8Auth);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_SRIX4KReadUID(byte u8COMPort, out byte pu8Uid);       
    #endregion //end ISO-14443_TypeB  Function


    #region ISO-15693  Function ====================================================
    [DllImport("RDINT.dll")]
    public static extern int RDINT_ISO15693Inventory(byte u8COMPort, byte u8Flag, byte u8Afi, byte u8MaskLen, [In] ref byte pu8Mask, out byte pu8Dsfid, out byte pu8Uid);
            
    [DllImport("RDINT.dll")]
    public static extern int RDINT_ISO15693StayQuiet(byte u8COMPort, byte u8Flag, [In] ref byte pu8Uid);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_ISO15693Select(byte u8COMPort, byte u8Flag, [In] ref byte pu8Uid);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_ISO15693Reset2Ready(byte u8COMPort, byte u8Flag, [In] ref byte pu8Uid);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_ISO15693Read(byte u8COMPort, byte u8Flag, [In] ref byte pu8Uid, byte u8BlockStart, byte u8BlockCount, out byte pu8Data);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_ISO15693Write(byte u8COMPort, byte u8Flag, [In] ref byte pu8Uid, byte u8Block, [In] ref byte pu8Data);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_ISO15693LockBlock(byte u8COMPort, byte u8Flag, [In] ref byte pu8Uid, byte u8Block);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_ISO15693WriteAfi(byte u8COMPort, byte u8Flag, [In] ref byte pu8Uid, byte u8AfiValue);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_ISO15693LockAfi(byte u8COMPort, byte u8Flag, [In] ref byte pu8Uid);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_ISO15693WriteDsfidISO15693WriteDsfid(byte u8COMPort, byte u8Flag, [In] ref byte pu8Uid, byte u8DsfidValue);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_ISO15693LockDsfid(byte u8COMPort, byte u8Flag, [In] ref byte pu8Uid);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_ISO15693GetSysInf(byte u8COMPort, byte u8Flag, [In] ref byte pu8Uid, out byte pu8SysInf);

    [DllImport("RDINT.dll")]
    public static extern int RDINT_ISO15693GetBlockSecurity(byte u8COMPort, byte u8Flag, [In] ref byte pu8Uid, byte u8BlockStart, byte u8BlockCount, out byte pu8SecurityData);
    #endregion //end ISO-15693  Function
}//RDINT

