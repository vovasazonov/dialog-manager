using System.Collections.Generic;

namespace Dialogs
{
    internal class DialogsController : IDialogsController
    {
        private readonly IDictionary<string, IDialog> _dialogs;
        private readonly IQueueDialogsController _queueDialogsController;

        public DialogsController(IDictionary<string, IDialog> dialogs)
        {
            _dialogs = dialogs;
            _queueDialogsController = new QueueDialogsController();
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
            if (dialog.AllowQueue)
            {
                _queueDialogsController.Open(dialog);
            }
            else
            {
                dialog.Open();
            }
        }

        private void OnRequestClose(IDialog dialog)
        {
            dialog.Close();
        }
    }
}