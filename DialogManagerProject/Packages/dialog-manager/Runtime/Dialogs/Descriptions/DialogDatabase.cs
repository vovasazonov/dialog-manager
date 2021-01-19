using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dialogs.Descriptions
{
    [CreateAssetMenu(fileName = "DialogDatabase", menuName = "DialogPackage/DialogDatabase", order = 0)]
    public class DialogDatabase : ScriptableObject, IDialogDatabase
    {
        [SerializeField] private List<DialogDescription> _dialogDescriptionList;
        private Dictionary<string, IDialogDescription> _dialogDescriptionDic;
        
        public IReadOnlyDictionary<string, IDialogDescription> DialogDescriptionDic
        {
            get
            {
                if (_dialogDescriptionDic == null)
                {
                    _dialogDescriptionDic = _dialogDescriptionList.ToDictionary(k => k.Id, v => (IDialogDescription) v);
                }

                return _dialogDescriptionDic;
            }
        }
    }
}