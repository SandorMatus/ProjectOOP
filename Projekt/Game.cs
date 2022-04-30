using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Collections;
using System.Text;
using System.IO;
using System.Globalization;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public class Game
    {
        private string displayText;
        private string inputBuffer;
        private ArrayList displayInput = new ArrayList(); //TODO: maybe add text to the input line as well..
        private int position = 0;
        private List<String> loadedLines = new List<String>();
        GameLine one = new GameLine("");
        public Game(){//CONDITIONS : 0-start screen, 1-next line, 2-win, 3-lose
            displayText = ("Welcome to the game, press enter to begin...");
            one.addAnswer("1","",0);
        }
        public string Display{
            get{return displayText;}
        }
        public string Input{
            get{return inputBuffer;}
            set{inputBuffer = value;
                GameRunner();}
            }
        public void GameRunner(){
            switch (one.getCondition(inputBuffer)){
                case 0: //START SCREEN
                    one.clearAnswers();
                    textCreator();
                    displayText = one.getGameLine();
                    string[] splitString = LoadGameLines(@"saveGame.txt");
                    if(position < splitString.Length-2){
                        position++;
                    }else{
                        one.addAnswer("","",0);//temporary solution
                        position = 0;
                    }
                break;
                case 1://NEXT
                    displayText += one.getAnswer(inputBuffer);
                    one.clearAnswers();
                    one.addAnswer("","",0);//temporary solution
                break;
                case 2://WIN
                    displayText += one.getAnswer(inputBuffer);
                    one.clearAnswers();
                    one.addAnswer("","",0);//temporary solution
                    splitString = LoadGameLines(@"saveGame.txt");
                    position = splitString.Length - 2;
                break;
                case 3://LOSE
                    displayText += one.getAnswer(inputBuffer);
                    one.clearAnswers();
                    one.addAnswer("","",0);//temporary solution
                    splitString = LoadGameLines(@"saveGame.txt");
                    position = splitString.Length - 1;
                break;
                case 4://REPEAT
                    displayText += one.getAnswer(inputBuffer);
                break;
                default:
                    displayText += "\nInvalid input...";
                break;
            }

        }
        public string[] LoadGameLines(string filePath){
            string inputData = File.ReadAllText(filePath);
            return inputData.Split(';');
    }
        public void textCreator(){
                    string[] splitString = LoadGameLines(@"saveGame.txt");
                    string[] splitLoadedLines = splitString[position].Split('~');
                    for(int i = 0; i < splitLoadedLines.Length; i++){
                        if(splitLoadedLines[i].IndexOf('{') > 0){
                            string[] multipleGameLines = splitLoadedLines[i].Split('{');
                            one.addGameLine(multipleGameLines[0]);
                        }else if(splitLoadedLines[i].IndexOf('}') > 0){
                            string[] splitAnswer = splitLoadedLines[i].Split('}');
                            one.addAnswer(splitAnswer[0],splitAnswer[1],Int32.Parse(splitAnswer[2]));
                        }
                    }
        }
    }
}
