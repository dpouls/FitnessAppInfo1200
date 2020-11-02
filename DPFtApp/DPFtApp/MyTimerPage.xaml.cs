//Name: (Dallin Poulson)
//Class: (INFO 1200)
//Section: (002)
//Professor: (Crandall)
//Date: 11/1/2020
//Project #: 6 B
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
            //make sure input was entered as a  number (integer)
            if (int.TryParse(TimeEnt.Text,out int time))
            {
                //create variables for seconds and minutes that will be used for the timer
                int seconds = 0, minutes = 0;
                //disable the start btn so the user can't start a new timer
                StartBtn.IsEnabled = false;
                // while time is greater than zero, execute this code.
                while (time >= 0)
                {
                    //minutes are time / 60 
                    minutes = time / SECONDS;
                    //seconds are the remainder of time / 60 so we use the modulus operator
                    seconds = time % SECONDS;
                    //if seconds have double digits we will print them as is
                    if (seconds >= DOUBLE_DIGITS)
                    {
                        //change the lbltimer text to the current time using our minutes and seconds variables.
                        LblTimer.Text = $"0{minutes}:{seconds}";
                    } else
                    {
                        //change the lbltimer text to the current time using our minutes and seconds variables while placing a 0 in front of seconds because we know it is less than 10.

                        LblTimer.Text = $"0{minutes}:0{seconds}";
                    }
                    //call the start timer method so we have a one second gap between loops.
                     await StartTimer();
                    //decrement the time so our timer goes down.
                    time -= 1;

                }
                //re enable the start button for another time if desired
                StartBtn.IsEnabled = true;
            } 
            else
            {
                //if the input was not an integer, we send this alert to help the user enter correct information.
               await DisplayAlert("Invalid Input", "Please enter time as a number", "Close");
            }
        }
        /// <summary>
        /// delays the function for 1000 milliseconds (1 second)
        /// </summary>
        /// <returns></returns>
        private async Task StartTimer()
        {
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

        
    }
}