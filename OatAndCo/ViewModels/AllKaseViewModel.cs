namespace OatAndCo.ViewModels
{
    [QueryProperty(nameof(FromSearch), nameof(FromSearch))]
    public partial class AllKaseViewModel : ObservableObject
    {
        private readonly KaseService _kaseService;
        public AllKaseViewModel(KaseService kaseService)
        {
            _kaseService = kaseService;
            Kases = new(_kaseService.GetAllKase());
        }
        public ObservableCollection<Kase> Kases { get; set; }

        [ObservableProperty]
        private bool _fromSearch;

        [ObservableProperty]
        private bool _searching;

        [RelayCommand]
        private async Task SearchKases(string searchTerm)
        {
            Kases.Clear();
            Searching = true;
            await Task.Delay(1000);
            foreach(var kase in _kaseService.SearchKases(searchTerm))
            {
                Kases.Add(kase);
            }
            Searching = false;

        }
        [RelayCommand]
        private async Task GoToDetailsPage(Kase kase)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(DetailsViewModel.Kase)] = kase
            };
            await Shell.Current.GoToAsync(nameof(DetailPage), animate: true, parameters);
        }
    }
}
