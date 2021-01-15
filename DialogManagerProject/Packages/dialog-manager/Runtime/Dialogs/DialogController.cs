namespace Dialogs
{
    internal class DialogController : IDialogController
    {
        public event DialogClosedHandler DialogClosed;
        
        private readonly IDialog _dialog;
        public bool IsBlock { get; }

        public DialogController(IDialog dialog, bool isBlock)
        {
            _dialog = dialog;
            IsBlock = isBlock;

            AddDialogListener();
        }
        
        public void Close()
        {
            _dialog.Close();
        }

        private void AddDialogListener()
        {
            _dialog.Closed += OnClosed;
        }

        private void RemoveDialogListener()
        {
            _dialog.Closed -= OnClosed;
        }

        private void OnClosed(IDialog dialog)
        {
            RemoveDialogListener();
            CallDialogClosed(this);
        }
        
        private void CallDialogClosed(IDialogController dialogController)
        {
            DialogClosed?.Invoke(dialogController);
        }
    }
}