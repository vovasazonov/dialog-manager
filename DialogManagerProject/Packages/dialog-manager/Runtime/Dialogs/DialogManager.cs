using System.Collections.Generic;

namespace Dialogs
{
    public class DialogManager : IDialogManager
    {
        private readonly IDictionary<string, IDialog> _dialogs;
        private readonly List<IDialog> _openDialogs = new List<IDialog>();

        public DialogManager(IDictionary<string, IDialog> dialogs)
        {
            _dialogs = dialogs;
        }
        
        public IDialogController GetDialog(string id)
        {
            var dialog = _dialogs[id];
            var dialogController = new DialogController(dialog);
            AddDialogListener(dialog);
                
            return dialogController;
        }

        private void AddDialogListener(IDialog dialog)
        {
            dialog.Closed += OnDialogClosed;
            dialog.Opened += OnDialogOpened;
        }

        private void RemoveDialogListener(IDialog dialog)
        {
            dialog.Closed -= OnDialogClosed;
            dialog.Opened -= OnDialogOpened;
        }

        private void OnDialogOpened(IDialog dialog)
        {
            _openDialogs.Add(dialog);
        }

        private void OnDialogClosed(IDialog dialog)
        {
            _openDialogs.Remove(dialog);
            RemoveDialogListener(dialog);
        }

        public void CloseLastDialogByBack()
        {
            if (_openDialogs.Count > 0)
            {
                var lastDialog = _openDialogs[_openDialogs.Count - 1];
                
                if (lastDialog.IsAllowCloseByBack)
                {
                    lastDialog.Close();
                }
            }
        }
    }
}