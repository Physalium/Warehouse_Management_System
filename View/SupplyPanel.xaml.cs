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
    /// Interaction logic for SupplyPanel.xaml
    /// </summary>
    public partial class SupplyPanel : UserControl
    {
        public SupplyPanel()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty SuppliesProperty =
          DependencyProperty.Register(
              "Supplies",
              typeof(IEnumerable),
              typeof(SupplyPanel),
              new FrameworkPropertyMetadata(null)
          );

        public IEnumerable Supplies
        {
            get { return (IEnumerable)GetValue(SuppliesProperty); }
            set { SetValue(SuppliesProperty, value); }
        }

        #region Label properties

        public static readonly DependencyProperty DateLabelProperty =
          DependencyProperty.Register(
              "DateLabel",
              typeof(string),
              typeof(SupplyPanel),
              new FrameworkPropertyMetadata(null)
          );

        public string DateLabel
        {
            get { return (string)GetValue(DateLabelProperty); }
            set { SetValue(DateLabelProperty, value); }
        }

        public static readonly DependencyProperty ValueLabelProperty =
          DependencyProperty.Register(
              "ValueLabel",
              typeof(string),
              typeof(SupplyPanel),
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
              typeof(SupplyPanel),
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
              typeof(SupplyPanel),
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
              typeof(SupplyPanel),
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
              typeof(SupplyPanel),
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
              typeof(SupplyPanel),
              new FrameworkPropertyMetadata(null)
          );

        public string CustomerLabel
        {
            get { return (string)GetValue(CustomerLabelProperty); }
            set { SetValue(CustomerLabelProperty, value); }
        }

        #endregion Label properties
    }
}