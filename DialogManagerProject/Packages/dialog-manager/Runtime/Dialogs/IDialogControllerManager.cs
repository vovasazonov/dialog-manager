namespace Dialogs
{
    internal interface IDialogControllerManager
    {
        IDialogController GetDialog(string id);
    }
}