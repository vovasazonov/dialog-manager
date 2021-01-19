using System;
using System.Collections.Generic;

namespace Dialogs
{
    public interface IDialogController
    {
        void SetButtonsCallbacks(IDictionary<string, Action> callbacks);
        void SetButtonsTexts(IDictionary<string, string> texts);
        void Open();
        void Close();
    }
}