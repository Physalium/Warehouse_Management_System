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
    /// Interaction logic for Sidebar.xaml
    /// </summary>
    public partial class Sidebar : UserControl
    {
        public Sidebar()
        {
            InitializeComponent();
        }

        #region Events

        public static readonly DependencyProperty ProductsProperty =
          DependencyProperty.Register(
              "Products",
              typeof(IEnumerable),
              typeof(Sidebar),
              new FrameworkPropertyMetadata(null)
          );

        protected static readonly DependencyProperty ProductsLabelProperty =
            DependencyProperty.Register("ProductsLabel", typeof(string), typeof(Sidebar));

        #endregion Events

        #region Props

        public IEnumerable Products
        {
            get { return (IEnumerable)GetValue(ProductsProperty); }
            set { SetValue(ProductsProperty, value); }
        }

        public string ProductsLabel
        {
            get { return (string)GetValue(ProductsLabelProperty); }
            set { SetValue(ProductsLabelProperty, value); }

            #endregion Props
        }
    }
}