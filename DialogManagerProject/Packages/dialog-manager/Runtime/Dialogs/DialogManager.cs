using System;
using System.Collections.Generic;

namespace Dialogs
{
    public class DialogManager : IDialogManager
    {
        private readonly IDictionary<string, IDialog> _customDialogs;
        private readonly IDictionary<CommonDialogType, ICommonDialog> _commonDialogs;
        private readonly List<IDialogController> _activeDialogs = new List<IDialogController>();

        public DialogManager(IDictionary<string, IDialog> customDialogs, IDictionary<CommonDialogType, ICommonDialog> commonDialogs)
        {
            _customDialogs = customDialogs;
            _commonDialogs = commonDialogs;
        }

        public void OpenDialog(string id)
        {
            var dialog = _customDialogs[id];
            dialog.Open();

            InstantiateActiveDialog(dialog, false);
        }

        public ICloserBlockDialog OpenBlockDialog(string id)
        {
            var dialog = _customDialogs[id];
            var closerDialog = new CloserBlockDialog(dialog);
            OpenDialog(id);

            return closerDialog;
        }

        public void OpenCommonDialog(string title, string message, CommonDialogType commonDialogType, IDictionary<ButtonDialogType, Action> actions)
        {
            var dialog = _commonDialogs[commonDialogType];
            dialog.ResetToFactory();
            dialog.SetTitle(title);
            dialog.SetMessage(message);
            dialog.SetActions(actions);
            dialog.Open();
            
            InstantiateActiveDialog(dialog, false);
        }

        public void CloseLastDialog()
        {
            if (_activeDialogs.Count > 0)
            {
                var lastDialog = _activeDialogs[_activeDialogs.Count - 1];
                
                if (!lastDialog.IsBlock)
                {
                    lastDialog.Close();
                }
            }
        }
        
        private void InstantiateActiveDialog(IDialog dialog, bool isBlock)
        {
            var dialogController = new DialogController(dialog, isBlock);
            _activeDialogs.Add(dialogController);
            AddDialogControllerListener(dialogController);
        }

        private void AddDialogControllerListener(IDialogController dialogController)
        {
            dialogController.DialogClosed += OnDialogClosed;
        }

        private void RemoveDialogControllerListener(IDialogController dialogController)
        {
            dialogController.DialogClosed -= OnDialogClosed;
        }

        private void OnDialogClosed(IDialogController dialogController)
        {
            RemoveDialogControllerListener(dialogController);
            _activeDialogs.Remove(dialogController);
        }
    }
}