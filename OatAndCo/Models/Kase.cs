using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OatAndCo.Models
{
    public partial class Kase : ObservableObject
    {
        public string Name { get; set; }
        public string Image {  get; set; }
        public double Price { get; set; }

        [ObservableProperty, NotifyPropertyChangedFor(nameof(Amount))]
        private int _cartQuantity;

        public double Amount => CartQuantity * Price;

        public Kase Clone() => MemberwiseClone() as Kase;
    }
}
