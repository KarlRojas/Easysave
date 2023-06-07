using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using ProjectEasysafe;

namespace Statefile  {
    public class Statefile : Logfile
    {
        //variables
        
    public string sourcePath;
    public string targetpath;
        public string dirfullname { get; set; }
        public System.IO.DirectoryInfo root { get; set; }
        public System.IO.FileAttributes attributes { get; set; }
        public DateTime creationTime { get; set; }
        public string name { get; set; }
        public string ffullName { get; set; }
        public string fname { get; set; }
        public DateTime fcreationTime { get; set; }
        public long sizefile { get; set; }
        public string srcPath;

        //Counter to indicate number of bytes already copied
        public int nbByteslefttodo { get; set; }
        //variables

        //method
        public void retrieveinfo()
            {
                //Retrieve drive informations
                DriveInfo[] di = DriveInfo.GetDrives();
                Console.WriteLine("Total Partitions");
                Console.WriteLine("----------------------------");
                foreach (DriveInfo items in di)
                {
                    Console.WriteLine(items.Name);
                }
            }
        //that method retrieves drive info and shows it on the console
        
            //method to create a real time file
            public void createStatusfile()
            {
            //string sourcePath = @"D:\";
            //Retrieve directory info
            //creation of a object called directory
            string srcPath;
            Console.WriteLine("Saisissez le répertoire source");
            srcPath = Console.ReadLine();
            this.srcPath = srcPath;
            Console.WriteLine(srcPath);
            DirectoryInfo directory = new DirectoryInfo(srcPath);

            //creation of a object called file
            
            FileInfo file = new FileInfo(srcPath);

            //open file
            //iterate till all the bytes read from FileStream
            /*FileStream fs = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

            
            
            //create byte array of same size as FileStream length
            byte[] fileBytes = new byte[sizefile];

            //define counter to check how much bytes to copy. Decrease the counter as we copy each byte
            // put the initial value of bytes to copy
            //count how much bytes to copy left and how much copied bytes is left
            while (sizefile > 0)
            {
                int n = fs.Read(fileBytes, nbByteslefttodo, Convert.ToInt32(sizefile));

                if (n == 0)
                    break;
                nbByteslefttodo += n;
                sizefile -= n;
                */
                Statefile state = new Statefile()
                {
                    fileSize = 1,
                    fileTransferTime = 300,
                    Time = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),

                    //retrieve directory info 
                    dirfullname = directory.FullName,
                    root = directory.Root,
                    attributes = directory.Attributes,
                    creationTime = directory.CreationTime,
                    name = directory.Name,

                    //retrieve file info
                    ffullName = file.FullName,
                    fname = file.Name,
                    fcreationTime = file.CreationTime,
                    sizefile = file.Length,
                    nbByteslefttodo = 0,

                    //retrieve backup info

                };
                // creation d'un fichier unique contenant l'état d'avancement des travaux de sauvegardes


                String JsonResult = JsonConvert.SerializeObject(state, Formatting.Indented);
                File.WriteAllText(@"statefile.json", JsonResult);
                Console.WriteLine("state has been created successfully !");

                JsonResult = String.Empty;
                JsonResult = File.ReadAllText(@"statefile.json");
                Logfile resultLog = JsonConvert.DeserializeObject<Logfile>(JsonResult);


            }



        }

        
    } 



