using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TestSystem
{
    class CheckQuestion:TypeQuestion
    {
       
        public static int Id { get; private set; }
        int id;
        public CheckBox Choose { get; set; }
        public CheckQuestion(){}
        public CheckQuestion(string content, bool isCorrect):base(content, isCorrect)
        {
            id = Id;
            Id++;
            IsCorrect = isCorrect;
            Choose = new CheckBox();
            Choose.Content = content;
            Choose.Name = $"checkBox{id}";
            Place.Content = Choose;
            Place.HorizontalAlignment = HorizontalAlignment.Left;
        }

        public override string ToString()
        {
            return $"{Choose.Content}";
        }

    }
}
