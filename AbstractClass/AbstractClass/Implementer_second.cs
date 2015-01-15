using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    class Implementer_second: Loan
    {
        public Implementer_second()
        {
            Ask();
            VirAsk();
        }

        public override void Ask()
        {
            Console.WriteLine("Printed by SECOND IMPLEMENTER ....");
        }

        public override void VirAsk()
        {
            base.VirAsk();
            Console.WriteLine("Printed by SECOND IMPLEMENTER by overriding virtual method VirAsk...");
        }
    }
}
