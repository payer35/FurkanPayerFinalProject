using System;
using FurkanPayerFinalProject.Models;
using FurkanPayerFinalProject.Services;
using Microsoft.Maui.Controls;

namespace FurkanPayerFinalProject.Pages;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void RegisterButton_Clicked(object sender, EventArgs e)
    {
        string email = EmailEntry.Text;
        string password = "defaultPassword";
        string firstName = FirstNameEntry.Text;
        string lastName = LastNameEntry.Text;
        string phone = PhoneEntry.Text;
        string gender = SelectedGender.Text == "Select Gender" ? null : SelectedGender.Text;
        DateTime dateOfBirth = DateOfBirthPicker.Date;

        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
        {
            await DisplayAlert("Error", "Please fill in all required fields.", "OK");
            return;
        }

        try
        {

            var newUser = new User
            {
                Email = email,
                Password = password,
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                Gender = gender,
                DateOfBirth = dateOfBirth
            };


            var database = DatabaseService.GetDatabase();
            await database.InsertAsync(newUser);

            await Shell.Current.GoToAsync("..");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await DatabaseService.InitializeDatabase(); // Veritabanýný baþlat
    }
}