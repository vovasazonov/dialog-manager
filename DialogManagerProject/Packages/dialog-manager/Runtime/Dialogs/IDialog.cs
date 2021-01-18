namespace Dialogs
{
    public delegate void ShownHandler(IDialog dialog);
    public delegate void HiddenHandler(IDialog dialog);

    public interface IDialog
    {
        event ShownHandler Shown;
        event HiddenHandler Hidden;
        
        void Show();
        void Hide();
    }
}