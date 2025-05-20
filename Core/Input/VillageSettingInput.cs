using Core.ViewModels;
using ReactiveUI;
using ReactiveUI.SourceGenerators;
using Serilog;
using System.Reactive.Linq;

namespace Core
{
    public partial class VillageSettingInput : ReactiveObject
    {
        [Reactive]
        private bool _useHeroResourceForBuilding;

        [Reactive]
        private bool _applyRomanQueueLogicWhenBuilding;

        [Reactive]
        private bool _useSpecialUpgrade;

        [Reactive]
        private bool _completeImmediately;

        [Reactive]
        private bool _trainTroopEnable;

        [Reactive]
        private bool _trainWhenLowResource;

        public TribeSelectorViewModel Tribe { get; } = new();

        public VillageSettingInput()
        {
            this.WhenAnyValue(vm => vm.Tribe.SelectedItem)
                .Select(x => x.Tribe)
                .Subscribe((tribe) =>
                {
                    // for minimal example, just log the tribe
                    Log.Information($"Tribe: {tribe}");
                });
        }
    }
}