using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SplashAndSolve
{
    public class GameOverView : MonoBehaviour
    {
        [SerializeField] private TMPro.TMP_Text txtGameOver;

        private void OnEnable()
        {
            txtGameOver.text = $"Game Over\nYour score was {ScoreManager.Instance.GetScore()}";
        }

        public void OnRestartButtonClick()
        {
            QuestionManager.Instance.ResetQuestions();
            UiManager.Instance.ShowMainMenu();
        }

        public void OnExitButtonClick()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            return;
#endif
            Application.Quit();
        }

        public void SetGameOverTest(string v)
        {
            txtGameOver.text = $"Out of Ammo. Game Over\nYour score was {ScoreManager.Instance.GetScore()}";
        }
    }
}