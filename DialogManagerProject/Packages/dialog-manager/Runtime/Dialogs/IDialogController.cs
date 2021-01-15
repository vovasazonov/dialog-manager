namespace Dialogs
{
    internal delegate void DialogClosedHandler(IDialogController dialogController);

    internal interface IDialogController
    {
        event DialogClosedHandler DialogClosed;
        
        bool IsBlock { get; }
        void Close();
    }
}