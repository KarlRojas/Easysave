<<<<<<< HEAD:Version1.1/Program.cs
﻿using System;
using MyApp;


namespace ProjectEasysafe
{
    class Program
    {
        static void Main(string[] args)
        {
             //Language obj = new Language();
             //obj.setLanguage();

            Console.WriteLine("Hello World!");
            //backupJob test = new backupJob();
            //test.setParameters();
            //test.display();
            //test.startBackup();

            Statefile.Statefile run = new Statefile.Statefile();
            run.createStatusfile();
            
        }
    }
}
=======
﻿using System;
using System.IO;

namespace ProjectEasysafe
{
    class Program
    {


        static void Main(string[] args)
        {
            backupJob backup = new backupJob();
            using(Language obj = new Language()){
                backup.arrayParam = obj.setLanguage();
            }

            backup.startBackup(backup.arrayParam);
            //Console.WriteLine("Combien d'instance voulez vous lancer?");
            //test.nbFiles = Convert.ToInt32(Console.ReadLine());
            //test.mulTithreading(test.nbFiles);

            //Logfile run = new Logfile();
            //run.createXmlFile();
        }
    }
}
>>>>>>> 572da76def248194f7fa05a7fcfa0912a62c21d4:Version1.0/Program.cs
