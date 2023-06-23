using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.SceneLoading
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        [SerializeField] private Image _progressBar;
        [SerializeField] private TMP_Text _progressBarText;

        public void SetProgressBarFillAmount(float amount)
        {
            _progressBar.fillAmount = amount;
            _progressBarText.text = $"{amount * 100:0}%";
        }

        public void SetActive(bool active)
        {
            _panel.SetActive(active);
        }
    }
}