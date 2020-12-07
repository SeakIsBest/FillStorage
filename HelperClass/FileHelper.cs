using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FillStorage.HelperClass
{
    class FileHelper
    {
        //单位：B
        private static readonly long mMaxTempFileUnitSize = 200 * 1024 * 1024;
        private static long mTempFileSize = 0;

        /// <summary>
        /// 生成缓存文件的目录。
        /// </summary>
        public static string FilePath
        {
            get
            {
                return "D:\\NewTemp.txt";
            }
        }

        /// <summary>
        /// 生成缓存文件。
        /// size:Byte
        /// </summary>
        public static int CreateNewTempFile(long size)
        {
            //留下1M不要填充
            size -= 1024 * 1024;
            int repeatCount = 0;
            do
            {
                repeatCount++;
                mTempFileSize = size / repeatCount;
            } while (mTempFileSize > mMaxTempFileUnitSize);
            Console.WriteLine("mTempFileSize: " + mTempFileSize / 1024 / 1024 + "MB\trepeat: " + repeatCount + "\ttotal: " + mTempFileSize * repeatCount / 1024);
            try
            {
                if(File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                }
                FileStream fs = new FileStream(@FilePath, FileMode.OpenOrCreate);
                //fs.Seek(size, SeekOrigin.Begin);
                Console.WriteLine("CreateNewTempFile  size = {0}", mTempFileSize);
                byte[] data = new byte[mTempFileSize];
                fs.Write(data, 0, data.Length);
                fs.Close();
                return repeatCount;
            }
            catch (IOException)
            {
            }
            return 0;
            //ProcessHelper.Run("cmd.exe", string.Format("fsutil file createnew {0} {1}", FilePath, size));
        }

        public static void DeleteTempFile()
        {
            File.Delete(@FilePath);
        }
    }
}
