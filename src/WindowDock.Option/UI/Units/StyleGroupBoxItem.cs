using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WindowDock.Option.Local.Models;

namespace WindowDock.Option.UI.Units;

public class StyleGroupBoxItem :ListBoxItem
{
    public static readonly DependencyProperty SelectStyleCommandProperty;
    public ICommand SelectStyleCommand
    {
        get { return (ICommand)GetValue (SelectStyleCommandProperty); }
        set { SetValue (SelectStyleCommandProperty, value); }
    }
    static StyleGroupBoxItem()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(StyleGroupBoxItem), new FrameworkPropertyMetadata(typeof(StyleGroupBoxItem)));
        SelectStyleCommandProperty = DependencyProperty.Register ("SelectStyleCommand", typeof (ICommand), typeof (StyleGroupBoxItem), null);
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate ();

        var rb =GetTemplateChild ("PART_Btn") as RadioButton;
        rb.Checked += (s, e) =>
        {
            SelectStyleCommand.Execute (this.DataContext as StyleModel);
        };
    }
}
