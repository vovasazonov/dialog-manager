namespace Dialogs
{
    internal interface IButton : IClickable
    {
        string Id { get; }
        void SetText(string text);
    }
}