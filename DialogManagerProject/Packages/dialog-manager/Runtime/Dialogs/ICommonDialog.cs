using System;
using System.Collections.Generic;

namespace Dialogs
{
    public interface ICommonDialog : IDialog
    {
        void SetActions(IDictionary<ButtonDialogType, Action> actions);
        void SetMessage(string message);
        void SetTitle(string title);
        void ResetToFactory();
    }
}