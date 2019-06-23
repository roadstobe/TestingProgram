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
    abstract class TypeQuestion
    {
        public bool IsCorrect { get; set; }
        public Button Place { get; set; }
        public TypeQuestion()
        {

        }
        public TypeQuestion(string content, bool isCorrect)
        {
            Place = new Button();
            IsCorrect = IsCorrect;
        }
    }
}
