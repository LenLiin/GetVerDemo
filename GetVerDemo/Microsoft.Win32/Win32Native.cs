using System.Runtime.InteropServices;

namespace GetVerDemo.Microsoft.Win32
{
    internal class Win32Native
    {
        //https://docs.microsoft.com/en-us/windows/win32/api/sysinfoapi/nf-sysinfoapi-getproductinfo
        [DllImport("Kernel32.dll")]
        internal static extern bool GetProductInfo(int osMajorVersion, int osMinorVersion, int spMajorVersion, int spMinorVersion, out int edition);


        //https://docs.microsoft.com/zh-cn/windows/win32/api/sysinfoapi/nf-sysinfoapi-getversion
        [DllImport("kernel32.dll")]
        public static extern bool GetVersionEx(ref OSVERSIONINFOEX osVersionInfo);


        /// <summary>
        /// 请将dwOSVersionInfoSize设置为sizeof(OSVERSIONINFOEX).
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        internal struct OSVERSIONINFOEX
        {
            internal int dwOSVersionInfoSize;//此数据结构的大小(以字节为单位)。将此成员设置为sizeof(OSVERSIONINFOEX).
            internal int dwMajorVersion;//操作系统的主要版本号。
            internal int dwMinorVersion;//操作系统的次要版本号
            internal int dwBuildNumber;//操作系统的内部版本号
            internal int dwPlatformId;//操作系统平台。这个成员可以VER_PLATFORM_WIN32_NT 
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x80)]
            internal string szCSDVersion;//以空结尾的字符串，如“ServicePack 3”，指示系统上安装的最新ServicePack。如果没有安装ServicePack，则字符串为空。
            internal ushort wServicePackMajor;//系统上安装的最新ServicePack的主版本号。例如，对于ServicePack 3，主要版本号为3。如果没有安装ServicePack，则值为零。
            internal ushort wServicePackMinor;//系统上安装的最新ServicePack的次要版本号。例如，对于ServicePack 3，次要版本号为0。
            internal short wSuiteMask;//识别系统上可用的产品套件的位掩码。详情参考 https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-osversioninfoexa
            internal byte wProductType; //任何有关系统的其他信息。详情参考 https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-osversioninfoexa
            internal byte wReserved;//预留字段
        }
    }
}
