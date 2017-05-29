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
using System.Diagnostics;


namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // initialized for timer
        public int seconds;
        public int minutes;
        public int hours;

        DispatcherTimer timer = new DispatcherTimer(); // used for stopwatch
        DispatcherTimer timer1 = new DispatcherTimer(); // used for timer
        Stopwatch wat = new Stopwatch();
        string currentTime = string.Empty;

        private bool isClicked = false; // used for stopwatch

        private bool isClicked2 = false; // to run in
        public MainWindow()
        {
            InitializeComponent();
            // watch running when button clicked for stopwatch
            timer.Tick += new EventHandler(timer_click);
            timer.Interval = new TimeSpan(0, 0, 0, 0); // using seconds speed as stopwatch
                                                       // to set to 1 we just change the interval to 0,0,0,1



            // for timer 
            // setting interval 
            timer1.Tick += new EventHandler(timer1_click);
            timer1.Interval = new TimeSpan(0, 0, 0, 1);

        }

        /*
         * start watch
         * start timer
         * play watch at the text lable
         * 
         */
        void timer_click(object sender, EventArgs e)
        {

            if (wat.IsRunning)
            {

                TimeSpan ts = wat.Elapsed;
                currentTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                watch.Text = currentTime;

            }
        }

        /* by clicking 
         * setting 0s if the input isEmpty
         * 
         */
        private void Count_down(object sender, RoutedEventArgs e)
        {

            // if input is empty
            if (hrs.Text == "")
            {
                hrs.Text = "0";
            }
            if (mins.Text == "")
            {
                mins.Text = "0";

            }
            if (secs.Text == "")
            {
                secs.Text = "0";
            }
            // convert int to text 

            hours = Convert.ToInt32(hrs.Text);
            minutes = Convert.ToInt32(mins.Text);
            seconds = Convert.ToInt32(secs.Text);

            // start timer
            if (hrs.Text != "0" || mins.Text != "0" || secs.Text != "0")
            {
                timer1.Start();
            }
        }
        /*input int and start count-down
         * 
         * 
         */
        private void timer1_click(object sender, EventArgs e)
        {


            seconds = seconds - 1;
            if (seconds == -1)
            {
                minutes = minutes - 1;
                seconds = 59;
            }
            if (minutes == -1)
            {
                hours = hours - 1;
                minutes = 59;
            }
            if (hours == 0 && minutes == 0 && seconds == 3)
            {
                tm.Foreground = new SolidColorBrush(Colors.Red);
            }

            if (hours == 0 && minutes == 0 && seconds == 0)
            {
                timer1.Stop();

                tm.Foreground = new SolidColorBrush(Colors.Black);

            }



            string hhr = Convert.ToString(hours);
            string minns = Convert.ToString(minutes);
            string seccs = Convert.ToString(seconds);
            tm.Content = string.Format("{0:00}:{1:00}:{2:00}", hhr, minns, seccs);
            // TimeSpan elapsedTime = TimeSpan.ParseExact(a, "c", null);

        }

        /*
         * to change content of 
         * start-button
         * record-button
         * 
         * */
        private void sbtn_Click(object sender, RoutedEventArgs e)
        {

            if (!isClicked)
            {
                timer.Start();
                wat.Start();
                sbtn.Content = "Stop";
                rec.Content = "Record";
                isClicked = true;
            }
            else
            {
                timer.Stop(); // puase the stopwatch timer
                wat.Stop();     // stopwatch stopped
                sbtn.Content = "Start"; // change content of start button
                rec.Content = "Reset";  // change the content of record button
                isClicked = false;
            }

        }
        /*
         * reset the timer 
         * and clear the listbox
         */
        private void rec_Click(object sender, RoutedEventArgs e)
        {
            if (!isClicked)
            {
                wat.Reset(); //reset stopwatch
                watch.Text = "00:00:00";
                TIMERec.Items.Clear(); // clear content of listbox


            }
            // add item to the listbox
            if (wat.IsRunning)
            {
                TIMERec.Items.Add(currentTime);
            }

        }

       
    }
}

