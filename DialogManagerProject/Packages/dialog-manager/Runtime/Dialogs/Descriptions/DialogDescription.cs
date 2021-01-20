﻿using UnityEngine;

namespace Dialogs.Descriptions
{
    [CreateAssetMenu(fileName = "DialogDescription", menuName = "DialogPackage/DialogDescription", order = 0)]
    public sealed class DialogDescription : ScriptableObject, IDialogDescription
    {
        [SerializeField] private string _id;
        [SerializeField] private bool _isAllowCloseByBack;
        [SerializeField] private bool _isAllowCloseByOverlay;
        [SerializeField] private bool _isAllowQueue;
        [SerializeField] private DialogPriorityType dialogPriorityType;

        public string Id => _id;
        public bool IsAllowCloseByBack => _isAllowCloseByBack;
        public bool IsAllowCloseByOverlay => _isAllowCloseByOverlay;
        public bool AllowQueue => _isAllowQueue;
        public DialogPriorityType DialogPriorityType => dialogPriorityType;
    }
}