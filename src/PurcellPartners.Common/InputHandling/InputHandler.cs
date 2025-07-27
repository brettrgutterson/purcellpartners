using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurcellPartners.Common.InputHandling
{
    public class InputHandler : IInputHandler
    {
        public string RetrieveUserInput() => Console.ReadLine().Trim();

        public bool IsInputValid(string input)
        {
            var inputParts = input.Split(',');

            return inputParts.All(p => int.TryParse(p.Trim(), out _));
        }
    }
}