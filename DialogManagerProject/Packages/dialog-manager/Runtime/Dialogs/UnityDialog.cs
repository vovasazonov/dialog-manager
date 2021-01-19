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
        [SerializeField] private List<UnityButton> _buttons;
        [SerializeField] private List<UnityDialogText> _labelTexts;
        
        private RectTransform _rectTransform;
        private bool _isAllowCloseByOverlay;
        private IButtonsController _buttonsController;
        private IDialogTextsController _dialogTextsController;

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
            _buttonsController = new ButtonsController(_buttons);
            _dialogTextsController = new DialogTextsController(_labelTexts);
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
            _buttonsController.SetButtonsCallbacks(callbacks);
        }

        public void SetButtonsTexts(IDictionary<string, string> labels)
        {
            _buttonsController.SetButtonsTexts(labels);
        }

        public void SetDialogTexts(IDictionary<string, string> labels)
        {
            _dialogTextsController.SetDialogTexts(labels);
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