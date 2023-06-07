using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace ProjectEasysafe
{
    public class backupJobEn
    {
        private string[] arrayParam;

        public void setParam(){
            English param = new English();
            this.arrayParam = param.getParameter();
        }
        private void countFiles(string srcPath, bool recursive){
            int nbFiles=0;
            var dir = new DirectoryInfo(srcPath);
            nbFiles = nbFiles + dir.GetFiles().Length;
            DirectoryInfo[] dirs = dir.GetDirectories();
            if (recursive)
            {

                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(srcPath, subDir.Name);
                    countFiles(newDestinationDir, true);
                }
            }
            arrayParam[4]=Convert.ToString(nbFiles);
        }

        private void copyDirectory(string sourcePath, string destinationDir, bool recursive)
        {
            // Get information about the source directory
            var dir = new DirectoryInfo(sourcePath);

            // Check if the source directory exists
            if (!dir.Exists)
                throw new DirectoryNotFoundException($"Source directory not found: {dir.FullName}");

            // Cache directories before we start copying
            DirectoryInfo[] dirs = dir.GetDirectories();

            // Create the destination directory
            Directory.CreateDirectory(destinationDir);
            // Get the files in the source directory and copy to the destination directory
            foreach (FileInfo file in dir.GetFiles())
            {
                string targetFilePath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(targetFilePath);
            }
            //Rewrite Files already existing

            // If recursive and copying subdirectories, recursively call this method
            if (recursive)
            {
                foreach (DirectoryInfo subDir in dirs)
                {
                    string newDestinationDir = Path.Combine(destinationDir, subDir.Name);
                    copyDirectory(subDir.FullName, newDestinationDir, true);
                }
            }
        }
        public void mulTithreading(int nbthread){
            
            Thread[] threadArray = new Thread[nbthread];
            for(int i=0 ;i < nbthread; i++){
                threadArray[i] = new Thread(startBackup);
            }
            for(int i=0 ;i < nbthread; i++){
                threadArray[i].Start();
            }


        }
        public void startBackup(){
            setParam();
            countFiles(Convert.ToString(arrayParam[1]), true);
            Console.WriteLine("Le repertoire a copier contient "+ Convert.ToInt32(arrayParam[4]) + " fichiers voulez vous continuer?");
            Console.ReadKey();
            copyDirectory(arrayParam[1], arrayParam[2], true);
            Console.WriteLine("La copie s'est déroulée sans problème");

            
        }
    }
}