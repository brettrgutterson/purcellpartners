using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using PurcellPartners.Common.ConfigurationSetting;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PurcellPartners.Common.Application
{
    public class Application : IApplication
    {
        private readonly ConfigurationSettingManager _ConfigurationSettingManager;

        public Application(ConfigurationSettingManager configurationSettingManager)
        {
            _ConfigurationSettingManager = configurationSettingManager;
        }

        public async void Execute()
        {
            var inputPrompt = _ConfigurationSettingManager.GetValueByKey("InputPrompt") ?? "Please enter the input list";

            var input = await PromptForInput(inputPrompt);

            var isInputValid = await ValidateInput(input);

            var processingMessage = _ConfigurationSettingManager.GetValueByKey("ProcessingStarted") ?? "Please wait while we process your request";
            Console.WriteLine(processingMessage);

            var inputList = await RetrieveInputList(input);

            var orderedList = await OrderInputList(inputList);

            var missingNumbers = await DetectMissingNumbers(inputList);

            Console.WriteLine(string.Join(", ", missingNumbers));

            Console.ReadLine();
        }

        public Task<string?> PromptForInput(string inputPrompt)
        {
            Console.Write($"{inputPrompt}:");

            return Task.FromResult(Console.ReadLine()?.Trim());
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