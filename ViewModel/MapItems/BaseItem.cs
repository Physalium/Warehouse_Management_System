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

        private double xPos;

        public double XPos
        {
            get
            {
                return xPos;
            }
            set
            {
                xPos = value;
                OnPropertyChanged(nameof(XPos));
            }
        }

        private double yPos;

        public double YPos
        {
            get
            {
                return yPos;
            }
            set
            {
                yPos = value;
                OnPropertyChanged(nameof(YPos));
            }
        }

        private double width;

        public double Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        private double height;

        public double Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        #endregion Props

        public BaseItem((double xPos, double yPos) cityCoord)
        {
            XPos = cityCoord.xPos;
            YPos = cityCoord.yPos;
        }
    }
}