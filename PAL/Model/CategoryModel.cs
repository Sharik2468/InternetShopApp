using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace PL.Model
{
    class CategoryModel : INotifyPropertyChanged
    {
        public CategoryModel()
        {

        }

        public CategoryModel(DBAccess.Category_Table c)
        {
            Category_ID = c.Category_ID;
            Category_Name = c.Category_Name;
            Parent_ID = c.Parent_ID;
        }

        public int Category_ID
        {
            get => _categoryID;
            set
            {
                _categoryID = value;
                OnPropertyChanged(nameof(Category_ID));
            }
        }
        public string Category_Name
        {
            get => _categoryName;
            set
            {
                _categoryName = value;
                OnPropertyChanged(nameof(Category_Name));
            }
        }
        public int Parent_ID
        {
            get => _parentID;
            set
            {
                _parentID = value;
                OnPropertyChanged(nameof(Parent_ID));
            }
        }

        private int _categoryID;
        private string _categoryName;
        private int _parentID;


        #region Overides of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
