using Microsoft.Win32;
using PL.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PL.Model;

namespace PL.ViewModel
{
    class ProductViewModel : INotifyPropertyChanged
    {
        private static ProductViewModel _instance = new ProductViewModel();
        public static ProductViewModel Instance => _instance;
        private readonly ProductService _productService = new ProductService();

        private Product _newProduct;
        public Product NewProduct
        {
            get
            {
                return _newProduct;
            }
            set
            {
                _newProduct = value;
                OnPropertyChanged(nameof(NewProduct));
            }
        }
        public ProductViewModel()
        {
            SetAllProducts();
            setNewProductInstance();
        }

        public void SetAllProducts()
        {
            var NewProducts =_productService.GetProducts(ClientViewModel.Instance.AuthorizedUser.UserTable);
            NewProducts.Reverse();
            Products = new ObservableCollection<Product>(NewProducts);
            OnPropertyChanged(nameof(Products));
        }

        public void setNewProductInstance()
        {
            _newProduct = _newProduct == null ? new Product() : _newProduct;
        }

        public Product getNewProductInstance()
        {
            setNewProductInstance();
            return _newProduct;
        }

        public void SetProductByID(int CategoryID)
        {
            Products = new ObservableCollection<Product>(_productService.GetProductByCategoryID(CategoryID, ClientViewModel.Instance.AuthorizedUser.UserTable));
            OnPropertyChanged(nameof(Products));
        }

        public void SetProductByText(string Text)
        {
            Products = new ObservableCollection<Product>(_productService.GetProductByText(Text, ClientViewModel.Instance.AuthorizedUser.UserTable));
            OnPropertyChanged(nameof(Products));
        }

        private RelayCommand _addCommand;
        public RelayCommand AddCommand => _addCommand ??
                  (_addCommand = new RelayCommand(obj =>
                  {

                      OpenFileDialog openFileDialog = new OpenFileDialog();
                      openFileDialog.Filter = "Файлы рисунков (*.bmp, *.jpg)|*.bmp;*.jpg";
                      openFileDialog.DefaultExt = ".jpeg";
                      if (openFileDialog.ShowDialog().Value)
                      {
                          _productService.AddProduct(getNewProductInstance(), openFileDialog.FileName);
                          Products = new ObservableCollection<Product>(_productService.GetProducts());
                          OnPropertyChanged(nameof(Products));
                      }
                  }));

        private RelayCommand _addAmountCommand;
        public RelayCommand AddAmountCommand => _addAmountCommand ??
                  (_addAmountCommand = new RelayCommand(obj =>
                  {
                      SelectedProduct.NumberInStock++;
                      _productService.Update(SelectedProduct);
                      SetAllProducts();
                  }));

        private RelayCommand _decAmountCommand;
        public RelayCommand DecreaseAmountCommand => _decAmountCommand ??
                  (_decAmountCommand = new RelayCommand(obj =>
                  {
                      SelectedProduct.NumberInStock--;
                      if (SelectedProduct.NumberInStock < 0) return;

                      _productService.Update(SelectedProduct);
                      SetAllProducts();
                  }));

        private RelayCommand _delCommand;
        public RelayCommand DelCommand => _delCommand ??
                  (_delCommand = new RelayCommand(obj =>
                  {
                      _productService.DeleteProduct(SelectedProduct);
                      SetAllProducts();
                  }));

        private RelayCommand _saveCommand;
        public RelayCommand SaveCommand => _saveCommand ??
                  (_saveCommand = new RelayCommand(obj =>
                  {
                      _productService.Update(SelectedProduct);
                  }));

        public ObservableCollection<Product> Products { get; set; }

        private Product _selectedProduct;
        public Product SelectedProduct
        {
            get
            {
                return _selectedProduct;
            }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
