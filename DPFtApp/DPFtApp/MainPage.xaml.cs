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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DPFtApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //Set today's date on initialization
            CurrentDate.Text = DateTime.Now.ToString("d");
        }

        /// <summary>
        /// lets the user navigate to the my profile page and/or click the welcome button for a welcome alert
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MyProfileNavBtn_Clicked(object sender, EventArgs e)
        {
            //This will let a user navigate to the "My Profile" page.
            Navigation.PushModalAsync(new MyProfilePage());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BMRNavButton_Clicked(object sender, EventArgs e)
        {
            //This will let a user navigate to the "My BMR" page.
            Navigation.PushAsync(new MyBMRPage());

        }
    }
}
