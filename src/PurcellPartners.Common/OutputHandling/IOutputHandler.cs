using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurcellPartners.Common.OutputHandling
{
    public interface IOutputHandler
    {
        void WriteListPromptMessage();

        void WriteInvalidInputMessage();

        void WriteProcessingMessage();

        void WriteMissingNumbersList(string missingNumbersCSVList);
    }
}