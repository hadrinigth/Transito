using Transito.Componente;

namespace Transito
{
    public partial class QuizMain : ContentPage
    {
        private readonly Random random = new Random(); // Gerador de números aleatórios
        private List<QuizQuestion> questions; // Lista de perguntas
        private QuizQuestion currentQuestion; // Pergunta atual

        public List<string> Alternatives { get; set; } = new List<string>(); // Alternativas para exibição
        private int counterAcerto = 0;
        private int counterErr = 0;

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
                new QuizQuestion("Resources/Images/Reg/r1.jpg", "Pare",
                    new List<string> { "Siga em Frente", "Proibido Estacionar", "Proibido Ultrapassar" }),

                new QuizQuestion("Resources/Images/Reg/r2.jpg", "Dê a Preferência",
                    new List<string> { "Pare", "Proibido Estacionar", "Sentido Proibido" }),

                new QuizQuestion("Resources/Images/Reg/r3.jpg", "Sentido Proibido",
                    new List<string> { "Proibido Vira à Direita ", "Estacionamento Permitido", "Proibido Parar e Estacionar"}),

                new QuizQuestion("Resources/Images/Reg/r4a.jpg", "Proibido Virar à Direita",
                    new List<string> { "Siga em Frente", "Dê a Preferência", "Proibido Virar à Esquerda"}),

                new QuizQuestion("Resources/Images/Reg/r4b.jpg", "Proibido Vira à Esquerda",
                    new List<string>{ "Proibido Vira à Direita", "Siga em Frente", "Proibido Ultrapassar"}),

                new QuizQuestion("Resources/Images/Reg/r5a.jpg", "Proibido Retorna à Direita ", 
                    new List<string> { "Estacionamento Permitido", "Curva à Direita ", "Proibido Ultrapassar"}),

                new QuizQuestion("Resources/Images/Reg/r5b.jpg", "Proibido Retorna à Esquerda ",
                    new List<string> { "Estacionamento Permitido", "Curva à Direita ", "Proibido Ultrapassar"}),

                new QuizQuestion("Resources/Images/Reg/r6a.jpg", "Proibido Estacionar",
                    new List<string> { "Cruva Fechada à Direita ", "Siga em Frente", "Proibido Parar e Estacionar" }),

                new QuizQuestion("Resources/Images/Reg/r6b.jpg", "Estacionamento Permitido  ",
                    new List<string> { "Proibido Parar e Estacionar", "Curva à Esquerda ", "Proibido Estacionar" }),

                new QuizQuestion("Resources/Images/Reg/r6c.jpg", "Proibido Parar e Estacionar ",
                    new List<string> { "Proibido Estacionar", "Curva à Esquerda", "Estacionamento Permitido" }),

                new QuizQuestion("Resources/Images/Reg/r7.jpg", "Proibido Ultrapassar",
                    new List<string> { "Dê a Preferência", "Proibido Vira à Direita", "Siga em Frente" }),

                new QuizQuestion("Resources/Images/Reg/r8a.jpg", "Proibido Mudança de Faixa ou Pista da Direita para a Esquerda",
                    new List<string> { "Proibido Estacionar", "Proibido Retornar", "Curva Fechada à Direita" }),

                new QuizQuestion("Resources/Images/Reg/r8b.jpg", "Proibido Mudança de Faixa ou Pista da Esquerda para a Direita ",
                    new List<string> { "Proibido Mudança de Faixa ou Pista da Direita para a Esquerda", "Proibido Ultrapassar", "Siga em Frente" }),

                new QuizQuestion("Resources/Images/Reg/r9.jpg", "Proibido Trânsito De Caminhões ",
                    new List<string> { "Proibido Retornar", "Siga em Frente", "Dê a Preferência" }),

                new QuizQuestion("Resources/Images/Reg/r10.jpg", "Proibido Trânsito De Veículos Automotores ",
                    new List<string> { "Proibido Estacionar", "Proibido Retornar", "Dê a Preferência" }),

                new QuizQuestion("Resources/Images/Reg/r11.jpg", "Proibido Trânsito De Veículos De Tração Animal",
                    new List<string> { "Proibido Trânsito De Caminhões", "Proibido Trânsito De Veículos Automotores", "Dê a Preferência" }),

                new QuizQuestion("Resources/Images/Reg/r12.jpg", " Proibido Trânsito De Bicicletas",
                    new List<string> { "Proibido Trânsito De Veículos De Tração Animal", "Proibido Trânsito De Caminhões", "Proibido Trânsito De Veículos Automotores" }),

