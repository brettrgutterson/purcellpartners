using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using PurcellPartners.Common.ConfigurationSetting;
using PurcellPartners.Common.ListProcessing;
using PurcellPartners.Common.OutputHandling;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PurcellPartners.Common.Application
{
    public class Application : IApplication
    {
        private readonly IOutputHandler _OutputHandler;
        private readonly IListProcessor _ListProcessor;

        public Application(IOutputHandler outputHandler, IListProcessor listProcessor)
        {
            _OutputHandler = outputHandler;
            _ListProcessor = listProcessor;
        }

        public async void Execute()
        {
            _OutputHandler.WriteListPromptMessage();

            var input = Console.ReadLine().Trim();

            var isInputValid = await ValidateInput(input);

            _OutputHandler.WriteProcessingMessage();

            var inputList = await RetrieveInputList(input);

            var orderedList = await OrderInputList(inputList);

            var missingNumbers = await DetectMissingNumbers(inputList);

            var missingNumbersCSVList = _ListProcessor.GetMissingNumberCSVList(missingNumbers);

            _OutputHandler.WriteMissingNumbersList(missingNumbersCSVList);

            Console.ReadLine();
        }

        public Task<bool> ValidateInput(string input)
        {
            var parts = input.Split(',');
            
            var validationResult = parts.All(p => int.TryParse(p.Trim(), out _));

            return Task.FromResult(validationResult);
        }

        public Task<List<int>> RetrieveInputList(string input)
        {
            var returnList = input.Split(',').Select(p => int.Parse(p.Trim())).ToList();

            return Task.FromResult(returnList);
        }

        public Task<List<int>> OrderInputList(List<int> inputList) => Task.FromResult(inputList.OrderBy(n => n).ToList());

        public Task<List<int>> DetectMissingNumbers(List<int> inputList)
        {
            var fullRangeOfNumbers = Enumerable.Range(inputList.Min(), inputList.Max() - inputList.Min() + 1);
            var missing = fullRangeOfNumbers.Except(inputList).ToList();
            return Task.FromResult(missing);
        }
    }
}