using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace FileSignature
{
    class SHA256
    {
         public async void Async()
        {   
           
            int core = Environment.ProcessorCount;
            try
            {
                Console.WriteLine("Enter the path:\n");
                string filename = Console.ReadLine();
                Console.WriteLine("Write on how many parts you want to break the file");
                int PartSize = int.Parse(Console.ReadLine());
                byte[] buffer;

                SHA256 mySHA256 = new SHA256Managed.Create();
                byte[] hashvalue;
                using (FileStream SourceStream = File.Open(filename, FileMode.Open))
                {
                    try
                    {
                        buffer = new Byte[SourceStream.Length / PartSize];
                        for (int i = buffer.Length; i <= SourceStream.Length; )
                        {
                            await SourceStream.ReadAsync(buffer, 0, (int)buffer.Length);
                            Int64 number = i / buffer.Length;
                            Console.WriteLine("\nSHA of part №{0}:", number);
                            hashvalue = mySHA256.ComputeHash(buffer);
                            PrintByteArray(hashvalue);
                            i = i + buffer.Length;
                            if (number == PartSize)
                            {
                                Console.WriteLine("\nEnd");
                                return;
                            }
                        }

                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("need more part for this file");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        private static void PrintByteArray(byte[] array)
        {
            int i;

            for (i = 0; i < array.Length; i++)
            {
                Console.Write(String.Format("{0:X2}", array[i]));
                if ((i % 4) == 3) Console.Write(" ");
            }

            Console.WriteLine();
        }
    }
    }

