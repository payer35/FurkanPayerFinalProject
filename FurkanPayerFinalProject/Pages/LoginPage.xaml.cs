using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurkanPayerFinalProject.Models;
using FurkanPayerFinalProject.Services;

namespace FurkanPayerFinalProject.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(RegisterPage));
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            string email = EmailEntry.Text;
            string password = PasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Please enter your email and password.", "OK");
                return;
            }

            var database = DatabaseService.GetDatabase();
            var user = await database.Table<User>()
                                      .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                await Shell.Current.GoToAsync(nameof(CriteriaPage));
            }
            else
            {
                await DisplayAlert("Error", "Invalid email or password.", "OK");
            }
        }
    }
}
