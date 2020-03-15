using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace KIOSKUM.mobile.ViewModels
{
    public class ProdutosViewModel<TKey, TItem> : ObservableCollection<TItem>
    {
        public TKey Key { get; private set; }

        public ProdutosViewModel(TKey key, IEnumerable<TItem> items)
        {
            this.Key = key;
            foreach (var item in items)
                this.Items.Add(item);
        }
    }
}
