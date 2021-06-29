using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    /// <summary>
    /// contains user score and method to calculate score at the end of the game
    /// </summary>
    public class UserScore
    {
        public int CorrectAnswers = 0;
        public List<string> WrongAnswers = new List<string>();

        // method to calculate and update score after each question
        public UserScore CalculateScore(UserScore score, DataGroup data)
        {
            int i = 0;
            foreach(var question in data.questions)
            {
                var splitData = question.Split(',');
                if (splitData[1].Trim() == data.guesses[i]) score.CorrectAnswers++;
                else score.WrongAnswers.Add(question);
                i++;
            }
            return score;
        }
    }
}
