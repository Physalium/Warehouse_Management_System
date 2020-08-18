using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace Warehouse_Management.View
{
    /// <summary>
    /// Interaction logic for Sidebar.xaml
    /// </summary>
    public partial class Sidebar : UserControl
    {
        public Sidebar()
        {
            InitializeComponent();
        }

        #region Props

        public static readonly DependencyProperty SemitrailersProperty =
         DependencyProperty.Register(
             "Semitrailers",
             typeof(IEnumerable),
             typeof(Sidebar),
             new FrameworkPropertyMetadata(null)
         );

        public static readonly DependencyProperty SemitrailersLabelProperty =
            DependencyProperty.Register(
                "SemitrailersLabel",
                typeof(string),
                typeof(Sidebar),
                new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty TrucksProperty =
         DependencyProperty.Register(
             "Trucks",
             typeof(IEnumerable),
             typeof(Sidebar),
             new FrameworkPropertyMetadata(null)
         );

        public static readonly DependencyProperty TrucksLabelProperty =
            DependencyProperty.Register(
                "TrucksLabel",
                typeof(string),
                typeof(Sidebar),
                new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty ProductsProperty =
          DependencyProperty.Register(
              "Products",
              typeof(IEnumerable),
              typeof(Sidebar),
              new FrameworkPropertyMetadata(null)
          );

        public static readonly DependencyProperty ProductsLabelProperty =
            DependencyProperty.Register(
                "ProductsLabel",
                typeof(string),
                typeof(Sidebar),
                new FrameworkPropertyMetadata(null));

        public static readonly DependencyProperty WarehouseNameProperty =
            DependencyProperty.Register(nameof(WarehouseName),
                typeof(string),
                typeof(Sidebar),
                new FrameworkPropertyMetadata(null));

        public IEnumerable Products
        {
            get { return (IEnumerable)GetValue(ProductsProperty); }
            set { SetValue(ProductsProperty, value); }
        }

        public string ProductsLabel
        {
            get { return (string)GetValue(ProductsLabelProperty); }
            set { SetValue(ProductsLabelProperty, value); }
        }

        public IEnumerable Trucks
        {
            get { return (IEnumerable)GetValue(TrucksProperty); }
            set { SetValue(TrucksProperty, value); }
        }

        public string TrucksLabel
        {
            get { return (string)GetValue(TrucksLabelProperty); }
            set { SetValue(TrucksLabelProperty, value); }
        }

        public IEnumerable Semitrailers
        {
            get { return (IEnumerable)GetValue(SemitrailersProperty); }
            set { SetValue(SemitrailersProperty, value); }
        }

        public string SemitrailersLabel
        {
            get { return (string)GetValue(SemitrailersLabelProperty); }
            set { SetValue(SemitrailersLabelProperty, value); }
        }

        public string WarehouseName
        {
            get { return (string)GetValue(WarehouseNameProperty); }
            set { SetValue(WarehouseNameProperty, value); }
        }

        #endregion Props
    }
}