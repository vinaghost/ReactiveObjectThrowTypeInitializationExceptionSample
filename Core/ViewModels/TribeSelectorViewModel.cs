using Core.Enums;
using ReactiveUI;
using ReactiveUI.SourceGenerators;
using System.Collections.ObjectModel;

namespace Core.ViewModels
{
    public partial class TribeSelectorViewModel : ReactiveObject
    {
        public TribeSelectorViewModel()
        {
            var tribes = Enum.GetValues<TribeEnums>()
                .AsEnumerable()
                .Where(x => x != TribeEnums.Nature)
                .Where(x => x != TribeEnums.Natars)
                .Select(x => new TribeItem(x))
                .ToList();
            Items = new(tribes);
            _selectedItem = Items[0];
        }

        public void Set(TribeEnums tribe)
        {
            SelectedItem = Items.First(x => x.Tribe == tribe);
        }

        public TribeEnums Get()
        {
            return SelectedItem.Tribe;
        }

        public ObservableCollection<TribeItem> Items { get; }

        [Reactive]
        private TribeItem _selectedItem;
    }
}