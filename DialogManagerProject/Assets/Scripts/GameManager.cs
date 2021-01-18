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
        
        var dialog = _dialogManager.GetDialog("okCancel");
        dialog.Show();
    }
}