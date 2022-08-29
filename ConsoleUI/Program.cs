using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string rootPath = @"C:\Users\DF\source\repos\FIleSystemProject\Files"; //@ symbol allows to use slashes w/o having to escape

            //read all directories in this path
            string[] dirs = Directory.GetDirectories(rootPath);

            foreach(string dir in dirs)
            {
                Console.WriteLine(dir);
            }

            Console.ReadLine(); //stops application
        }
    }
}
