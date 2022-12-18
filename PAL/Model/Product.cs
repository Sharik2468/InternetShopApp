using PL.Commands;
using PL.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PL.Model
{
    class Product : INotifyPropertyChanged
    {
        private readonly CategoryService _categoryServ = new CategoryService();
        private readonly ProductService _productServ = new ProductService();
        public Product()
        { }
        public Product(DBAccess.Product_Table product)
        {
            Product_Code = product.Product_Code;
            Name = product.Name_Product;
            PurchasePrice = (float)product.Purchase_Price_Product;
            MarketPrice = (float)product.Market_Price_Product;
            BestBeforeDate = (float)product.Best_Before_Date_Product;
            Desctription = product.Description;
            Image = product.Image;
            NumberInStock = Convert.ToInt32(product.Number_in_Stock);
            DateOfManufacture = (DateTime)product.Date_of_Manufacture_Product;
            CategoryID = (int)product.Category_ID;

            /// Выгрузка изображения
            try
            {
                using (Stream StreamObj = new MemoryStream(product.Image))
                {
                    var image = new BitmapImage();

                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.StreamSource = StreamObj;
                    image.EndInit();
                    ImageToShow = image;
                }
            }
            catch
            {
                //Необходимо использования логгера
                Console.WriteLine($"Ошибка инициализации изображения пользователя {this}");
            }
        }
        public int Product_Code { get; set; }
        public byte[] Image { get; set; }

        private ImageSource _imageToShow;
        public ImageSource ImageToShow
        {
            get => _imageToShow;
            set
            {
                _imageToShow = value;
                OnPropertyChanged(nameof(ImageToShow));
            }
        }

        private int _num;
        public int NumberInStock
        {
            get => _num;
            set
            {
                _num = value;
                OnPropertyChanged(nameof(NumberInStock));
            }
        }

        private int _category;
        public int CategoryID
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged(nameof(CategoryID));
            }
        }

        private string _categoryName;
        public string CategoryName
        {
            get => _categoryName;
            set
            {
                CategoryID = _categoryServ.GetCategoryIDByName(value.ToString()).Category_ID;
                _categoryName = value;
                OnPropertyChanged(nameof(CategoryName));
            }
        }

        private System.DateTime _dateOfManuf;
        public System.DateTime DateOfManufacture
        {
            get => _dateOfManuf;
            set
            {
                _dateOfManuf = value;
                OnPropertyChanged(nameof(DateOfManufacture));
            }
        }

        private string _desc;
        public string Desctription
        {
            get => _desc;
            set
            {
                _desc = value;
                OnPropertyChanged(nameof(Desctription));
            }
        }

        private float _purchasePrice;
        public float PurchasePrice
        {
            get => _purchasePrice;
            set
            {
                _purchasePrice = value;
                OnPropertyChanged(nameof(PurchasePrice));
            }
        }

        private float _marketPrice;
        public float MarketPrice
        {
            get => _marketPrice;
            set
            {
                _marketPrice = value;
                OnPropertyChanged(nameof(MarketPrice));
            }
        }

        private float _bestData;
        public float BestBeforeDate
        {
            get => _bestData;
            set
            {
                _bestData = value;
                OnPropertyChanged(nameof(BestBeforeDate));
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private int _currentAmount;
        public int CurrentAmount
        {
            get => _currentAmount;
            set
            {
                _currentAmount = value;
                OnPropertyChanged(nameof(CurrentAmount));
            }
        }

        private float _currentSum;
        public float CurrentSum
        {
            get => _currentSum;
            set
            {
                _currentSum = value;
                OnPropertyChanged(nameof(CurrentSum));
            }
        }

        private string _currentStatusName;
        public string CurrentStatusName
        {
            get => _currentStatusName;
            set
            {
                    _currentStatusName = value;
                OnPropertyChanged(nameof(CurrentStatusName));
            }
        }

        private RelayCommand _changeOrderItemStatusCommand;
        public RelayCommand ChangeOrderItemStatusCommand => _changeOrderItemStatusCommand ??
                  (_changeOrderItemStatusCommand = new RelayCommand(obj =>
                  {
                      _currentStatusName = OrderViewModel.Instance.ChangeOrderItemStatus(_currentStatusName, _productServ.GetProductByID(Product_Code)[0]);
                  }));

        #region Overides of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
