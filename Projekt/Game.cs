using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public class Game
    {
        private string displayText;
        private string inputBuffer;
        private string displayInput;
        private int repeatSequence;
        public Game(){
            displayText="";
            inputBuffer="";
        }
        public string Display{get{return displayText;}

        }
        public string Input{get{return inputBuffer;}
                            set{inputBuffer = value;}
            }
        public int RepeatSequence{get{return repeatSequence;}}
        public void gameTitle(){
            displayText = "Welcome to the game, press enter to begin...";
        }
        public void first(){
            displayText = "You wake up in class with an angry Mr. Storm standing over you."
            + "\nWhat do you do ?" + "\n1. Punch" + "\n2. Cry" + "\n3. Pee a little.";
            inputBuffer = "Choice : ";
        }
        public void second(){
            repeatSequence = 0;
            Random rnd = new Random();
            string[] secOptions = {"\n...\nIn the hallway, you see that the cops are searching lockers.",
            "\n...\nIn the hallway, you see your stalker walking toward you.",
            "\n...\nIn the hallway, the fire alarm goes off."};
            int randomNumber = rnd.Next(0,3);

            displayText += secOptions[randomNumber] + "\n..."+"\nDo you try hiding in the bathroom; Yer or No?";

        }
        public void third(){
            repeatSequence = 0;
            displayText += "\n...\nYou burst into the bathroom and all of your friends and family are there."+
            "\nThey yell 'Surprise!' and you remember it's your birthday." +
            "\nHow old are you today ?";
        }
        public void gameOver(){
            displayText = "At your funeral, they sing songs of your bravery."
            +"\nThen they remember who's funeral they are attending and they take it all back."
            +"\nBetter luck next time"
            +"\nPress enter to restart";
            repeatSequence = 2;
        }
        public void youWin(){
            displayText = "Your birthday party was a big hit."
            +"\nThe cake gave everyone superpowers"
            +"\nYou will all live for another 100 years."
            +"\nGreat job! You won!"
            +"\nPress 'Enter' to start over";
            repeatSequence = 2;
        }
        public void answers(int sequence){
            switch (sequence){
                case 0:
                    first();
                break;
                case 1:
                switch(inputBuffer.ToLower()){
                    case "1":
                    case "punch him":
                    case "punch":
                        displayText += "\n...."+"\nYour fist pounds into Mr. Storm's face. " + "\nAll the other students in class cheer your name."
                        +"\nMrs. Storm hears the commotion and comes to investigate."+"\nWhen she sees her husband crying in the corner, she shoots you with her laser eyes."
                        +"\nPress 'Enter' to continue";
                        gameOver();
                    break;
                    case "2":
                    case "cry":
                        displayText += "\n...."+"\nMr. Storm's face becomes the color of ripe tomatoes."
                        +"\n'You wanna cry? Do it out in the hall!' He screams at the top of his lungs."
                        +"\n press 'Enter' to continue";
                        second();
                    break;
                    case "3":
                    case "pee":
                    case "pee a little":
                        displayText += "\n...."+"\nMr. Storm sniffs the air. The other students begin plugging their noses."
                        +"\n'Did you just ...? Get out of here!' He screams at the top of his lungs."
                        +"\n press 'Enter' to continue";
                        second();
                    break;
                    default:
                        displayText += "\n..."+"\nInvalid command try again";
                        repeatSequence = 1;
                    break;
                }
                break;
                case 2:
                    if(inputBuffer == "yes" || inputBuffer == "y"){
                        third();
                    }else if(inputBuffer == "no" || inputBuffer == "n"){
                        displayText += "\n..."+"\nA meteor slams into the school at that exact moment, killing you instantly.";
                        gameOver();
                    }else{
                        displayText += "\n..."+"\nInvalid command try again";
                        repeatSequence = 1;
                    }
                break;
                case 3:
                int age;
                int.TryParse(inputBuffer, out age);
            if(age < 100){
                displayText += "\n...\nSeriously ? You look older than that!" +
                "\n How old are you really ?";
                repeatSequence = 1;
            }else{
                displayText += "\n...\nWow, you're old! You must have been held back a lot!"
                +"\nPress 'Enter' to continue";
                repeatSequence = 3;
            }
                break;
                case 011011:
                    repeatSequence = 0;
                    youWin();
                break;
                case 100100:
                    repeatSequence = 0;
                    gameTitle();
                break;
            }
        }
    }
}
