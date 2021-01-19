using System;
using System.Collections.Generic;
using UnityEngine;

namespace Dialogs
{
    [RequireComponent(typeof(RectTransform))]
    public sealed class UnityDialog : MonoBehaviour, IDialog
    {
        public event OpenedHandler Opened;
        public event ClosedHandler Closed;

        [SerializeField] private string _id;
        [SerializeField] private ClickablePanel _overlay;
        [SerializeField] private List<UnityDialogButton> _buttons;
        
        private RectTransform _rectTransform;
        private bool _isAllowCloseByOverlay;
        private IDialogButtonsController _dialogButtonsController;

        public string Id => _id;
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

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _dialogButtonsController = new DialogButtonsController(_buttons);
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

        public void SetButtonsCallbacks(IDictionary<string, Action> callbacks)
        {
            _dialogButtonsController.SetButtonsCallbacks(callbacks);
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