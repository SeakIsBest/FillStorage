using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FillStorage.HelperClass
{
    class AdbHelper
    {
        /// <summary>
        /// adb.exe文件的路径，默认相对于当前应用程序目录取。
        /// </summary>
        public static string AdbExePath
        {
            get
            {
                return Path.Combine(Application.StartupPath, "AdbBin\\adb.exe");
            }
        }
        public static string InternalDataPath
        {
            get
            {
                return "/data";
            }
        }

        private static string copyPath;
        public static string CopyPath
        {
            get
            {
                return copyPath;
            }
            private set
            {
                copyPath = value;
            }
        }
        public static string SdcardPath
        {
            get
            {
                return "/mnt/media";
            }
        }

        /// <summary>
        /// 启动ADB服务
        /// </summary>
        /// <returns></returns>
        public static bool StartServer()
        {
            return ProcessHelper.Run(AdbExePath, "start-server").Success;
        }

        /// <summary>
        /// 关闭ADB服务
        /// </summary>
        /// <returns></returns>
        public static void StopServer()
        {
            ProcessHelper.Run(AdbExePath, "kill-server");
        }

        public static string[] GetDevices()
        {
            var result = ProcessHelper.Run(AdbExePath, "devices");
            var itemsString = result.OutputString;
            var items = itemsString.Split(new[] { "$", "#", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            var itemsList = new List<String>();
            foreach (var item in items)
            {
                var temp = item.Trim();
                Console.WriteLine(temp);
                if (temp.Contains("List of devices attached"))
                {
                    Console.WriteLine("continue");
                    continue;
                }
                if (temp.Contains("device"))
                {
                    int idEnd = temp.IndexOf("device");
                    var id = temp.Substring(0, idEnd).Trim();
                    Console.WriteLine(id);
                    itemsList.Add(id);
                }
            }
            return itemsList.ToArray();
        }

        public static void CatchBugreport(string deviceNo)
        {
            string aaa = string.Format(" -s {0} bugreport {1} ", deviceNo, Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
            Console.WriteLine(aaa);
            ProcessHelper.RunResult re =  ProcessHelper.Run(AdbHelper.AdbExePath,string.Format(" -s {0} bugreport {1} ", deviceNo, Environment.GetFolderPath(Environment.SpecialFolder.Desktop)));
            Console.WriteLine(re.OutputString);
        }

            /// <summary>
            /// 获取剩余可用空间 Filesystem       1K-blocks      Used Available Use% Mounted on
            /// </summary>
            public static string[] GetPartitionInfo(string deviceNo, bool isInternal)
        {
            string path;
            if(isInternal)
            {
                path = AdbHelper.InternalDataPath;
                CopyPath = "/sdcard/";
            }
            else
            {
                path = AdbHelper.SdcardPath;
            }
            //var moreArgs = new[] { string.Format("df | grep {0}", path), "exit" };
            //var result = ProcessHelper.RunAsContinueMode(AdbExePath, string.Format(" -s {0} shell", deviceNo), moreArgs);
            var result = ProcessHelper.Run(AdbExePath, string.Format(" -s {0} shell df", deviceNo));
            var itemsString = result.OutputString;
            var items = itemsString.Split(new[] {"\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in items)
            {
                var temp = item.Trim();
                if (temp.Contains(path))
                {
                    var valsList = new List<String>();
                    var vals = temp.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    foreach(var val in vals)
                    {
                        valsList.Add(val.Trim());
                        Console.WriteLine(val.Trim());
                    }
                    if(!isInternal)
                    {
                        CopyPath = valsList.Last() + "/";
                        Console.WriteLine(CopyPath);
                    }
                    return valsList.ToArray();
                }
                continue;
            }
            Console.WriteLine(CopyPath);
            return new string[0];
        }

        /// <summary>
        /// 将文件拷贝到设备上（不适用于文件夹）
        /// </summary>
        /// <param name="deviceNo"></param>
        /// <param name="pcPath"></param>
        /// <param name="devPath"></param>
        /// <returns></returns>
        public static bool CopyToDevice(string deviceNo, string pcPath, string devPath,
            int repeat, ProgressBar progressBar, Label progressText)
        {
            progressBar.PerformStep();
            string newTempName = "NewTemp" + DateTime.Now.ToFileTimeUtc().ToString() + repeat + ".txt";
            //adb push [-p] <local> <remote> 
            //- copy file/dir to device
            var result = ProcessHelper.Run(AdbExePath, string.Format("-s {0} push {1} {2}", deviceNo, pcPath, devPath + newTempName));
           // m_log.Info("推送PAD时结果：" + result.ToString());

            if (result.ExitCode != 0
                || (result.OutputString.Contains("failed")
                && result.OutputString.Contains("No such file or directory")))//若出现设备文件夹不存在的情况，则创建该文件夹
            {
                //构建拷贝后设备路径
                int index1 = result.OutputString.IndexOf("failed to copy ");
                //输出字符串：" failed to copy 'F:\padData\image\1.jpg' to 'sdcard/21at/output/image/1.jpg': No such file or directory"
                string temp = result.OutputString.Substring(index1);
                int index2 = temp.IndexOf(devPath);
                int index3 = temp.IndexOf("': No such file or directory");
                string devPath2 = temp.Substring(index2, index3 - index2);//设备图片路径
                devPath2 = devPath2.Substring(0, devPath2.LastIndexOf('/'));
                var moreArgs = new[] { "su", "mkdir -p " + devPath2, "exit", "exit" };
                //shell 方式创建文件夹
                ProcessHelper.RunAsContinueMode(AdbExePath, string.Format("-s {0} shell", deviceNo), moreArgs);
               // m_log.Info("创建文件夹：" + devPath2);
               // m_log.Info("创建文件夹结果：" + result.ToString());
                //再次推送该文件
                result = ProcessHelper.Run(AdbExePath, string.Format("-s {0} push {1} {2}", deviceNo, pcPath, devPath + newTempName));
               // m_log.Info("再次推送PAD结果：" + result.ToString());
            }
            if (!result.Success
                || result.ExitCode != 0
                || (result.OutputString != null && result.OutputString.Contains("failed")))
            {
                return false;
                throw new Exception("push 执行返回的结果异常：" + result.OutputString);
            }
            int progress = progressBar.Maximum - repeat + 1;
            Console.WriteLine("copying: " + progress);
            progressText.Text = ((float)(int)((float)progress * 10000 / progressBar.Maximum) / 100) + "%";
            progressText.Refresh();
            if(repeat > 1)
                return CopyToDevice(deviceNo, pcPath, devPath,
                    --repeat, progressBar, progressText);
            return true;
        }

        #region 获取设备相关信息
        /// <summary>
        /// -s 0123456789ABCDEF shell getprop ro.product.brand
        /// </summary>
        /// <param name="deviceNo"></param>
        /// <param name="propKey"></param>
        /// <returns></returns>
        public static string GetDeviceProp(string deviceNo, string propKey)
        {
            var result = ProcessHelper.Run(AdbExePath, string.Format("-s {0} shell getprop {1}", deviceNo, propKey));
            return result.OutputString.Trim();
        }
        /// <summary>
        /// 型号：[ro.product.model]: [Titan-6575]
        /// </summary>
        /// <param name="deviceNo"></param>
        /// <returns></returns>
        public static string GetDeviceModel(string deviceNo)
        {
            return GetDeviceProp(deviceNo, "ro.product.model");
        }
        /// <summary>
        /// 牌子：[ro.product.brand]: [Huawei]
        /// </summary>
        /// <param name="deviceNo"></param>
        /// <returns></returns>
        public static string GetDeviceBrand(string deviceNo)
        {
            return GetDeviceProp(deviceNo, "ro.product.brand");
        }
        #endregion
    }
}
