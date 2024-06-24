using System.Collections.Generic;

namespace SplashAndSolve
{
    [System.Serializable]
    public class Question
    {
        public string question;
        public string answer;
        public List<string> options;

        public Question(string question, string answer, List<string> options)
        {
            this.question = question;
            this.answer = answer;
            this.options = options;
        }

        public string GetQuestion()
        {
            return question;
        }

        public List<string> GetAllOptions()
        {
            List<string> que_options = new List<string>();
            que_options.Add(this.answer);
            que_options.AddRange(this.options);
            return que_options;
        }

        public bool VerifyAnswer(string answerToCheck)
        {
            return answerToCheck.Equals(answer);
        }
    }
}