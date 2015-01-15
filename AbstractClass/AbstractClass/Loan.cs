using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    abstract class Loan
    {
        public void Borrow()
        {
            Console.WriteLine("Borowed...");
        }

        public abstract void Ask();

        public virtual void VirAsk()
        {
            Console.WriteLine("Printed by VirAsk from LOAN class");
        }
    }
}