                new QuizQuestion("Resources/Images/Reg/r13.jpg", "Proibido Trânsito De Tratores",
                    new List<string> {"Proibido Trânsito De Veículos De Tração Animal", "Proibido Trânsito De Caminhões", "Proibido Trânsito De Veículos Automotores"}),

                new QuizQuestion("Resources/Images/Reg/r14.jpg", "Peso Máximo Permitido",
                    new List<string> { "Siga em Frente ", "Proibido Estacionar", "Passagem Obrigatoria" }),

                new QuizQuestion("Resources/Images/Reg/r15.jpg", "Altura Máxima Permitida ",
                    new List<string> { "Proibido Estacionar", "Siga em Frente", "Proibido Estacionar" }),

                new QuizQuestion("Resources/Images/Reg/r16.jpg", "Largura Máxima Permitida ",
                    new List<string> { "Proibido Retornar", "Dê a Preferencia ", "Curva Fechada à Esquerda" }),

                new QuizQuestion("Resources/Images/Reg/r17.jpg", "Peso Máximo Permitido Por Eixo ",
                    new List<string> { "Largura Máxima Permitida", "Altura Máxima Permitida", "Peso Máximo Permitido" }),

                new QuizQuestion("Resources/Images/Reg/r18.jpg", "Comprimento Máximo Permitido",
                    new List<string> { "Largura Máxima Permitida", "Altura Máxima Permitida", "Peso Máximo Permitido"  }),

                new QuizQuestion("Resources/Images/Reg/r19.jpg", "Velocidade Máxima Permitida",
                    new List<string> { "Siga em Frente ", "Proibido Estacionar", "Passagem Obrigatoria" }),

                new QuizQuestion("Resources/Images/Reg/r20.jpg", "Proibido Acionar Buzina Ou Sinal Sonoro ",
                    new List<string> {"Siga em Frente ", "Proibido Estacionar", "Passagem Obrigatoria" }),

                new QuizQuestion("Resources/Images/Reg/r21.jpg", "Alfândega ",
                    new List<string> { "Siga em Frente ", "Proibido Estacionar", "Passagem Obrigatoria" }),

                new QuizQuestion("Resources/Images/Reg/r22.jpg", "Uso Obrigatório De Corrente",
                    new List<string> { "Siga em Frente", "Largura Máxima Permitida", "Proibido Trânsito De Caminhões" }),

                new QuizQuestion("Resources/Images/Reg/r23.jpg", "Conserve-Se À Direita",
                    new List<string> { "Siga em Frente", "Proibido Mudança de Faixa ou Pista da Direita para a Esquerda", "Passagem Obrigatoria" }),

                new QuizQuestion("Resources/Images/Reg/r24a.jpg", "Sentido De Circulação Da Via Ou Pista",
                    new List<string> { "Conserve-Se À Direita", "Siga em Frente", "Passagem Obrigatoria" }),

                new QuizQuestion("Resources/Images/Reg/r24b.jpg", "Passagem Obrigatória ",
                    new List<string> { "Sentido De Circulação Da Via Ou Pista", "Siga em Frente", "Conserve-Se À Direita" }),

                new QuizQuestion("Resources/Images/Reg/r25a.jpg", "Vire À Esquerda",
                    new List<string> { "Sentido De Circulação Da Via Ou Pista", "Siga em Frente", "Conserve-Se À Direita" }),

                new QuizQuestion("Resources/Images/Reg/r25b.jpg", "Vire À Direita ",
                    new List<string> { "Vire À Esquerda", "Siga em Frente", "Sentido De Circulação Da Via Ou Pista"  }),

                new QuizQuestion("Resources/Images/Reg/r25c.jpg", "Siga Em Frente Ou À Esquerda ",
                    new List<string> { "Vire À Esquerda", "Siga em Frente", "Sentido De Circulação Da Via Ou Pista" }),

                new QuizQuestion("Resources/Images/Reg/r25d.jpg", "Siga Em Frente Ou À Direita",
                    new List<string> { "Siga Em Frente Ou À Esquerda", "Siga em Frente", "Sentido De Circulação Da Via Ou Pista" }),

                new QuizQuestion("Resources/Images/Reg/r26.jpg", "Siga Em Frente ",
                    new List<string> { "Proibido Retornar", "Dê a Preferencia ", "Curva Fechada à Esquerda"}),

                new QuizQuestion("Resources/Images/Reg/r27.jpg", "Ônibus Caminhões Mantenham-Se À Direita ",
                    new List<string> { "Conserve-Se À Direita", "Siga em Frente", "Passagem Obrigatoria"  }),

