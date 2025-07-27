using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PurcellPartners.Common.ConfigurationSetting;

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
    }
}