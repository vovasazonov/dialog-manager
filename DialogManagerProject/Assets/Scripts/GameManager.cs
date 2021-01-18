using System;
using System.Collections.Generic;
using Dialogs;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    [SerializeField] private UnityDialog OkCancelDialog;
    private DialogManager _dialogManager;

    private void Awake()
    {
        var dialogDic = new Dictionary<string, IDialog> {{"okCancel", OkCancelDialog}};
        _dialogManager = new DialogManager(dialogDic);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            _dialogManager.CloseLastDialogByBack();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            var dialog = _dialogManager.GetDialog("okCancel");
            dialog.IsCloseByClickBack = true;
            dialog.IsCloseByClickOverlay = true;
            dialog.Open();
        }
    }
}