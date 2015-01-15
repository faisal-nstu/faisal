using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateExample
{

    public delegate void KeyPressDelegate(char key);
    public delegate void QuitDelegate();

    class KeystrokeHandler
    {
        public KeyPressDelegate OnKey;
        public QuitDelegate OnQuitting;
            
        public void Run()
        {
            Console.WriteLine("Running");
            while (true) 
            {
                char key = Console.ReadKey(true).KeyChar;

                if (key == 'q')
                {
                    if (OnQuitting != null)
                        OnQuitting();
                    break;
                }

                if (OnKey != null)
                    OnKey(key);
            }
        }
    }
}
