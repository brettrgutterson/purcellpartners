using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurcellPartners.Common.ListProcessing
{
    public class ListProcessor : IListProcessor
    {
        public string GetMissingNumberCSVList(List<int> missingNumberList) => string.Join(", ", missingNumberList);
    }
}