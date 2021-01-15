using System.Collections.Generic;
using NUnit.Framework;
using Dialogs;
using NSubstitute;

namespace Tests.Runtime
{
    [TestFixture]
    public class DialogManagerTest
    {
        [Test]
        public void CloseLastDialog_ThereIsNoDialogs_DoesNotThrow()
        {
            var customDialogDic = Substitute.For<IDictionary<string, IDialog>>();
            var commonDialogDic = Substitute.For<IDictionary<CommonDialogType, ICommonDialog>>();
            var dialogManager = new DialogManager(customDialogDic, commonDialogDic);
            
            Assert.DoesNotThrow(()=>dialogManager.CloseLastDialog());
        }
    }
}