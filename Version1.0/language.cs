using System;
using System.ComponentModel;
using System.Runtime.InteropServices;




namespace ProjectEasysafe
{

public class Language:IDisposable
{
            // Pointer to an external unmanaged resource.
        private IntPtr handle;

        private Component component = new Component();

        private bool disposed = false;

        public void MyResource(IntPtr handle)
        {
            this.handle = handle;
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {

            if(!this.disposed)
            {
                if(disposing)
                {
                    component.Dispose();
                }
                CloseHandle(handle);
                handle = IntPtr.Zero;
                disposed = true;
            }
        }

        [System.Runtime.InteropServices.DllImport("Kernell32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        ~Language()
        {
            Dispose(disposing: false);
        }
    public string[] setLanguage()
    {
        Console.WriteLine("Choose your language, press '1' for English or '2' for French : \nChoisissez la langue, '1' pour Anglais ou '2' pour Français:");
        int characters = Convert.ToInt32(Console.ReadLine());
        if (characters == 1)
        {
            English e = new English();
            return e.getParameter();
        }
        else if (characters == 2)
        {
            French f = new French();
            return f.getParameter();
        }
        else
        {
            Console.WriteLine("Wrong entry.../Mauvais choix...");
            return null;
            setLanguage();
        }

        }
    }
}
