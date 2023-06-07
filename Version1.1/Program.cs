using System;
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
