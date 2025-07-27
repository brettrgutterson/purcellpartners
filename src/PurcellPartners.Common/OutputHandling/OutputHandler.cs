using PurcellPartners.Common.ConfigurationSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurcellPartners.Common.OutputHandling
{
    public class OutputHandler : IOutputHandler
    {
        private readonly ConfigurationSettingManager _ConfigurationSettingManager;

        public OutputHandler(ConfigurationSettingManager configurationSettingManager)
        {
            _ConfigurationSettingManager = configurationSettingManager;
        }

        public void WriteListPromptMessage()
        {
            var promptMessage = _ConfigurationSettingManager.GetValueByKey("InputPrompt") ?? "Please enter the input list";

            Console.Write($"{promptMessage}:");
        }

        public void WriteProcessingMessage()
        {
            var processingMessage = _ConfigurationSettingManager.GetValueByKey("ProcessingStarted") ?? "Please wait while we process your request";

            Console.WriteLine(processingMessage);
        }

        public void WriteMissingNumbersList(string missingNumbersCSVList)
        {
            var missingNumbersListMessage = $"The following missing numbers were detected: {missingNumbersCSVList}";

            Console.WriteLine(missingNumbersListMessage);
        }
    }
}