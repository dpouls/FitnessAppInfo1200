//Name: (Dallin Poulson)
//Class: (INFO 1200)
//Section: (002)
//Professor: (Crandall)
//Date: 12/6/2020
//Project #: 8 B
//I declare that the source code contained in this assignment was written solely by me.
//I understand that copying any source code, in whole or in part,
// constitutes cheating, and that I will receive a zero on this project
// if I am found in violation of this policy.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DPFtApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyWaterPage : ContentPage
    {

        //creating our various variables we will use
        const int DAILY_GLASS_GOAL = 8;
        string today = DateTime.Now.ToString("d");
        string documents = "";
        string filename = "";
        string filestored = "";
        int watercount = 0;

        public MyWaterPage()
        {
            InitializeComponent();
            //display the current date by changing the label text. 
            LblCurDate.Text = today;
            //after component is initialized, we call getfilepatch method to get the file path
            GetFilePath();
            //if we successfully found the file path, we can read the files
            if (File.Exists(filestored))
            {
                //we read the last of the file and assign the parsed value to watercount.
                watercount = int.Parse(File.ReadAllLines(filestored).Last().ToString());
                //we loop from 0 up to 1 less than watercount and add a water image to the stack layout
                for (int i = 0; i < watercount; i++)
                {
                    //create a new image instance with the Water.jpg source
                    Image image = new Image { Source = "Water.jpg" };
                    //we add another image as a child to the stack layout
                    SLWater.Children.Add(image);
                }
                //we update the watercount. 
                LblWaterCount.Text = $"Water Count: {watercount}";

            }

        }
        /// <summary>
        /// finds the file path where we are storing the glasses of water.
        /// </summary>
        private void GetFilePath()
        {
            //it wouldnt let me use the single quotes for the replace. we get rid of the illegal / character and place _ instead
            today = today.Replace("/", "_");
            //we assign documents the path to the water glass files.
            documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //we create a file name using today's date.
            filename = $"{today}water.txt";

            //we combine the path with the file name and assign it to filestored
            filestored = Path.Combine(documents, filename);

        }
        /// <summary>
        /// adds new water to the record.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddWater_Clicked(object sender, EventArgs e)
        {
            //if watercount is less than our goal (8)
            if (watercount < DAILY_GLASS_GOAL)
            {
                //we add a new image for another glass of water
                Image image = new Image { Source = "Water.jpg" };
                //we add the image to the stack layout
                SLWater.Children.Add(image);
                //increment the watercount variable.
                watercount += 1;
                //write a new file with the updated watercount
                File.WriteAllText(filestored, watercount.ToString());
                //change the watercount label to the updated value
                LblWaterCount.Text = watercount.ToString();
            }
            else
            {
                //if we are at our goal we alert the user that they have reached their goal. 
                DisplayAlert("Goal Complete!", "You've reached your goal of 8 glasses already!", "Close");
            }
        }
        /// <summary>
        /// navigates user back to home page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Clicked(object sender, EventArgs e)
        {
            //pops the MyWaterPage from the navigation stack and navigates the user back to the main page.
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}