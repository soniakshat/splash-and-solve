using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SplashAndSolve
{
    public class PauseMenuView : MonoBehaviour
    {
        public void OnResumeButtonClick()
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
        }

        public void OnHomeButtonClick()
        {
            QuestionManager.Instance.ResetQuestions();
            UiManager.Instance.ShowMainMenu();
        }
    }
}