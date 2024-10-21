using TMPro;
using DataService;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.CalculatorWindow
{
    public class CalculatorView : MonoBehaviour
    {
        public string InputData => inputField.text;

        [SerializeField] private TMP_InputField inputField;
        [SerializeField] private Button calculateButton;

        [SerializeField] private ElementExpressionView elementExpression;
        [SerializeField] private Transform parentElements;
        [SerializeField] private GameObject errorDialog;

        private CalculatorPresenter _presenter;

        public void Initialize(HistoryStorage historyStorage)
        {
            _presenter = new CalculatorPresenter(this, historyStorage);
            calculateButton.onClick.AddListener(_presenter.OnСalculateButtonClicked);
        }

        public void AddExpressionToView(string expressionName)
        {
            var newElement = Instantiate(elementExpression, parentElements);
            newElement.DisplayExpressionName(expressionName);
        }

        public void ShowErrorDialog()
        {
            Instantiate(errorDialog, transform.parent);
        }

        private void OnDisable()
        {
            _presenter.Dispose();
            calculateButton.onClick.RemoveListener(_presenter.OnСalculateButtonClicked);
        }
    }
}