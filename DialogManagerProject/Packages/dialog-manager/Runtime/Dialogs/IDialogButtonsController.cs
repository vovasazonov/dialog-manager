using System;
using System.Collections.Generic;

namespace Dialogs
{
    internal interface IDialogButtonsController
    {
        void SetButtonsCallbacks(IDictionary<string, Action> callbacks);
        void SetButtonsLabels(IDictionary<string, string> labels);
    }
}