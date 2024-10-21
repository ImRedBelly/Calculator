using TMPro;
using UnityEngine;

namespace Core.UI.CalculatorWindow
{
    public class ElementExpressionView : MonoBehaviour
    {
        [SerializeField] TMP_Text textExpression;
        public void DisplayExpressionName(string count)
        {
            textExpression.text = count;
        }
    }
}