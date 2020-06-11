using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Warehouse_Management.View
{
    /// <summary>
    /// Interaction logic for PanelTC.xaml
    /// </summary>
    ///
    public partial class MapControl : UserControl
    {
        public MapControl()
        {
            InitializeComponent();
        }

        #region Events


        //public static readonly RoutedEvent PathChangedEvent =
        //EventManager.RegisterRoutedEvent("PathChanged",
        //             RoutingStrategy.Bubble, typeof(RoutedEventHandler),
        //             typeof(MapControl));

        // public event RoutedEventHandler PathChanged
        // {
        //     add { AddHandler(PathChangedEvent, value); }
        //     remove { RemoveHandler(PathChangedEvent, value); }
        // }

        // public static readonly RoutedEvent PathEnterEvent =
        //EventManager.RegisterRoutedEvent("PathEnter",
        //             RoutingStrategy.Bubble, typeof(RoutedEventHandler),
        //             typeof(MapControl));

        // public event RoutedEventHandler PathEnter
        // {
        //     add { AddHandler(PathChangedEvent, value); }
        //     remove { RemoveHandler(PathChangedEvent, value); }
        // }

        // private void RaisePathChanged()
        // {
        //     RoutedEventArgs newEventArgs =
        //             new RoutedEventArgs(PathChangedEvent);
        //     RaiseEvent(newEventArgs);
        // }

        // public static readonly DependencyProperty PathProperty =
        //     DependencyProperty.Register(
        //         "Path",
        //         typeof(string),
        //         typeof(MapControl),
        //         new FrameworkPropertyMetadata(null)
        //     );


        protected static readonly DependencyProperty MapImageProperty =
            DependencyProperty.Register("MapImage", typeof(BitmapImage), typeof(MapControl));

        #endregion Events

        #region Dependency props

        public BitmapImage MapImage
        {
            get { return (BitmapImage)GetValue(MapImageProperty); }
            set { SetValue(MapImageProperty, value); }
        }


        #endregion Dependency props

        #region Internal event handlers


        #endregion Internal event handlers
    }
}