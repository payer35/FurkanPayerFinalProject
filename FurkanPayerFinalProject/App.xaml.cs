using FurkanPayerFinalProject.Pages;
namespace FurkanPayerFinalProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            InitializeApp();

            MainPage = new AppShell();
        }

        private async void InitializeApp()
        {
            await FurkanPayerFinalProject.Services.DatabaseService.InitializeDatabase();
        }
    }

}
