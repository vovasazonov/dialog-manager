using UnityEngine;
using UnityEngine.UI;

namespace Dialogs
{
    [RequireComponent(typeof(Text))]
    public sealed class UnityDialogText : MonoBehaviour, IDialogText
    {
        [SerializeField] private string _id;
        private Text _text;
        
        private void Awake()
        {
            _text = GetComponent<Text>();
        }

        public string Id => _id;
        
        public void SetLabel(string text)
        {
            _text.text = text;
        }
    }
}