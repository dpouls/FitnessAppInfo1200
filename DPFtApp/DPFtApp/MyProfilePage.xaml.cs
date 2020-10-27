//Name: (Dallin Poulson)
//Class: (INFO 1200)
//Section: (002)
//Professor: (Crandall)
//Date: 10/26/2020
//Project #: 5
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
        const double MAX_WEIGHT = (double)1000;
        const double MIN_WEIGHT = (double)50;
        const double MAX_AGE = (double)120;
        const double MIN_AGE = (double)12;
        const double MAX_HEIGHT = (double)96;
        const double MIN_HEIGHT = (double)48;
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
            if(double.TryParse(WeightEnt.Text, out double weight) && weight <= MAX_WEIGHT && weight >= MIN_WEIGHT)
            {
                if (double.TryParse(HeightEnt.Text, out double height) && height <= MAX_HEIGHT && height >= MIN_HEIGHT)
                {
                    if (double.TryParse(AgeEnt.Text, out double age) && age <= MAX_AGE && age >= MIN_AGE)
                    {
                        //set weight to the ProfWeight global variable
                        FitnessGlobalVariables.ProfWeight = double.Parse(WeightEnt.Text);
                        //set Height to the ProfHeight global variable
                        FitnessGlobalVariables.ProfHeight = double.Parse(HeightEnt.Text);
                        //set age to the ProfAge global variable
                        FitnessGlobalVariables.ProfAge = double.Parse(AgeEnt.Text);
                        //when clicked, returns user to the main page (exits my profile page)
                        Application.Current.MainPage.Navigation.PopModalAsync();
                    } else
                    {
                        DisplayAlert("Input Error", $"Please enter age between {MIN_AGE} and {MAX_AGE}", "Close");
                        BtnClearAll_Clicked(sender, e);
                    }
                }
                else
                {
                    DisplayAlert("Input Error", $"Please enter height between {MIN_HEIGHT} and {MAX_HEIGHT}", "Close");
                    BtnClearAll_Clicked(sender, e);
                }
            }

            //if there are errors display this message
            else
            {
                //displaay the aleart
                DisplayAlert("Input Error", $"Please enter weight between {MIN_WEIGHT} and {MAX_WEIGHT}", "Close");
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