using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetVerDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            //获取系统相关版本
            string strOSInfo =
                 "Build version: " + OSInfoEx.BuildVersion.ToString() + Environment.NewLine +
                 "Edition: " + OSInfoEx.Edition.ToString() + Environment.NewLine +
                 "Major Version: " + OSInfoEx.MajorVersion.ToString() + Environment.NewLine +
                 "Minor Version: " + OSInfoEx.MinorVersion.ToString() + Environment.NewLine +
                 "Revision Version: " + OSInfoEx.RevisionVersion.ToString() + Environment.NewLine +
                 "Service pack: " + OSInfoEx.ServicePack;
            Console.WriteLine(strOSInfo);
            Console.ReadKey();
        }

        /// <summary>
        /// 关于Windows 10 Enterprise LTSC https://docs.microsoft.com/en-us/windows/whats-new/ltsc/
        /// 关于Windows 10 版本信息  https://docs.microsoft.com/zh-cn/windows/release-information/
        /// </summary>
        private void LTSC()
        { 
        
        }

    }
}
