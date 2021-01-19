using UnityEngine;
using UnityEngine.EventSystems;

namespace Dialogs
{
    public sealed class ClickablePanel : MonoBehaviour, IClickable, IPointerClickHandler
    {
        public event ClickHandler Click;
        
        public void OnPointerClick(PointerEventData eventData)
        {
            CallClick();
        }

        private void CallClick()
        {
            Click?.Invoke();
        }
    }
}