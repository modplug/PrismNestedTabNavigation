using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismTabNavigationRepro.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabPage : TabbedPage
    {
        public TabPage()
        {
            InitializeComponent();
        }
    }
}
