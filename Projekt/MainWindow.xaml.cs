using System.Reflection.Emit;
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
using System.Windows.Threading;
using System.Windows.Interop;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int counter = 0;
        string display = "";
        bool typing;
        int speed = 30;
        private Game mainGame = new Game();
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            display = mainGame.Display;
			timer.Interval = TimeSpan.FromMilliseconds(speed);
			timer.Tick += timerTick;
            timer.Start();
            Loaded += MainWindow_Loaded;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
{
    IntPtr windowhandle = new WindowInteropHelper(this).Handle;
    HwndSource hwndSource = HwndSource.FromHwnd(windowhandle);
    hwndSource.AddHook(new HwndSourceHook(WndProc));
}

//The WM_NCRBUTTONDOWN message is posted when the user presses the right mouse button while the cursor is within the nonclient area of a window.
private const uint WM_NCRBUTTONDOWN = 0xa4;

//window message parameter for the hit test in the title bar
private const uint HTCAPTION = 0x02;

private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
{
    //Message for the right click
    if ((msg == WM_NCRBUTTONDOWN ) && (wParam.ToInt32() == HTCAPTION))
    {
        //Show our context menu
        ShowContextMenu();

        //prevent default context menu from appearing
        handled = true;
    }

    return IntPtr.Zero;
}
private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e){
    Slider slider = sender as Slider;
    timer.Interval = TimeSpan.FromMilliseconds(slider.Value);
}

private void ShowContextMenu()
{
    var contextMenu = Resources["contextMenu"] as ContextMenu;
    contextMenu.IsOpen = true;
}
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
{
    if (e.Key == Key.Return)
    {
        if(typing == true){
            TextUp.Text = display;
            counter = display.Length;
        }else{
        typing = true;
        mainGame.Input = TextDown.Text;
        TextDown.Text = "";
        display = mainGame.Display;
        if(TextUp.Text.Length >= display.Length){
            counter = 0;
        }else if(TextUp.Text.Length < display.Length){
            counter = TextUp.Text.Length;
        }
        }
    }
}
    private void timerTick(object sender, EventArgs e){
        if(display.Length >= counter){
            TextUp.Text = display.Substring(0, counter);
        }
        if(counter == display.Length){
            typing = false;
        }
        counter++;
    }
    }
}

