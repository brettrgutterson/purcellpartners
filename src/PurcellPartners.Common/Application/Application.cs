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

            while (string.IsNullOrWhiteSpace(input))
            {
                var emptyInputDetectedMessage = _ConfigurationSettingManager.GetValueByKey("EmptyInputDetected") ?? "Input not detected. Please try again";

                Console.WriteLine(emptyInputDetectedMessage);
                Console.WriteLine();

                input = await PromptForInput(inputPrompt);
            }

            var processingMessage = _ConfigurationSettingManager.GetValueByKey("ProcessingStarted") ?? "Please wait while we process your request";
            Console.WriteLine(processingMessage);

            Console.ReadLine();
        }

        public Task<string?> PromptForInput(string inputPrompt)
        {
            Console.Write($"{inputPrompt}:");

            return Task.FromResult(Console.ReadLine()?.Trim());
        }


    }
}