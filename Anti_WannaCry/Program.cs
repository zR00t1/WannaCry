using System;
using System.IO;

namespace Anti_WannaCry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();

            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles("*.*", SearchOption.TopDirectoryOnly);

            int j = 0;
            for (int i = 0; i < files.Length; i++)
            {
                
                bool isContain = files[i].FullName.Contains(".WNCRY");

                if (isContain)
                {
                    Console.WriteLine(Path.GetFileNameWithoutExtension(files[i].FullName));
                    files[i].MoveTo(Path.ChangeExtension(files[i].FullName, ""));
                    j++;
                } 
            }
            Console.WriteLine("\n******************************************************\n");
            Console.WriteLine("共恢复成功" + j + "个文件");
            Console.WriteLine("按任意键退出....");
            Console.ReadLine();
        }

    }
}
