using UnityEngine;

namespace Dialogs
{
    public class UnityDialog : MonoBehaviour, IDialog
    {
        public event ShownHandler Shown;
        public event HiddenHandler Hidden;
        
        public void Show()
        {
            gameObject.SetActive(true);
            CallShown(this);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            CallHidden(this);
        }

        private void CallShown(IDialog dialog)
        {
            Shown?.Invoke(dialog);
        }

        private void CallHidden(IDialog dialog)
        {
            Hidden?.Invoke(dialog);
        }
    }
}