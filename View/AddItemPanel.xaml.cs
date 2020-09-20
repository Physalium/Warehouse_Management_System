using System;
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
    /// Interaction logic for AddItemPanel.xaml
    /// </summary>
    public partial class AddItemPanel : UserControl
    {
        public AddItemPanel()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty FirstFieldProperty =
          DependencyProperty.Register(
              "FirstField",
              typeof(string),
              typeof(AddItemPanel),
              new FrameworkPropertyMetadata(null)
          );

        public string FirstField
        {
            get { return (string)GetValue(FirstFieldProperty); }
            set { SetValue(FirstFieldProperty, value); }
        }

        public static readonly DependencyProperty SecondFieldProperty =
          DependencyProperty.Register(
              "SecondField",
              typeof(string),
              typeof(AddItemPanel),
              new FrameworkPropertyMetadata(null)
          );

        public string SecondField
        {
            get { return (string)GetValue(SecondFieldProperty); }
            set { SetValue(SecondFieldProperty, value); }
        }

        public static readonly DependencyProperty ThirdFieldProperty =
          DependencyProperty.Register(
              "ThirdField",
              typeof(string),
              typeof(AddItemPanel),
              new FrameworkPropertyMetadata(null)
          );

        public string ThirdField
        {
            get { return (string)GetValue(ThirdFieldProperty); }
            set { SetValue(ThirdFieldProperty, value); }
        }

        public static readonly DependencyProperty FourthFieldProperty =
          DependencyProperty.Register(
              "FourthField",
              typeof(string),
              typeof(AddItemPanel),
              new FrameworkPropertyMetadata(null)
          );

        public string FourthField
        {
            get { return (string)GetValue(FourthFieldProperty); }
            set { SetValue(FourthFieldProperty, value); }
        }
    }
}