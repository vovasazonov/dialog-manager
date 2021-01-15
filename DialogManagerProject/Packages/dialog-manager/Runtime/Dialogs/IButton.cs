namespace Dialogs
{
    internal delegate void ClickHandler();

    internal interface IButton
    {
        event ClickHandler Click;
    }
}