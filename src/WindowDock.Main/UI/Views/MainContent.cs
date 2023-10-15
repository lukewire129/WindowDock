using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Event;
using Lombok.NET;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
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
                Style3Change ();
            }
            else if (e == StyleEnum.Style4)
            {
                Orientation = Orientation.Horizontal;
                Style4Change ();
            }
            else if (e == StyleEnum.Style5)
            {

            }
        });
    }
    private void Style1Change()
    {
        var a = this.Width;
        Orientation = Orientation.Horizontal;

        var tempwidth = this.ActualWidth;
        Style1WidthInit (tempwidth);
    }

    private Task Style1WidthInit(double width) 
    {
        Task.Delay (100);
        Dispatcher.BeginInvoke (() =>
        {
            var _da = Style1 (width, 0);
            _da.Completed += (s, e) =>
            {
                bdr.Margin = new Thickness (0, 0, 0, 0);
                bdr.CornerRadius = new CornerRadius (7);

                StyleWidthComplte (width);
            };
            WidthSizeChange (_da);
        });
        return Task.CompletedTask;
    }

    private Task StyleWidthComplte(double width)
    {
        Dispatcher.BeginInvoke (() =>
        {
            bdr.Margin = new Thickness (0, 0, 0, 0);
            bdr.CornerRadius = new CornerRadius (7);

            var _da2 = Style1 (0, width);
            WidthSizeChange (_da2);
            _da2.Completed += (s, e) =>
            {
                StyleWidth ();
            };
        });
        return Task.CompletedTask;
    }

    private Task StyleWidth()
    {
        this.Width = double.NaN;
        return Task.CompletedTask;
    }

    private void Style3Change()
    {
        var _da = Style3 (30);
        HeightSizeChange (_da);
        bdr.Margin = new Thickness (0, 30, 0, 0);
        bdr.CornerRadius = new CornerRadius (0);
    }

    private void Style4Change()
    {
        var _da = Style4 (30);
        HeightSizeChange (_da);
        bdr.Margin = new Thickness (0, 30, 0, 0);
        bdr.CornerRadius = new CornerRadius (0);
    }
    private void WidthSizeChange(DoubleAnimation da)
    {
        this.BeginAnimation (JamesContent.WidthProperty, da);
    }
    private void HeightSizeChange(DoubleAnimation da)
    {
        BounceEase bounceEase = new BounceEase ();
        bounceEase.EasingMode = EasingMode.EaseIn;
        da.EasingFunction = bounceEase;

        bdr.BeginAnimation (Border.HeightProperty, da);        
    }
    private DoubleAnimation Style1(double from, double to)
    {
        DoubleAnimation sizeAnimation = new (from, to, new Duration (TimeSpan.FromSeconds (1)));
        sizeAnimation.AutoReverse = false;
        return sizeAnimation;
    }
    private DoubleAnimation Style3(double to)
    {
        DoubleAnimation sizeAnimation = new (0, to, new Duration (TimeSpan.FromSeconds (3)));
        sizeAnimation.AutoReverse = false;
        return sizeAnimation;
    }
    private DoubleAnimation Style4(double to)
    {
        DoubleAnimation sizeAnimation = new (0, to, new Duration (TimeSpan.FromSeconds (5)));
        sizeAnimation.AutoReverse = true;
        sizeAnimation.RepeatBehavior = RepeatBehavior.Forever;
        return sizeAnimation;
    }
}
