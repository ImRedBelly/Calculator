using DataService;
using UnityEngine;
using Core.UI.CalculatorWindow;

namespace Core.Controllers
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private GameObject calculateWindow;
        [SerializeField] private Transform parentWindow;

        private void Start()
        {
            HistoryStorage historyStorage = new HistoryStorage();
            historyStorage.LoadHistory();

            var newCalculateWindow = Instantiate(calculateWindow, parentWindow);
            newCalculateWindow.GetComponent<CalculatorView>().Initialize(historyStorage);
        }
    }
}