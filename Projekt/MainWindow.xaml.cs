using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int sequence = 0;
        private Game mainGame = new Game();
        public MainWindow()
        {
            InitializeComponent();
            mainGame.gameTitle();
            TextUp.Text = mainGame.Display;
        }
        public void changeEvent(){
            mainGame.Input = TextDown.Text;
            if(mainGame.RepeatSequence == 0){
                mainGame.answers(sequence++);
            }else if (mainGame.RepeatSequence == 1){
                mainGame.answers(sequence - 1);
            }else if (mainGame.RepeatSequence == 2){
                mainGame.answers(100100);
                sequence = 0;
            }else if (mainGame.RepeatSequence == 3){
                mainGame.answers(011011);
                sequence = 0;
            }
            TextUp.Text = mainGame.Display;
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
{
    if (e.Key == Key.Return)
    {
       changeEvent();
       TextDown.Text = "";
    }
}
    }
}