                new QuizQuestion("Resources/Images/Reg/r28.jpg", "Duplo Sentido De Circulação",
                    new List<string> { "Vire À Esquerda", "Siga em Frente", "Sentido De Circulação Da Via Ou Pista"}),

                new QuizQuestion("Resources/Images/Reg/r29.jpg", "Proibido Trânsito De Pedestres ",
                    new List<string> {  "Proibido Trânsito De Veículos De Tração Animal", "Proibido Trânsito De Caminhões", "Proibido Trânsito De Veículos Automotores" }),

                new QuizQuestion("Resources/Images/Reg/r30.jpg", " Pedestre Ande Pela Esquerda ",
                    new List<string> {  "Proibido Retornar", "Dê a Preferencia ", "Curva Fechada à Esquerda"}),

                new QuizQuestion("Resources/Images/Reg/r31.jpg", "Pedestre Ande Pela Direita ",
                    new List<string> { "Pedestre Ande Pela Esquerda",  "Vire À Esquerda", "Siga em Frente" }),

                new QuizQuestion("Resources/Images/Reg/r32.jpg", "Circulação Exclusiva De Ônibus",
                    new List<string> { "Proibido Trânsito De Veículos De Tração Animal", "Proibido Trânsito De Caminhões", "Proibido Trânsito De Veículos Automotores" }),

                new QuizQuestion("Resources/Images/Reg/r33.jpg", "Sentido De Circulação Na Rotatória ",
                    new List<string> { "Vire À Esquerda", "Siga em Frente", "Sentido De Circulação Da Via Ou Pista" }),

                new QuizQuestion("Resources/Images/Reg/r34.jpg", "Circulação Exclusiva De Bicicletas",
                    new List<string> {  "Proibido Retornar", "Dê a Preferencia ", "Curva Fechada à Esquerda" }),

                new QuizQuestion("Resources/Images/Reg/r35a.jpg", "Ciclista Transite À Esquerda ",
                    new List<string> { "Circulação Exclusiva De Bicicletas","Siga em Frente", "Sentido De Circulação Da Via Ou Pista" }),

                new QuizQuestion("Resources/Images/Reg/r35b.jpg", "Ciclista Transite À Direita",
                    new List<string> { "Ciclista Transite À Esquerda ", "Vire À Esquerda", "Siga em Frente"}),

                new QuizQuestion("Resources/Images/Reg/r36a.jpg", "Ciclistas À Esquerda Pedestres À Direita",
                    new List<string> { "Ciclista Transite À Esquerda ", "Vire À Esquerda", "Siga em Frente" }),

                new QuizQuestion("Resources/Images/Reg/r36b.jpg", "Pedestres À Esquerda Ciclista À Direita",
                    new List<string> { "Ciclista Transite À Esquerda ", "Sentido De Circulação Na Rotatória ", "Pedestre Ande Pela Direita" }),

                new QuizQuestion("Resources/Images/Reg/r37.jpg", "Proibido Trânsito De Motocicletas",
                    new List<string> { "Proibido Trânsito De Caminhões", "Proibido Trânsito De Veículos Automotores", "Dê a Preferência"  }),

                new QuizQuestion("Resources/Images/Reg/r38.jpg", "Proibido Trânsito De Ônibus ",
                    new List<string> { "Proibido Trânsito De Veículos De Tração Animal", "Proibido Trânsito De Caminhões", "Proibido Trânsito De Veículos Automotores" }),

                new QuizQuestion("Resources/Images/Reg/r39.jpg", "Circulação Exclusiva De Caminhão ",
                    new List<string> { "Ciclista Transite À Esquerda", "Sentido De Circulação Na Rotatória", "Proibido Trânsito De Ônibus" }),

                new QuizQuestion("Resources/Images/Reg/r40.jpg", "Trânsito Proibido À Carros De Mão ",
                    new List<string> { "Proibido Trânsito De Veículos De Tração Animal", "Proibido Trânsito De Caminhões", "Proibido Trânsito De Veículos Automotores" }),





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
                counterAcerto++;
                var popup = new RespostaPop("Parabéns!!");
                popup.MostraPopUp(this);
            }
            else
            {
                // Popup de erro
                counterErr++;
                var popup = new RespostaPop("Tente Novamente!!");
                popup.MostraPopUp(this);
            }
            Certa.Text = $"{counterAcerto}";
            Errada.Text = $"{counterErr}";

            // Exibe a próxima pergunta após a resposta
            DisplayRandomQuestion();
        }

        // Função para ir para a próxima pergunta
        private void NextButton_Clicked(object sender, EventArgs e)
        {
            DisplayRandomQuestion();
        }

        private void Label_BindingContextChanged(object sender, EventArgs e)
        {

        }
    }
}
