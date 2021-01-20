using System.Collections.Generic;
using Dialogs;
using Dialogs.Descriptions;
using UnityEngine;

namespace Samples
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private DialogDatabase _dialogDatabase;
        [SerializeField] private List<UnityDialog> _dialogs;
        [SerializeField] private List<ButtonView> _dialogOpenerButtons;

        private DialogManager _dialogManager;

        private void Awake()
        {
            _dialogManager = new DialogManager(_dialogs, _dialogDatabase);

            var models = new List<IDialogOpenerModel>
            {
                new DialogOpenerModel(_dialogManager, "OkCancel"),
                new DialogOpenerModel(_dialogManager, "Ok")
            };

            for (int i = 0; i < models.Count; i++)
            {
                var dialogOpenerPresenter = new DialogOpenerPresenter(_dialogOpenerButtons[i], models[i]);
                dialogOpenerPresenter.Activate();
            }
        }
    }
}