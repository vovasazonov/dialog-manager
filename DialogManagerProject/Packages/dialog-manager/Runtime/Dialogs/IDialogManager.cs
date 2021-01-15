using System;
using System.Collections.Generic;

namespace Dialogs
{
    public interface IDialogManager
    {
        void OpenDialog(string id);
        void OpenCommonDialog(string title, string message, CommonDialogType commonDialogType, IDictionary<ButtonDialogType, Action> actions);
        void CloseLastDialog();
    }
}