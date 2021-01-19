using System;
using System.Collections.Generic;

namespace Dialogs
{
    internal sealed class DialogButtonsController : IDialogButtonsController
    {
        private readonly IDictionary<string, IDialogButton> _buttons = new Dictionary<string, IDialogButton>();
        private readonly IDictionary<string, Action> _buttonCallbacks = new Dictionary<string, Action>();
        
        public DialogButtonsController(IEnumerable<IDialogButton> dialogButtons)
        {
            InstantiateButtons(dialogButtons);
        }
        
        private void InstantiateButtons(IEnumerable<IDialogButton> dialogButtons)
        {
            foreach (var dialogButton in dialogButtons)
            {
                _buttons[dialogButton.Id] = dialogButton;
            }
        }
        
        private void SetButtonCallback(string id, Action callback)
        {
            _buttonCallbacks.Add(id, callback);
            AddButtonListener(_buttons[id], callback);
        }

        public void SetButtonsCallbacks(IDictionary<string, Action> callbacks)
        {
            ResetButtonsCallbacks();
            
            foreach (var id in callbacks.Keys)
            {
                SetButtonCallback(id, callbacks[id]);
            }
        }

        private void ResetButtonsCallbacks()
        {
            foreach (var id in _buttonCallbacks.Keys)
            {
                RemoveButtonListener(_buttons[id], _buttonCallbacks[id]);
            }

            _buttonCallbacks.Clear();
        }

        private void AddButtonListener(IDialogButton dialogButton, Action callback)
        {
            dialogButton.Click += callback.Invoke;
        }
        
        private void RemoveButtonListener(IDialogButton dialogButton, Action callback)
        {
            dialogButton.Click -= callback.Invoke;
        }
        
        public void SetButtonsLabels(IDictionary<string, string> labels)
        {
            foreach (var id in _buttons.Keys)
            {
                _buttons[id].SetLabel(labels[id]);
            }
        }
    }
}