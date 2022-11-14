using Microsoft.Win32;
using PL.Commands;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PL.Model;

namespace PL.ViewModel
{
    class ProductViewModel : INotifyPropertyChanged
    {
        private readonly ProductService _productService = new ProductService();
        public ProductViewModel()
        {
            Products = new ObservableCollection<Product>(_productService.GetProducts());
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
                          Product product = new Product();
                          _productService.AddProduct(product, openFileDialog.FileName);
                          Products = new ObservableCollection<Product>(_productService.GetProducts());
                          OnPropertyChanged(nameof(Products));
                      }
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
