using Transito.Componente;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Maui.Controls;

namespace Transito
{
    public partial class QuizMain : ContentPage
    {
        private readonly Random random = new Random(); // Gerador de números aleatórios
        private List<QuizQuestion> questions; // Lista de perguntas
        private QuizQuestion currentQuestion; // Pergunta atual

        public List<string> Alternatives { get; set; } = new List<string>(); // Alternativas para exibição

        public QuizMain()
        {
            InitializeComponent(); // Inicializa a interface
            InitializeQuestions(); // Inicializa as questões
            DisplayRandomQuestion(); // Exibe a primeira pergunta
        }

        // Inicializando as questões com alternativas erradas
        private void InitializeQuestions()
        {
            questions = new List<QuizQuestion>
            {
                new QuizQuestion("Resources/Images/Reg/r1.jpg", "Resposta Correta",
                    new List<string> { "Alternativa Errada 1", "Alternativa Errada 2", "Alternativa Errada 3" }),

                new QuizQuestion("Resources/Images/Reg/r2.jpg", "Resposta Correta",
                    new List<string> { "Alternativa Errada 4", "Alternativa Errada 5", "Alternativa Errada 6" })
            };
        }

        // Classe de cada pergunta, incluindo as alternativas erradas
        public class QuizQuestion
        {
            public string ImagePath { get; set; }
            public string CorrectAnswer { get; set; }
            public List<string> WrongAnswers { get; set; }

            public QuizQuestion(string imagePath, string correctAnswer, List<string> wrongAnswers)
            {
                ImagePath = imagePath;
                CorrectAnswer = correctAnswer;
                WrongAnswers = wrongAnswers;
            }
        }

        // Exibe a pergunta aleatória e mistura as alternativas
        private void DisplayRandomQuestion()
        {
            if (questions == null || questions.Count == 0) return;

            // Escolhe uma pergunta aleatória
            var randomIndex = random.Next(questions.Count);
            currentQuestion = questions[randomIndex];

            // Mistura a resposta correta com as alternativas erradas
            var allAnswers = currentQuestion.WrongAnswers
                                        .Concat(new List<string> { currentQuestion.CorrectAnswer })
                                        .OrderBy(x => random.Next())
                                        .ToList();

            // Atualiza as alternativas para exibição
            Alternatives = allAnswers;

            // Atualiza a imagem e as alternativas no UI
            QuizImage.Source = currentQuestion.ImagePath;
            Alternativa_1.Text = Alternatives[0];
            Alternativa_2.Text = Alternatives[1];
            Alternativa_3.Text = Alternatives[2];
            Alternativa_4.Text = Alternatives[3];
        }

        // Verifica se a resposta escolhida está correta
        private void AlternativaCheck(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            var selectedAnswer = button.Text;

            // Verifica se a resposta está correta
            if (selectedAnswer == currentQuestion.CorrectAnswer)
            {
                // Popup de sucesso
                var popup = new RespostaPop("Parabéns!!");
                popup.MostraPopUp(this);
            }
            else
            {
                // Popup de erro
                var popup = new RespostaPop("Tente Novamente!!");
                popup.MostraPopUp(this);
            }

            // Exibe a próxima pergunta após a resposta
            DisplayRandomQuestion();
        }

        // Função para ir para a próxima pergunta
        private void NextButton_Clicked(object sender, EventArgs e)
        {
            DisplayRandomQuestion();
        }
    }
}
