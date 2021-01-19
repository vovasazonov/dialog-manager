using System;
using System.Collections.Generic;

namespace Dialogs
{
    public delegate void OpenedHandler(IDialog dialog);
    public delegate void ClosedHandler(IDialog dialog);

    public interface IDialog
    {
        event OpenedHandler Opened;
        event ClosedHandler Closed;

        string Id { get; }
        bool IsAllowCloseByBack { get; set; }
        bool IsAllowCloseByOverlay { get; set; }
        void SetButtonsCallbacks(IDictionary<string, Action> callbacks);
        void SetButtonsLabels(IDictionary<string, string> labels);
        void SetLabelsTexts(IDictionary<string, string> labels);
        void Open();
        void Close();
    }
}