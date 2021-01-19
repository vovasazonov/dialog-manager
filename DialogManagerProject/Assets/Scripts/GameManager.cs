using System.Collections.Generic;
using Dialogs;
using Dialogs.Descriptions;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    [SerializeField] private DialogDatabase _dialogDatabase;
    [SerializeField] private List<UnityDialog> _dialogs;
    private DialogManager _dialogManager;

    private void Awake()
    {
        _dialogManager = new DialogManager(_dialogs, _dialogDatabase);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _dialogManager.CloseLastDialogByBack();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            var dialog = _dialogManager.GetDialog("OkCancel");
            dialog.Open();
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            var dialog = _dialogManager.GetDialog("Ok");
            dialog.Open();
        }
    }
}