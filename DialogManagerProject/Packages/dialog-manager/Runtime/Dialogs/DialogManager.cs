using System;
using System.Collections.Generic;

namespace Dialogs
{
    public class DialogManager : IDialogManager
    {
        private readonly IDictionary<string, IDialog> _customDialogs;
        private readonly IDictionary<CommonDialogType, ICommonDialog> _commonDialogs;
        private readonly Stack<IDialog> _dialogs = new Stack<IDialog>();

        public DialogManager(IDictionary<string, IDialog> customDialogs, IDictionary<CommonDialogType, ICommonDialog> commonDialogs)
        {
            _customDialogs = customDialogs;
            _commonDialogs = commonDialogs;
        }

        public void OpenDialog(string id)
        {
            var dialog = _customDialogs[id];
            dialog.Open();
            
            _dialogs.Push(dialog);
        }

        public void OpenCommonDialog(string title, string message, CommonDialogType commonDialogType, IDictionary<ButtonDialogType, Action> actions)
        {
            var dialog = _commonDialogs[commonDialogType];
            dialog.ResetToFactory();
            dialog.SetTitle(title);
            dialog.SetMessage(message);
            dialog.SetActions(actions);
            dialog.Open();
            
            _dialogs.Push(dialog);
        }

        public void CloseLastDialog()
        {
            _dialogs.Pop().Close();
        }
    }
}