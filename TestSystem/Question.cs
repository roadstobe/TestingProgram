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
    class Question
    {
        public bool IsCorrect { get; set; }
        public static int Id {get; set ;}
        int id;
        public RadioButton Choose { get; set; }
        public Question(string content, bool correct)
        {
            id = Id;
            Id++;
            IsCorrect = correct;
            Choose = new RadioButton();
            Choose.Content = content;
            Choose.Name = $"radioButton{id}";

        }

        public override string ToString()
        {
            return $"{Choose.Content}";
        }
    }
}
