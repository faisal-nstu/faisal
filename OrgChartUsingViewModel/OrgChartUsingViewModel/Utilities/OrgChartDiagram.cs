using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.UI.Xaml.Diagram;

namespace OrgChartUsingViewModel.Utilities
{
    class OrgChartDiagram: SfDiagram
    {
        public Selector SfSelector = new Selector();
        protected override Selector GetSelectorForItemOverride(object item)
        {
            return SfSelector;
        }
    }
}
