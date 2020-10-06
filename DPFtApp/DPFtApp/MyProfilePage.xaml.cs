//Name: (Dallin Poulson)
//Class: (INFO 1200)
//Section: (002)
//Professor: (Crandall)
//Date: 10/5/2020
//Project #: 4
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
    public partial class MyProfilePage : ContentPage
    {
        public MyProfilePage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Allows the user to fill in their name(s) and also return to the main page when desired
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyProfileCloseBtn_Clicked(object sender, EventArgs e)
        {
            //try to see if there's any issues with the parsing, if not run this code
            try
            {
            //set weight to the ProfWeight global variable
            FitnessGlobalVariables.ProfWeight = double.Parse(WeightEnt.Text);
            //set Height to the ProfHeight global variable
            FitnessGlobalVariables.ProfHeight = double.Parse(HeightEnt.Text);
            //set age to the ProfAge global variable
            FitnessGlobalVariables.ProfAge = double.Parse(AgeEnt.Text);
            //when clicked, returns user to the main page (exits my profile page)
            Application.Current.MainPage.Navigation.PopModalAsync();
            }
            //if there are errors display this message
            catch
            {
                //displaay the aleart
                DisplayAlert("Invalid Input", "Please enter integers in the Weight, Height, and Age fields.", "Close");
                BtnClearAll_Clicked(sender,e);
              
            }

        }
        /// <summary>
        /// Allows the user to see the before picture
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBefore_Clicked(object sender, EventArgs e)
        {
            //changes the image source to the before.jpg picture
            ImgProfile.Source = "before.jpg";
        }
        /// <summary>
        /// Allows the user to see the after picture and receive an encouraging message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAfter_Clicked(object sender, EventArgs e)
        {
            //changes the image source to the after.jpg picture
            
            ImgProfile.Source = "after.jpg";

            // shows the user an encouraging message
            DisplayAlert("Good Job!", "You're KILLING it!", "Close");
        }
        /// <summary>
        /// clears all height, weight, and age variables/inputs to 0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClearAll_Clicked(object sender, EventArgs e)
        {
            //clear the fields
            WeightEnt.Text = "";
            HeightEnt.Text = "";
            AgeEnt.Text = "";

            //reassign variables to equal zero
            FitnessGlobalVariables.ProfWeight = 0;
            FitnessGlobalVariables.ProfHeight = 0;
            FitnessGlobalVariables.ProfAge = 0;
        }

    }
}