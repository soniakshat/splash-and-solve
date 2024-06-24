using UnityEngine;
using TMPro;
using System;

namespace SplashAndSolve
{
    public class PlayerHud : MonoBehaviour
    {
        [SerializeField] TMP_Text txtAmmo;
        [SerializeField] TMP_Text txtQuestion;
        [SerializeField] TMP_Text txtScore;
        [SerializeField] UnityEngine.UI.Button pauseButton;

        private void Awake()
        {
            pauseButton.onClick.RemoveAllListeners();
            pauseButton.onClick.AddListener(()=>
            {
                UiManager.Instance.ShowPauseMenu();
            });
        }

        private void OnEnable()
        {
            ProjectileThrower.OnBallonThrow += OnAmmoChange;
        }

        private void OnDisable()
        {
            ProjectileThrower.OnBallonThrow -= OnAmmoChange;
        }

        private void OnAmmoChange(int count)
        {
            txtAmmo.text = count.ToString();
        }

        public void SetScore(int score)
        {
            txtScore.text = score.ToString();
        }

        public void SetQuestion(string question)
        {
            txtQuestion.text = question;
        }
    }
}