using System.Collections;
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

        private void RaiseItemClicked()
        {
            RoutedEventArgs newEventArgs =
                    new RoutedEventArgs(ItemClickedEvent);
            RaiseEvent(newEventArgs);
        }

        public static readonly RoutedEvent ItemClickedEvent =
        EventManager.RegisterRoutedEvent("ItemClicked",
                     RoutingStrategy.Bubble, typeof(RoutedEventHandler),
                     typeof(MapControl));

        public event RoutedEventHandler ItemClicked
        {
            add { AddHandler(ItemClickedEvent, value); }
            remove { RemoveHandler(ItemClickedEvent, value); }
        }

        public static readonly DependencyProperty MapItemsProperty =
            DependencyProperty.Register(
                "MapItems",
                typeof(IEnumerable),
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

        public IEnumerable MapItems
        {
            get { return (IEnumerable)GetValue(MapItemsProperty); }
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

        #region Internal Event Handlers

        private void Image_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            RaiseItemClicked();
        }

        #endregion Internal Event Handlers
    }
}