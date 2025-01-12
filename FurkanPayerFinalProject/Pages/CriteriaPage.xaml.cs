namespace FurkanPayerFinalProject.Pages;

public partial class CriteriaPage : ContentPage
{
    public CriteriaPage()
    {
        InitializeComponent();
        FromCountryPicker.SelectedIndex = 0;
    }

    private void OnPickerChanged(object sender, EventArgs e)
    {
        ShowDocumentsButton.IsEnabled = !string.IsNullOrWhiteSpace(FromCountryPicker.SelectedItem?.ToString()) &&
                                        !string.IsNullOrWhiteSpace(ToCountryPicker.SelectedItem?.ToString()) &&
                                        !string.IsNullOrWhiteSpace(VisaTypePicker.SelectedItem?.ToString()) &&
                                        !string.IsNullOrWhiteSpace(DurationPicker.SelectedItem?.ToString()) &&
                                        !string.IsNullOrWhiteSpace(ApplicantTypePicker.SelectedItem?.ToString());
    }

    private async void OnShowDocumentsClicked(object sender, EventArgs e)
    {
        var selectedFromCountry = FromCountryPicker.SelectedItem?.ToString();
        var selectedToCountry = ToCountryPicker.SelectedItem?.ToString();
        var selectedVisaType = VisaTypePicker.SelectedItem?.ToString();
        var selectedDuration = DurationPicker.SelectedItem?.ToString();
        var selectedApplicantType = ApplicantTypePicker.SelectedItem?.ToString();


        
    }
}
