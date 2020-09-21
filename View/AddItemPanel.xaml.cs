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
    /// Interaction logic for AddItemPanel.xaml
    /// </summary>
    public partial class AddItemPanel : UserControl
    {
        public AddItemPanel()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ItemsProperty =
        DependencyProperty.Register(
            "Items",
            typeof(IEnumerable),
            typeof(AddItemPanel),
            new FrameworkPropertyMetadata(null)
        );

        public IEnumerable Items
        {
            get { return (IEnumerable)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty =
         DependencyProperty.Register(
             "SelectedItem",
             typeof(object),
             typeof(AddItemPanel),
             new FrameworkPropertyMetadata(null)
         );

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
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

        public static readonly DependencyProperty FirstFieldNameProperty =
          DependencyProperty.Register(
              "FirstFieldName",
              typeof(string),
              typeof(AddItemPanel),
              new FrameworkPropertyMetadata(null)
          );

        public string FirstFieldName
        {
            get { return (string)GetValue(FirstFieldNameProperty); }
            set { SetValue(FirstFieldNameProperty, value); }
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

        public static readonly DependencyProperty SecondFieldNameProperty =
         DependencyProperty.Register(
             "SecondFieldName",
             typeof(string),
             typeof(AddItemPanel),
             new FrameworkPropertyMetadata(null)
         );

        public string SecondFieldName
        {
            get { return (string)GetValue(SecondFieldNameProperty); }
            set { SetValue(SecondFieldNameProperty, value); }
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

        public static readonly DependencyProperty ThirdFieldNameProperty =
         DependencyProperty.Register(
             "ThirdFieldName",
             typeof(string),
             typeof(AddItemPanel),
             new FrameworkPropertyMetadata(null)
         );

        public string ThirdFieldName
        {
            get { return (string)GetValue(ThirdFieldNameProperty); }
            set
            {
                SetValue(ThirdFieldNameProperty, value);
            }
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

        public static readonly DependencyProperty FourthFieldNameProperty =
         DependencyProperty.Register(
             "FourthFieldName",
             typeof(string),
             typeof(AddItemPanel),
             new FrameworkPropertyMetadata(null)
         );

        public string FourthFieldName
        {
            get { return (string)GetValue(FourthFieldNameProperty); }
            set
            {
                SetValue(FourthFieldNameProperty, value);
            }
        }

        public static readonly DependencyProperty FourthFieldVisProperty =
         DependencyProperty.Register(
             "FourthFieldVis",
             typeof(Visibility),
             typeof(AddItemPanel),
             new FrameworkPropertyMetadata(null)
         );

        public Visibility FourthFieldVis
        {
            get { return (Visibility)GetValue(FourthFieldVisProperty); }
            set
            {
                SetValue(FourthFieldVisProperty, value);
            }
        }

        public static readonly DependencyProperty ThirdFieldVisProperty =
        DependencyProperty.Register(
            "ThirdFieldVis",
            typeof(Visibility),
            typeof(AddItemPanel),
            new FrameworkPropertyMetadata(null)
        );

        public Visibility ThirdFieldVis
        {
            get { return (Visibility)GetValue(ThirdFieldVisProperty); }
            set
            {
                SetValue(ThirdFieldVisProperty, value);
            }
        }
    }
}