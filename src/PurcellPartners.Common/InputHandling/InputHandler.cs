using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurcellPartners.Common.InputHandling
{
    public class InputHandler : IInputHandler
    {
        public string RetrieveUserInput() => Console.ReadLine().Trim();
    }
}