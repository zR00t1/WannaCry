using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Anti_WannaCry
{
    internal class Program
    {
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        const int SPI_SETDESKWALLPAPER = 0x14;
        const int SPIF_UPDATEINIFILE = 0x1;
        const int SPIF_SENDCHANGE = 0x2;

        static void RestoreDefaultWallpaper()
        {
            string defaultWallpaper = @"C:\\Windows\\Web\\Wallpaper\\Windows\\img0.jpg";
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, defaultWallpaper, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
            Console.WriteLine("默认壁纸已恢复。");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("\r\n __          __                      _____            \r\n \\ \\        / /                     / ____|           \r\n  \\ \\  /\\  / /_ _ _ __  _ __   __ _| |     _ __ _   _ \r\n   \\ \\/  \\/ / _` | '_ \\| '_ \\ / _` | |    | '__| | | |\r\n    \\  /\\  / (_| | | | | | | | (_| | |____| |  | |_| |\r\n     \\/  \\/ \\__,_|_| |_|_| |_|\\__,_|\\_____|_|   \\__, |\r\n                                                 __/ |\r\n                                                |___/ \r\n\n\n                             勒索病毒文件恢复工具 V2.0");

            string path = Directory.GetCurrentDirectory();
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles("*.*", SearchOption.TopDirectoryOnly);

            int j = 0;
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].FullName.Contains(".WNCRY"))
                {
                    Console.WriteLine(Path.GetFileNameWithoutExtension(files[i].FullName));
                    files[i].MoveTo(Path.ChangeExtension(files[i].FullName, ""));
                    j++;
                }
            }

            Console.WriteLine("\n******************************************************\n");
            Console.WriteLine("共恢复成功" + j + "个文件");

            // 恢复默认壁纸
            RestoreDefaultWallpaper();

            Console.WriteLine("按任意键退出....");
            Console.ReadLine();
        }
    }
}
