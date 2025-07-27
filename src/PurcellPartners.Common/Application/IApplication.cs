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

        Task<bool> ValidateInput(string input);

        Task<List<int>> RetrieveInputList(string input);
    }
}