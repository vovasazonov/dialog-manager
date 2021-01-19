namespace Dialogs
{
    internal interface IDialogControllers
    {
        IDialogController GetDialog(string id);
    }
}