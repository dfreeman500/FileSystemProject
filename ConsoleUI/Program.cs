using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; 

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            string rootPath = @"C:\Users\DF\source\repos\FIleSystemProject\Files"; //@ symbol allows to use slashes w/o having to escape

            //read all directories in this path
            //string[] dirs = Directory.GetDirectories(rootPath); // only gets upper level directories
            string[] dirs = Directory.GetDirectories(rootPath, "*", SearchOption.AllDirectories); // reads all directories


            foreach (string dir in dirs)
            {
                Console.WriteLine(dir);
            }


            Console.WriteLine();

            //get files instead of directories
            //var files = Directory.GetFiles(rootPath,"*.*", SearchOption.TopDirectoryOnly);
            var files = Directory.GetFiles(rootPath, "*.*", SearchOption.AllDirectories); //ex: "*.txt", "folder*.*"

            foreach (string file in files)
            {
                //Console.WriteLine(file);
                //Console.WriteLine(Path.GetFileName(file)); // just gets file name
                Console.WriteLine(Path.GetFileNameWithoutExtension(file)); // file name no extension
                                                                           //Console.WriteLine(Path.GetFullPath(file)); // full path, beneficial if you have a relative path when you passed it in
                //Console.WriteLine(Path.GetDirectoryName(file)); // Gives directory names of files

            }


            //getting fileinfo with FileInfo()
            foreach (string file in files)
            {
                var info = new FileInfo(file);
                Console.WriteLine(info.Length); //size in bites of the current file
                Console.WriteLine(info.LastAccessTime);
                Console.WriteLine(info.CreationTime);
            }


            //verify if directory exists
            string newPath = @"C:\Users\DF\source\repos\FIleSystemProject\SubFolderC\SubSubFolderD";
            bool directoryExists = Directory.Exists(newPath);

            if (directoryExists)
            {
                Console.WriteLine("The direcotry exists");
            }
            else
            {
                Console.WriteLine("The directory does not exist");
                Directory.CreateDirectory(newPath); //creates new directory if not exists
            }





            string[] files1 = Directory.GetFiles(rootPath);
            Directory.CreateDirectory(@"C:\Users\DF\source\repos\FIleSystemProject\Files\Destination");
            string destinationFolder = @"C:\Users\DF\source\repos\FIleSystemProject\Files\Destination"; //@ symbol allows to use slashes w/o having to escape





            //CopyFiles(files1, destinationFolder);

            //CopyRename(files, destinationFolder);
            Mover(files1, destinationFolder);

            Console.ReadLine(); //stops application
        }






        public static void Mover(string[] files1, string destinationFolder)
        {
            //moving
            foreach (string file in files1)
            {
                File.Move(file, $"{destinationFolder}\\{Path.GetFileName(file)}");
            }
        }


        public static void CopyRename(string[] files, string destinationFolder)
        {
            //copying and renaming as you go.
            for (int i = 0; i < files.Length; i++)
            {
                File.Copy(files[i], $"{destinationFolder}\\{i}.txt", true); // true for overwriting
            }

        }

        public static void CopyFiles(string[] files1, string destinationFolder)
        {
            foreach (string file in files1)
            {
                Console.WriteLine(file);
                Console.WriteLine(Path.GetFileName(file)); //just the filename
                File.Copy(file, $"{destinationFolder}\\{Path.GetFileName(file)}", true); // true for overwriting
            }
        }

}
}
