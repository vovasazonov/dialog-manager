namespace Dialogs.Descriptions
{
    public interface IDialogDescription
    {
        string Id { get; }
        bool IsAllowCloseByBack { get; }
        bool IsAllowCloseByOverlay { get; }
    }
}