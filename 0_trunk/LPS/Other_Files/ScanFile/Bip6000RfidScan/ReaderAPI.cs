using System;
using System.Collections.Generic;
using System.Text;
using Bluebird.RFID;


namespace Comtop.Terminal.Common
{

   public enum ReaderCmd
    {
        rcAntennaOff = 0,
        rcAntennaOn,
        rcGetVersion,
        rcHighSpeedSelect,
        rcIsoReqa,
        rcIsoRATS,
        rcPPSR,
        rcMultiList,
        rcMultiSelect,
        rcReadBlock,
        rcReadRegister,
        rcResetField,
        rcResetReader,
        rcSelect,
        rcSendCardMessage,
        rcSendDESFireCommand,
        rcSendSamMessage,
        rcSetTagType,
        rcWriteBlock,
        rcWriteUserport,
        rcLogin,
        rcDecVBlock,
        rcIncVBlock,
        rcCopyValue,
        rcReadValue,
        rcWriteValue, 
// ISO 15693
        rcChangeDataCodeMode,
        rcInventory,
        rcGetSystemInfo,
        rcGetMultiSecStatus,
        rcSelectRequest,
        rcQuietRequest,
        rcReadyRequest,
        rcReadSingleBlock,
        rcWriteSingleBlock,
        rcLockBlock,
        rcReadMultiBlock,
        rcWriteMultiBlock,
        rcWriteAFI,
        rcLockAFI,
        rcWriteDSFID,
        rcLockDSFID
    };

    public enum DESFireCmd
    {
        cSAMOnOff = 0x00,
        cAuthenticate,
        cChangeKeySettings,
        cGetKeySettings,
        cChangeKey,
        cGetKeyVersion,
        cCreateApplication,
        cGetApplicationIDs,
        cSelectApplication,
        cFormatPICC,
        cGetVersion,
        cGetFileIDs,
        cGetFileSettings,
        cChangeFileSettings,
        cCreateStandardDataFile,
        cCreateBackupDataFile,
        cCreateValueFile,
        cCreateLinearRecordFile,
        cCreateCyclicRecordFile,
        cReadData,
        cReadRecords,
        cWriteData,
        cWriteRecords,
        cGetValue,
        cCredit,
        cDebit,
        cCommitTransaction,
        cAbortTransaction,
        cSetFileSettings,
        cChangeKeyEntry,
        cGetKeyEntry,
        cGetVersionSAM,
        cAuthenticateHost,
        cSetLogicalChannel

    };

    public class ReaderAPI
    {
        BBRFReader m_clsRFReader;

        public ReaderAPI()
        {
            m_clsRFReader = new BBRFReader();
        }

