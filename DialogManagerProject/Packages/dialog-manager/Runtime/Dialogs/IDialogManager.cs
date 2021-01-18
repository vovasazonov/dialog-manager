namespace Dialogs
{
    public interface IDialogManager
    {
        IDialogController GetDialog(string id);
    }
}