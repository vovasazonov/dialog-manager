namespace Dialogs
{
    internal class CloserBlockDialog : ICloserBlockDialog
    {
        private readonly IDialog _dialog;

        public CloserBlockDialog(IDialog dialog)
        {
            _dialog = dialog;
        }
        
        public void Close()
        {
            _dialog.Close();
        }
    }
}