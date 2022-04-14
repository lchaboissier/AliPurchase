using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AliPurchase.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AliPurchase.ViewModels
{
    class StocksViewModel : ObservableObject
    {
        // Properties : Datas needed to be binded/registered in the view StocksView
        private List<Category> _categories;
        private Category _selectedCategory;
        private String _productsTitle;
        // Properties and Getters/Setters: Action commands needed to be binded /registered to interact with the view StockView
        public RelayCommand FlushCommand { get; private set; }
        public RelayCommand<object> CategoryRowSelectedCommand { get; private set; }

        // Getters and Setters only for the datas
        public List<Category> Categories
        {
            get
            {
                return _categories;
            }
            set { this.SetProperty(ref _categories, value); }
        }

        public Category SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {
                this.SetProperty(ref _selectedCategory, value);
            }
        }

        public String ProductsTitle
        {
            get
            {
                return _productsTitle;
            }
            set
            {
                this.SetProperty(ref _productsTitle, value);
            }
        }
        // Constructor 
        public StocksViewModel()
        {
            Console.WriteLine("StocksViewModel - Constructor");

            // The default title of the products list of the selected category
            ProductsTitle = "Pas de catégorie sélectionnée";

            // Init the RelayCommands
            this.FlushCommand = new RelayCommand(FlushAction);
            this.CategoryRowSelectedCommand = new RelayCommand<object>(CategoryRowSelectedAction);

            // Get the datas for the view
            this.Categories = Category.All();
        }

        // Object methods that interract with the actions commands
        private void FlushAction()
        {
            Console.WriteLine("StockViewModel - FlushAction");

            // Reload the datas for the view
            Categories = Category.All();
        }

        private void CategoryRowSelectedAction(object SelectedItem)
        {
            Console.WriteLine("StockViewModel - CategoryRowSelectedAction");

            Console.WriteLine(((Category)SelectedItem).Name);

            // Reload the datas for the view
            SelectedCategory = Category.Find(((Category)SelectedItem).Id);
            ProductsTitle = "Listes de produits de la catégorie " + SelectedCategory.Name;
        }

    }
}
