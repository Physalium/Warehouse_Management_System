using System.IO;
using System.Windows.Media.Imaging;

using Warehouse_Management.ViewModel.Base;

namespace Warehouse_Management.ViewModel.MapItems
{
    internal class BaseItem : BaseViewModel
    {
        #region Props

        private BitmapImage itemImage;
        public BitmapImage ItemImage
        {
            get
            {
                return itemImage;
            }
            set
            {
                itemImage = value;
                OnPropertyChanged(nameof(ItemImage));
            }
        }

        private double left;

        public double Left
        {
            get
            {
                return left;
            }
            set
            {
                left = value;
                OnPropertyChanged(nameof(Left));
            }
        }

        private double top;

        public double Top
        {
            get
            {
                return top;
            }
            set
            {
                top = value;
                OnPropertyChanged(nameof(Top));
            }
        }


        #endregion Props


    }
}