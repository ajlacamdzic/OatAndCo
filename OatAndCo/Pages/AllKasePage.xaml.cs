namespace OatAndCo.Pages;

public partial class AllKasePage : ContentPage
{
	private readonly AllKaseViewModel _allKaseViewModel;
	public AllKasePage(AllKaseViewModel allKaseViewModel)
	{
		InitializeComponent();
		_allKaseViewModel = allKaseViewModel;
		BindingContext = _allKaseViewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		if( _allKaseViewModel.FromSearch) 
		{
			await Task.Delay(100);
			searchBar.Focus();
		}
    }

    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
		if(!string.IsNullOrEmpty(e.OldTextValue) && string.IsNullOrWhiteSpace(e.NewTextValue))
		{
			_allKaseViewModel.SearchKasesCommand.Execute(null);
		}
    }
}