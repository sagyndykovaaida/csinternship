using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace ConsoleAppModule05
{
    internal class task1
    {
        static void Main()
        {
            string url = "http://example.com/nonexistentpage";

            try
            {
                using (WebClient client = new WebClient())
                {
                    string content = client.DownloadString(url);
                    Console.WriteLine("Содержимое ресурса: " + content);
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("Произошла ошибка запроса к веб-ресурсу: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка: " + ex.Message);
            }
            Console.ReadKey();
        }
    }
}

