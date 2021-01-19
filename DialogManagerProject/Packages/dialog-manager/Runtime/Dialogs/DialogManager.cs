using System.Collections.Generic;

namespace Dialogs
{
    public class DialogManager : IDialogManager
    {
        private readonly IDictionary<string, IDialog> _dialogs;
        private readonly List<IDialog> _openDialogs = new List<IDialog>();
        private readonly IDialogControllerManager _dialogControllerManager;

        public DialogManager(IDictionary<string, IDialog> dialogs)
        {
            _dialogs = dialogs;
            _dialogControllerManager = new DialogControllerManager(dialogs);
            
            foreach (var dialog in _dialogs.Values)
            {
                AddDialogListener(dialog);
            }
        }

        private void AddDialogListener(IDialog dialog)
        {
            dialog.Opened += OnOpened;
            dialog.Closed += OnClosed;
        }
        
        private void RemoveDialogListener(IDialog dialog)
        {
            dialog.Opened -= OnOpened;
            dialog.Closed -= OnClosed;
        }

        private void OnClosed(IDialog dialog)
        {
            _openDialogs.Remove(dialog);
        }

        private void OnOpened(IDialog dialog)
        {
            _openDialogs.Add(dialog);
        }

        public IDialogController GetDialog(string id)
        {
            return _dialogControllerManager.GetDialog(id);
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