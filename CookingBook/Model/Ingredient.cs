using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cookbook.Models
{
    //класс Інгрідіент
    public class Ingredient
    {
        private int _index;
        private string _name;
        private string _amount;
        private string _unit;
        //поле індексу
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
        //поле назви інгрідіенту
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        //поле кількості
        public string Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
        // поле одениць
        public string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }
        //поле формату кількості
        public string AmountFormatted
        {
            get { return string.Format("{0} {1}", _amount, _unit); }
        }
        //поле формату індексу інгрідіенту
        public string IndexFormatted
        {
            get { return string.Format("{0}.", _index); }
        }
    }
}