using FurkanPayerFinalProject.Models;

namespace FurkanPayerFinalProject.Pages;

public partial class FinalDetailsPage : ContentPage
{
    public FinalDetailsPage(string fromCountry, string toCountry, string visaType, string duration, string applicantType)
    {
        InitializeComponent();

        var visaData = VisaDataProvider.GetVisaData();
        var visaDetails = GetVisaDetails(visaData, toCountry, visaType, duration, applicantType);

        FeeLabel.Text = visaDetails.Fee;
        ProcessingTimeLabel.Text = visaDetails.ProcessingTime;
        DocumentsCollectionView.ItemsSource = visaDetails.Documents;
    }

    private VisaDetails GetVisaDetails(VisaData visaData, string toCountry, string visaType, string duration, string applicantType)
    {
        if (visaData.Countries.TryGetValue(toCountry, out var country) &&
            country.VisaTypes.TryGetValue(visaType, out var type) &&
            type.Durations.TryGetValue(duration, out var dur) &&
            dur.ApplicantTypes.TryGetValue(applicantType, out var details))
        {
            return details;
        }

        return new VisaDetails
        {
            Fee = "Not Available",
            ProcessingTime = "Not Available",
            Documents = new List<Document>
            {
                new Document { Name = "No Data", Details = "No documents available for the selected criteria." }
            }
        };
    }
    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//CriteriaPage");
    }

}