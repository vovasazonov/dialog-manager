using UnityEngine;

namespace Dialogs
{
    public class UnityDialog : MonoBehaviour, IDialog
    {
        public event OpenedHandler Opened;
        public event ClosedHandler Closed;

        public bool IsAllowCloseByBack { get; set; }

        public void Open()
        {
            gameObject.SetActive(true);
            CallOpened(this);
        }

        public void Close()
        {
            gameObject.SetActive(false);
            CallClosed(this);
        }

        private void CallOpened(IDialog dialog)
        {
            Opened?.Invoke(dialog);
        }

        private void CallClosed(IDialog dialog)
        {
            Closed?.Invoke(dialog);
        }
    }
}