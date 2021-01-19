using System.Collections.Generic;

namespace Dialogs
{
    public class DialogTextsController : IDialogTextsController
    {
        private readonly IDictionary<string, IDialogText> _texts = new Dictionary<string, IDialogText>();

        public DialogTextsController(IEnumerable<IDialogText> dialogTexts)
        {
            InitializeTexts(dialogTexts);
        }
        
        private void InitializeTexts(IEnumerable<IDialogText> dialogTexts)
        {
            foreach (var dialogText in dialogTexts)
            {
                _texts[dialogText.Id] = dialogText;
            }
        }

        public void SetDialogTexts(IDictionary<string, string> texts)
        {
            foreach (var id in texts.Keys)
            {
                _texts[id].SetText(texts[id]);
            }
        }
    }
}