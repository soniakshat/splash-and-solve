using DG.Tweening;
using UnityEngine;


namespace SplashAndSolve
{
    public class MainMenuView : MonoBehaviour
    {
        [SerializeField] private RectTransform playModePanel;
        [SerializeField] private RectTransform settingsPanel;

        private void Awake()
        {
            HidePlayModePanel();
            HideSettingsPanel();
        }

        private void HideSettingsPanel()
        {
            settingsPanel.DOAnchorPosY(-1440, 1f).OnComplete(() =>
            {
                settingsPanel.gameObject.SetActive(false);
            });
        }

        private void ShowPlayModePanel()
        {
            playModePanel.gameObject.SetActive(true);
            playModePanel.DOAnchorPosY(-50, 1f);
        }

        private void HidePlayModePanel()
        {
            playModePanel.DOAnchorPosY(-1440, 1f).OnComplete(() =>
            {
                playModePanel.gameObject.SetActive(false);
            });
        }

        public void OnPlayButtonClick()
        {
            ShowPlayModePanel();
        }

        public void OnPlayRandomButtonClick()
        {
            GameManager.Instance.SetGameMode(Enums.QuestionType.Random);
            QuestionManager.Instance.GenerateQuestions();
            HidePlayModePanel();
            gameObject.SetActive(false);
        }

        public void OnPlayAdditionButtonClick()
        {
            GameManager.Instance.SetGameMode(Enums.QuestionType.Addition);
            QuestionManager.Instance.GenerateQuestions();
            HidePlayModePanel();
            gameObject.SetActive(false);
        }

        public void OnPlaySubtractionButtonClick()
        {
            GameManager.Instance.SetGameMode(Enums.QuestionType.Subtraction);
            QuestionManager.Instance.GenerateQuestions();
            HidePlayModePanel();
            gameObject.SetActive(false);
        }

        public void OnPlayMultiplicationClick()
        {
            GameManager.Instance.SetGameMode(Enums.QuestionType.Multiplication);
            QuestionManager.Instance.GenerateQuestions();
            HidePlayModePanel();
            gameObject.SetActive(false);
        }

        public void OnPlayDivisionButtonClick()
        {
            GameManager.Instance.SetGameMode(Enums.QuestionType.Division);
            QuestionManager.Instance.GenerateQuestions();
            HidePlayModePanel();
            gameObject.SetActive(false);
        }

        public void OnPlayFractionsButtonClick()
        {
            GameManager.Instance.SetGameMode(Enums.QuestionType.Fraction);
            QuestionManager.Instance.GenerateQuestions();
            HidePlayModePanel();
            gameObject.SetActive(false);
        }

        public void OnClosePlayModeButtonClick()
        {
            HidePlayModePanel();
        }

        public void OnSettingsButtonClick()
        {
            settingsPanel.gameObject.SetActive(true);
            settingsPanel.DOAnchorPosY(0, 1f);
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