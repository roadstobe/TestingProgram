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
        public List<TypeQuestion> questions = new List<TypeQuestion>();
        public List<bool> CorectAnswer = new List<bool>();

        public ReadyQuestion(string condition, List<TypeQuestion> q)
        {
            Condition = condition;
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
