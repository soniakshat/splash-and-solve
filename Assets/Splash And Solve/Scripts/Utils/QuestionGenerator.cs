using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SplashAndSolve
{
    public static class QuestionGenerator
    {
        private static string currentAnswer;

        public static Question GenerateQuestion()
        {
            Enums.QuestionType questionType = GameManager.Instance.GetGameMode() == Enums.QuestionType.Random
                ? (Enums.QuestionType)Random.Range(0, System.Enum.GetValues(typeof(Enums.QuestionType)).Length)
                : GameManager.Instance.GetGameMode();

            string question = "";
            List<string> options = new List<string>();
            switch (questionType)
            {
                case Enums.QuestionType.Addition:
                    question = GenerateAdditionQuestion(out options);
                    break;
                case Enums.QuestionType.Subtraction:
                    question = GenerateSubtractionQuestion(out options);
                    break;
                case Enums.QuestionType.Multiplication:
                    question = GenerateMultiplicationQuestion(out options);
                    break;
                case Enums.QuestionType.Division:
                    question = GenerateDivisionQuestion(out options);
                    break;
                case Enums.QuestionType.Fraction:
                    question = GenerateFractionQuestion(out options);
                    break;
                //case Enums.QuestionType.Conversion:
                //    question = GenerateUnitConversionQuestion(out options);
                //    break;
                default:
                    question = GenerateAdditionQuestion(out options);
                    break;
            }

            options.Shuffle();

            return new Question(question, currentAnswer, options);
        }

        static string GenerateAdditionQuestion(out List<string> options)
        {
            int a = Random.Range(1, 100);
            int b = Random.Range(1, 100);
            currentAnswer = (a + b).ToString();
            options = GenerateOptions(currentAnswer);
            return $"What is {a} + {b}?";
        }

        static string GenerateSubtractionQuestion(out List<string> options)
        {
            int a = Random.Range(1, 100);
            int b = Random.Range(1, a); // Ensure non-negative result
            currentAnswer = (a - b).ToString();
            options = GenerateOptions(currentAnswer);
            return $"What is {a} - {b}?";
        }

        static string GenerateMultiplicationQuestion(out List<string> options)
        {
            int a = Random.Range(1, 20);
            int b = Random.Range(1, 20);
            currentAnswer = (a * b).ToString();
            options = GenerateOptions(currentAnswer);
            return $"What is {a} × {b}?";
        }

        static string GenerateDivisionQuestion(out List<string> options)
        {
            int a = Random.Range(1, 100);
            int b = Random.Range(1, 10);
            currentAnswer = (a / b).ToString();
            options = GenerateOptions(currentAnswer);
            return $"What is {a} ÷ {b}? (Round down to the nearest whole number)";
        }

        static string GenerateFractionQuestion(out List<string> options)
        {
            int numerator = Random.Range(1, 10);
            int denominator = Random.Range(1, 10);
            currentAnswer = $"{numerator}/{denominator}";
            options = GenerateOptions(currentAnswer);
            return $"What is the fraction {numerator}/{denominator}?";
        }

        static string GenerateUnitConversionQuestion(out List<string> options)
        {
            int cm = Random.Range(1, 100);
            float inches = cm / 2.54f;
            currentAnswer = inches.ToString("F2");
            options = GenerateOptions(currentAnswer);
            return $"Convert {cm} cm to inches (2 decimal places)";
        }

        static List<string> GenerateOptions(string correctAnswer)
        {
            List<string> options = new List<string> { correctAnswer };

            for (int i = 0; i < 3; i++)
            {
                string option;
                do
                {
                    option = Random.Range(1, 200).ToString();
                } while (options.Contains(option));
                options.Add(option);
            }

            return options;
        }
    }
}
