using GetVerDemo.Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using static GetVerDemo.Microsoft.Win32.Win32Native;

namespace GetVerDemo
{
    //windows版本信息可参考
    //https://docs.microsoft.com/zh-cn/windows/release-information/

    //关于Windows 10 Enterprise LTSC
    //https://docs.microsoft.com/en-us/windows/whats-new/ltsc/
    static public class OSInfoEx
    {
        #region pinvoke
        #region VERSIONS

        //wSuiteMask
        private const int VER_SUITE_BACKOFFICE = 0x00000004;//Microsoft BackOffice components are installed.
        private const int VER_SUITE_BLADE = 0x00000400;//Windows Server 2003, Web Edition is installed.
        private const int VER_SUITE_COMPUTE_SERVER = 0x00004000;//Windows Server 2003, Compute Cluster Edition is installed.
        private const int VER_SUITE_DATACENTER = 0x00000080;//128 Windows Server 2008 Datacenter, Windows Server 2003, Datacenter Edition, or Windows 2000 Datacenter Server is installed.
        private const int VER_SUITE_ENTERPRISE = 0x00000002; //Windows Server 2008 Enterprise, Windows Server 2003, Enterprise Edition, or Windows 2000 Advanced Server is installed.Refer to the Remarks section for more information about this bit flag.
        private const int VER_SUITE_EMBEDDEDNT = 0x00000040;//Windows XP Embedded is installed.
        private const int VER_SUITE_PERSONAL = 0x00000200;//512;Windows Vista Home Premium, Windows Vista Home Basic, or Windows XP Home Edition is installed.
        private const int VER_SUITE_SINGLEUSERTS = 0x00000100;//256;Remote Desktop is supported, but only one interactive session is supported. This value is set unless the system is running in application server mode.
        private const int VER_SUITE_SMALLBUSINESS = 0x00000001;//Microsoft Small Business Server was once installed on the system, but may have been upgraded to another version of Windows. Refer to the Remarks section for more information about this bit flag.
        private const int VER_SUITE_SMALLBUSINESS_RESTRICTED = 0x00000020;//Microsoft Small Business Server is installed with the restrictive client license in force. Refer to the Remarks section for more information about this bit flag.
        private const int VER_SUITE_STORAGE_SERVER = 0x00002000;//Windows Storage Server 2003 R2 or Windows Storage Server 2003is installed.
        private const int VER_SUITE_TERMINAL = 0x00000010;//Terminal Services is installed. This value is always set. ---If VER_SUITE_TERMINAL is set but VER_SUITE_SINGLEUSERTS is not set, the system is running in application server mode.
        private const int VER_SUITE_WH_SERVER = 0x00008000;//Windows Home Server is installed.
        private const int VER_SUITE_MULTIUSERTS = 0x00020000;//AppServer mode is enabled.

        //wProductType
        private const int VER_NT_DOMAIN_CONTROLLER = 0x0000002;//he system is a domain controller and the operating system is Windows Server 2012 , Windows Server 2008 R2, Windows Server 2008, Windows Server 2003, or Windows 2000 Server.

        private const int VER_NT_SERVER = 0x0000003;//The operating system is Windows Server 2012, Windows Server 2008 R2, Windows Server 2008, Windows Server 2003, or Windows 2000 Server. --- Note that a server that is also a domain controller is reported as VER_NT_DOMAIN_CONTROLLER, not VER_NT_SERVER.

        private const int VER_NT_WORKSTATION = 0x0000001;//The operating system is Windows 8, Windows 7, Windows Vista, Windows XP Professional, Windows XP Home Edition, or Windows 2000 Professional.


        //win10  OSVERSIONINFOEX.wProductType == VER_NT_WORKSTATION
        //https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-osversioninfoexa
        #endregion VERSIONS

