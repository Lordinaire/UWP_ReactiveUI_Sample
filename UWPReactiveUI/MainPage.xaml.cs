using UWPReactiveUI.Core;
using Windows.UI.Xaml.Controls;

namespace UWPReactiveUI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public HipsterViewModel ViewModel { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            ViewModel = DataContext as HipsterViewModel;
        }
    }
}
