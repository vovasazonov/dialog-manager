namespace Dialogs
{
    internal class DialogController : IDialogController
    {
        private readonly IDialog _dialog;

        public DialogController(IDialog dialog)
        {
            _dialog = dialog;
        }
        
        public void Show()
        {
            _dialog.Show();
        }

        public void Hide()
        {
            _dialog.Hide();
        }
    }
}