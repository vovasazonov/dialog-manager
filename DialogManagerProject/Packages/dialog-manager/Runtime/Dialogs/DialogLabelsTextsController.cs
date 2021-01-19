using System.Collections.Generic;

namespace Dialogs
{
    public class DialogLabelsTextsController : IDialogLabelsTextsController
    {
        private readonly IDictionary<string, IDialogText> _texts = new Dictionary<string, IDialogText>();

        public DialogLabelsTextsController(IEnumerable<IDialogText> dialogTexts)
        {
            InstantiateLabelTexts(dialogTexts);
        }
        
        private void InstantiateLabelTexts(IEnumerable<IDialogText> dialogTexts)
        {
            foreach (var dialogText in dialogTexts)
            {
                _texts[dialogText.Id] = dialogText;
            }
        }

        public void SetLabelsTexts(IDictionary<string, string> labels)
        {
            foreach (var id in labels.Keys)
            {
                _texts[id].SetLabel(labels[id]);
            }
        }
    }
}