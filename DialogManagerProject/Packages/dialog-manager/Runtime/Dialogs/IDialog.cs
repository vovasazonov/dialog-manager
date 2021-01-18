namespace Dialogs
{
    public delegate void OpenedHandler(IDialog dialog);
    public delegate void ClosedHandler(IDialog dialog);

    public interface IDialog
    {
        event OpenedHandler Opened;
        event ClosedHandler Closed;

        bool IsAllowCloseByBack { get; set; }
        
        void Open();
        void Close();
    }
}