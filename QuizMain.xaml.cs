using Transito.Componente;

namespace Transito
{
    public partial class QuizMain : ContentPage
    {
        private Random random = new Random();
        private List<QuizQuestion> questions;
        private List<string> AltenativaErrada; 
        private QuizQuestion currentQuestion;

        public QuizMain()
        {
            InitializeComponent();
            LoadQuestions();
            LoadWrongOptions();
            DisplayRandomQuestion();
        }

        private void LoadQuestions()
        {
            questions = new List<QuizQuestion> 
            {
                new QuizQuestion("Resources/Images/Quiz/Img1.png", "Correct Answer 1"),
                new QuizQuestion("path/to/image2.png", "Correct Answer 2"),
                // Adicione mais perguntas conforme necessário
            };
        }

        private void LoadWrongOptions()
        {
            AltenativaErrada = new List<string>
            {
                "Wrong Option 1", "Wrong Option 2", "Wrong Option 3", "Wrong Option 4",
                // Adicione mais opções erradas conforme necessário
            };
        }

        private void DisplayRandomQuestion()
        {
            currentQuestion = questions[random.Next(questions.Count)];

            string imagePath = Path.Combine("Resources", "Images", "Quiz",  currentQuestion.ImagePath);

            QuizImage.Source = ImageSource.FromFile(imagePath);

            var options = new List<string> { currentQuestion.CorrectAnswer };
            options.AddRange(AltenativaErrada.OrderBy(x => random.Next()).Take(3));
            options = options.OrderBy(x => random.Next()).ToList();

            Altenativa_1.Text = options[0];
            Altenativa_2.Text = options[1];
            Altenativa_3.Text = options[2];
            Altenativa_4.Text = options[3];
        }

        private void AltenativaCheck(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button.Text == currentQuestion.CorrectAnswer)
            {
                var popup = new RespostaPop("parabéns!!");
                popup.MostraPopUp(this);
            }
            else
            {
                var popup = new RespostaPop("Tente Novamente!!");
                popup.MostraPopUp(this);
            }

            DisplayRandomQuestion();
        }

        public class QuizQuestion
        {
            public string ImagePath { get; }
            public string CorrectAnswer { get; }

            public QuizQuestion(string imagePath, string correctAnswer)
            {
                ImagePath = imagePath;
                CorrectAnswer = correctAnswer;
            }
        }
    }
}
