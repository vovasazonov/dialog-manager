namespace Dialogs
{
    internal interface IDialogsController
    {
        IDialogController GetDialog(string id);
    }
}