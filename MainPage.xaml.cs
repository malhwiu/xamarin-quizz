using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core.Views;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

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
        
        async private void ShowToast(string msg)
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            string text = msg;
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;

            var toast = Toast.Make(text, duration, fontSize);

            await toast.Show(cancellationTokenSource.Token);
        }

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
            string msg = vastaus == oikeaVastaus ? "Oikein" : "Väärin";
            //jotain.Text = msg;
            ShowToast(msg);


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