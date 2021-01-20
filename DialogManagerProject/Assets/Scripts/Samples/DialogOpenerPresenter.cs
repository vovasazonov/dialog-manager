using System;

namespace Samples
{
    public sealed class DialogOpenerPresenter : IPresenter
    {
        private readonly IButtonView _view;
        private readonly IDialogOpenerModel _model;

        public DialogOpenerPresenter(IButtonView view, IDialogOpenerModel model)
        {
            _view = view;
            _model = model;
        }
        
        public void Activate()
        {
            _view.Click += OnClick;
        }

        public void Deactivate()
        {
            _view.Click -= OnClick;
        }
        
        private void OnClick()
        {
            _model.Open();
        }
    }
}