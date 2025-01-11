using FurkanPayerFinalProject.Pages;
namespace FurkanPayerFinalProject
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell(); // LoginPage başlangıç sayfası
        }
    }

}
