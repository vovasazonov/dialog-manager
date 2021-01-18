using System.Collections.Generic;

namespace Dialogs
{
    public class DialogManager : IDialogManager
    {
        private readonly IDictionary<string, IDialog> _dialogs;

        public DialogManager(IDictionary<string, IDialog> dialogs)
        {
            _dialogs = dialogs;
        }
        
        public IDialogController GetDialog(string id)
        {
            var dialog = _dialogs[id];
            var dialogController = new DialogController(dialog);
            
            return dialogController;
        }
    }
}