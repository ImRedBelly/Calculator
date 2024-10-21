using System;
using DataService;
using CalculatorService;
using System.Collections.Generic;

namespace Core.UI.CalculatorWindow
{
    public class CalculatorModel
    {
        public event Action<string> OnAppendExpression;
        public IReadOnlyCollection<string> History => _historyStorage.GetHistory();

        private readonly HistoryStorage _historyStorage;

        public CalculatorModel(HistoryStorage historyStorage)
        {
            _historyStorage = historyStorage;
        }

        public bool TryCalculateResult(string expression)
        {
            var isCalculateResult = ExpressionCalculator.TryCalculateResult(ref expression);
            _historyStorage.AddToHistory(expression);
            OnAppendExpression?.Invoke(expression);
            return isCalculateResult;
        }
    }
}