using System.Collections.ObjectModel;
using System.ComponentModel;
using PL.Model;

namespace PL.ViewModel
{
    class CathegoryViewModel : INotifyPropertyChanged
    {
        private readonly CategoryService _categoryService = new CategoryService();
        private static CathegoryViewModel _instance = new CathegoryViewModel();
        public static CathegoryViewModel Instance => _instance;


        public CathegoryViewModel()
        {
            Categories = new ObservableCollection<CategoryModel>(_categoryService.GetCategoryByParentID(1));
        }

        public ObservableCollection<CategoryModel> Categories { get; set; }

        private CategoryModel _selectedCategory;
        public CategoryModel SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }

        public void SetNewCategory(int ParentID)
        {
            Categories = new ObservableCollection<CategoryModel>(_categoryService.GetCategoryByParentID(ParentID));
            OnPropertyChanged(nameof(Categories));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
