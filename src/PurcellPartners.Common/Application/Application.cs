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
            string input;
            bool isValid;

            do
            {
                _OutputHandler.WriteListPromptMessage();
                input = _InputHandler.RetrieveUserInput();

                if (string.IsNullOrWhiteSpace(input))
                {
                    _OutputHandler.WriteInvalidMessage();
                    isValid = false;
                    continue;
                }

                isValid = _InputHandler.IsInputValid(input);

                if (!isValid)
                {
                    _OutputHandler.WriteInvalidListMessage();
                }
            }
            while (!isValid);

            _OutputHandler.WriteProcessingMessage();

            var inputList = _ListProcessor.RetrieveInputList(input);
            var missingNumbers = _ListProcessor.DetectMissingNumbers(inputList);
            var missingNumbersCSVList = _ListProcessor.GetMissingNumberCSVList(missingNumbers);

            _OutputHandler.WriteMissingNumbersList(missingNumbersCSVList);

            Console.ReadLine();
        }
    }
}