using System;
using System.Collections.Generic;
using Dialogs;
using UnityEngine;

public sealed class GameManager : MonoBehaviour
{
    [SerializeField] private UnityDialog OkCancelDialog;
    [SerializeField] private UnityDialog OkDialog;
    private DialogManager _dialogManager;

    private void Awake()
    {
        var dialogDic = new Dictionary<string, IDialog> {{"okCancel", OkCancelDialog}, {"ok", OkDialog}};
        _dialogManager = new DialogManager(dialogDic);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            _dialogManager.CloseLastDialogByBack();
        }
        else if (Input.GetKey(KeyCode.C))
        {
            var dialog = _dialogManager.GetDialog("okCancel");
            dialog.IsCloseByClickBack = true;
            dialog.IsCloseByClickOverlay = true;
            dialog.Open();
        }
        else if (Input.GetKey(KeyCode.O))
        {
            var dialog = _dialogManager.GetDialog("ok");
            dialog.IsCloseByClickBack = true;
            dialog.IsCloseByClickOverlay = true;
            dialog.Open();
        }
    }
}