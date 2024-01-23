using System;

namespace OatAndCo.ViewModels
{
    [QueryProperty(nameof(Kase), nameof(Kase))]
    public partial class DetailsViewModel : ObservableObject
    {
        public DetailsViewModel() 
        {

        }
        [ObservableProperty]
        private Kase _kase;
    }
}
