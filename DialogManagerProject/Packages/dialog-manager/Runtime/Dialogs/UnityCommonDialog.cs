using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dialogs
{
    [RequireComponent(typeof(UnityDialog))]
    public sealed class UnityCommonDialog : MonoBehaviour, ICommonDialog
    {
        [SerializeField] private List<DialogButton> _buttons;
        [SerializeField] private Text _titleText;
        [SerializeField] private Text _messageText;
        private UnityDialog _unityDialog;
        private readonly IDictionary<ButtonDialogType, IButton> _dialogButtons = new Dictionary<ButtonDialogType, IButton>();
        private readonly IDictionary<ButtonDialogType, Action> _dialogButtonActions = new Dictionary<ButtonDialogType, Action>();

        private void Awake()
        {
            _unityDialog = GetComponent<UnityDialog>();

            InstantiateButtons();
        }

        private void InstantiateButtons()
        {
            foreach (var dialogButton in _buttons)
            {
                _dialogButtons[dialogButton.ButtonDialogType] = new UnityButton(dialogButton.Button);
            }
        }
        
        public void Open()
        {
            _unityDialog.Open();
        }

        public void Close()
        {
            _unityDialog.Close();
        }

        private void SetAction(ButtonDialogType buttonType, Action action)
        {
            _dialogButtonActions.Add(buttonType, action);
            AddButtonListener(_dialogButtons[buttonType], action);
        }

        public void SetActions(IDictionary<ButtonDialogType, Action> actions)
        {
            ResetActions();
            
            foreach (var buttonDialogType in actions.Keys)
            {
                SetAction(buttonDialogType, actions[buttonDialogType]);
            }
        }

        public void SetMessage(string message)
        {
            _messageText.text = message;
        }

        public void SetTitle(string title)
        {
            _titleText.text = title;
        }

        public void ResetToFactory()
        {
            _titleText.text = "";
            _messageText.text = "";
            ResetActions();
        }

        private void ResetActions()
        {
            foreach (var buttonDialogType in _dialogButtonActions.Keys)
            {
                RemoveButtonListener(_dialogButtons[buttonDialogType], _dialogButtonActions[buttonDialogType]);
            }

            _dialogButtonActions.Clear();
        }

        private void AddButtonListener(IButton button, Action action)
        {
            button.Click += action.Invoke;
        }

        private void RemoveButtonListener(IButton button, Action action)
        {
            button.Click -= action.Invoke;
        }

        [Serializable]
        private struct DialogButton
        {
            public ButtonDialogType ButtonDialogType;
            public Button Button;
        }
    }
}