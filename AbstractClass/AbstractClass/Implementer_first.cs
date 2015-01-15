using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClass
{
    class Implementer_first: Loan
    {
        public Implementer_first()
        {
            Ask();
            VirAsk();
        }

        public override void Ask()
        {
            Console.WriteLine("Printed by FIRST IMPLEMENTER by overriding LOAN...");
        }

        public override void VirAsk()
        {
            base.VirAsk();
            Console.WriteLine("Printed by FIRST IMPLEMENTER by overriding virtual method VirAsk");
        }
    }
}
