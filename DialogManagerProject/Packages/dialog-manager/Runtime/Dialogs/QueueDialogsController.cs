using System;
using System.Collections.Generic;

namespace Dialogs
{
    internal sealed class QueueDialogsController : IQueueDialogsController
    {
        private readonly IReadOnlyDictionary<DialogPriorityType, Queue<IDialog>> _dialogQueues;

        public QueueDialogsController()
        {
            _dialogQueues = new Dictionary<DialogPriorityType, Queue<IDialog>>
            {
                {DialogPriorityType.First, new Queue<IDialog>()},
                {DialogPriorityType.Last, new Queue<IDialog>()},
                {DialogPriorityType.Middle, new Queue<IDialog>()}
            };
        }

        private bool IsQueue(DialogPriorityType dialogPriorityType)
        {
            bool isQueue;

            switch (dialogPriorityType)
            {
                case DialogPriorityType.First:
                    isQueue = _dialogQueues[DialogPriorityType.First].Count > 0;
                    break;
                case DialogPriorityType.Middle:
                    isQueue = _dialogQueues[DialogPriorityType.First].Count > 0 || _dialogQueues[DialogPriorityType.Middle].Count > 0;
                    break;
                case DialogPriorityType.Last:
                    isQueue = _dialogQueues[DialogPriorityType.First].Count > 0 || _dialogQueues[DialogPriorityType.Middle].Count > 0 || _dialogQueues[DialogPriorityType.Last].Count > 0;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(dialogPriorityType), dialogPriorityType, null);
            }

            return isQueue;
        }

        public void Open(IDialog dialog)
        {
            if (!IsQueue(dialog.DialogPriorityType))
            {
                dialog.Open();
            }

            _dialogQueues[dialog.DialogPriorityType].Enqueue(dialog);
            AddDialogListener(dialog);
        }

        private void AddDialogListener(IDialog dialog)
        {
            dialog.Closed += OnClosed;
        }

        private void RemoveDialogListener(IDialog dialog)
        {
            dialog.Closed -= OnClosed;
        }

        private void OnClosed(IDialog dialog)
        {
            RemoveFromQueue(dialog);
            RemoveDialogListener(dialog);
            CloseNext(dialog.DialogPriorityType);
        }

        private void CloseNext(DialogPriorityType dialogPriorityType)
        {
            if (_dialogQueues[dialogPriorityType].Count > 0)
            {
                _dialogQueues[dialogPriorityType].Peek().Close();
            }
        }

        private void RemoveFromQueue(IDialog dialog)
        {
            _dialogQueues[dialog.DialogPriorityType].Dequeue();
        }
    }
}