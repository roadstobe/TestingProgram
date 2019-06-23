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
using System.Xml;
using System.Xml.XPath;
using System.IO;
using Microsoft.Win32;

namespace TestSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        List<ReadyQuestion> questions = new List<ReadyQuestion>();
        List<List<TypeQuestion>> qq = new List<List<TypeQuestion>>();
        //імя поточниї кнопки
        string activeButton;
        List<CheckBox> checkMark = new List<CheckBox>();
        bool isEnd = false;
        bool isOpen = false;
        int rating;
        public MainWindow()
        {
            rating = 0;
            InitializeComponent();
            questionMark.Background = new SolidColorBrush(Color.FromArgb(155, 75, 75, 200));
        }

        void FillQuestionFromXML()
        {

            try
            {

                OpenFileDialog path = new OpenFileDialog();
                path.ShowDialog();

                XmlReader reader = XmlReader.Create(path.FileName);
                XmlDocument document = new XmlDocument();
                document.Load(reader);
                reader.Close();

                XmlNode root = document.DocumentElement;

                List<ReadyQuestion> questionsTest = new List<ReadyQuestion>();

                List<List<TypeQuestion>> qqTest = new List<List<TypeQuestion>>();
                List<TypeQuestion> singleQ = new List<TypeQuestion>();

                XmlNodeList innerQuestion = root.ChildNodes;


                for (int i = 0; i < innerQuestion.Count; i++)
                {
                    string condition = "";
                    for (int j = 0; j < innerQuestion[i].ChildNodes.Count; j++)
                    {
                        //XmlNode x = innerQuestion[i].ChildNodes.Item(j);
                        //Console.WriteLine(x.ChildNodes[0].InnerText);
                        string content = "";
                        bool isCorrect = false;

                        try
                        {
                            content = innerQuestion[i].ChildNodes[j]["title"].InnerText;
                            isCorrect = bool.Parse(innerQuestion[i].ChildNodes[j]["isTrue"].InnerText);
                            if (innerQuestion[i]["TypeButton"].InnerText == "RadioButton")
                                singleQ.Add(new Question(content, isCorrect));
                            else
                                singleQ.Add(new CheckQuestion(content, isCorrect));
                        }
                        catch
                        {

                            condition = innerQuestion[i]["condition"].InnerText;
                        }

                    }
                    qqTest.Add(new List<TypeQuestion> { singleQ[0] });
                    for (int q = 1; q < singleQ.Count; q++)
                    {
                        qqTest[0].Add(singleQ[q]);

                    }
                    qq.Add(qqTest[0]);
                    questionsTest.Add(new ReadyQuestion(condition, qqTest[0]));
                    qqTest.Clear();
                    singleQ.Clear();
                }
            }
            catch
            {
                MessageBox.Show("Upss xml file is broken");
                isOpen = false;
                isEnd = false;
            }

        }

        //заповнення запитаннями
        void FillQuestion( )
        {
            //qq.Add(new List<TypeQuestion> { new Question ("answer 0", true), new Question("answer 0", false), new Question("answer 0", false) });
            //qq.Add(new List<TypeQuestion> { new Question("answer 1", false), new Question("answer 1", true), new Question("answer 1", false) });
            //qq.Add(new List<TypeQuestion> { new Question("answer 2", true), new Question("answer 2", false), new Question("answer 2", false) });
            //qq.Add(new List<TypeQuestion> { new CheckQuestion("answer 3", true), new CheckQuestion("answer 3", false), new CheckQuestion("answer 3", true) });
            //qq.Add(new List<TypeQuestion> { new Question("answer 4", false), new Question("answer 4", true), new Question("answer 4", false) });
            
            for (int i = 0; i < qq.Count; i++)
            {
                questions.Add(new ReadyQuestion($"Question: {i}", qq[i]));
                Button b = new Button();
                checkMark.Add(new CheckBox());
                checkMark[i].Content = "Mark";
                checkMark[i].Click += MarkCheck_click;
                b.Name = $"button{i}";
                b.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                b.Content = questions[i].Condition;
                b.Click += B_Click;
                questionPanel.Children.Add(b);
                
            }
            numberQuestion.Text = $"Question {0} of {questions.Count}";
            for (int i = 0; i < qq.Count; i++)
            {
                for (int j = 0; j < qq[i].Count; j++)
                {
                    if (qq[i][j] is Question)
                    {
                        (qq[i][j] as Question).Choose.Click += Choose_Click;

                    }
                    if(qq[i][j] is CheckQuestion)
                    {
                        (qq[i][j] as CheckQuestion).Choose.IsThreeState = false;
                        (qq[i][j] as CheckQuestion).Choose.Click += CheckClick;
                    }
                }
            }

            
        }

        private void MarkCheck_click(object sender, RoutedEventArgs e)
        {
            questionMark.Children.Clear();
            for (int i = 0; i < questions.Count; i++)
            {
                TextBlock tb = new TextBlock();
                tb.VerticalAlignment = VerticalAlignment.Center;
                tb.FontSize = 15;
                tb.Background = new SolidColorBrush(Color.FromArgb(155, 75, 75, 200));
                if (checkMark[i].IsChecked == true)
                {
                    (questionPanel.Children[i] as Button).Background = new SolidColorBrush(Color.FromArgb(155, 75, 75, 200));

                    tb.Text = "✓";
                    questionMark.Children.Add(tb);
                }
                else
                {
                    tb.Text = "";
                    questionMark.Children.Add(tb);
                }
            }
        }

        //логіка для чекбоксів
        private void CheckClick(object sender, RoutedEventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            for (int i = 0; i < qq.Count; i++)
            {
                for (int j = 0; j < qq[i].Count; j++)
                {
                    try
                    {
                        if (cb.Name == ((qq[i][j] as CheckQuestion).Choose.Name))
                        {
                            if ((qq[i][j] as CheckQuestion).Choose.IsChecked == false)
                                (qq[i][j] as CheckQuestion).Choose.IsChecked = false;
                            else
                                (qq[i][j] as CheckQuestion).Choose.IsChecked = true;
                            break;
                        }
                    }
                    catch { }
                }
            }
        }

        //самі клаки по радіобатонах 
        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            for (int i = 0; i < qq.Count; i++)
            {
                for (int j = 0; j < qq[i].Count; j++)
                {
                    try
                    {
                        if (rb.Name == (qq[i][j] as Question).Choose.Name)
                        {
                            (qq[i][j] as Question).Choose.IsChecked = true;
                        }
                    }
                    catch { }
                }
            }
        }
        //малює запитання
        private void B_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            mainWindow.Children.Clear();
            markChekBox.Children.Clear();
            for (int i = 0; i < questions.Count; i++)
            {
                if(b.Name == $"button{i}")
                {
                    markChekBox.Children.Add(checkMark[i]);
                    markChekBox.VerticalAlignment = VerticalAlignment.Center;
                    TextBlock text = new TextBlock();
                    text.Text = questions[i].Condition;
                    mainWindow.Children.Add(text);
                    for (int j = 0; j < qq[i].Count; j++)
                    {
                        if (qq[i][j] is Question)
                        {
                            if(qq[i][j].IsCorrect == true && isEnd == true)
                                (qq[i][j] as Question).Place.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                            mainWindow.Children.Add((qq[i][j] as Question).Place);
                            
                        }
                        else if (qq[i][j] is CheckQuestion)
                        {
                            if (qq[i][j].IsCorrect == true && isEnd == true)
                                (qq[i][j] as CheckQuestion).Place.Background = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                                
                            mainWindow.Children.Add((qq[i][j] as CheckQuestion).Place);
                        }
                        
                    }
                    activeButton = b.Name;
                    numberQuestion.Text = $"Question {i+1} of {questions.Count}";
                }
            }
            for (int i = 0; i < questions.Count; i++)
            {
                if ((questionPanel.Children[i] as Button).Name == activeButton)
                (questionPanel.Children[i] as Button).Background =  new SolidColorBrush(Color.FromArgb(155, 75, 255, 0));
                else
                    (questionPanel.Children[i] as Button).Background = new SolidColorBrush(Color.FromArgb(155, 255, 0, 0));
            }
        }
        //переключати кнопкою некст і превіус
        private void PrevQuestion_Click(object sender, RoutedEventArgs e)
        {
            if (qq.Count > 0)
            {
                if (activeButton == null)
                    activeButton = "button0";
                else
                {
                    char[] tmp = new char[3];
                    int index = 0;
                    for (int i = 6; i < activeButton.Length; i++)
                    {
                        tmp[index] = activeButton[i];
                        index++;
                    }
                    int digit = int.Parse(tmp[0].ToString());

                    if (e.Source == nextQuestion)
                        activeButton = $"button{++digit}";
                    else
                        activeButton = $"button{--digit}";
                    if (digit < 0)
                        activeButton = $"button{0}";
                    if (digit > questions.Count - 1)
                        activeButton = $"button{questions.Count - 1}";
                }
                Button b = new Button();
                b.Name = activeButton;
                B_Click(b, e);
            }
        }
        //блокує чек так радіобатони
        private void EndExam_click(object sender, RoutedEventArgs e)
        {
            
            if (isEnd == true)
                MessageBox.Show("You have ended exam");
            else
            if (MessageBox.Show("Do you want end exam?", "End exam", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                isEnd = true;
                for (int i = 0; i < questions.Count; i++)
                {
                    for (int j = 0; j < qq[i].Count; j++)
                    {
                        if (qq[i][j] is Question)
                        {
                            (qq[i][j] as Question).Choose.IsEnabled = false;
                            if ((qq[i][j] as Question).Choose.IsChecked == true && qq[i][j].IsCorrect == true)
                                rating++;
                        }
                        else if (qq[i][j] is CheckQuestion )
                        {
                            (qq[i][j] as CheckQuestion).Choose.IsEnabled = false;
                            if ((qq[i][j] as CheckQuestion).Choose.IsChecked == true && qq[i][j].IsCorrect)
                                rating++;
                        }
                    }
                }
                MessageBox.Show($"Your mark is: {rating}");
                YourMark.Visibility = Visibility.Visible;
                YourMark.Text = $"You have mark {rating}";
            }
           

        }

        private void CommandBinding_ExecutedOpen(object sender, ExecutedRoutedEventArgs e)
        {
            
            if (isOpen == false)
            {
                isOpen = true;
                FillQuestionFromXML();
                FillQuestion();
                
               
            }
            else
                MessageBox.Show("You have started exam");
            if (isOpen == true )
                EndExamButton.IsEnabled = true;
            else
                EndExamButton.IsEnabled = false;
        }

        private void CommandBinding_ExecutedExit(object sender, ExecutedRoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want exit ?", "Exit", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                this.Close();
        }

        private void CommandBinding_ExecutedSave(object sender, ExecutedRoutedEventArgs e)
        {
            
            if (isOpen == true)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.ShowDialog();
                XmlReader reader = XmlReader.Create(save.FileName);
                XmlDocument document = new XmlDocument();
                document.Load(reader);
                reader.Close();

                XmlNode root = document.DocumentElement;

                XmlNodeList allAnswer = root.ChildNodes;

                for (int i = 0; i < allAnswer.Count; i++)
                {
                    allAnswer[i].ParentNode.RemoveChild(allAnswer[i]);
                    i--;
                }

                for (int i = 0; i < qq.Count; i++)
                {
                    XmlNode questionNode = document.CreateElement("question");
                    for (int j = 0; j < qq[i].Count; j++)
                    {
                        XmlNode itemNode = document.CreateElement("item");
                        XmlNode isCheckedNode = document.CreateElement("isChecked");
                        if (qq[i][j] is Question)
                            isCheckedNode.InnerText = (qq[i][j] as Question).Choose.IsChecked.ToString();
                        if (qq[i][j] is CheckQuestion)
                            isCheckedNode.InnerText = (qq[i][j] as CheckQuestion).Choose.IsChecked.ToString();

                        itemNode.AppendChild(isCheckedNode);
                        questionNode.AppendChild(itemNode);
                    }
                    root.AppendChild(questionNode);
                }
                document.Save(save.FileName);

                MessageBox.Show("Session was saved", "Save", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Begin load some exam", "Dont load exam", MessageBoxButton.OK, MessageBoxImage.Stop);
        }

        private void CommandBinding_CanExecuteLoadSession(object sender, CanExecuteRoutedEventArgs e)
        {
            if (isOpen == true)
                e.CanExecute = true;
            else
                e.CanExecute = false;
        }

        private void MenuItem_ClickLoadSession(object sender, RoutedEventArgs e)
        {
            if (isOpen == true)
            {
                OpenFileDialog open = new OpenFileDialog();
                open.ShowDialog();
                XmlReader reader = XmlReader.Create(open.FileName);
                XmlDocument document = new XmlDocument();
                document.Load(reader);
                reader.Close();
                XmlNode root = document.DocumentElement;
                XmlNodeList innerAnswer = root.ChildNodes;
                for (int i = 0; i < innerAnswer.Count; i++)
                {
                    for (int j = 0; j < innerAnswer[i].ChildNodes.Count; j++)
                    {
                        Console.WriteLine(innerAnswer[i].ChildNodes[j]["isChecked"].InnerText);
                        if (qq[i][j] is Question)
                        {
                            (qq[i][j] as Question).Choose.IsChecked = bool.Parse(innerAnswer[i].ChildNodes[j]["isChecked"].InnerText);
                        }
                        else if (qq[i][j] is CheckQuestion)
                            (qq[i][j] as CheckQuestion).Choose.IsChecked = bool.Parse(innerAnswer[i].ChildNodes[j]["isChecked"].InnerText);
                    }
                }
            }
            else
            {
                MessageBox.Show("Begin load some exam", "Not found exam", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void MenuItem_ClickCreateExamen(object sender, RoutedEventArgs e)
        {
            EditWindow editWindow = new EditWindow();
            editWindow.ShowDialog();
        }
    }
}
