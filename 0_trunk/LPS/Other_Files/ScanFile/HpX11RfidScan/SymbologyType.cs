using System;
using System.Runtime.InteropServices;
using SocketCommunications.Scan;

namespace Comtop.Terminal.Common
{
	/// <summary>
	/// SocketScan Symbology types for ISC, CHS, SD scanner
	/// </summary>
	public enum SymbolTypeSSI : int
	{
		Code39 = 0x01, 
		Codabar,
		Code128,
		Discrete2of5, 
		IATA2of5, 
		Interleaved2of5, 
		Code93, 
		UPC_A, 
		UPC_A_with_2_supps = 0x48, 
		UPC_A_with_5_supps = 0x88, 
		UPC_E0 = 0x09, 
		UPC_E0_with_2_supps = 0x49, 
		UPC_E0_with_5_supps = 0x89, 
		EAN_8 = 0x0A, 
		EAN_8_with_2_supps = 0x4A, 
		EAN_8_with_5_supps = 0x8A, 
		EAN_13 = 0x0B,
		EAN_13_with_2_supps = 0x4B, 
		EAN_13_with_5_supps = 0x8B, 
		MSI_Plessey = 0x0E, 
		EAN_128 = 0x0F, 
		UPC_E1 = 0x10, 
		UPC_E1_with_2_supps = 0x50, 
		UPC_E1_with_5_supps = 0x90, 
		Trioptic_Code_39 = 0x15, 
		Bookland_EAN = 0x16, 
		CouponCode = 0x17, 
		PDF417 = 0x11
	};

	/// <summary>
	/// SocketScan Symbology types for 2D SD scanner
	/// </summary>
	public enum SymbolTypeHHP : int
	{
		AZTEC = 'z', 
		MESA = 'z', 
		CODABAR = 'a', 
		CODE11 = 'h', 
		CODE128 = 'j', 
		CODE39 = 'b', 
		CODE49 = 'l', 
		CODE93 = 'i', 
		COMPOSITE = 'y', 
		DATAMATRIX = 'u', 
		EAN = 'd', 
		INT25 = 'e', 
		MAXICODE = 'x', 
		MICROPDF = 'R', 
		PDF417 = 'r', 
		POSTNET = 'P', 
		OCR = 'o', 
		QR = 's', 
		RSS = 'y', 
		UPC = 'c', 
		ISBT = 'j', 
		BPO = 'B', 
		CANPOST = 'C', 
		AUSPOST = 'A', 
		IATA25 = 'f', 
		CODABLOCK = 'q', 
		JAPOST = 'J', 
		PLANET = 'L', 
		DUTCHPOST = 'K', 
		MSI = 'g', 
		TLC39 = 'T', 
		MATRIX25 = 'm',
		EAN_128 = 'I'

	};

	public class ScanSymbologyType
	{
		//private int	symbolTypeInternal;		// Symbol type code from scanner

		internal ScanSymbologyType()
		{
		}

		public string BarcodeSymbolType(ScannerTypes scannerType, int symbolType)
		{
			string ret = string.Empty;
            //ScanDevInfo DevInfo = socketScanner.ScanGetDevInfo();
			if((scannerType == ScannerTypes.SCANNER_CFCARD) || (scannerType == ScannerTypes.SCANNER_CHS) || (scannerType == ScannerTypes.SCANNER_SDIO))
				ret = ((SymbolTypeSSI)symbolType).ToString();
			else
				if(scannerType == (ScannerTypes.SCANNER_ISCI))
					ret = ((SymbolTypeHHP)symbolType).ToString();

			return ret;

		}
	};
}