using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Collections;

namespace Projekt
{
    public class GameLine{
    private List<string> answers = new List<string>();
    private List<string> expectedAnswers = new List<string>();
    private List<int> condition = new List<int>();
    private List<string> gameLine = new List<string>();
        public GameLine(string gameLine){
            this.gameLine.Insert(0,gameLine);
        }
        public void addAnswer(string answer, string expectedInput, int condition){
            answers.Add(answer);
            expectedAnswers.Add(expectedInput);
            this.condition.Add(condition);
        }
        public void setGameLine(string gameLine){
            this.gameLine.Insert(0,gameLine);
        }
        public void addGameLine(string gameLine){
            this.gameLine.Add(gameLine);
        }
        public string getGameLine(){
            Random rnd = new Random();
            if(gameLine.Count > 1){
                return gameLine[rnd.Next(0,gameLine.Count)];
            }else{
                return gameLine[0];
            }
        }
        public int countGameLines(){
            return gameLine.Count;
        }
        public void clearAnswers(){
            answers.Clear();
            expectedAnswers.Clear();
            condition.Clear();
            gameLine.Clear();
        }
        public string getAnswer(string input){
            int n = expectedAnswers.IndexOf(input);
            if(int.TryParse(expectedAnswers[0], out _) == true){
                int parsedInput = int.Parse(input);
                int range1 = int.Parse(expectedAnswers[1]);
                int range0 = int.Parse(expectedAnswers[0]);
            if(range1 > range0){
                if(parsedInput <= range1 || parsedInput >= range0){//second one is correct
                    return answers[1];
                }else{
                    return answers[0];
                }
            }else if(range1 < range0){
                if(range1 >= parsedInput || parsedInput <= range0){//first one is correct
                    return answers[0];
                }else{
                    return answers[1];
                }
            }else if(range1 == range0){//first one needs to be correct
                if(parsedInput >= range0){
                    return answers[0];
                }else{
                    return answers[1];
                }
            }
            }
            if(expectedAnswers.Count >= n){
                return answers[n];
            }else{
                return "Invalid input";
            }
        }

        public int getCondition(string input){//CONDITIONS : 0-start screen, 1-next line, 2-win, 3-lose, 4-repeat
            if(int.TryParse(expectedAnswers[0], out _) == true && int.TryParse(input, out _) == true){
                int parsedInput = int.Parse(input);
                int range1 = int.Parse(expectedAnswers[1]);
                int range0 = int.Parse(expectedAnswers[0]);
            if(range1 > range0){
                if(parsedInput <= range1 || parsedInput >= range0){//second one is correct
                    return condition[1];
                }else{
                    return condition[0];
                }
            }else if(range1 < range0){
                if(range1 >= parsedInput || parsedInput <= range0){//first one is correct
                    return condition[0];
                }else{
                    return condition[1];
                }
            }else if(range1 == range0){//first one needs to be correct
                if(parsedInput >= range0){
                    return condition[0];
                }else{
                    return condition[1];
                }
            }
            }
            else if(expectedAnswers.Contains(input)){
            int n = expectedAnswers.IndexOf(input);
            if(n <= expectedAnswers.Count){
                return condition[n];
            }
            }
            return 48;
        }
    }
}