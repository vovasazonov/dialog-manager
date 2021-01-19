using System.Collections.Generic;
using Dialogs.Descriptions;

namespace Dialogs
{
    public class DialogManager : IDialogManager
    {
        private readonly IDictionary<string, IDialog> _dialogs;
        private readonly List<IDialog> _openDialogs = new List<IDialog>();
        private readonly IDialogControllerManager _dialogControllerManager;

        public DialogManager(IDictionary<string, IDialog> dialogs, IDialogDatabase dialogDatabase)
        {
            _dialogs = dialogs;
            _dialogControllerManager = new DialogControllerManager(dialogs);

            InitializeDialogs(dialogs, dialogDatabase);
            
            foreach (var dialog in _dialogs.Values)
            {
                AddDialogListener(dialog);
            }
        }

        private static void InitializeDialogs(IDictionary<string, IDialog> dialogs, IDialogDatabase dialogDatabase)
        {
            foreach (var dialogDescription in dialogDatabase.DialogDescriptionDic.Values)
            {
                var dialog = dialogs[dialogDescription.Id];
                dialog.IsAllowCloseByBack = dialogDescription.IsAllowCloseByBack;
                dialog.IsAllowCloseByOverlay = dialogDescription.IsAllowCloseByOverlay;
                dialog.DialogPriorityType = dialogDescription.DialogPriorityType;
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