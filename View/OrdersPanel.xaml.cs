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
    /// Interaction logic for OrdersPanel.xaml
    /// </summary>
    public partial class OrdersPanel : UserControl
    {
        public OrdersPanel()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty OrdersProperty =
          DependencyProperty.Register(
              "Orders",
              typeof(IEnumerable),
              typeof(OrdersPanel),
              new FrameworkPropertyMetadata(null)
          );

        public IEnumerable Orders
        {
            get { return (IEnumerable)GetValue(OrdersProperty); }
            set { SetValue(OrdersProperty, value); }
        }
    }
}