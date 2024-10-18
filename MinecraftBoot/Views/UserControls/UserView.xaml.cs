using MinecraftBoot;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MinecraftBoot.Views.UserControls;
public sealed partial class UserView : UserControl
{
    public UserView()
    {
        this.InitializeComponent();
    }

    private void SettingsMenuFlyoutItem_Click(object sender, RoutedEventArgs e)
    {
        App.Current.JsonNavigationViewService.NavigateTo(typeof(SettingsPage));
    }

    private void UserMenuFlyoutItem_Click(object sender, RoutedEventArgs e)
    {
        App.Current.JsonNavigationViewService.NavigateTo(typeof(UserInfoPage));
    }

    private void UserManagerMenuFlyoutItem_Click(object sender, RoutedEventArgs e)
    {
        App.Current.JsonNavigationViewService.NavigateTo(typeof(UserInfoPage));
    }
}