        #region PRODUCT
        private const int PRODUCT_BUSINESS = 0x00000006;//Business
        private const int PRODUCT_BUSINESS_N = 0x00000010;//Business N
        private const int PRODUCT_CLUSTER_SERVER = 0x00000012;//HPC Edition
        private const int PRODUCT_CLUSTER_SERVER_V = 0x00000040;//Server Hyper Core V
        private const int PRODUCT_CORE = 0x00000065;//Windows 10 Home
        private const int PRODUCT_CORE_COUNTRYSPECIFIC = 0x00000063;//Windows 10 Home China
        private const int PRODUCT_CORE_N = 0x00000062;//Windows 10 Home N
        private const int PRODUCT_CORE_SINGLELANGUAGE = 0x00000064;//Windows 10 Home Single Language
        private const int PRODUCT_DATACENTER_EVALUATION_SERVER = 0x00000050;//Server Datacenter (evaluation installation)
        private const int PRODUCT_DATACENTER_A_SERVER_CORE = 0x00000091;//Server Datacenter, Semi-Annual Channel (core installation)
        private const int PRODUCT_STANDARD_A_SERVER_CORE = 0x00000092;//Server Standard, Semi-Annual Channel (core installation)
        private const int PRODUCT_DATACENTER_SERVER = 0x00000008;//Server Datacenter (full installation. For Server Core installations of Windows Server 2012 and later, use the method, Determining whether Server Core is running.)
        private const int PRODUCT_DATACENTER_SERVER_CORE = 0x0000000C;//Server Datacenter (core installation, Windows Server 2008 R2 and earlier)
        private const int PRODUCT_DATACENTER_SERVER_CORE_V = 0x00000027;//Server Datacenter without Hyper-V (core installation)
        private const int PRODUCT_DATACENTER_SERVER_V = 0x00000025;//Server Datacenter without Hyper-V (full installation)
        private const int PRODUCT_EDUCATION = 0x00000079;//Windows 10 Education
        private const int PRODUCT_EDUCATION_N = 0x0000007A;//Windows 10 Education N
        private const int PRODUCT_ENTERPRISE = 0x00000004;//Windows 10 Enterprise
        private const int PRODUCT_ENTERPRISE_E = 0x00000046;//Windows 10 Enterprise E
        private const int PRODUCT_ENTERPRISE_EVALUATION = 0x00000048;//Windows 10 Enterprise Evaluation
        private const int PRODUCT_ENTERPRISE_N = 0x0000001B;//Windows 10 Enterprise N
        private const int PRODUCT_ENTERPRISE_N_EVALUATION = 0x00000054;//Windows 10 Enterprise N Evaluation
        private const int PRODUCT_ENTERPRISE_S = 0x0000007D;//Windows 10 Enterprise 2015 LTSB
        private const int PRODUCT_ENTERPRISE_S_EVALUATION = 0x00000081;//Windows 10 Enterprise 2015 LTSB Evaluation
        private const int PRODUCT_ENTERPRISE_S_N = 0x0000007E;//Windows 10 Enterprise 2015 LTSB N
        private const int PRODUCT_ENTERPRISE_S_N_EVALUATION = 0x00000082;//Windows 10 Enterprise 2015 LTSB N Evaluation
        private const int PRODUCT_PROFESSIONAL = 0x00000030;//Windows 10 Pro
        private const int PRODUCT_PROFESSIONAL_N = 0x00000030;//Windows 10 Pro N
        private const int PRODUCT_ENTERPRISE_SERVER = 0x0000000A;//Server Enterprise (full installation)
        private const int PRODUCT_HOME_BASIC = 0x00000002;//Home Basic
        private const int PRODUCT_HOME_PREMIUM = 0x00000003;//Home Premium
        //private const int VER_SUITE_DATACENTER = 0x00000080;
        //private const int VER_SUITE_ENTERPRISE = 0x00000002;

        #endregion PRODUCT 
        #endregion

        static OSInfoEx()
        {

        }

        #region 版本
        static private string s_Edition;
        /// <summary>
        /// 获取此计算机上运行的操作系统的版本。
        /// </summary>
        static public string Edition
        {
            get
            {
                if (s_Edition != null)
                    return s_Edition;  //***** RETURN *****//

                string edition = String.Empty;

                //OperatingSystem osVersion = Environment.OSVersion;
                OSVERSIONINFOEX osVersionInfo = new OSVERSIONINFOEX();
                osVersionInfo.dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFOEX));

