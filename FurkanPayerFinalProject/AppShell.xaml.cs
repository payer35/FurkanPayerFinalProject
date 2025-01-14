﻿using FurkanPayerFinalProject.Pages;

namespace FurkanPayerFinalProject
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            Routing.RegisterRoute(nameof(CriteriaPage), typeof(CriteriaPage));
            Routing.RegisterRoute(nameof(FinalDetailsPage), typeof(FinalDetailsPage));
        }
    }
}
