namespace Dialogs
{
    internal class DialogController : IDialogController
    {
        private readonly IDialog _dialog;

        public DialogController(IDialog dialog)
        {
            _dialog = dialog;
        }

        public bool IsCloseByClickBack
        {
            set => _dialog.IsAllowCloseByBack = value;
        }

        public bool IsCloseByClickOverlay
        {
            set => _dialog.IsAllowCloseByOverlay = value;
        }

        public void Open()
        {
            _dialog.Open();
        }

        public void Close()
        {
            _dialog.Close();
        }
    }
}