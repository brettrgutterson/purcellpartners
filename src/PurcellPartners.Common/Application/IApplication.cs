using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurcellPartners.Common.Application
{
    public interface IApplication
    {
        void Execute();

        Task<string?> PromptForInput(string inputPrompt);

        Task<bool> ValidateInput(string input);
    }
}