        void ReaderCmd2Text(ReaderCmd cmd, byte[] abyCmd)
        {
            String textCmd = null;
            switch (cmd)
            {
                case ReaderCmd.rcAntennaOn: textCmd = "antenna on"; break;
                case ReaderCmd.rcAntennaOff: textCmd = "antenna off"; break;
                case ReaderCmd.rcIsoReqa: textCmd = "iso reqa"; break;
                case ReaderCmd.rcPPSR: textCmd = "PPSR"; break;
                case ReaderCmd.rcMultiList: textCmd = "multilist"; break;
                case ReaderCmd.rcReadBlock: textCmd = "read block"; break;
                case ReaderCmd.rcSelect: textCmd = "select"; break;
                case ReaderCmd.rcWriteBlock: textCmd = "write block"; break;
                case ReaderCmd.rcWriteUserport: textCmd = "write userport"; break;
                case ReaderCmd.rcHighSpeedSelect: textCmd = "h"; break;
                case ReaderCmd.rcSetTagType: textCmd = "o"; break;
                case ReaderCmd.rcGetVersion: textCmd = "v"; break;
                case ReaderCmd.rcResetReader: textCmd = "x"; break;
                case ReaderCmd.rcResetField: textCmd = "y"; break;
                case ReaderCmd.rcLogin: textCmd = "login"; break;
                case ReaderCmd.rcDecVBlock: textCmd = "dec vblock"; break;
                case ReaderCmd.rcIncVBlock: textCmd = "inc vblock"; break;
                case ReaderCmd.rcCopyValue: textCmd = "copy vblock"; break;
                case ReaderCmd.rcReadValue: textCmd = "read vblock"; break;
                case ReaderCmd.rcWriteValue: textCmd = "write vblock"; break;
// ISO 15693                
                case ReaderCmd.rcChangeDataCodeMode: textCmd = "changedata mode"; break;
                case ReaderCmd.rcInventory: textCmd = "inventory"; break;
                case ReaderCmd.rcQuietRequest: textCmd = "quiet request"; break;
                case ReaderCmd.rcReadyRequest: textCmd = "ready request"; break;
                case ReaderCmd.rcSelectRequest: textCmd = "select request"; break;
                case ReaderCmd.rcReadSingleBlock: textCmd = "readsingle block"; break;
                case ReaderCmd.rcWriteSingleBlock: textCmd = "writesingle block"; break;
                case ReaderCmd.rcLockBlock: textCmd = "lock block"; break;
                case ReaderCmd.rcGetSystemInfo: textCmd = "getsystem info"; break;
                case ReaderCmd.rcReadMultiBlock: textCmd = "readmulti block"; break;
                case ReaderCmd.rcWriteMultiBlock: textCmd = "writemulti block"; break;
                case ReaderCmd.rcWriteAFI: textCmd = "write afi"; break;
                case ReaderCmd.rcLockAFI: textCmd = "lock afi"; break;
                case ReaderCmd.rcWriteDSFID: textCmd = "write dsfid"; break;
                case ReaderCmd.rcLockDSFID: textCmd = "lock dsfid"; break;
                case ReaderCmd.rcGetMultiSecStatus: textCmd = "get bss"; break;
  

                default: textCmd = "baad f00d"; break;
            }

            byte[] temp = Encoding.ASCII.GetBytes(textCmd);
            Array.Copy(temp, abyCmd, temp.Length);
        }


        Bluebird.RFID.DESFireCmd desFireCmd2bb(DESFireCmd cmd)
        {
            switch (cmd)
            {
                case DESFireCmd.cSAMOnOff: return Bluebird.RFID.DESFireCmd.cSAMOnOff;
                case DESFireCmd.cAuthenticate: return Bluebird.RFID.DESFireCmd.cAuthenticate;
                case DESFireCmd.cChangeKeySettings: return Bluebird.RFID.DESFireCmd.cChangeKeySettings;
                case DESFireCmd.cGetKeySettings: return Bluebird.RFID.DESFireCmd.cGetKeySettings;
                case DESFireCmd.cChangeKey: return Bluebird.RFID.DESFireCmd.cChangeKey;
                case DESFireCmd.cGetKeyVersion: return Bluebird.RFID.DESFireCmd.cGetKeyVersion;
                case DESFireCmd.cCreateApplication: return Bluebird.RFID.DESFireCmd.cCreateApplication;
                case DESFireCmd.cGetApplicationIDs: return Bluebird.RFID.DESFireCmd.cGetApplicationIDs;
                case DESFireCmd.cSelectApplication: return Bluebird.RFID.DESFireCmd.cSelectApplication;
                case DESFireCmd.cFormatPICC: return Bluebird.RFID.DESFireCmd.cFormatPICC;
                case DESFireCmd.cGetVersion: return Bluebird.RFID.DESFireCmd.cGetVersion;
                case DESFireCmd.cGetFileIDs: return Bluebird.RFID.DESFireCmd.cGetFileIDs;
                case DESFireCmd.cGetFileSettings: return Bluebird.RFID.DESFireCmd.cGetFileSettings;
                case DESFireCmd.cChangeFileSettings: return Bluebird.RFID.DESFireCmd.cChangeFileSettings;
                case DESFireCmd.cCreateStandardDataFile: return Bluebird.RFID.DESFireCmd.cCreateStandardDataFile;
                case DESFireCmd.cCreateBackupDataFile: return Bluebird.RFID.DESFireCmd.cCreateBackupDataFile;
                case DESFireCmd.cCreateValueFile: return Bluebird.RFID.DESFireCmd.cCreateValueFile;
                case DESFireCmd.cCreateLinearRecordFile: return Bluebird.RFID.DESFireCmd.cCreateLinearRecordFile;
                case DESFireCmd.cCreateCyclicRecordFile: return Bluebird.RFID.DESFireCmd.cCreateCyclicRecordFile;
                case DESFireCmd.cReadData: return Bluebird.RFID.DESFireCmd.cReadData;
                case DESFireCmd.cReadRecords: return Bluebird.RFID.DESFireCmd.cReadRecords;
                case DESFireCmd.cWriteData: return Bluebird.RFID.DESFireCmd.cWriteData;
                case DESFireCmd.cWriteRecords: return Bluebird.RFID.DESFireCmd.cWriteRecords;
                case DESFireCmd.cGetValue: return Bluebird.RFID.DESFireCmd.cGetValue;
                case DESFireCmd.cCredit: return Bluebird.RFID.DESFireCmd.cCredit;
                case DESFireCmd.cDebit: return Bluebird.RFID.DESFireCmd.cDebit;
                case DESFireCmd.cCommitTransaction: return Bluebird.RFID.DESFireCmd.cCommitTransaction;
                case DESFireCmd.cAbortTransaction: return Bluebird.RFID.DESFireCmd.cAbortTransaction;
                case DESFireCmd.cSetFileSettings: return Bluebird.RFID.DESFireCmd.cSetFileSettings;
                case DESFireCmd.cChangeKeyEntry: return Bluebird.RFID.DESFireCmd.cChangeKeyEntry;
                case DESFireCmd.cGetKeyEntry: return Bluebird.RFID.DESFireCmd.cGetKeyEntry;
                case DESFireCmd.cGetVersionSAM: return Bluebird.RFID.DESFireCmd.cGetVersionSAM;
                case DESFireCmd.cAuthenticateHost: return Bluebird.RFID.DESFireCmd.cAuthenticateHost;
                default:  // something is missing (TODO)
                case DESFireCmd.cSetLogicalChannel: return Bluebird.RFID.DESFireCmd.cSetLogicalChannel;
            }
        }

