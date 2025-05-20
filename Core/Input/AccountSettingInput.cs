using ReactiveUI;
using ReactiveUI.SourceGenerators;

namespace Core
{
    public partial class AccountSettingInput : ReactiveObject
    {
        [Reactive]
        private bool _enableAutoLoadVillage;

        [Reactive]
        private bool _headlessChrome;

        [Reactive]
        private bool _enableAutoStartAdventure;

        [Reactive]
        private bool _useStartAllButton;
    }
}