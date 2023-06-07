using System;
using System.Threading;
using System.IO;

namespace ProjectEasysafe// Note: actual namespace depends on the project name.
{

    public class backupJob{
        public string[] arrayParam;
        /*private string name, srcPath, trgtPath;
        //do a private seter to set the infor 
        public int nbFiles = 0;
        private bool type;
        //set all the attributes needed in a backupJob on e by one 
        private void setName(){
            string name;
            Console.WriteLine("Saisissez le nom de la sauvegarde");
            name = Console.ReadLine();
            this.name = name;
        }
        private void setSourcePath(){
            string srcPath;
            Console.WriteLine("Saisissez le répertoire source");
            srcPath = Console.ReadLine();
            this.srcPath =srcPath;

        }
        private void setTargetPath(){
            string trgtPath;
            Console.WriteLine("Saisissez le répertoire de destination");
            trgtPath = Console.ReadLine();
            this.trgtPath = trgtPath;
        }
        private void setType(){
            bool type;
            string istype;
            Console.WriteLine("Voulez vous  faire une sauvegarde complete ou différentielle: O/N? ");
            istype = Console.ReadLine();
            if(istype=="O"){
                type = true;
            }else{
                type=false;
            }
            
            this.type =type;
        }

        public void setParameters(){
            setName();
            setSourcePath();
            setTargetPath();
            setType();
        }
        public void display(){

        }*/
        public void setParam(string[]tabParam){
            this.arrayParam = tabParam;
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
                threadArray[i] = new Thread(()=>startBackup(this.arrayParam));
            }
            for(int i=0 ;i < nbthread; i++){
                threadArray[i].Start();
            }


        }
        public void startBackup(string[]tabParam){
            setParam(tabParam);
            countFiles(Convert.ToString(arrayParam[1]), true);
            Console.WriteLine("Le repertoire a copier contient "+ Convert.ToInt32(arrayParam[4]) + " fichiers voulez vous continuer?");
            Console.ReadKey();
            copyDirectory(arrayParam[1], arrayParam[2], true);
            Console.WriteLine("La copie s'est déroulée sans problème");
            
        }
    }
}