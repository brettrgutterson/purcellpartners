using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurcellPartners.Common.ListProcessing
{
    public class ListProcessor : IListProcessor
    {
        public List<int> DetectMissingNumbers(List<int> inputList)
        {
            var fullRangeOfNumbers = Enumerable.Range(inputList.Min(), inputList.Max() - inputList.Min() + 1);
            var missingNumbers = fullRangeOfNumbers.Except(inputList).ToList();

            return missingNumbers;
        }

        public string GetMissingNumberCSVList(List<int> missingNumberList) => string.Join(", ", missingNumberList);
    }
}