using System.Collections.Generic;
using UnityEngine;

namespace SplashAndSolve {
    public class QuestionManager : MonoBehaviour
    {
        public static QuestionManager Instance;

        [SerializeField] private TargetManager targetManager;
        
        private List<Question> _questions = new List<Question>();
        private Question _currentQuestion;
        private List<Target> _targets = new List<Target>();

        private void Awake()
        {
            Instance = this;
        }

        public void GenerateQuestions()
        {
            for (int i = 0; i < AppConstants.QUESTION_COUNT; i++)
            {
                _questions.Add(QuestionGenerator.GenerateQuestion());
            }
            SetNextQuestion();
        }

        public void SetNextQuestion() {
            if(_questions.Count <= 0)
            {
                CustomLog.Log("Questions", "No More Questions Available");
                UiManager.Instance.SetQuestion("No More Questions! Game Over");
                UiManager.Instance.ShowGameOver();
                targetManager.RemoveStaticTargets();
                return;
            }

            _currentQuestion = _questions.SelectRandom();
            _questions.Remove(_currentQuestion);
            List<string> options = _currentQuestion.GetAllOptions();
            UiManager.Instance.SetQuestion(_currentQuestion.GetQuestion());
            
            _targets = targetManager.SetStaticTargets();
            for(int i=0; i<_targets.Count; i++)
            {
                _targets[i].SetAnswer(options[i]);
            }
        }

        public bool VerifyAnswer(string answer)
        {
            return _currentQuestion.VerifyAnswer(answer);
        }

        public void ResetQuestions()
        {
            _questions.Clear();
            _currentQuestion = null;
            UiManager.Instance.SetQuestion("");
            targetManager.RemoveStaticTargets();
            // Refill Ammo here.
        }
    }
}