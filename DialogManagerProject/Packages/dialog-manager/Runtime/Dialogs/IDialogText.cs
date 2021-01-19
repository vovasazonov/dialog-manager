namespace Dialogs
{
    public interface IDialogText
    {
        string Id { get; }
        void SetLabel(string text);
    }
}