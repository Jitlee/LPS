using System;
using System.Runtime.InteropServices;

class Sound
{
    private enum Flags
    {
        SND_SYNC = 0x0000,  /* play synchronously (default) */
        SND_ASYNC = 0x0001,  /* play asynchronously */
        SND_NODEFAULT = 0x0002,  /* silence (!default) if sound not found */
        SND_MEMORY = 0x0004,  /* pszSound points to a memory file */
        SND_LOOP = 0x0008,  /* loop the sound until next sndPlaySound */
        SND_NOSTOP = 0x0010,  /* don't stop any currently playing sound */
        SND_NOWAIT = 0x00002000, /* don't wait if the driver is busy */
        SND_ALIAS = 0x00010000, /* name is a registry alias */
        SND_ALIAS_ID = 0x00110000, /* alias is a predefined ID */
        SND_FILENAME = 0x00020000, /* name is file name */
        SND_RESOURCE = 0x00040004  /* name is resource name or atom */
    }

    [DllImport("CoreDll.DLL", EntryPoint = "PlaySound", SetLastError = true)]
    private extern static int WCE_PlaySound(string szSound, IntPtr hMod, int flags);

    public static void Play(string strFile)
    {
        if (strFile != null)
        {
            if (System.IO.File.Exists(strFile))
            {
                WCE_PlaySound(strFile, IntPtr.Zero,
                    (int)(Flags.SND_ASYNC | Flags.SND_FILENAME));
            }
        }
    }
} // class

class SysIOAPI
{
    public const int LEFT_TRIGGER_KEY = 1;
    public const int RIGHT_TRIGGER_KEY = 2; 

    [DllImport("Sysioapi.dll", EntryPoint = "TriggerKeyStatus")]
    public static extern bool TriggerKeyStatus(int nKey);
}

class Method
{
    public static string ByteArrayToString(byte[] data,int nlength)
    {
        string strData = "";
        //15693反方向读数，所以需要对数组反方向读取
        //for (int i = 0; i < nlength; i++)
        //{
        //    strData += data[i].ToString("X2");
        //}
        for (int i = nlength - 1; i >= 0; i--)
        {
            strData += data[i].ToString("X2");
        }
        return strData;
    }

    public static bool IsRule(string strData)
    {        
        char[] charData = strData.ToCharArray();
        for (int i = 0; i < charData.Length; i++ )
        {
            if ((charData[i] >= '0') && (charData[i] <= '9'))
            {
                continue;
            }
            else if ((charData[i] >= 'A') && (charData[i] <= 'F'))
            {
                continue;
            }
            else if ((charData[i] >= 'a') && (charData[i] <= 'f'))
            {
                continue;
            }
            else
            {
                return false;
            }            
        }
        return true;
    }
}