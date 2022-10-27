using cookbook.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cookbook.Models
{
    //класс рецепт
    public class Recipe : ObservableObject
    {
        private int _index;
        private string _name;
        private string _category;
        private string _imagePath;
        private int _people;
        private int _time;
        private string _description;
        private Ingredient[] _ingredients;
        private Instruction[] _instructions;
        private bool _isFavorite;
        private bool _isEditable;
        //поле індекс рецепту
        public int Index
        {
            get { return _index; }
            set { OnPropertyChanged(ref _index, value); }
        }
        //поле назва рецепту
        public string Name
        {
            get { return _name; }
            set { OnPropertyChanged(ref _name, value); }
        }
        // поле категорії
        public string Category
        {
            get { return _category; }
            set { OnPropertyChanged(ref _category, value); }
        }
        //поле для завантаження зображення рецепту
        public string ImagePath
        {
            get { return _imagePath; }
            set { OnPropertyChanged(ref _imagePath, value); }
        }
        //поле люди
        public int People
        {
            get { return _people; }
            set { OnPropertyChanged(ref _people, value); }
        }
        // поле яке виводить формат для 
        public string PeopleFormatted
        {
            get { return string.Format("Люди: {0}", _people); }
        }
        //поле часу
        public int Time
        {
            get { return _time; }
            set { OnPropertyChanged(ref _time, value); }
        }
        //поле яке виводить  формат часу
        public string TimeFormatted
        {
            get
            {
                if (Time == 1)
                {
                    return "Время: 1 минута";
                }
                if (Time < 59)
                {
                    return string.Format("Время: {0} мин.", _time.ToString());
                }
                else
                {
                    int hours = _time / 60;
                    int minutes = _time - (hours * 60);
                    if (minutes == 0)
                    {
                        return string.Format("Время: {0} часов", hours.ToString());
                    }
                    else
                    {
                        if (minutes == 1)
                        {
                            return string.Format("Время: {0} часов 1 минута", hours.ToString());
                        }
                        else
                        {
                            return string.Format("Время: {0} часы {1} минуты", hours.ToString(), minutes.ToString());
                        }
                    }
                };
            }

        }
        //поле опису
        public string Description
        {
            get { return _description; }
            set { OnPropertyChanged(ref _description, value); }
        }
        //поле інгрідіентів
        public Ingredient[] Ingredients
        {
            get { return _ingredients; }
            set { OnPropertyChanged(ref _ingredients, value); }
        }
       //Поле інструкції
        public Instruction[] Instructions
        {
            get { return _instructions; }
            set { OnPropertyChanged(ref _instructions, value); }
        }
        //Поле улюблених рецептів
        public bool IsFavorite
        {
            get { return _isFavorite; }
            set { OnPropertyChanged(ref _isFavorite, value); }
        }
        //Поле яке дозволяе редагувати
        public bool IsEditable
        {
            get { return _isEditable; }
            set { OnPropertyChanged(ref _isEditable, value); }
        }
    }
}