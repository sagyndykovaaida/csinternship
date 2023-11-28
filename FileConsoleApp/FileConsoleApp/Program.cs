using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileConsoleApp
{
    internal class Program
    {
        static string path = @"C:\\temp\\TNSShort";

        static void GetDirectoryInfo()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if(directoryInfo.Exists )
            {
                Dictionary<string,int> dic = new Dictionary<string,int>();
                foreach (var item in directoryInfo.GetFiles())
                {
                    if (!dic.ContainsKey(item.Extension))
                    {
                        dic.Add(item.Extension,0);
                    }

                }

                foreach (var item in dic)
                {
                    Console.WriteLine(item.Key);
                }

                string selectedEx = " ";
                Console.Write("Choose extensions: ");
                selectedEx = Console.ReadLine();
                Dictionary<string,string> dicReplace = new Dictionary<string,string>(); 

                foreach (FileInfo item in directoryInfo.GetFiles("*."+selectedEx))
                {
                    Console.WriteLine(item.Name);
                    foreach (char i in item.Name)
                    {
                        if(!(i>=65 && i<=90 && i>=97 && i<=122) || !(i>=192 && i <= 225))
                        {
                            if (!dicReplace.ContainsKey(i.ToString()))
                            {
                                dicReplace.Add(i.ToString(), " ");
                            }
                        }
                    }
                }

                for(int i=0;i<dicReplace.Count; i++)
                {
                    Console.WriteLine("«-» заменить на (пользователь вводит на что заменить)",
                        dicReplace.ElementAt(i).Key);
                    dicReplace[dicReplace.ElementAt(i).Key] = Console.ReadLine();   


                }

                
            }
        }
        static void Main(string[] args)
        {
            GetDirectoryInfo();
            Console.ReadKey();  
        }
    }

}
