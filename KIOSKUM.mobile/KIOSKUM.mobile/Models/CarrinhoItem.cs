
using System.Collections.Generic;
using System.ComponentModel;

namespace KIOSKUM.mobile.Models
{
    public class CarrinhoItem : INotifyPropertyChanged
    {
        int _qtd;
        double _precoTotal => Qtd * PrecoUnidade;

        public string Id { get; set; }   // Volta a mudar para int!!
        public int Qtd { 
            get { return _qtd; }
            set
            {
                _qtd = value;
                OnPropertyChanged("PrecoTotal");
                OnPropertyChanged("Qtd");
            }
        }
        public string Obs { get; set; }
        public double PrecoUnidade { get; set; }
        public double PrecoTotal
        {
            get { return _precoTotal; }
            set {
                PrecoTotal = value;
                OnPropertyChanged("PrecoTotal");
            }
        }

        //public event NotifyCollectionChangedEventHandler CollectionChanged;

        public override bool Equals(object obj)
        {
            return obj is CarrinhoItem item &&
                   Id == item.Id &&
                   Qtd == item.Qtd &&
                   Obs == item.Obs;
        }

        public override int GetHashCode()
        {
            int hashCode = -1629259719;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Id);
            hashCode = hashCode * -1521134295 + Qtd.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Obs);
            return hashCode;
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