        public bool OpenComm(String strCommDevice, byte byAutodetect, uint dwBaudRate, byte byProtocol)
        {
            CommSettings tCommSet = new CommSettings();
            tCommSet.baudrate = dwBaudRate;
            tCommSet.protocol = (sbyte)byProtocol;
            sbyte b_retv = m_clsRFReader.OpenComm(strCommDevice, byAutodetect, tCommSet);
            if (b_retv.Equals(1))
                return true ;
            return false;
        }

        public bool CloseComm()
        {
            m_clsRFReader.CloseComm();
            return true;
        }

        public bool OpenReader(byte byId, short sReaderType)
        {
            uint b_retv = m_clsRFReader.OpenReader(byId, sReaderType);
            if (b_retv.Equals(0))
                return true;
            return false;
        }

        public bool CloseReader()
        {
            m_clsRFReader.CloseReader();
            return true;
        }

        public bool EmptyCommRcvBuffer()
        {
            m_clsRFReader.EmptyCommRcvBuffer();
            return true;
        }

        public bool GetResumeState(ref bool bResumeStateActive)
        {
            sbyte b_retv = m_clsRFReader.GetResumeState();
            bResumeStateActive = b_retv != 0;
            return true;
        }

        public bool SetCommBaudRate(uint dwBaudRate)
        {
            m_clsRFReader.SetCommBaudRate(dwBaudRate);
            return true;
        }

        public bool GetCommBaudRate(ref uint dwBaudRate)
        {
            dwBaudRate = m_clsRFReader.GetCommBaudRate();
            if (dwBaudRate.Equals(0x9044))
                return false;
            return true;
        }

        public bool GetCommProtocol(ref byte byProtocol)
        {
            byProtocol = (byte)m_clsRFReader.GetCommProtocol();
            if (byProtocol.Equals(87))
                return false;
            return true;
        }

        public bool SetCommProtocol(byte byProtocol)
        {
            m_clsRFReader.SetCommProtocol(byProtocol);
            return true;
        }

        public bool SetCommTimeout(uint dwTimeout)
        {
            m_clsRFReader.SetCommTimeout(dwTimeout);
            return true;
        }

        public bool GetCommTimeout(ref uint dwTimeout)
        {
            dwTimeout = m_clsRFReader.GetCommTimeout();
            if (dwTimeout.Equals(87))
                return false;
            return true;
        }

