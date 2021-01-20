using Dialogs;

namespace Samples
{
    public class DialogOpenerModel : IDialogOpenerModel
    {
        private readonly IDialogManager _dialogManager;
        private readonly string _dialogId;

        public DialogOpenerModel(IDialogManager dialogManager, string dialogId)
        {
            _dialogManager = dialogManager;
            _dialogId = dialogId;
        }
        
        public void Open()
        {
            _dialogManager.GetDialog(_dialogId).Open();
        }
    }
}