                if (GetVersionEx(ref osVersionInfo))
                {
                    int majorVersion = osVersionInfo.dwMajorVersion;
                    int minorVersion = osVersionInfo.dwMinorVersion;

                    byte productType = osVersionInfo.wProductType;//用来检测版本;版本对照: https://docs.microsoft.com/zh-cn/windows/win32/sysinfo/operating-system-version
                    short suiteMask = osVersionInfo.wSuiteMask;

                    if (majorVersion == 4)
                    {
                        if (productType == VER_NT_WORKSTATION)
                        {
                            // Windows NT 4.0 Workstation
                            edition = "Workstation";
                        }
                        else if (productType == VER_NT_SERVER)
                        {
                            if ((suiteMask & VER_SUITE_ENTERPRISE) != 0)
                            {
                                // Windows NT 4.0 Server Enterprise
                                edition = "Enterprise Server";
                            }
                            else
                            {
                                // Windows NT 4.0 Server
                                edition = "Standard Server";
                            }
                        }
                    }

                    else if (majorVersion == 5)
                    {
                        if (productType == VER_NT_WORKSTATION)
                        {
                            if ((suiteMask & VER_SUITE_PERSONAL) != 0)
                            {
                                // Windows XP Home Edition
                                edition = "Home";
                            }
                            else
                            {
                                // Windows XP / Windows 2000 Professional
                                edition = "Professional";
                            }
                        }
                        else if (productType == VER_NT_SERVER)
                        {
                            if (minorVersion == 0)
                            {
                                if ((suiteMask & VER_SUITE_DATACENTER) != 0)
                                {
                                    // Windows 2000 Datacenter Server
                                    edition = "Datacenter Server";
                                }
                                else if ((suiteMask & VER_SUITE_ENTERPRISE) != 0)
                                {
                                    // Windows 2000 Advanced Server
                                    edition = "Advanced Server";
                                }
                                else
                                {
                                    // Windows 2000 Server
                                    edition = "Server";
                                }
                            }
                            else
                            {
                                if ((suiteMask & VER_SUITE_DATACENTER) != 0)
                                {
                                    // Windows Server 2003 Datacenter Edition
                                    edition = "Datacenter";
                                }
                                else if ((suiteMask & VER_SUITE_ENTERPRISE) != 0)
                                {
                                    // Windows Server 2003 Enterprise Edition
                                    edition = "Enterprise";
                                }
                                else if ((suiteMask & VER_SUITE_BLADE) != 0)
                                {
                                    // Windows Server 2003 Web Edition
                                    edition = "Web Edition";
                                }
                                else
                                {
                                    // Windows Server 2003 Standard Edition
                                    edition = "Standard";
                                }
                            }
                        }
                    }

                    #region VERSION 6
                    else if (majorVersion == 6 || majorVersion == 10)
                    {
                        int ed;
                        if (GetProductInfo(majorVersion, minorVersion,
                            osVersionInfo.wServicePackMajor, osVersionInfo.wServicePackMinor,
                            out ed))
                        {
                            switch (ed)
                            {
                                case PRODUCT_HOME_BASIC:
                                    edition = "Home Basic";
                                    break;
                                case PRODUCT_HOME_PREMIUM:
                                    edition = "Home Premium";
                                    break;

                                case PRODUCT_PROFESSIONAL_N:
                                    edition = "Windows 10 Pro";
                                    break;

                                case PRODUCT_BUSINESS:
                                    edition = "Business";
                                    break;
                                case PRODUCT_BUSINESS_N:
                                    edition = "Business N";
                                    break;
                                case PRODUCT_CLUSTER_SERVER:
                                    edition = "HPC Edition";
                                    break;
                                case PRODUCT_DATACENTER_SERVER:
                                    edition = "Datacenter Server";
                                    break;
                                case PRODUCT_DATACENTER_SERVER_CORE:
                                    edition = "Datacenter Server (core installation)";
                                    break;
                                case PRODUCT_ENTERPRISE:
                                    edition = "Enterprise";
                                    break;
                                case PRODUCT_ENTERPRISE_N:
                                    edition = "Enterprise N";
                                    break;
                                case PRODUCT_ENTERPRISE_SERVER:
                                    edition = "Enterprise Server";
                                    break;
                            }
                        }
                    }
                    #endregion VERSION 6
                }

                s_Edition = edition;
                return edition;
            }
        }
        #endregion EDITION

        #region  版本号(主要版本号,次要版本号,内部版本号,修订版本号)

        /// <summary>
        /// 获取此计算机上运行的操作系统的主要版本号
        /// </summary>

        static public int MajorVersion
        {
            get
            {
                OperatingSystem osVersion = Environment.OSVersion;
                OSVERSIONINFOEX osVersionInfo = new OSVERSIONINFOEX
                {
                    dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFOEX))
                };
                Win32Native.GetVersionEx(ref osVersionInfo);
                return osVersionInfo.dwMajorVersion;
            }
        }

        /// <summary>
        /// 获取此计算机上运行的操作系统的次要版本号
        /// </summary>
        static public int MinorVersion
        {
            get
            {
                OperatingSystem osVersion = Environment.OSVersion;
                OSVERSIONINFOEX osVersionInfo = new OSVERSIONINFOEX
                {
                    dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFOEX))
                };
                Win32Native.GetVersionEx(ref osVersionInfo);
                return osVersionInfo.dwMinorVersion;
            }
        }


        /// <summary>
        /// 获取此计算机上运行的操作系统的内部版本号。
        /// </summary>
        static public int BuildVersion
        {
            get
            {
                OSVERSIONINFOEX osVersionInfo = new OSVERSIONINFOEX
                {
                    dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFOEX))
                };
                Win32Native.GetVersionEx(ref osVersionInfo);

                return osVersionInfo.dwBuildNumber;
            }
        }

        /// <summary>
        /// 获取此计算机上运行的操作系统的修订版本号。
        /// </summary>
        static public int RevisionVersion
        {
            get
            {
                return Environment.OSVersion.Version.Revision;
            }
        }
        #endregion

        #region SERVICE PACK
        /// <summary>
        /// 获取此计算机上运行的操作系统的service pack信息。
        /// </summary>
        static public string ServicePack
        {
            get
            {
                string servicePack = String.Empty;
                OSVERSIONINFOEX osVersionInfo = new OSVERSIONINFOEX();
                osVersionInfo.dwOSVersionInfoSize = Marshal.SizeOf(typeof(OSVERSIONINFOEX));

                if (GetVersionEx(ref osVersionInfo))
                {
                    servicePack = osVersionInfo.szCSDVersion;
                }

                return servicePack;
            }
        }
        #endregion SERVICE PACK
    }
}
