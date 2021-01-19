﻿namespace Dialogs
{
    internal delegate void RequestOpenHandler(IDialog dialog);
    internal delegate void RequestCloseHandler(IDialog dialog);

    internal class DialogController : IDialogController
    {
        internal event RequestOpenHandler RequestOpen;
        internal event RequestCloseHandler RequestClose;

        private readonly IDialog _dialog;

        public DialogController(IDialog dialog)
        {
            _dialog = dialog;
        }

        public void Open()
        {
            CallRequestOpen(_dialog);
        }

        public void Close()
        {
            CallRequestClose(_dialog);
        }

        private void CallRequestOpen(IDialog dialog)
        {
            RequestOpen?.Invoke(dialog);
        }

        private void CallRequestClose(IDialog dialog)
        {
            RequestClose?.Invoke(dialog);
        }
    }
}