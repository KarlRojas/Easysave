using System;
namespace ProjectEasysafe
{

public class French{
    private string[] arrayParam = new string[5];
            private bool type;
            //set all the attributes needed in a backupJob on e by one 
            private void setName(){
                Console.WriteLine("Saisissez le nom de la sauvegarde");
                arrayParam[0] = Console.ReadLine();
            }
            private void setSourcePath(){
                string srcPath;
                Console.WriteLine("Saisissez le répertoire source");
                srcPath = Console.ReadLine();
                arrayParam[1] =srcPath;

            }
            private void setTargetPath(){
                string trgtPath;
                Console.WriteLine("Saisissez le répertoire de destination");
                trgtPath = Console.ReadLine();
                arrayParam[2] = trgtPath;
            }
            private void setType(){
                Console.WriteLine("Voulez vous  faire une sauvegarde complete ou différentielle: O/N? ");
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
