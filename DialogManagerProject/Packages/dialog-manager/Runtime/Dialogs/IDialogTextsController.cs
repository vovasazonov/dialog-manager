using System.Collections.Generic;

namespace Dialogs
{
    internal interface IDialogTextsController
    {
        void SetDialogTexts(IDictionary<string, string> texts);
    }
}