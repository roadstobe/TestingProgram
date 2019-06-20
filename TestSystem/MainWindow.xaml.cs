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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Question> q = new List<Question>();
        List<ReadyQuestion> questions = new List<ReadyQuestion>();
        List<List<Question>> qq = new List<List<Question>>();
        public MainWindow()
        {
            q.Add(new Question("answer 1", false));
            q.Add(new Question("answer 2", true));
            q.Add(new Question("answer 3", false));
            q.Add(new Question("answer 4", false));


            InitializeComponent();
            //questions.Add(new ReadyQuestion("Choose answer", true, "some", q));
            //StackPanel stackPanel = new StackPanel();
            //stackPanel.Name = "mainStackPanel";
            //stackPanel.Orientation = Orientation.Vertical;
            //TextBlock condition = new TextBlock();
            //condition.Text = questions[0].Condition;
            //stackPanel.Children.Add(condition);
            //for (int i = 0; i < q.Count; i++)
            //{
            //    RadioButton tmp = new RadioButton();
            //    tmp.GroupName = "g";
            //    tmp.Content = q[i].Content;
            //    stackPanel.Children.Add(tmp);

            //}
            //mainWindow.Children.Add(stackPanel);
            FillQuestion();
        }

        void FillQuestion( )
        {
            qq.Add(new List<Question> { new Question ("answer 0", true), new Question("answer 0", false), new Question("answer 0", false) });
            qq.Add(new List<Question> { new Question("answer 1", false), new Question("answer 1", true), new Question("answer 1", false) });
            qq.Add(new List<Question> { new Question("answer 2", true), new Question("answer 2", false), new Question("answer 2", false) });
            qq.Add(new List<Question> { new Question("answer 3", false), new Question("answer 3", false), new Question("answer 3", true) });
            qq.Add(new List<Question> { new Question("answer 4", false), new Question("answer 4", true), new Question("answer 4", false) });
            for (int i = 0; i < qq.Count; i++)
            {
                questions.Add(new ReadyQuestion($"Question: {i}", true, "RadioButton", qq[i]));
                Button b = new Button();
                b.Name = $"button{i}";
                b.Content = questions[i].Condition;
                b.Click += B_Click;
                questionPanel.Children.Add(b);
            }
            for (int i = 0; i < qq.Count; i++)
            {
                for (int j = 0; j < qq[i].Count; j++)
                {
                    qq[i][j].Choose.Click += Choose_Click;
                }
            }
        }

        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            for (int i = 0; i < qq.Count; i++)
            {
                for (int j = 0; j < qq[i].Count; j++)
                {
                    if (rb.Name == qq[i][j].Choose.Name)
                    {
                        qq[i][j].Choose.IsChecked = true;
                        //MessageBox.Show( $"{qq[i][j].IsCorrect}");
                    }
                }
            }
        }

        private void B_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            mainWindow.Children.Clear();
            for (int i = 0; i < questions.Count; i++)
            {
                if(b.Name == $"button{i}")
                {
                    for (int j = 0; j < qq[i].Count; j++)
                    {
                        mainWindow.Children.Add(qq[i][j].Choose);
                    }
                }
            }

        }
    }
}
