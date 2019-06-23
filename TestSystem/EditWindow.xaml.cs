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
using System.Windows.Shapes;

namespace TestSystem
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        List<List<TypeQuestion>> question = new List<List<TypeQuestion>>();
        List<ReadyQuestion> readyQuestions = new List<ReadyQuestion>();


         List<TypeQuestion> tmp = new List<TypeQuestion>();
        int indexQuestion;
        public EditWindow()
        {
            indexQuestion = 0;
            InitializeComponent();
        }

        private void Button_ClickAddAnswer(object sender, RoutedEventArgs e)
        {
            TextBlock answer = new TextBlock();
            answer.Text = tbAnswer.Text;
            stackWithAnswer.Children.Add(answer);
            tbAnswer.Text = "";
            bool isTrueAnsw;
           
            if (isTrueAnswer.IsChecked == true)
                isTrueAnsw = true;
            else
                isTrueAnsw = false;
            if (typeSingle.IsChecked == true)
            {
                tmp.Add(new Question(answer.Text, isTrueAnsw));
            }
            else
            {
                tmp.Add(new CheckQuestion(answer.Text, isTrueAnsw));
            }
        }

        private void Button_ClickAddQuestion(object sender, RoutedEventArgs e)
        {
            question.Add(tmp);
            readyQuestions.Add(new ReadyQuestion(tbQuestion.Text, question[question.Count - 1]));
            
            stackWithAnswer.Children.Clear();
            tmp.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < question.Count; i++)
            {
                for (int j = 0; j < question[i].Count; j++)
                {
                    Console.WriteLine(question[i][j]);
                }
            }
            Console.WriteLine("///////////////////////////////////////////////////////");
            foreach (var item in readyQuestions)
            {
                Console.WriteLine(item);
            }
        }
    }
}