        public bool GetReaderConfig(ref ReaderSettings tReaderSet)
        {
            m_clsRFReader.GetReaderConfig(ref tReaderSet);
            return true;
        }

        public bool GetReaderType(byte[] abyDeviceVersion, ref int nNumChars)
        {
            int n = 0;
            byte[] b_buf = new byte[255];
            Array.Clear(b_buf, 0, 255);
            m_clsRFReader.GetReaderType(b_buf);

            if (nNumChars < b_buf.Length)
                n = nNumChars;
            else
                n = b_buf.Length;
            Array.Copy(b_buf, abyDeviceVersion, n);
            abyDeviceVersion[n] = (byte)'\0';
            nNumChars = n;
            return true;
        }

        public bool GetDebugOutputState(ref bool bActiveState)
        {
            sbyte b_retv = m_clsRFReader.GetDebugOutputState();
            if (b_retv.Equals(87))
                return false;
            bActiveState = b_retv == 1;
            return true;
        }

        public bool SetDebugOutputState(bool bActiveState)
        {
            byte b_active = 0;
            if (bActiveState)
                b_active = 1;
            m_clsRFReader.SetDebugOutputState(b_active);
            return true;
        }

        public bool SendCommand(ReaderCmd cmd, byte[] abyData)
        {
            byte[] readerCmd = new byte[255];
            ReaderCmd2Text(cmd, readerCmd);

            uint b_retv = m_clsRFReader.SendCommand(readerCmd, abyData);
            if (b_retv.Equals(1))
                return true;
            return false;
        }

        public bool SendCommandGetData(ReaderCmd cmd, byte[] abyData, byte[] abyResultBuf, ref int nNumBytes)
        {
            byte[] readerCmd = new byte[255];
            ReaderCmd2Text(cmd, readerCmd);
            uint b_retv = m_clsRFReader.SendCommandGetData(readerCmd, abyData, abyResultBuf);
            nNumBytes = abyResultBuf[0];
            if (b_retv.Equals(1))
                return true;
            return false;
        }

        public bool SendCommandGetDataTimeout(ReaderCmd cmd, byte[] abyData, byte[] abyResultBuf, int nTiemout, ref int nNumBytes)
        {
            byte[] readerCmd = new byte[255];
            ReaderCmd2Text(cmd, readerCmd);
            uint b_retv = m_clsRFReader.SendCommandGetDataTimeout(readerCmd, abyData, abyResultBuf, nTiemout);
            nNumBytes = abyResultBuf[0];
            if (b_retv.Equals(1))
                return true;
            return false;
        }

        public bool GetData(byte[] abyResultBuf, ref int nNumBytes)
        {
            byte[] abyTempBuf = new byte[255];
            uint b_retv = m_clsRFReader.GetData(abyResultBuf);
           
            nNumBytes = abyResultBuf[0];

            if (b_retv == 0 && nNumBytes > 0)
                return true;
            return false;
        }

        public bool GetDataTimeout(byte[] abyResultBuf, ref int nNumBytes, int nTimeout)
        {
            byte[] abyTempBuf = new byte[255];

            uint b_retv = m_clsRFReader.GetDataTimeout(abyResultBuf, (uint)nTimeout);
            
            nNumBytes = abyResultBuf[0];
            if (b_retv == 0 && nNumBytes > 0)
                return true;
          return false;
        }

        public bool SendDESFireCmd(DESFireCmd cmd, byte[] abyData, byte[] abyResultBuf, ref int nNumBytes)
        {
            byte cCmd = (byte)desFireCmd2bb(cmd);
            uint b_retv = m_clsRFReader.DESFire(cCmd, abyData, abyResultBuf);
            nNumBytes = abyResultBuf[0];
            if (b_retv.Equals(0))
                return true;
            return false;
        }

        public bool GetDESFireSAMTimeout(ref int nTimeout)
        {
            nTimeout = m_clsRFReader.GetDESFireSAMTimeout();
            return true;
        }

        public bool SetDESFireSAMTimeout(int nTimeout)
        {
            m_clsRFReader.SetDESFireSAMTimeout((byte)nTimeout);
            return true;
        }

    }
}
        
 
