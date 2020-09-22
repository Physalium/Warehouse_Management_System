using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Warehouse_Management.View
{
    /// <summary>
    /// Interaction logic for AddOrderPanel.xaml
    /// </summary>
    public partial class AddOrderPanel : UserControl
    {
        public AddOrderPanel()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty WarehouseListProperty =
           DependencyProperty.Register(
               "WarehousesList",
               typeof(IEnumerable),
               typeof(AddOrderPanel),
               new FrameworkPropertyMetadata(null)
           );

        public IEnumerable WarehousesList
        {
            get { return (IEnumerable)GetValue(WarehouseListProperty); }
            set { SetValue(WarehouseListProperty, value); }
        }

        public static readonly DependencyProperty CustomersListProperty =
          DependencyProperty.Register(
              "CustomersList",
              typeof(IEnumerable),
              typeof(AddOrderPanel),
              new FrameworkPropertyMetadata(null)
          );

        public IEnumerable CustomersList
        {
            get { return (IEnumerable)GetValue(CustomersListProperty); }
            set { SetValue(CustomersListProperty, value); }
        }

        public static readonly DependencyProperty TrucksListProperty =
          DependencyProperty.Register(
              "TrucksList",
              typeof(IEnumerable),
              typeof(AddOrderPanel),
              new FrameworkPropertyMetadata(null)
          );

        public IEnumerable TrucksList
        {
            get { return (IEnumerable)GetValue(TrucksListProperty); }
            set { SetValue(TrucksListProperty, value); }
        }

        public static readonly DependencyProperty SemitrailersListProperty =
          DependencyProperty.Register(
              "SemitrailersList",
              typeof(IEnumerable),
              typeof(AddOrderPanel),
              new FrameworkPropertyMetadata(null)
          );

        public IEnumerable SemitrailersList
        {
            get { return (IEnumerable)GetValue(SemitrailersListProperty); }
            set { SetValue(SemitrailersListProperty, value); }
        }

        public static readonly DependencyProperty ProductsListProperty =
          DependencyProperty.Register(
              "ProductsList",
              typeof(IEnumerable),
              typeof(AddOrderPanel),
              new FrameworkPropertyMetadata(null)
          );

        public IEnumerable ProductsList
        {
            get { return (IEnumerable)GetValue(ProductsListProperty); }
            set { SetValue(ProductsListProperty, value); }
        }

        public static readonly DependencyProperty SelectedProductsProperty =
            DependencyProperty.Register(
                "SelectedProducts",
                typeof(IList),
                typeof(AddOrderPanel),
                new FrameworkPropertyMetadata(null)
            );

        public static readonly DependencyProperty MessageTextProperty =
         DependencyProperty.Register(
             "MessageText",
             typeof(string),
             typeof(AddOrderPanel),
             new FrameworkPropertyMetadata(null)
         );

        public string MessageText
        {
            get { return (string)GetValue(MessageTextProperty); }
            set { SetValue(MessageTextProperty, value); }
        }

        public IList SelectedProducts
        {
            get { return (IList)GetValue(SelectedProductsProperty); }
            set { SetValue(SelectedProductsProperty, value); }
        }

        public static readonly DependencyProperty SelectedSemitrailerProperty =
            DependencyProperty.Register(
                "SelectedSemitrailer",
                typeof(object),
                typeof(AddOrderPanel),
                new FrameworkPropertyMetadata(null)
            );

        public object SelectedSemitrailer
        {
            get { return GetValue(SelectedSemitrailerProperty); }
            set { SetValue(SelectedSemitrailerProperty, value); }
        }

        public static readonly DependencyProperty SelectedTruckProperty =
            DependencyProperty.Register(
                "SelectedTruck",
                typeof(object),
                typeof(AddOrderPanel),
                new FrameworkPropertyMetadata(null)
            );

        public object SelectedTruck
        {
            get { return GetValue(SelectedTruckProperty); }
            set { SetValue(SelectedTruckProperty, value); }
        }

        public static readonly DependencyProperty SelectedWarehouseProperty =
            DependencyProperty.Register(
                "SelectedWarehouse",
                typeof(object),
                typeof(AddOrderPanel),
                new FrameworkPropertyMetadata(null)
            );

        public object SelectedWarehouse
        {
            get { return GetValue(SelectedWarehouseProperty); }
            set { SetValue(SelectedWarehouseProperty, value); }
        }

        public static readonly DependencyProperty SelectedCustomerProperty =
            DependencyProperty.Register(
                "SelectedCustomer",
                typeof(object),
                typeof(AddOrderPanel),
                new FrameworkPropertyMetadata(null)
            );

        public object SelectedCustomer
        {
            get { return GetValue(SelectedCustomerProperty); }
            set { SetValue(SelectedCustomerProperty, value); }
        }

        #region Label properties

        public static readonly DependencyProperty DateLabelProperty =
          DependencyProperty.Register(
              "DateLabel",
              typeof(string),
              typeof(AddOrderPanel),
              new FrameworkPropertyMetadata(null)
          );

        #region AddToWarehouse

        public static readonly DependencyProperty CreateOrderProperty =
            DependencyProperty.Register(
                "CreateOrder",
                typeof(ICommand),
                typeof(AddOrderPanel),
                new UIPropertyMetadata(null));

        public ICommand CreateOrder
        {
            get { return (ICommand)GetValue(CreateOrderProperty); }
            set { SetValue(CreateOrderProperty, value); }
        }

        #endregion AddToWarehouse

        public string DateLabel
        {
            get { return (string)GetValue(DateLabelProperty); }
            set { SetValue(DateLabelProperty, value); }
        }

        public static readonly DependencyProperty ValueLabelProperty =
          DependencyProperty.Register(
              "ValueLabel",
              typeof(string),
              typeof(AddOrderPanel),
              new FrameworkPropertyMetadata(null)
          );

        public string ValueLabel
        {
            get { return (string)GetValue(ValueLabelProperty); }
            set { SetValue(ValueLabelProperty, value); }
        }

        public static readonly DependencyProperty WarehouseLabelProperty =
          DependencyProperty.Register(
              "WarehouseLabel",
              typeof(string),
              typeof(AddOrderPanel),
              new FrameworkPropertyMetadata(null)
          );

        public string WarehouseLabel
        {
            get { return (string)GetValue(WarehouseLabelProperty); }
            set { SetValue(WarehouseLabelProperty, value); }
        }

        public static readonly DependencyProperty TruckLabelProperty =
          DependencyProperty.Register(
              "TruckLabel",
              typeof(string),
              typeof(AddOrderPanel),
              new FrameworkPropertyMetadata(null)
          );

        public string TruckLabel
        {
            get { return (string)GetValue(TruckLabelProperty); }
            set { SetValue(TruckLabelProperty, value); }
        }

        public static readonly DependencyProperty SemitrailerLabelProperty =
          DependencyProperty.Register(
              "SemitrailerLabel",
              typeof(string),
              typeof(AddOrderPanel),
              new FrameworkPropertyMetadata(null)
          );

        public string SemitrailerLabel
        {
            get { return (string)GetValue(SemitrailerLabelProperty); }
            set { SetValue(SemitrailerLabelProperty, value); }
        }

        public static readonly DependencyProperty ProductsLabelProperty =
          DependencyProperty.Register(
              "ProductsLabel",
              typeof(string),
              typeof(AddOrderPanel),
              new FrameworkPropertyMetadata(null)
          );

        public string ProductsLabel
        {
            get { return (string)GetValue(ProductsLabelProperty); }
            set { SetValue(ProductsLabelProperty, value); }
        }

        public static readonly DependencyProperty CustomerLabelProperty =
          DependencyProperty.Register(
              "CustomerLabel",
              typeof(string),
              typeof(AddOrderPanel),
              new FrameworkPropertyMetadata(null)
          );

        public string CustomerLabel
        {
            get { return (string)GetValue(CustomerLabelProperty); }
            set { SetValue(CustomerLabelProperty, value); }
        }

        #endregion Label properties

        public static readonly DependencyProperty SelectedDateProperty =
          DependencyProperty.Register(
              "SelectedDate",
              typeof(DateTime),
              typeof(AddOrderPanel),
              new FrameworkPropertyMetadata(null)
          );

        public DateTime SelectedDate
        {
            get { return (DateTime)GetValue(SelectedDateProperty); }
            set { SetValue(SelectedDateProperty, value); }
        }
    }
}