using System.Collections.ObjectModel;
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
        //private void RaisePathChanged()
        //{
        //    RoutedEventArgs newEventArgs =
        //            new RoutedEventArgs(PathChangedEvent);
        //    RaiseEvent(newEventArgs);
        //}

        //     public static readonly RoutedEvent MapItemsChangedEvent =
        //     EventManager.RegisterRoutedEvent("MapItemsChanged",
        //                  RoutingStrategy.Bubble, typeof(RoutedEventHandler),
        //                  typeof(MapControl));

        //     public event RoutedEventHandler MapItemsChanged
        //     {
        //         add { AddHandler(MapItemsChangedEvent, value); }
        //         remove { RemoveHandler(MapItemsChangedEvent, value); }
        //     }

        //     public static readonly RoutedEvent ItemImageChangedEvent =
        //    EventManager.RegisterRoutedEvent("ItemImageChanged",
        //                 RoutingStrategy.Bubble, typeof(RoutedEventHandler),
        //                 typeof(MapControl));





        // public event RoutedEventHandler ItemImageChanged
        // {
        //     add
        //     {
        //         AddHandler(ItemImageChangedEvent, value);
        //     }
        //     remove
        //     {
        //         RemoveHandler(ItemImageChangedEvent, value);
        //     }
        // }

        public static readonly DependencyProperty MapItemsProperty =
            DependencyProperty.Register(
                "MapItems",
                typeof(ObservableCollection<BitmapImage>),
                typeof(MapControl),
                new FrameworkPropertyMetadata(null)
            );


        protected static readonly DependencyProperty MapImageProperty =
            DependencyProperty.Register("MapImage", typeof(BitmapImage), typeof(MapControl));

        public static readonly DependencyProperty ItemImageProperty =
            DependencyProperty.Register(
                "ItemImage",
                typeof(BitmapImage),
                typeof(MapControl),
                new FrameworkPropertyMetadata(null)
            );


        #endregion Events

        #region Dependency props

        

        public ObservableCollection<BitmapImage> MapItems
        {
            get { return (ObservableCollection<BitmapImage>)GetValue(MapItemsProperty); }
            set { SetValue(MapItemsProperty, value); }
        }

        public BitmapImage MapImage
        {
            get { return (BitmapImage)GetValue(MapImageProperty); }
            set { SetValue(MapImageProperty, value); }
        }

        public BitmapImage ItemImage
        {
            get { return (BitmapImage)GetValue(ItemImageProperty); }
            set { SetValue(ItemImageProperty, value); }
        }

        #endregion Dependency props
    }
}