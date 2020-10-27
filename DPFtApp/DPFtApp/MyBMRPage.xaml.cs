//Name: (Dallin Poulson)
//Class: (INFO 1200)
//Section: (002)
//Professor: (Crandall)
//Date: 10/26/2020
//Project #: 5
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
        const decimal FEMALE_BMR_INDEX = 655m;
        const decimal FEMALE_BMR_INDEX_WEIGHT = 4.35m;
        const decimal FEMALE_BMR_INDEX_HEIGHT = 4.7m;
        const decimal FEMALE_BMR_INDEX_AGE = 4.7m;
        const decimal MALE_BMR_INDEX = 66m;
        const decimal MALE_BMR_INDEX_WEIGHT = 6.23m;
        const decimal MALE_BMR_INDEX_HEIGHT = 12.7m;
        const decimal MALE_BMR_INDEX_AGE = 6.8m;
        public MyBMRPage()
        {
            InitializeComponent();
            PckActivity.SelectedIndex = 0;
            PckGender.SelectedIndex = 0;
        }
        /// <summary>
        /// we will make a modal and make the BMR calculations, then assign the results to the corresponding labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BMRCalculateBtn_Clicked(object sender, EventArgs e)
        {
            //declare varialbes to hold the female and male BMR values
            
            decimal ProfWeight = (decimal)FitnessGlobalVariables.ProfWeight;
            decimal ProfHeight = (decimal)FitnessGlobalVariables.ProfHeight;
            decimal ProfAge = (decimal)FitnessGlobalVariables.ProfAge;
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
            femaleBMR = FEMALE_BMR_INDEX + (FEMALE_BMR_INDEX_WEIGHT * (decimal)FitnessGlobalVariables.ProfWeight) + (FEMALE_BMR_INDEX_HEIGHT * (decimal)FitnessGlobalVariables.ProfHeight) - (FEMALE_BMR_INDEX_AGE * (decimal)FitnessGlobalVariables.ProfAge);
            maleBMR = MALE_BMR_INDEX + (MALE_BMR_INDEX_WEIGHT * (decimal)FitnessGlobalVariables.ProfWeight) + (MALE_BMR_INDEX_HEIGHT * (decimal)FitnessGlobalVariables.ProfHeight) - (MALE_BMR_INDEX_AGE * (decimal)FitnessGlobalVariables.ProfAge);
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