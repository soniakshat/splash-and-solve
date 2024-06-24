using System;
using UnityEngine;

namespace SplashAndSolve
{
    public class UiManager : MonoBehaviour
    {
        public static UiManager Instance;

        [SerializeField] private GameOverView gameOverPanel;
        [SerializeField] private MainMenuView mainMenu;
        [SerializeField] private PauseMenuView pauseMenu; 
        [SerializeField] private PlayerHud playerHud;

        private void Awake()
        {
            Instance = this;
            ShowMainMenu();
        }

        public void ShowScore(int score)
        {
            playerHud.SetScore(score);
        }

        public void ShowGameOver()
        {
            gameOverPanel.gameObject.SetActive(true);
        }

        public void HideGameOver()
        {
            gameOverPanel.gameObject.SetActive(false);
        }

        public void ShowPauseMenu()
        {
            pauseMenu.gameObject.SetActive(true);
        }

        public void HidePauseMenu()
        {
            pauseMenu.gameObject.SetActive(false);
        }

        public void SetQuestion(string question)
        {
            playerHud.SetQuestion(question);
        }

        public void ShowMainMenu()
        {
            mainMenu.gameObject.SetActive(true);
            HideGameOver();
            HidePauseMenu();
        }
    }
}