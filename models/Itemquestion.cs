namespace xamarin_tietovisa5.models
{


    // https://marklowg.medium.com/packing-and-unpacking-with-c-tuples-e2d07b44d993

    public struct Answers
    {
        public Answers(string firstAns, string secondAns, string thirdAns)
        {
            firstAnswer = firstAns;
            secondAnswer = secondAns;
            thirdAnswer = thirdAns;
        }

        public void Deconstruct(out string firstAns, out string secondAns, out string thirdAns)
        {
            firstAns = firstAnswer;
            secondAns = secondAnswer;
            thirdAns = thirdAnswer;
        }

        readonly string firstAnswer = "Empty";
        readonly string secondAnswer = "Empty";
        readonly string thirdAnswer = "Empty";
    }

    internal class Itemquestion
    {

        public Itemquestion(string question, Answers answers, string rightAnswer)
        {
            this.question = question;
            this.answers = answers;
            this.rightAnswer = rightAnswer;
        }

        public string Question
        {
            get
            {
                return question;
            }
        }

        public string RightAnswer
        {
            get
            {
                return rightAnswer;
            }
        }

        public Answers Answers
        {
            get
            {
                return answers;
            }
        }

        private readonly Answers answers;
        private readonly string question, rightAnswer;

    }
}
