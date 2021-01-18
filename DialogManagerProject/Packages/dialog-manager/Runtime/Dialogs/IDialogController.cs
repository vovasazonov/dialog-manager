namespace Dialogs
{
    public interface IDialogController
    {
        bool IsCloseByClickBack { set; }
        bool IsCloseByClickOverlay { set; }
        
        void Open();
        void Close();
    }
}