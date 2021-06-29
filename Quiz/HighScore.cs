using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace Quiz
{
    /// <summary>
    /// contains user score and method to update score throughout the game
    /// </summary>
    public class HighScore
    {
        
        public void HighScoreModule(DataGroup datagroup, UserScore score)
        {
            List<string> highscorelist = new List<string>();
            highscorelist=readFile(datagroup,false);
            highscorelist =checkScore(highscorelist, score.CorrectAnswers);
            writeFile(highscorelist);
            if (score.WrongAnswers.Count() > 0)
                ShowWrongAnswers(score);

                Console.WriteLine("*****************Leaderboard**************\n");
            highscorelist = readFile(datagroup,true);
               Console.WriteLine("\n*******************************************");
        }

        public void ShowWrongAnswers(UserScore score)
        {
            Console.WriteLine("*****************WrongAnswers**************\n");
            foreach (string value in score.WrongAnswers)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine("\n*******************************************\n");
        }

        public List<string> readFile(DataGroup dataGroup, bool show)
        {
            List<string> highscorelist = new List<string>();
            string file = "../../highscore.txt";
            int i = 1;
            if (File.Exists(file))
            {
                string fileContent = File.ReadAllText(file).Replace("\r", "");
                string[] lines = fileContent.Split('\n');
                foreach (string value in lines)
                {
                    if (value != "")
                    {
                        if (show)
                        {
                            Console.WriteLine(i + " - " + value.Split(',')[0] + " - " + value.Split(',')[1]);
                        }
                        highscorelist.Add(value);
                        i++;
                    }
                }
            }
            else
                File.OpenWrite(file);

            return highscorelist;
        }

        public void writeFile(List<string> highscorelist)
        {
            File.WriteAllLines("../../highscore.txt", highscorelist);
        }

        public List<string> checkScore(List<string> highscorelist,int score)
        {
            List<string> NyHighScoreList = new List<string>();
            foreach (string linje in highscorelist)
            {
                if (Int32.Parse(linje.Split(',')[1]) > score)
                {
                    NyHighScoreList.Add(linje);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("*****ENTER YOUR NAME*****\n");
                    Console.WriteLine("Skriv dit navn");
                    Console.WriteLine("\n*************************");
                    string navn = Console.ReadLine();
                    Thread.Sleep(1000);
                    Console.Clear();
                    NyHighScoreList.Add(navn+","+score);
                    NyHighScoreList.Add(linje);
                    score = -1;
                }
            }
            return NyHighScoreList;
        }

        }
}
