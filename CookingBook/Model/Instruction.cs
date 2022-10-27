using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cookbook.Models
{
    //клас Інструкція
    public class Instruction
    {

        private int _index;
        private string _content;
        //поле індексу
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
        //поле формату індексу
        public string IndexFormatted
        {
            get { return string.Format("{0}.", _index); }
        }
        //поле вмисту
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
    }
}