
namespace OatAndCo.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly KaseService _kaseService;
        public HomeViewModel(KaseService kaseService)
        {
            _kaseService = kaseService;
            Kases = new(_kaseService.GetPopularKase());
        }

        public ObservableCollection<Kase> Kases { get; set; }

        [RelayCommand]
        private async Task GoToAllKasePage(bool fromSearch = false)
        {
            var parameters = new Dictionary<string, object>
            {
                [nameof(AllKaseViewModel.FromSearch)] = fromSearch
            };
            await Shell.Current.GoToAsync(nameof(AllKasePage), animate: true, parameters);
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
