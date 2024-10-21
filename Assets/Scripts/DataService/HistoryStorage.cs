using UnityEngine;
using System.Collections.Generic;

namespace DataService
{
    public class HistoryStorage
    {
        private List<string> _history = new();
        private const string HistoryKey = "CalculatorHistory";

        public void SaveHistory()
        {
            PlayerPrefs.SetString(HistoryKey, string.Join("|", _history));
            PlayerPrefs.Save();
        }

        public void LoadHistory()
        {
            string savedHistory = PlayerPrefs.GetString(HistoryKey, "");
            if (!string.IsNullOrEmpty(savedHistory))
            {
                _history = new List<string>(savedHistory.Split('|'));
            }
        }

        public List<string> GetHistory()
        {
            return _history;
        }

        public void AddToHistory(string expression)
        {
            _history.Add(expression);
            SaveHistory();
        }
    }
}