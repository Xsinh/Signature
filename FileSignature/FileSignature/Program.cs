using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSignature
{
    class Program
    {
        static void Main(string[] args)
        {
            SHA256 sh = new SHA256();
            sh.Async();
            Console.ReadKey();
        }
    }
}
