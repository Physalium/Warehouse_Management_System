using System.IO;
using System.Windows.Media.Imaging;
using Warehouse_Management.ViewModel.Base;

namespace Warehouse_Management.ViewModel.MapItems
{
    class BaseItem : BaseViewModel
    {

        #region Props
        private BitmapImage itemImage;

        public BitmapImage ItemImage
        {
            get { return itemImage; }
            set
            {
                itemImage = value;
                OnPropertyChanged(nameof(ItemImage));
            }
        }
        #endregion

        #region Private methods
        protected BitmapImage createBitmap(byte[] data)
        {
            using (Stream stream = new MemoryStream(data))
            {
                BitmapImage image = new BitmapImage();
                stream.Position = 0;
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = stream;
                image.EndInit();
                image.Freeze();
                return image;
            }
        }
        #endregion
    }
}