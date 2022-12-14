using cookbook.Models;
using cookbook.Services;
using cookbook.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace cookbook.ViewModels
{
    public class CookbookViewModel : ObservableObject, IPageViewModel
    {

        private ObservableCollection<Recipe> _recipes;
        private IRecipeDataService _dataService;
        public ICommand LoadRecipeCommand { get; private set; }

        public ICommand LoadAllRecipesCommand { get; private set; }
        public ICommand LoadFavoriteRecipesCommand { get; private set; }
        public ICommand LoadDessertsCommand { get; private set; }
        public ICommand LoadSoupsCommand { get; private set; }
        public ICommand LoadLunchesCommand { get; private set; }
        public ICommand LoadDinnersCommand { get; private set; }
        public ICommand LoadBreakfastsCommand { get; private set; }
        public ICommand LoadAppetizersCommand { get; private set; }
        public ICommand LoadEditRecipeViewModelCommand { get; private set; }
        //поле колекції рецептів
        public ObservableCollection<Recipe> Recipes
        {
            get { return _recipes; }
            set { OnPropertyChanged(ref _recipes, value); }
        }
        //
        public CookbookViewModel(IRecipeDataService dataService, string mode = "All")
        {
            _dataService = dataService;

            LoadRecipeCommand = new RelayCommand(LoadRecipe);
            LoadFavoriteRecipesCommand = new RelayCommand(LoadFavoriteRecipes);
            LoadAllRecipesCommand = new RelayCommand(LoadRecipes);
            LoadDessertsCommand = new RelayCommand(LoadDesserts);
            LoadSoupsCommand = new RelayCommand(LoadSoups);
            LoadLunchesCommand = new RelayCommand(LoadLunches);
            LoadDinnersCommand = new RelayCommand(LoadDinners);
            LoadBreakfastsCommand = new RelayCommand(LoadBreakfasts);
            LoadAppetizersCommand = new RelayCommand(LoadAppetizers);

            LoadEditRecipeViewModelCommand = new RelayCommand(LoadAddRecipe);

            Mediator.Subscribe("LoadAll", LoadAllRecipes);
            Mediator.Subscribe("AddRecipe", AddRecipe);
            Mediator.Subscribe("RemoveRecipe", RemoveRecipe);
            if (mode == "All")
            {
                LoadAllRecipes("");
            }
        }
        //функція завантаження рецепту
        private void LoadRecipe(object obj)
        {
            Mediator.Notify("LoadRecipeView", obj);
        }
        //функція завантаження всих рецептів
        private void LoadAllRecipes(object obj)
        {
            Recipes = new ObservableCollection<Recipe>(_dataService.GetRecipes());
        }
        //функція завантаження рецептів
        private void LoadRecipes(object obj)
        {
            Recipes = new ObservableCollection<Recipe>(_dataService.GetRecipes());
        }
        //функція завантаження улюблених рецептів
        private void LoadFavoriteRecipes(object obj)
        {
            Recipes = new ObservableCollection<Recipe>(_dataService.GetRecipes().Where(c => c.IsFavorite));
        }
        //функція завантаження дисерту
        private void LoadDesserts(object obj)
        {
            Recipes = new ObservableCollection<Recipe>(_dataService.GetRecipes().Where(c => c.Category == "Десерт"));
        }
        //функція завантаження супу
        private void LoadSoups(object obj)
        {
            Recipes = new ObservableCollection<Recipe>(_dataService.GetRecipes().Where(c => c.Category == "Суп"));
        }
        //функція перевірки ланч
        private void LoadLunches(object obj)
        {
            Recipes = new ObservableCollection<Recipe>(_dataService.GetRecipes().Where(c => c.Category == "Обед"));
        }
        //функція перевірки обід
        private void LoadDinners(object obj)
        {
            Recipes = new ObservableCollection<Recipe>(_dataService.GetRecipes().Where(c => c.Category == "Ужин"));
        }
        //функція перевірки завтрак 
        private void LoadBreakfasts(object obj)
        {
            Recipes = new ObservableCollection<Recipe>(_dataService.GetRecipes().Where(c => c.Category == "Завтрак"));
        }
        //функція перевірки закуски
        private void LoadAppetizers(object obj)
        {
            Recipes = new ObservableCollection<Recipe>(_dataService.GetRecipes().Where(c => c.Category == "Закуска"));
        }
        //функція завантаження всіх рецептів
        private void LoadAddRecipe(object obj)
        {
            Mediator.Notify("LoadAddRecipeView", "ALL");
        }
        //функція яка додае рецепт
        private void AddRecipe(object obj)
        {
            Recipe recipe = (Recipe)obj;
            if (recipe.Index != 0)
            {
                foreach (Recipe recipeObj in Recipes)
                {
                    if (recipe.Index == recipeObj.Index)
                    {
                        recipe.Index = recipeObj.Index;

                        Recipes.Remove(recipeObj);
                        break;
                    }
                }
            }
            else
            {
                int numOfRecipes = Recipes.Count;

                if (numOfRecipes == 0)
                {
                    recipe.Index = 1;
                }
                else
                {
                    int maxIndex = 0;
                    foreach (Recipe recipeObj in Recipes)
                    {
                        if (recipeObj.Index > maxIndex)
                        {
                            maxIndex = recipeObj.Index;
                        }
                    }
                    int index = maxIndex + 1;
                    recipe.Index = index;
                }
            }
            Recipes.Add(recipe);
            _dataService.Save(Recipes);
        }
        //функція яка видаляе рецепт
        private void RemoveRecipe(object obj)
        {
            Recipe recipe = (Recipe)obj;

            foreach (Recipe recipeObj in Recipes)
            {
                if (recipe.Index == recipeObj.Index)
                {
                    Recipes.Remove(recipeObj);
                    break;
                }
            }
            _dataService.Save(Recipes);
        }
    }
}
