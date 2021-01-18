namespace Dialogs
{
    public interface IDialogController
    {
        bool IsAllowCloseByBack { set; }
        
        void Open();
        void Close();
    }
}