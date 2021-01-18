// using System;
// using System.Collections.Generic;
// using NUnit.Framework;
// using Dialogs;
// using NSubstitute;
//
// namespace Tests.Runtime
// {
//     [TestFixture]
//     public class DialogManagerTest
//     {
//         [Test]
//         public void CloseLastDialog_ThereIsNoDialogs_DoesNotThrowException()
//         {
//             var customDialogDic = new Dictionary<string, IDialog>();
//             var commonDialogDic = new Dictionary<CommonDialogType, ICommonDialog>();
//             var dialogManager = new DialogManager(customDialogDic, commonDialogDic);
//
//             Assert.DoesNotThrow(() => dialogManager.CloseLastDialog());
//         }
//
//         [Test]
//         public void OpenDialog_ThereIsNoSuchDialog_ThrowException()
//         {
//             var customDialogDic = new Dictionary<string, IDialog>();
//             var commonDialogDic = new Dictionary<CommonDialogType, ICommonDialog>();
//             var dialogManager = new DialogManager(customDialogDic, commonDialogDic);
//
//             Assert.Throws<KeyNotFoundException>(() => dialogManager.OpenDialog(""));
//         }
//
//         [Test]
//         public void OpenDialog_ThereIsSuchDialog_DoesNotThrowException()
//         {
//             var customDialogDic = new Dictionary<string, IDialog> {{"", Substitute.For<IDialog>()}};
//             var commonDialogDic = new Dictionary<CommonDialogType, ICommonDialog>();
//             var dialogManager = new DialogManager(customDialogDic, commonDialogDic);
//
//             Assert.DoesNotThrow(() => dialogManager.OpenDialog(""));
//         }
//
//         [Test]
//         public void OpenCommonDialog_ThereIsNoSuchDialog_ThrowException()
//         {
//             var customDialogDic = new Dictionary<string, IDialog>();
//             var commonDialogDic = new Dictionary<CommonDialogType, ICommonDialog>();
//             var buttonActions = new Dictionary<ButtonDialogType, Action>();
//             var dialogManager = new DialogManager(customDialogDic, commonDialogDic);
//
//             Assert.Throws<KeyNotFoundException>(() => dialogManager.OpenCommonDialog("", "", CommonDialogType.OkCancel, buttonActions));
//         }
//         
//         [Test]
//         public void OpenCommonDialog_ThereIsSuchDialog_DoesNotThrowException()
//         {
//             var customDialogDic = new Dictionary<string, IDialog>();
//             var commonDialogDic = new Dictionary<CommonDialogType, ICommonDialog> {{CommonDialogType.OkCancel, Substitute.For<ICommonDialog>()}};
//             var buttonActions = new Dictionary<ButtonDialogType, Action>();
//             var dialogManager = new DialogManager(customDialogDic, commonDialogDic);
//
//             Assert.DoesNotThrow(() => dialogManager.OpenCommonDialog("", "", CommonDialogType.OkCancel, buttonActions));
//         }
//     }
// }