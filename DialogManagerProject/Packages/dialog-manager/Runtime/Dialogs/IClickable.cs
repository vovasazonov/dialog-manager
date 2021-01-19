namespace Dialogs
{
    public delegate void ClickHandler();

    internal interface IClickable
    {
        event ClickHandler Click;
    }
}