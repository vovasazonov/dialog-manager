using System;

namespace Dialogs
{
    public interface ICommonDialog : IDialog
    {
        void SetAction(ButtonDialogType buttonType, Action action);
        void SetMessage(string message);
        void SetTitle(string title);
        void ResetToFactory();
    }
}