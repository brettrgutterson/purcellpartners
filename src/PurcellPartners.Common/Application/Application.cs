using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using PurcellPartners.Common.ConfigurationSetting;
using PurcellPartners.Common.InputHandling;
using PurcellPartners.Common.ListProcessing;
using PurcellPartners.Common.OutputHandling;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PurcellPartners.Common.Application
{
    public class Application : IApplication
    {
        private readonly IOutputHandler _OutputHandler;
        private readonly IListProcessor _ListProcessor;
        private readonly IInputHandler _InputHandler;

        public Application(IOutputHandler outputHandler, IListProcessor listProcessor, IInputHandler inputHandler)
        {
            _OutputHandler = outputHandler;
            _ListProcessor = listProcessor;
            _InputHandler = inputHandler;
        }

        public async void Execute()
        {
            _OutputHandler.WriteListPromptMessage();

            var input = _InputHandler.RetrieveUserInput();

            _OutputHandler.WriteProcessingMessage();

            var inputList = _ListProcessor.RetrieveInputList(input);

            var missingNumbers = _ListProcessor.DetectMissingNumbers(inputList);

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
    }
}