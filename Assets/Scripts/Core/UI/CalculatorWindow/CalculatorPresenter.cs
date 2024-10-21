using System;
using DataService;

namespace Core.UI.CalculatorWindow
{
    public class CalculatorPresenter : IDisposable
    {
        private readonly CalculatorView _view;
        private readonly CalculatorModel _model;

        public CalculatorPresenter(CalculatorView calculatorView, HistoryStorage historyStorage)
        {
            _view = calculatorView;
            _model = new CalculatorModel(historyStorage);

            _model.OnAppendExpression += _view.AddExpressionToView;

            foreach (var expressionHistory in _model.History)
                _view.AddExpressionToView(expressionHistory);
        }

        public void Dispose()
        {
            _model.OnAppendExpression -= _view.AddExpressionToView;
        }

        public void OnСalculateButtonClicked()
        {
            if (!_model.TryCalculateResult(_view.InputData))
                _view.ShowErrorDialog();
        }
    }
}