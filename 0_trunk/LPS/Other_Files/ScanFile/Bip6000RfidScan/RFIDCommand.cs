using System;
using System.Collections.Generic;
using System.Text;
using Bluebird.RFID;


namespace Comtop.Terminal.Common
{
    class RFIDCommand
    {
        // field member
        String m_strMsg;        // error message : Prcode.ToString
        bool m_bRequestFlag;    // Request state : success/fail
        ReaderAPI m_clsReaderAPI;

        public RFIDCommand()
        {
            m_strMsg = null;
            m_bRequestFlag = false;
            m_clsReaderAPI = new ReaderAPI();
        }

        public String GetErrorMsg()
        {
            return m_strMsg;
        }

        void CopyToBytes(byte[] abyBuf, int nData, int nIndexint, int nCopySize)
        {
            byte[] abyData = BitConverter.GetBytes(nData);
            Array.Copy(abyData, 0, abyBuf, nIndexint, nCopySize);
        }

        // Open device : Reader and Comm
        public bool OpenDevice(string strPortName, byte byDetectMode, uint dwBaudRate, byte byProtocol)
        {
            if (!m_clsReaderAPI.OpenComm(strPortName, byDetectMode, dwBaudRate, byProtocol))
                return false;
            if (!m_clsReaderAPI.OpenReader(1, 0))
                return false;
            return true;
        }

        public void CloseDevice()
        {
            m_bRequestFlag = false;
            m_clsReaderAPI.CloseComm();
            m_clsReaderAPI.CloseReader();
        }

        // *****************************************************************************************************************
        // Reader Command
        // *****************************************************************************************************************
        // EmptyCommRecvBuf
        // GetCommBaudRate
        // SetCommBaudRate
        // GetCommProtocol
        // SetCommProtocol
        // GetCommTimeout
        // SetCommTimeout
        // GetDESFireSAMTimeout
        // SetDESFireSAMTimeout
        // GetReaderConfig
        // AntennaOnOff
        // GetReaderType
        // OpenSAM
        // CloseSAM
        // ICChangePPS
        // SendSAMCommandGetData

        public bool EmptyCommRecvBuf()
        {
            if (!m_clsReaderAPI.EmptyCommRcvBuffer())
                return false;
            return true;
        }

        public bool GetCommBaudRate(ref uint dwBaudRate)
        {
            if (!m_clsReaderAPI.GetCommBaudRate(ref dwBaudRate))
                return false;
            return true;
        }

        public bool SetCommBaudRate(uint dwBaudRate)
        {
            if (!m_clsReaderAPI.SetCommBaudRate(dwBaudRate))
                return false;
            return true;
        }

        public bool GetCommProtocol(ref byte byProtocol)
        {
            if (!m_clsReaderAPI.GetCommProtocol(ref byProtocol))
                return false;
            return true;
        }

        public bool SetCommProtocol(byte byProtocol)
        {
            if (!m_clsReaderAPI.SetCommProtocol(byProtocol))
                return false;
            return true;
        }

        public bool GetCommTimeout(ref uint dwTimeout)
        {
            if (!m_clsReaderAPI.GetCommTimeout(ref dwTimeout))
                return false;
            return true;
        }

        public bool SetCommTimeout(uint dwTimeout)
        {
            if (!m_clsReaderAPI.SetCommTimeout(dwTimeout))
                return false;
            return true;
        }

        public bool GetDESFireSAMTimeout(ref int nTimeout)
        {
            if (!m_clsReaderAPI.GetDESFireSAMTimeout(ref nTimeout))
                return false;
            return true;
        }

        public bool SetDESFireSAMTimeout(int nTimeout)
        {
            if (!m_clsReaderAPI.SetDESFireSAMTimeout(nTimeout))
                return false;
            return true;
        }

        public bool GetReaderConfig(ref uint dwBaudRate, ref byte byProtocol, ref byte byStationID)
        {
            ReaderSettings tReaderSet = new ReaderSettings();
            if (!m_clsReaderAPI.GetReaderConfig(ref tReaderSet))
                return false;
            dwBaudRate = tReaderSet.baudrate;
            byProtocol = (byte)tReaderSet.protocol;
            byStationID = tReaderSet.stationID;
            return true;
        }

