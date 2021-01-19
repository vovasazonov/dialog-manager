using System.Collections.Generic;

namespace Dialogs.Descriptions
{
    public interface IDialogDatabase
    {
        IReadOnlyDictionary<string, IDialogDescription> DialogDescriptionDic { get; }
    }
}