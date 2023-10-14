using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Event;
using Lombok.NET;
using System.Windows;
using System.Windows.Controls;
using WindowDock.Core.Enums;
using WindowDock.Core.Event;

namespace WindowDock.Main.UI.Views;

[AllArgsConstructor]
public partial class MainContent : JamesContent
{

    // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty OrientationProperty;


    public Orientation Orientation
    {
        get { return (Orientation)GetValue (OrientationProperty); }
        set { SetValue (OrientationProperty, value); }
    }
    static MainContent()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(MainContent), new FrameworkPropertyMetadata(typeof(MainContent)));
        OrientationProperty = DependencyProperty.Register ("Orientation", typeof (Orientation), typeof (MainContent), new PropertyMetadata(Orientation.Horizontal));
    }

    private readonly IEventHub _eventHub;

    Border bdr;
    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate ();
        bdr = GetTemplateChild ("PART_BDR") as Border;
        this._eventHub.Subscribe<StyleChangedPubsub, StyleEnum> (e =>
        {
            if (e == StyleEnum.Style1)
            {
                Orientation = Orientation.Horizontal;
                bdr.Height = double.NaN;
                bdr.Margin = new Thickness (0, 0, 0, 0);
                bdr.CornerRadius = new CornerRadius (7);
            }
            else if (e == StyleEnum.Style2)
            {
                Orientation = Orientation.Vertical;
                bdr.Height = double.NaN;
                bdr.Margin = new Thickness (0, 0, 0, 0);
                bdr.CornerRadius = new CornerRadius (7);
            }
            else if (e == StyleEnum.Style3)
            {
                Orientation = Orientation.Horizontal;
                bdr.Height = 30;
                bdr.Margin = new Thickness (0, 30, 0, 0);
                bdr.CornerRadius = new CornerRadius (0);
            }
            else if (e == StyleEnum.Style4)
            {

            }
            else if (e == StyleEnum.Style5)
            {

            }
        });
    }
}
