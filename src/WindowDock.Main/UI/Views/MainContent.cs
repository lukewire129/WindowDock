using Jamesnet.Wpf.Controls;
using Jamesnet.Wpf.Global.Event;
using Lombok.NET;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using WindowDock.Core.Enums;
using WindowDock.Core.Event;
using WindowDock.Main.Local.ViewModels;

namespace WindowDock.Main.UI.Views;

[AllArgsConstructor]
public partial class MainContent : JamesContent
{
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
                Style1Change ();
            }
            else if (e == StyleEnum.Style2)
            {
                Style2Change ();
            }
            else if (e == StyleEnum.Style3)
            {
                Style3Change ();
            }
            else if (e == StyleEnum.Style4)
            {
                Style4Change ();
            }
            else if (e == StyleEnum.Style5)
            {

            }
        });
    }
    
    private (double width, double height) GetDockSize()
    {
        var itemsCount = ((MainContentViewModel)this.DataContext).QuickFiles.Count;
        double iconSize = 65.0;

        if(Orientation == Orientation.Vertical)
        {
            Height = (iconSize * itemsCount) + (10.0 * 2);
            Width = iconSize + (20.0 * 2);
        }
        else
        {
            Width = (iconSize * itemsCount) + (20.0 * 2);
            Height = iconSize + (10.0 * 2);
        }

        return (Width, Height);
    }
    Storyboard sb;
    private void Style1Change()
    {
        sb?.Remove ();
        Orientation = Orientation.Horizontal;
        var size = GetDockSize ();
        bdr.Width = size.width;
        bdr.Height = Double.NaN;
        bdr.Margin = new Thickness (0, 0, 0, 0);
        bdr.CornerRadius = new CornerRadius (7);
    }

    private void Style2Change()
    {
        sb?.Remove ();
        Orientation = Orientation.Vertical;
        var size = GetDockSize ();

        bdr.Width = size.width;
        bdr.Height = size.height;
        bdr.Margin = new Thickness (0, 0, 0, 0);
        bdr.CornerRadius = new CornerRadius (7);
    }


    private void Style3Change()
    {
        sb?.Remove ();
        Orientation = Orientation.Horizontal;
        var size = GetDockSize ();
        bdr.Width = size.width;
        bdr.Height = size.height;
        HeightSizeChange (Style3 (30));
        bdr.Margin = new Thickness (0, 30, 0, 0);
        bdr.CornerRadius = new CornerRadius (0);
    }

    private void Style4Change()
    {
        sb?.Remove ();
        Orientation = Orientation.Horizontal;
        var size = GetDockSize ();
        bdr.Width = size.width;
        bdr.Height = size.height;
        HeightSizeChange (Style4 (30));
        bdr.Margin = new Thickness (0, 30, 0, 0);
        bdr.CornerRadius = new CornerRadius (0);
    }
    private void HeightSizeChange(DoubleAnimation da)
    {
        BounceEase bounceEase = new BounceEase ();
        bounceEase.EasingMode = EasingMode.EaseIn;
        da.EasingFunction = bounceEase;
        sb = new Storyboard ();
        sb.Children.Add (da);
        Storyboard.SetTarget (sb, bdr);
        Storyboard.SetTargetProperty (sb, new PropertyPath ("Height"));
        Storyboard.SetTargetName (sb, "bdr");

        sb.Begin ();
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
