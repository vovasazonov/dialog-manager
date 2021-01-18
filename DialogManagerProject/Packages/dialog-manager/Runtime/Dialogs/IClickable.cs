namespace Dialogs
{
    public delegate void ClickHandler();

    public interface IClickable
    {
        event ClickHandler Click;
    }
}