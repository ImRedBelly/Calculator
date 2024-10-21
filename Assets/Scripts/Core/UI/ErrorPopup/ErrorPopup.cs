using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.ErrorPopup
{
    public class ErrorPopup : MonoBehaviour
    {
        [SerializeField] private Button closeButton;
        private void OnEnable() => closeButton.onClick.AddListener(ClosePopup);
        private void OnDisable() => closeButton.onClick.RemoveListener(ClosePopup);
        private void ClosePopup() => Destroy(gameObject);
    }
}