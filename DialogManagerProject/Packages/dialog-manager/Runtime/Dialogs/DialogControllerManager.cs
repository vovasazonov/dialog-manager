using System.Collections.Generic;

namespace Dialogs
{
    internal class DialogControllerManager : IDialogControllerManager
    {
        private readonly IDictionary<string, IDialog> _dialogs;

        public DialogControllerManager(IDictionary<string, IDialog> dialogs)
        {
            _dialogs = dialogs;
        }
        
        public IDialogController GetDialog(string id)
        {
            var dialog = _dialogs[id];
            var dialogController = new DialogController(dialog);
            AddDialogControllerListener(dialogController);
                
            return dialogController;
        }
        
        private void AddDialogControllerListener(DialogController dialogController)
        {
            dialogController.RequestClose += OnRequestClose;
            dialogController.RequestOpen += OnRequestOpen;
        }

        private void RemoveDialogControllerListener(DialogController dialogController)
        {
            dialogController.RequestClose -= OnRequestClose;
            dialogController.RequestOpen -= OnRequestOpen;
        }
        
        private void OnRequestOpen(IDialog dialog)
        {
            dialog.Open();
        }

        private void OnRequestClose(IDialog dialog)
        {
            dialog.Close();
        }
    }
}