using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace Comtop.Terminal.Common
{
	/// <summary>
	/// 
	/// </summary>
	public class NamedEvent : WaitHandle 
	{

		[DllImport("Coredll.dll")]
		protected static extern IntPtr CreateEvent( IntPtr lpEventAttr,
			bool bManualReset, bool bInitialState, string lpName );

		[DllImport("Coredll.dll")]
		protected static extern IntPtr OpenEvent( uint dwDesiredAccess,
			bool bInheritHandle, string lpName );

		[DllImport("Coredll.dll")]
		protected static extern bool SetEvent( IntPtr hEvent );

		[DllImport("Coredll.dll")]
		protected static extern bool EventModify( IntPtr hEvent, Int32 function );

		[DllImport("Coredll.dll")]
		protected static extern bool ResetEvent( IntPtr hEvent );

		[DllImport("Coredll.dll")]
		protected static extern bool CloseHandle( IntPtr hObject );

		[DllImport("Coredll.dll")]
		protected static extern uint GetLastError();

		[DllImport("Coredll.dll")]
		protected static extern uint WaitForSingleObject( IntPtr hHandle, uint dwMilliseconds ); 

		[DllImport("Coredll.dll")]
		protected unsafe static extern uint WaitForMultipleObjects(
			uint nCount,
			IntPtr* lpHandles,
			bool bWaitAll,
			uint dwMilliseconds);


		public static NamedEvent OpenExisting( string name ) 
		{
			NamedEvent evt=new NamedEvent();
			// 0x1F0003==EVENT_ALL_ACCESS
			evt.Handle=OpenEvent( 0x1F0003, false, name );
			if( evt.Handle==IntPtr.Zero )
				throw new System.ComponentModel.Win32Exception( (int)GetLastError() );
			return evt;
		}

		protected NamedEvent() 
		{
		}

		public NamedEvent( string name, bool manualReset, bool initialState ) 
		{
			Handle=CreateEvent( IntPtr.Zero, manualReset, initialState, name );
			if( Handle==IntPtr.Zero )
				throw new System.ComponentModel.Win32Exception( (int)GetLastError() );
		}

		public bool Set() 
		{
			return EventModify( Handle, 3);
		}

		public bool Reset() 
		{
			return ResetEvent( Handle );
		}

		public override void Close() 
		{
			if( Handle!=IntPtr.Zero ) 
			{
				CloseHandle( Handle );
				Handle=IntPtr.Zero;
			}
		}

		public override bool WaitOne()
		{
			WaitForSingleObject( Handle, 0xFFFFFFFF);
			return true;
		}
		public unsafe static uint WaitForMultipleObjects(IntPtr[] waitHandles, bool bWaitAll, uint dwMilliseconds)
		{
			uint ret = 0;
			fixed (IntPtr * handlesPointer = waitHandles)
			{
				ret = WaitForMultipleObjects( (uint) waitHandles.Length, handlesPointer, false, 0xFFFFFFFF);
			}
			
			if( ret == 0xFFFFFFFF)
			{
				throw new System.ComponentModel.Win32Exception( (int)GetLastError() );
			}
			return ret;
		}
	}
}
 

 