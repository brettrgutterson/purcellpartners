using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurcellPartners.Common.ListProcessing
{
    public interface IListProcessor
    {
        List<int> RetrieveInputList(string input);

        List<int> DetectMissingNumbers(List<int> inputList);

        string GetMissingNumberCSVList(List<int> missingNumberList);
    }
}