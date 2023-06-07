using System;
namespace ProjectEasysafe
{

/*public class English : Language
{
    public void setEnglish()
    {
        Console.WriteLine("What do you want to do?/Que voulez-vous faire ? \n1: Run backup/Executer un backup \n2: Run all backups sequentially/Exécuter séquentiellment tous les backups \n3: Create backup/Créer un backup");
        int choice = Convert.ToInt32(Console.ReadLine());
        if (choice == 1)
        {
            Console.WriteLine("Choice taken into account/Choix prit en compte");
            backupJob b = new backupJob();
            b.startBackup();
        }
        else if (choice == 2)
        {
            Console.WriteLine("Choice taken into account/Choix prit en compte");
            backupJob b = new backupJob();
            b.startBackup();
        }
        else if (choice == 3)
        {
            Console.WriteLine("Choice taken into account/Choix prit en compte");
            backupJob b = new backupJob();
            b.startBackup();
        }
        else
        {
            Console.WriteLine("Wrong entry.../Mauvais choix...");
        }
    }
}*/
public class English{
    private string[] arrayParam = new string[5];
            private bool type;
            //set all the attributes needed in a backupJob on e by one 
            private void setName(){
                Console.WriteLine("Enter the name of the backup");
                arrayParam[0] = Console.ReadLine();
            }
            private void setSourcePath(){
                string srcPath;
                Console.WriteLine("Enter the source directory");
                srcPath = Console.ReadLine();
                arrayParam[1] =srcPath;

            }
            private void setTargetPath(){
                string trgtPath;
                Console.WriteLine("Enter the destination directory");
                trgtPath = Console.ReadLine();
                arrayParam[2] = trgtPath;
            }
            private void setType(){
                Console.WriteLine("Do you want to make a full or differential backup: Y/N?");
                arrayParam[3] = Console.ReadLine();

            }
            public string[] getParameter(){
                setName();
                setSourcePath();
                setTargetPath();
                setType();
                return arrayParam;
            }
}
}
