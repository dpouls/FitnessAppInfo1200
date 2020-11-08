//Name: (Dallin Poulson)
//Class: (INFO 1200)
//Section: (002)
//Professor: (Crandall)
//Date: 11/7/2020
//Project #: 7 B
//I declare that the source code contained in this assignment was written solely by me.
//I understand that copying any source code, in whole or in part,
// constitutes cheating, and that I will receive a zero on this project
// if I am found in violation of this policy.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DPFtApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyTimerPage : ContentPage
    {
        //declare constants for our calculations
        //constant for seconds
        const int SECONDS = 60;
        //constant for double digits
        const int DOUBLE_DIGITS = 10;
        public string direction = "";
        public int lapCount = 1;
        int time = 0;
        public MyTimerPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// starts timer from when the user indicated
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void StartBtn_Clicked(object sender, EventArgs e)
        {
            //deactivate start button
            StartBtn.IsEnabled = false;
            //if time is verified continue to direction
            if (setTime())
            {
                //if direction is verified by user clicking one of the options, continue
                if (GetDirection(ref direction))
                {
                    //if direction is Count Down, user the CountDown() method. 
                    if(direction == "Count Down")
                    {
                        //creates task using CountDown method
                        var task = CountDown();
                        //awaits task while it finishes
                        await task;

                    } else
                    {
                        //creatse task using CountUp method if direction was not "Count Down"
                        var task = CountUp();
                        //awaits task while it finishes
                        await task;
                    }
                }
            }
        }
        /// <summary>
        /// checks to see if the time was input correctly;
        /// </summary>
        /// <returns></returns>
        private bool setTime()
        {
            //if parses correctly to integer, return true
            if (int.TryParse(TimeEnt.Text, out int time)) {
                //return true if integer was entered
            return true;
            }
            else
            {
                //alert if input was invalid and could not parse as integer.
                DisplayAlert("Invalid Input", "Please input a whole number for the time", "Close");
                //return false if no integer was entered into time entry
                return false;
            }
        }
        /// <summary>
        /// counts down from the user input time
        /// </summary>
        /// <returns></returns>
        private async Task CountDown()
        {
            //we set the time variable to the entered text so it starts our time off at the top for the countdown
            time = int.Parse(TimeEnt.Text);
            //while time is greater than or equal to zero, we display the time and decrement it
                while (time >= 0)
                {
                //use display time method to show current time
                    DisplayTime(time);
                //create task using StartTimer method.
                    Task task = StartTimer();
                //Await while task finishes
                    await task;
                //decrement time
                    time--;
                }
                //after while loop ends, start button is reenabled.
            StartBtn.IsEnabled = true;
            

        }
        /// <summary>
        /// counts up to the user specified input for time
        /// </summary>
        /// <returns></returns>
        private async Task CountUp()
        {
            //assign maxTime variable to parsed version of time entry input.
            int maxTime = int.Parse(TimeEnt.Text);
            //while time is less than or equal to maxTime, keep looping
                while (time <= maxTime)
                {
                //display time with displayTime method and current time
                    DisplayTime(time);
                //create task using StartTimer method.
                Task task = StartTimer();
                //Await while task finishes
                await task;
                //increment time
                time++;
                }

                //reenable start button so user can use it again. 
                StartBtn.IsEnabled = true;

            
        }
        private void DisplayTime(int time)
        {
            //create variables for seconds and minutes that will be used for the timer
            int seconds = 0, minutes = 0;
            //minutes are time / 60 
            minutes = time / SECONDS;
            //seconds are the remainder of time / 60 so we use the modulus operator
            seconds = time % SECONDS;
            //if seconds have double digits we will print them as is
            if (seconds >= DOUBLE_DIGITS)
            {
                //change the lbltimer text to the current time using our minutes and seconds variables.
                LblTimer.Text = $"0{minutes}:{seconds}";
            }
            else
            {
                //change the lbltimer text to the current time using our minutes and seconds variables while placing a 0 in front of seconds because we know it is less than 10.

                LblTimer.Text = $"0{minutes}:0{seconds}";
            }
        }

        /// <summary>
        /// verifies user picked a direction and assigns it to variable
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        private bool GetDirection(ref string direction)
        {
            //if index is 0 or greater, something was selected
            if (DirectionPicker.SelectedIndex >= 0)
            {
                //assign the string of the selected item to the direction variable
                direction = DirectionPicker.SelectedItem.ToString();
                //return true so it satisties what is needed in the Start timer method.
                return true;

            } else
            {
                //display alert if input was bad and nothing was selected
                DisplayAlert("Invalid Input", "Please select counting direction", "Close");
                //return false so it satisties what is needed in the Start timer method.
                return false;
            }
        }
        /// <summary>
        /// delays the function for 1000 milliseconds (1 second)
        /// </summary>
        /// <returns></returns>
        private async Task StartTimer()
        {
            //sets a 1 second delay between loops
            await Task.Delay(1000);
        }

        /// <summary>
        /// Navigates the user back to the main page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseBtn_Clicked(object sender, EventArgs e)
        {
            //pops the MyTimePage from the navigation stack and navigates the user back to the main page.
            Application.Current.MainPage.Navigation.PopAsync();
        }
        /// <summary>
        /// displays current time as a lap time each time the button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LapBtn_Clicked(object sender, EventArgs e)
        {
            
            //create variables for seconds and minutes that will be used for the timer
            int seconds = 0, minutes = 0;
            //minutes are time / 60 
            minutes = time / SECONDS;
            //seconds are the remainder of time / 60 so we use the modulus operator
            seconds = time % SECONDS;
            //if seconds have double digits we will print them as is
            if (seconds >= DOUBLE_DIGITS)
            {
                //change the labslbl text to the current time using our minutes and seconds variables.
                LapsLbl.Text = LapsLbl.Text + "[Lap #" + lapCount.ToString() + ": " + $"0{minutes}:{seconds}]";
            }
            else
            {
                //change the laplbl text to the current time using our minutes and seconds variables while placing a 0 in front of seconds because we know it is less than 10.
                LapsLbl.Text = LapsLbl.Text + "[Lap #" + lapCount.ToString() + ": " + $"0{minutes}:0{seconds}]";

                
            }
            //increment lapcount
            lapCount++;
        }
    }
}