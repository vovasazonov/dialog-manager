using UnityEngine;

namespace Dialogs
{
    [RequireComponent(typeof(RectTransform))]
    public sealed class UnityDialog : MonoBehaviour, IDialog
    {
        public event OpenedHandler Opened;
        public event ClosedHandler Closed;
        
        [SerializeField] private ClickablePanel _overlay;

        private RectTransform _rectTransform;
        private bool _isAllowCloseByOverlay;
        
        public bool IsAllowCloseByBack { get; set; }

        public bool IsAllowCloseByOverlay
        {
            get => _isAllowCloseByOverlay;
            set
            {
                if (_isAllowCloseByOverlay != value)
                {
                    _isAllowCloseByOverlay = value;

                    if (_isAllowCloseByOverlay)
                    {
                        AddOverlayListener();
                    }
                    else
                    {
                        RemoveOverlayListener();
                    }
                }
            }
        }

        public DialogPriorityType DialogPriorityType { get; set; }

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        private void AddOverlayListener()
        {
            _overlay.Click += OnOverlayClick;
        }

        private void RemoveOverlayListener()
        {
            _overlay.Click -= OnOverlayClick;
        }

        private void OnOverlayClick()
        {
            Close();
        }

        public void Open()
        {
            gameObject.SetActive(true);
            _rectTransform.SetAsLastSibling();
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