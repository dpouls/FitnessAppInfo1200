//Name: (Dallin Poulson)
//Class: (INFO 1200)
//Section: (002)
//Professor: (Crandall)
//Date: 09/24/2020
//Project #: 3
//I declare that the source code contained in this assignment was written solely by me.
//I understand that copying any source code, in whole or in part,
// constitutes cheating, and that I will receive a zero on this project
// if I am found in violation of this policy.<?xml version="1.0" encoding="utf-8" ?>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DPFtApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyBMRPage : ContentPage
    {
        public MyBMRPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// we will make a modal and make the BMR calculations, then assign the results to the corresponding labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BMRCalculateBtn_Clicked(object sender, EventArgs e)
        {
            //delcare varialbes to hold the female and male BMR values
            decimal femaleBMR;
            decimal maleBMR;
            //make it a modal
            var waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
            var modalPage = new MyProfilePage();
            modalPage.Disappearing += (sender2, e2) =>
            {
                waitHandle.Set();
            };
            await Navigation.PushModalAsync(modalPage);
            await Task.Run(() => waitHandle.WaitOne());
            //calculate the female and male BMR and store the result for each calculation in a seperate variable. 
            femaleBMR = 655m + (4.35m * (decimal)FitnessGlobalVariables.ProfWeight) + (4.7m * (decimal)FitnessGlobalVariables.ProfHeight) - (4.7m * (decimal)FitnessGlobalVariables.ProfAge);
            maleBMR = 66m + (6.23m * (decimal)FitnessGlobalVariables.ProfWeight) + (12.7m * (decimal)FitnessGlobalVariables.ProfHeight) - (6.8m * (decimal)FitnessGlobalVariables.ProfAge);
            //set the labels to the corresponding results
            FemaleBMRlbl.Text = femaleBMR.ToString("n2");
            MaleBMRlbl.Text = maleBMR.ToString("n2");

        }
        //Navigates back to home/main page
        private void BMRCloseBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
    }
}