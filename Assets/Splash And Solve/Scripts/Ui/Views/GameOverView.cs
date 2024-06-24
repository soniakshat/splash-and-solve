using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SplashAndSolve
{
    public class GameOverView : MonoBehaviour
    {
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
    }
}