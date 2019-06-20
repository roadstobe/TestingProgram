using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSystem
{
    class ReadyQuestion
    {
        public string Condition { get; set; }
        public bool IsSingleAnswer { get; set; }
        public string TypeAnswer { get; set; }
        public List<Question> questions = new List<Question>();
        public List<bool> CorectAnswer = new List<bool>();

        public ReadyQuestion(string condition, bool isSingleAnswer, string typeAnswer, List<Question> q)
        {
            Condition = condition;
            IsSingleAnswer = isSingleAnswer;
            TypeAnswer = typeAnswer;
            if (IsSingleAnswer == true)
                TypeAnswer = "RadioButton";
            questions = q;
            for (int i = 0; i < q.Count; i++)
            {
                CorectAnswer.Add(q[i].IsCorrect);
            }
        }

        public bool GetCorrectAnswer(int index)
        {
            return CorectAnswer[index];
        }

        public override string ToString()
        {
            return $"{Condition}";
        }

    }
}
