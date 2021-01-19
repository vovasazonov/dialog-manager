namespace Dialogs
{
    public interface IDialogButton : IClickable
    {
        string Id { get; }
        void SetLabel(string text);
    }
}