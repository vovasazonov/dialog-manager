using System;
using System.Collections.Generic;

namespace Dialogs
{
    internal interface IButtonsController
    {
        void SetButtonsCallbacks(IDictionary<string, Action> callbacks);
        void SetButtonsTexts(IDictionary<string, string> texts);
    }
}