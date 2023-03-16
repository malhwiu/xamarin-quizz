namespace xamarin_tietovisa5
{
    public partial class MainPage : ContentPage
    {
        int question = 0;
        string vastaus = "0";
        string oikeaVastaus = "0";

        List<models.Itemquestion> questions;

        public MainPage()
        {
            InitializeComponent();
            StartQuiz();
        }

        private readonly string DatabaseFilename = "tietovisa.db";

        private void NextQuestion()
        {
            kys.Text = questions[question].Question;

            (vas1.Text, vas2.Text, vas3.Text) = questions[index: question].Answers;

            oikeaVastaus = questions[question].RightAnswer;
            question++;
        }


        private void StartQuiz()
        {
            var db = new database.Databasehelper(DatabaseFilename);
            db.CreateDatabase();
            questions = db.GetData();
            NextQuestion();
        }

        void nextKys()
        {

            jotain.Text = vastaus == oikeaVastaus ? "Oikein" : "Väärin";

            NextQuestion();
        }

        private void nextButton(object sender, EventArgs e)
        {
            nextKys();
        }

        private void vastaus1(object sender, EventArgs e)
        {
            vastaus = "1";
            nextKys();
        }

        private void vastaus2(object sender, EventArgs e)
        {
            vastaus = "2";
            nextKys();
        }

        private void vastaus3(object sender, EventArgs e)
        {
            vastaus = "3";
            nextKys();
        }

    }
}