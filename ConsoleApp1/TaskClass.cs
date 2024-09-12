using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class TaskClass
    {
       public  async Task GetResult()
        {
            await Task.Run(() => {
            Thread.Sleep(2000);
            });
            Console.WriteLine("GetResult executed...");
        }
    }
}
