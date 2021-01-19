using System;
using System.Collections.Generic;

namespace Dialogs
{
    public interface IDialogController
    {
        void SetButtonsCallbacks(IDictionary<string, Action> callbacks);
        void SetButtonsLabels(IDictionary<string, string> labels);
        void Open();
        void Close();
    }
}