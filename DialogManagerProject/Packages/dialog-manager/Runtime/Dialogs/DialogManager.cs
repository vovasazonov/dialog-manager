using System.Collections.Generic;
using System.Linq;
using Dialogs.Descriptions;

namespace Dialogs
{
    public class DialogManager : IDialogManager
    {
        private readonly IDictionary<string, IDialog> _dialogs;
        private readonly List<IDialog> _openDialogs = new List<IDialog>();
        private readonly IDialogsController _dialogsController;

        public DialogManager(IEnumerable<IDialog> dialogs, IDialogDatabase dialogDatabase)
        {
            _dialogs = dialogs.ToDictionary(k => k.Id, v => v);
            _dialogsController = new DialogsController(_dialogs);

            InitializeDialogs(_dialogs, dialogDatabase);
            AddDialogListeners();
        }

        private static void InitializeDialogs(IDictionary<string, IDialog> dialogs, IDialogDatabase dialogDatabase)
        {
            foreach (var dialogDescription in dialogDatabase.DialogDescriptionDic.Values)
            {
                var dialog = dialogs[dialogDescription.Id];
                dialog.IsAllowCloseByBack = dialogDescription.IsAllowCloseByBack;
                dialog.IsAllowCloseByOverlay = dialogDescription.IsAllowCloseByOverlay;
                dialog.AllowQueue = dialogDescription.AllowQueue;
                dialog.DialogPriorityType = dialogDescription.DialogPriorityType;
            }
        }
        
        private void AddDialogListeners()
        {
            foreach (var dialog in _dialogs.Values)
            {
                AddDialogListener(dialog);
            }
        }
        
        private void RemoveDialogListeners()
        {
            foreach (var dialog in _dialogs.Values)
            {
                RemoveDialogListener(dialog);
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
            return _dialogsController.GetDialog(id);
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