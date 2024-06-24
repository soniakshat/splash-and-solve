using DG.Tweening;
using UnityEngine;
using TMPro;

namespace SplashAndSolve
{
    public class SettingsView : MonoBehaviour
    {
        [SerializeField] private TMP_Text txtMuteButton;
        [SerializeField] private TMP_Text txtVibrateButton;
        private RectTransform rect;

        private void Awake()
        {
            rect = gameObject.GetComponent<RectTransform>();
            bool mute = PreferenceManager.GetInstance().GetMute();
            txtMuteButton.text = mute ? "Mute" : "UnMute";
            bool vibrate = PreferenceManager.GetInstance().GetVibrate();
            txtVibrateButton.text = vibrate ? "Vibrate" : "No Vibrate";
        }
        public void OnCloseButtonClick()
        {
            rect.DOAnchorPosY(-1440, 1f).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        }

        public void OnMuteToggleClick()
        {
            bool state = PreferenceManager.GetInstance().GetMute();
            state = !state;
            PreferenceManager.GetInstance().SetMute(state);
            txtMuteButton.text = state ? "UnMute" : "Mute";
            AudioManager.Instance.ChangeMuteStatus(state);
        }

        public void OnVibrateToggleClick()
        {
            bool state = PreferenceManager.GetInstance().GetVibrate();
            state = !state;
            PreferenceManager.GetInstance().SetVibrate(state);
            txtVibrateButton.text = state ? "No Vibrate" : "Vibrate";
        }
    }
}