using System.Collections.ObjectModel;
using System.Diagnostics;
using Microsoft.UI.Xaml.Media;
using MinecraftBoot.DialogContent;
using MinecraftBoot.Views;
using Windows.Foundation;
using Windows.UI;
using Microsoft.UI.Composition;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MinecraftBoot.Views;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public partial class HomePage : Page
{
    public LinearGradientBrush DialogLinearGradientBrush { get; set; }

    private ObservableCollection<Symbol> strings { get; }

    public HomePage()
    {
        this.InitializeComponent();
        strings = new ObservableCollection<Symbol>
        {
            Symbol.Home,
            Symbol.Play,
            Symbol.Download
        };
    }

    private void gooeyButton_Invoked(object sender, GooeyButton.GooeyButtonInvokedEventArgs args)
    {
        Debug.WriteLine("Invoked");
    }

    private void gooeyButton_ItemInvoked(object sender, GooeyButton.GooeyButtonItemInvokedEventArgs args)
    {
        if (args.Item is Symbol symbol)
        {
            if (symbol == Symbol.Home)
            {
                HomeTeachingTip.IsOpen = true;
            }
            else if (symbol == Symbol.Play)
            {

            }
            else if (symbol == Symbol.Download)
            {
                App.Current.JsonNavigationViewService.NavigateTo(typeof(InstallPage));
            }
        }

        Debug.WriteLine(args.Item.ToString());
    }

    private async void HomeTeachingTip_ActionButtonClick(TeachingTip sender, object args)
    {
        sender.IsOpen = false;
        ContentDialog dialog = new ContentDialog();

        var l = new LinearGradientBrush()
        {
            StartPoint = new Point(0,0),
            EndPoint = new Point(1,1)
        };
        l.GradientStops = new GradientStopCollection()
        {
            new GradientStop(){Color= Color.FromArgb(255, 156, 196, 228), Offset=0.0},
            new GradientStop(){Color= Color.FromArgb(255, 192, 229, 243), Offset=1.0},
        };
        DialogLinearGradientBrush = l;

        // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
        dialog.XamlRoot = this.XamlRoot;
        dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
        dialog.Title = "创建房间";
        dialog.BorderThickness = new Thickness(2);
        dialog.BorderBrush = DialogLinearGradientBrush;
        dialog.Content = new CreateNewRoom();

        var result = await dialog.ShowAsync();

    }

    private void StartOffsetAnimation(Microsoft.UI.Composition.CompositionColorGradientStop gradientOffset, float offset)
    {
        var c = new Compositor();
        var offsetAnimation = c.CreateColorKeyFrameAnimation();
        offsetAnimation.Duration = TimeSpan.FromSeconds(1);
        offsetAnimation.InsertKeyFrame(1.0f, Color.FromArgb(255, 156, 196, 228));
        gradientOffset.StartAnimation(nameof(Microsoft.UI.Composition.CompositionColorGradientStop.Offset), offsetAnimation);
    }

    private void StartColorAnimation(Microsoft.UI.Composition.CompositionColorGradientStop gradientOffset, Color color)
    {
        var c = new Compositor();
        var colorAnimation = c.CreateColorKeyFrameAnimation();
        colorAnimation.Duration = TimeSpan.FromSeconds(2);
        colorAnimation.Direction = Microsoft.UI.Composition.AnimationDirection.Alternate;
        colorAnimation.InsertKeyFrame(1.0f, color);
        gradientOffset.StartAnimation(nameof(Microsoft.UI.Composition.CompositionColorGradientStop.Color), colorAnimation);
    }
}
