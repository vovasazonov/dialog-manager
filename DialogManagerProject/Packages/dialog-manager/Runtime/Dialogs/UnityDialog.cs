using UnityEngine;

namespace Dialogs
{
    public class UnityDialog : MonoBehaviour, IDialog
    {
        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}