        public bool GetReaderType(byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 0;
            if (!m_clsReaderAPI.GetReaderType(abyBuf, ref nNumBytes))
                return false;
            return true;
        }

   
        // ************************************************************************************************************
        // ISO Command
        // ************************************************************************************************************
        // RequestA
        // MultiList
        // Select
        // PPSR
        // HighSpeedSelect
        // ResetReader
        // ResetField
        // ReadBlock
        // WriteBlock
        // WriteUserPor
        // Login
        // DecreaseVBlock
        // IncreaseVBlock
        // ReadValue
        // WriteValue
        // CopyValue

        public bool SetTagType(byte byTagType, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 1;
            abyBuf[1] = byTagType;
            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcSetTagType, abyBuf))
                return false;
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool RequestA(ref short snATQA, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 0;
            if (m_bRequestFlag)
            {
                this.ResetField(abyBuf, ref nNumBytes);
            }
            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcIsoReqa, abyBuf))
                return false;

            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            if (abyBuf[0] == 3)
            {
                snATQA = (short)(abyBuf[2] | (abyBuf[3] << 8));
            }
            else
            {
                snATQA = 0x00;
            }
            m_bRequestFlag = true;
            return true;
        }

        public bool MultiList(byte[] abyBuf, ref int nNumBytes)
        {
            int i = 0;
            byte[] abyTemp = new byte[255];
            abyBuf[0] = 0;

            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcMultiList, abyBuf))
                return false;

            for (i = 0; i < 2; i++)
            {
                m_clsReaderAPI.GetData(abyTemp, ref nNumBytes);
                if (nNumBytes < 4)
                {
                    break;
                }
                Array.Copy(abyTemp, abyBuf, abyTemp[0] + 1);
            }
            if (i == 0)
                return false;
            nNumBytes = abyBuf[0];
            return true;
        }

        public bool Select(short snATQA, byte[] abyBuf, ref int nNumBytes)
        {
            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcSelect, abyBuf))
                return false;

            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool PPSR(byte byCID, byte DsiDri, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 2;
            abyBuf[1] = byCID;
            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcPPSR, abyBuf))
                return false;
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool HighSpeedSelect(short snATQA, byte byBaudRate, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 1;
            abyBuf[1] = byBaudRate;
            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcHighSpeedSelect, abyBuf))
                return false;
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool ResetReader(byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 0;
            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcResetReader, abyBuf))
                return false;
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool ResetField(byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 0;
            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcResetField, abyBuf))
                return false;
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool AntennaOnOff(byte[] abyBuf, ref int nNumBytes, bool bOnOff)
        {
            abyBuf[0] = 0;
            if (bOnOff)
            {
                if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcAntennaOn, abyBuf))
                    return false;
            }
            else
            {
                if (m_clsReaderAPI.SendCommand(ReaderCmd.rcAntennaOff, abyBuf))
                    return false;
            }
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool WriteBlock(byte byBlockAddress, byte[] abyData, byte byDataLen, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = (byte)(1 + byDataLen);
            abyBuf[1] = byBlockAddress;
            Array.Copy(abyData, 0, abyBuf, 2, byDataLen);
            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcWriteBlock, abyBuf))
                return false;
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool ReadBlock(byte byBlockAddress, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 1;
            abyBuf[1] = byBlockAddress;
            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcReadBlock, abyBuf))
                return false;

            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool WriteUserPort(int nSocketNum, byte[] abyBuf, ref int nNumByte)
        {
            abyBuf[0] = 1;
            abyBuf[1] = (byte)nSocketNum;
            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcWriteUserport, abyBuf))
                return false;

            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumByte))
                return false;

            return true;
        }

        public bool Login(byte byABL, byte byASC, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 2;
            abyBuf[1] = byABL;
            abyBuf[2] = byASC;
            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcLogin, abyBuf))
                return false;

            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool DecreaseVBlock(byte byABL, int nValue, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 5;
            abyBuf[1] = byABL;
            CopyToBytes(abyBuf, nValue, 2, 4);
            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcDecVBlock, abyBuf))
                return false;
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool IncreaseVBlock(byte byABL, int nValue, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 5;
            abyBuf[1] = byABL;
            CopyToBytes(abyBuf, nValue, 2, 4);
            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcIncVBlock, abyBuf))
                return false;

            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool CopyValue(byte bySelfABL, byte byDestABL, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 2;
            abyBuf[1] = bySelfABL;
            abyBuf[2] = byDestABL;
            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcCopyValue, abyBuf))
                return false;

            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool ReadValue(byte byABL, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 1;
            abyBuf[1] = byABL;
            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcReadValue, abyBuf))
                return false;

            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool WriteValue(byte byABL, byte[] abyValue, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 5;
            abyBuf[1] = byABL;
            Array.Copy(abyValue, 0, abyBuf, 2, 4);

            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcWriteValue, abyBuf))
                return false;

            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool ChangeDataCodingMode(byte byMode, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 1;
            abyBuf[1] = byMode;
            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcChangeDataCodeMode, abyBuf))
                return false;
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool InventoryRequest(byte bySlot, byte byAFIF, byte byAFIV, byte byMSKL, byte[] abyMSKV, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = (byte)(4 + byMSKL);
            abyBuf[1] = bySlot;
            abyBuf[2] = byAFIF;
            abyBuf[3] = byAFIV;
            abyBuf[4] = byMSKL;
            if (byMSKL > 0)
                Array.Copy(abyMSKV, 0, abyBuf, 5, 8);


            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcInventory, abyBuf))
                return false;
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool StayQuietRequest(byte[] abyUID, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 8;
            Array.Copy(abyUID, 0, abyBuf, 1, 8);
            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcQuietRequest, abyBuf))
                return false;
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool ResetToReadyRequest(byte byMode, byte[] abyUID, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 1;
            abyBuf[1] = byMode;
            if (byMode == 0x00)
            {
                abyBuf[0] += 8;
                Array.Copy(abyUID, 0, abyBuf, 2, 8);
            }

            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcReadyRequest, abyBuf))
                return false;
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }


        public bool SelectRequest(byte[] abyUID, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 8;
            Array.Copy(abyUID, 0, abyBuf, 1, 8);
            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcSelectRequest, abyBuf))
                return false;
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool ReadSingleBlock(byte byMode, byte bySEC, byte byBNUM, byte[] abyUID, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 3;
            abyBuf[1] = byMode;
            abyBuf[2] = bySEC;
            abyBuf[3] = byBNUM;
            if (byMode == 0x00)
            {
                abyBuf[0] += 8;
                Array.Copy(abyUID, 0, abyBuf, 4, 8);
            }

            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcReadSingleBlock, abyBuf))
                return false;
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }



        public bool WriteSingleBlock(byte byMode, byte byRESP, byte byBNUM, byte[] abyData, byte[] abyUID,
                                     byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 7;

            abyBuf[1] = byMode;
            abyBuf[2] = byRESP;
            abyBuf[3] = byBNUM;
            Array.Copy(abyData, 0, abyBuf, 4, 4);
            if (byMode == 0x00)
            {
                abyBuf[0] += 8;
                Array.Copy(abyUID, 0, abyBuf, 8, 8);
            }

            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcWriteSingleBlock, abyBuf))
                return false;
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool LockBlockRequest(byte byMode, byte byRESP, byte byBNUM, byte[] abyUID, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 3;

            abyBuf[1] = byMode;
            abyBuf[2] = byRESP;
            abyBuf[3] = byBNUM;
            if (byMode == 0x00)
            {
                abyBuf[0] += 8;
                Array.Copy(abyUID, 0, abyBuf, 4, 8);
            }

            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcLockBlock, abyBuf))
                return false;
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool GetSystemInfoRequest(byte byMode, byte[] abyUID, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 1;
            abyBuf[1] = byMode;
            if (byMode == 0x00)
            {
                abyBuf[0] += 8;
                Array.Copy(abyUID, 0, abyBuf, 2, 8);
            }

            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcGetSystemInfo, abyBuf))
                return false;
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool ReadMultiBlockRequest(byte byMode, byte bySEC, byte byBNUM, byte byBCNT, byte[] abyUID,
                                          byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 4;
            abyBuf[1] = byMode;
            abyBuf[2] = bySEC;
            abyBuf[3] = byBNUM;
            abyBuf[4] = byBCNT;
            if (byMode == 0x00)
            {
                abyBuf[0] += 8;
                Array.Copy(abyUID, 0, abyBuf, 5, 8);
            }

            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcReadMultiBlock, abyBuf))
                return false;
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool WriteMultiBlockRequest(byte byMode, byte byRESP, byte byBNUM, byte byBCNT, byte[] abyData, byte byDataLen, byte[] abyUID,
                                           byte[] abyBuf, ref int nNumBytes)
        {
            
            abyBuf[0] = (byte)(4 + byDataLen);
            abyBuf[1] = byMode;
            abyBuf[2] = byRESP;
            abyBuf[3] = byBNUM;
            abyBuf[4] = byBCNT;
            Array.Copy(abyData, 0, abyBuf, 5, byDataLen);
            if (byMode == 0x00)
            {
                Array.Copy(abyUID, 0, abyBuf, (abyBuf[0]+1), 8);
                abyBuf[0] += 8;
            }

            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcWriteMultiBlock, abyBuf))
                return false;
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool WriteAFI(byte byMode, byte byRESP, byte byAFIV, byte[] abyUID, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 3;
            abyBuf[1] = byMode;
            abyBuf[2] = byRESP;
            abyBuf[3] = byAFIV;
            if (byMode == 0x00)
            {
                abyBuf[0] += 8;
                Array.Copy(abyUID, 0, abyBuf, 4, 8);
            }

            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcWriteAFI, abyBuf))
                return false;
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool LockAFIRequest(byte byMode, byte byRESP, byte[] abyUID, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 2;
            abyBuf[1] = byMode;
            abyBuf[2] = byRESP;

            if (byMode == 0x00)
            {
                abyBuf[0] += 8;
                Array.Copy(abyUID, 0, abyBuf, 3, 8);
            }

            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcLockAFI, abyBuf))
                return false;
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool WriteDSFIDRequest(byte byMode, byte byRESP, byte byDSFID, byte[] abyUID, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 3;
            abyBuf[1] = byMode;
            abyBuf[2] = byRESP;
            abyBuf[3] = byDSFID;
            if (byMode == 0x00)
            {
                abyBuf[0] += 8;
                Array.Copy(abyUID, 0, abyBuf, 4, 8);
            }

            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcWriteDSFID, abyBuf))
                return false;
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool LockDSFIDRequest(byte byMode, byte byRESP, byte[] abyUID, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 2;
            abyBuf[1] = byMode;
            abyBuf[2] = byRESP;
            if (byMode == 0x00)
            {
                abyBuf[0] += 8;
                Array.Copy(abyUID, 0, abyBuf, 3, 8);
            }

            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcLockDSFID, abyBuf))
                return false;
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool GetMultiBlockSecurityStatusRequest(byte byMode, byte byBNUM, byte byBCNT, byte[] abyUID, byte[] abyBuf, ref int nNumBytes)
        {
            abyBuf[0] = 3;
            abyBuf[1] = byMode;
            abyBuf[2] = byBNUM;
            abyBuf[3] = byBCNT;
            if (byMode == 0x00)
            {
                abyBuf[0] += 8;
                Array.Copy(abyUID, 0, abyBuf, 4, 8);
            }

            if (!m_clsReaderAPI.SendCommand(ReaderCmd.rcGetMultiSecStatus, abyBuf))
                return false;
            if (!m_clsReaderAPI.GetData(abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        // *******************************************************************************************************
        // DESFire Command
        // *******************************************************************************************************
        // SAMOnOff
        // AuthenticateHost
        // Authenticate
        // FormatPICC
        // GetApplicationIDs
        // SelectApplication
        // CreateApplication
        // SetFileSettings
        // GetFileSettings
        // GetFileIDs
        // CreateStandardDataFile
        // CreateBackupDataFile
        // CreateCyclicRecordFile
        // CreateLinearRecordFile
        // CreateValueFile
        // ReadData
        // WriteData
        // ReadRecord
        // WriteRecord
        // Credit
        // Debit
        // GetValue
        // ChangeKey
        // GetKeyEntry
        // GetKeyVersion
        // ChangeKeyEntry
        // GetVersionSAM
        // GetKeyVersion

        public bool SAMOnOff(bool bOnOff, byte[] abyBuf, ref int nNumBytes)
        {
            byte[] arCmdBuf = new byte[8];
            arCmdBuf[0] = 1;
            arCmdBuf[1] = 0;

            if (bOnOff)
            {
                if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cSAMOnOff, arCmdBuf, abyBuf, ref nNumBytes))
                    return false;

                arCmdBuf[1] = 1;
            }
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cSAMOnOff, arCmdBuf, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool AuthenticateHost(byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[64];
            Array.Clear(abyCmdData, 0, 20);
            abyCmdData[0] = 19;
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cAuthenticateHost, abyCmdData, abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool AuthenticateHost(byte[] arSamKey, byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[27];
            abyCmdData[0] = 19;
            abyCmdData[1] = 0x00;
            abyCmdData[2] = 0x00;
            abyCmdData[3] = 0x00;
            Array.Copy(arSamKey, 0, abyCmdData, 4, 16);
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cAuthenticateHost, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool Authenticate(byte byKeyNo, byte byAuthenticateMode, byte byKeyId, byte byKeyVersion,
                               byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[5];
            abyCmdData[0] = 4;
            abyCmdData[1] = byKeyNo;
            abyCmdData[2] = byAuthenticateMode;
            abyCmdData[3] = byKeyId;
            abyCmdData[4] = byKeyVersion;
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cAuthenticate, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool FormatPICC(byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[2];
            abyCmdData[0] = 0;
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cFormatPICC, abyCmdData, abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool GetApplicationIDs(byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[2];
            abyCmdData[0] = 0;
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cGetApplicationIDs, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool SelectApplication(int nAID, byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[4];
            abyCmdData[0] = 3;
            CopyToBytes(abyCmdData, nAID, 1, 3);
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cSelectApplication, abyCmdData, abyBuf, ref nNumBytes))
                return false;

            return true;
        }

        public bool CreateApplication(int nAID, byte byKeySetting, byte byKeyNo, byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[6];
            abyCmdData[0] = 5;
            CopyToBytes(abyCmdData, nAID, 1, 3);
            abyCmdData[4] = byKeySetting;
            abyCmdData[5] = byKeyNo;
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cCreateApplication, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool SetFileSettings(byte byFileNo, byte byComMode, int nAccessRights, byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[5];
            abyCmdData[0] = 4;
            abyCmdData[1] = byFileNo;
            abyCmdData[2] = byComMode;
            CopyToBytes(abyCmdData, nAccessRights, 3, 2);
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cSetFileSettings, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool GetFileSettings(byte byFID, byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[2];
            abyCmdData[0] = 1;
            abyCmdData[1] = byFID;
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cGetFileSettings, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool ChangeFileSettings(byte byComMode, int nAccessRights, byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[5];
            abyCmdData[0] = 3;
            abyCmdData[1] = byComMode;
            CopyToBytes(abyCmdData, nAccessRights, 2, 2);
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cChangeFileSettings, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool GetFileIDs(byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[2];
            abyCmdData[0] = 0;
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cGetFileIDs, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool CreateStandardDataFile(int nSize, byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[4];
            abyCmdData[0] = 3;
            CopyToBytes(abyCmdData, nSize, 1, 3);
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cCreateStandardDataFile, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool CreateBackupDataFile(int nSize, byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[4];
            abyCmdData[0] = 3;
            CopyToBytes(abyCmdData, nSize, 1, 3);
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cCreateBackupDataFile, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool CreateValueFile(int nLowLimit, int nHighLimit, int nValue, bool bLimitedCredit,
                                    byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[14];
            Array.Clear(abyCmdData, 0, 14);
            abyCmdData[0] = 13;
            CopyToBytes(abyCmdData, nLowLimit, 1, 4);
            CopyToBytes(abyCmdData, nHighLimit, 5, 4);
            CopyToBytes(abyCmdData, nValue, 9, 4);
            if (bLimitedCredit)
            {
                abyCmdData[13] = 0x01;
            }
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cCreateValueFile, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool CreateCyclicRecordFile(int nRecordSize, int nNumRecord, byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[7];
            abyCmdData[0] = 6;
            CopyToBytes(abyCmdData, nRecordSize, 1, 3);
            CopyToBytes(abyCmdData, nNumRecord, 4, 3);
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cCreateCyclicRecordFile, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool CreateLinearRecordFile(int nRecordSize, int nNumRecord, byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[7];
            abyCmdData[0] = 6;
            CopyToBytes(abyCmdData, nRecordSize, 1, 3);
            CopyToBytes(abyCmdData, nNumRecord, 4, 3);
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cCreateLinearRecordFile, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool CommitTransaction(byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[2];
            abyCmdData[0] = 0;
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cCommitTransaction, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool ReadData(int nOffset, int nLength, byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[7];
            abyCmdData[0] = 6;
            CopyToBytes(abyCmdData, nOffset, 1, 3);
            CopyToBytes(abyCmdData, nLength, 4, 3);
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cReadData, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool WriteData(int nOffset, int nLength, byte[] writeData, byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[4 + nLength];
            abyCmdData[0] = (byte)(3 + nLength);
            CopyToBytes(abyCmdData, nOffset, 1, 3);
            Array.Copy(writeData, 0, abyCmdData, 4, nLength);
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cWriteData, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool ReadRecord(int nRecordSize, int nOffset, int nNumberOfBytesToRead, byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[10];
            abyCmdData[0] = 9;
            CopyToBytes(abyCmdData, nRecordSize, 1, 3);
            CopyToBytes(abyCmdData, nOffset, 4, 3);
            CopyToBytes(abyCmdData, nNumberOfBytesToRead, 7, 3);
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cReadRecords, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool WriteRecord(int nOffset, int nNumberOfRecord, byte[] writeData, byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[7 + nNumberOfRecord];
            abyCmdData[0] = (byte)(6 + nNumberOfRecord);
            CopyToBytes(abyCmdData, nOffset, 1, 3);
            CopyToBytes(abyCmdData, nNumberOfRecord, 4, 3);
            Array.Copy(writeData, 0, abyCmdData, 7, nNumberOfRecord);
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cWriteRecords, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool Credit(int nValue, byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[5];
            abyCmdData[0] = 4;
            CopyToBytes(abyCmdData, nValue, 1, 4);
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cCredit, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool Debit(int nValue, byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[5];
            abyCmdData[0] = 4;
            CopyToBytes(abyCmdData, nValue, 1, 4);
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cDebit, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool GetValue(byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[2];
            abyCmdData[0] = 0;
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cGetValue, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }


        public bool ChangeKey(byte byKeyNo, byte byKeyCompMeth, byte byCurKeyId, byte byCurKeyVersion, byte byNewKeyId, byte byNewKeyVersion,
                              byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[24];
            abyCmdData[0] = 6;
            abyCmdData[1] = byKeyNo;
            abyCmdData[2] = byKeyCompMeth;
            abyCmdData[3] = byCurKeyId;
            abyCmdData[4] = byCurKeyVersion;
            abyCmdData[5] = byNewKeyId;
            abyCmdData[6] = byNewKeyVersion;
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cChangeKey, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool GetKeyEntry(byte byKeyNo, byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[2];
            abyCmdData[0] = 1;
            abyCmdData[1] = byKeyNo;
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cGetKeyEntry, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool ChangeKeyEntry(byte byOldKeyNoCEK, byte byKeyNo, byte byProMas, byte[] arNewKeyEntry,
                                    byte[] abyBuf, ref int nNumBytes)
        {
            byte[] arCmdBuf = new byte[67];
            Array.Clear(arCmdBuf, 0, 67);
            arCmdBuf[0] = 60;
            arCmdBuf[1] = byOldKeyNoCEK;
            arCmdBuf[2] = byKeyNo;
            arCmdBuf[3] = byProMas;
            Array.Copy(arNewKeyEntry, 0, arCmdBuf, 4, 57);
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cChangeKeyEntry, arCmdBuf, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool GetVersionSAM(byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[2];
            abyCmdData[0] = 0;
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cGetVersionSAM, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool GetVersion(byte[] abyBuf, ref int nNumBytes)
        {
            byte[] abyCmdData = new byte[2];
            abyCmdData[0] = 0;
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cGetVersion, abyCmdData, abyBuf, ref nNumBytes))
                return false;
            return true;
        }

        public bool GetKeyVersion(byte byKeyNoTag, byte[] abyBuf, ref int nNumbytes)
        {
            byte[] abyCmdData = new byte[2];
            abyCmdData[0] = 1;
            abyCmdData[1] = byKeyNoTag;
            if (!m_clsReaderAPI.SendDESFireCmd(DESFireCmd.cGetKeyVersion, abyCmdData, abyBuf, ref nNumbytes))
                return false;
            return true;
        }
    }
}


