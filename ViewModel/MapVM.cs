using System.IO;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

using Warehouse_Management.ViewModel.Base;

namespace Warehouse_Management.ViewModel
{
    using R = Properties.Resources;
    internal class MapVM : BaseViewModel
    {
        #region Props
        private BitmapImage mapImage;

        public BitmapImage MapImage
        {
            get { return mapImage; }
            set
            {
                mapImage = value;
                OnPropertyChanged(nameof(MapImage));
            }
        }

        #endregion
        public MapVM()
        {
            mapImage = createBitmap(R.MapImage);
        }

        #region Private methods
        private BitmapImage createBitmap(byte[] data)
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