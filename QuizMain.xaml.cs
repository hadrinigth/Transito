using Transito.Componente;

namespace Transito
{
    public partial class QuizMain : ContentPage
    {
        private readonly Random random = new Random(); // Gerador de n�meros aleat�rios
        private List<QuizQuestion> questions; // Lista de perguntas
        private QuizQuestion currentQuestion; // Pergunta atual

        public List<string> Alternatives { get; set; } = new List<string>(); // Alternativas para exibi��o
        private int counterAcerto = 0;
        private int counterErr = 0;

        public QuizMain()
        {
            InitializeComponent(); // Inicializa a interface
            InitializeQuestions(); // Inicializa as quest�es
            DisplayRandomQuestion(); // Exibe a primeira pergunta
        }

        // Inicializando as quest�es com alternativas erradas
        private void InitializeQuestions()
        {
            questions = new List<QuizQuestion>
            {
                new QuizQuestion("Resources/Images/Reg/r1.jpg", "Pare",
                    new List<string> { "Siga em Frente", "Proibido Estacionar", "Proibido Ultrapassar" }),

                new QuizQuestion("Resources/Images/Reg/r2.jpg", "D� a Prefer�ncia",
                    new List<string> { "Pare", "Proibido Estacionar", "Sentido Proibido" }),

                new QuizQuestion("Resources/Images/Reg/r3.jpg", "Sentido Proibido",
                    new List<string> { "Proibido Vira � Direita ", "Estacionamento Permitido", "Proibido Parar e Estacionar"}),

                new QuizQuestion("Resources/Images/Reg/r4a.jpg", "Proibido Virar � Direita",
                    new List<string> { "Siga em Frente", "D� a Prefer�ncia", "Proibido Virar � Esquerda"}),

                new QuizQuestion("Resources/Images/Reg/r4b.jpg", "Proibido Vira � Esquerda",
                    new List<string>{ "Proibido Vira � Direita", "Siga em Frente", "Proibido Ultrapassar"}),

                new QuizQuestion("Resources/Images/Reg/r5a.jpg", "Proibido Retorna � Direita ", 
                    new List<string> { "Estacionamento Permitido", "Curva � Direita ", "Proibido Ultrapassar"}),

                new QuizQuestion("Resources/Images/Reg/r5b.jpg", "Proibido Retorna � Esquerda ",
                    new List<string> { "Estacionamento Permitido", "Curva � Direita ", "Proibido Ultrapassar"}),

                new QuizQuestion("Resources/Images/Reg/r6a.jpg", "Proibido Estacionar",
                    new List<string> { "Cruva Fechada � Direita ", "Siga em Frente", "Proibido Parar e Estacionar" }),

                new QuizQuestion("Resources/Images/Reg/r6b.jpg", "Estacionamento Permitido  ",
                    new List<string> { "Proibido Parar e Estacionar", "Curva � Esquerda ", "Proibido Estacionar" }),

                new QuizQuestion("Resources/Images/Reg/r6c.jpg", "Proibido Parar e Estacionar ",
                    new List<string> { "Proibido Estacionar", "Curva � Esquerda", "Estacionamento Permitido" }),

                new QuizQuestion("Resources/Images/Reg/r7.jpg", "Proibido Ultrapassar",
                    new List<string> { "D� a Prefer�ncia", "Proibido Vira � Direita", "Siga em Frente" }),

                new QuizQuestion("Resources/Images/Reg/r8a.jpg", "Proibido Mudan�a de Faixa ou Pista da Direita para a Esquerda",
                    new List<string> { "Proibido Estacionar", "Proibido Retornar", "Curva Fechada � Direita" }),

                new QuizQuestion("Resources/Images/Reg/r8b.jpg", "Proibido Mudan�a de Faixa ou Pista da Esquerda para a Direita ",
                    new List<string> { "Proibido Mudan�a de Faixa ou Pista da Direita para a Esquerda", "Proibido Ultrapassar", "Siga em Frente" }),

                new QuizQuestion("Resources/Images/Reg/r9.jpg", "Proibido Tr�nsito De Caminh�es ",
                    new List<string> { "Proibido Retornar", "Siga em Frente", "D� a Prefer�ncia" }),

                new QuizQuestion("Resources/Images/Reg/r10.jpg", "Proibido Tr�nsito De Ve�culos Automotores ",
                    new List<string> { "Proibido Estacionar", "Proibido Retornar", "D� a Prefer�ncia" }),

                new QuizQuestion("Resources/Images/Reg/r11.jpg", "Proibido Tr�nsito De Ve�culos De Tra��o Animal",
                    new List<string> { "Proibido Tr�nsito De Caminh�es", "Proibido Tr�nsito De Ve�culos Automotores", "D� a Prefer�ncia" }),

                new QuizQuestion("Resources/Images/Reg/r12.jpg", " Proibido Tr�nsito De Bicicletas",
                    new List<string> { "Proibido Tr�nsito De Ve�culos De Tra��o Animal", "Proibido Tr�nsito De Caminh�es", "Proibido Tr�nsito De Ve�culos Automotores" }),

                new QuizQuestion("Resources/Images/Reg/r13.jpg", "Proibido Tr�nsito De Tratores",
                    new List<string> {"Proibido Tr�nsito De Ve�culos De Tra��o Animal", "Proibido Tr�nsito De Caminh�es", "Proibido Tr�nsito De Ve�culos Automotores"}),

                new QuizQuestion("Resources/Images/Reg/r14.jpg", "Peso M�ximo Permitido",
                    new List<string> { "Siga em Frente ", "Proibido Estacionar", "Passagem Obrigatoria" }),

                new QuizQuestion("Resources/Images/Reg/r15.jpg", "Altura M�xima Permitida ",
                    new List<string> { "Proibido Estacionar", "Siga em Frente", "Proibido Estacionar" }),

                new QuizQuestion("Resources/Images/Reg/r16.jpg", "Largura M�xima Permitida ",
                    new List<string> { "Proibido Retornar", "D� a Preferencia ", "Curva Fechada � Esquerda" }),

                new QuizQuestion("Resources/Images/Reg/r17.jpg", "Peso M�ximo Permitido Por Eixo ",
                    new List<string> { "Largura M�xima Permitida", "Altura M�xima Permitida", "Peso M�ximo Permitido" }),

                new QuizQuestion("Resources/Images/Reg/r18.jpg", "Comprimento M�ximo Permitido",
                    new List<string> { "Largura M�xima Permitida", "Altura M�xima Permitida", "Peso M�ximo Permitido"  }),

                new QuizQuestion("Resources/Images/Reg/r19.jpg", "Velocidade M�xima Permitida",
                    new List<string> { "Siga em Frente ", "Proibido Estacionar", "Passagem Obrigatoria" }),

                new QuizQuestion("Resources/Images/Reg/r20.jpg", "Proibido Acionar Buzina Ou Sinal Sonoro ",
                    new List<string> {"Siga em Frente ", "Proibido Estacionar", "Passagem Obrigatoria" }),

                new QuizQuestion("Resources/Images/Reg/r21.jpg", "Alf�ndega ",
                    new List<string> { "Siga em Frente ", "Proibido Estacionar", "Passagem Obrigatoria" }),

                new QuizQuestion("Resources/Images/Reg/r22.jpg", "Uso Obrigat�rio De Corrente",
                    new List<string> { "Siga em Frente", "Largura M�xima Permitida", "Proibido Tr�nsito De Caminh�es" }),

                new QuizQuestion("Resources/Images/Reg/r23.jpg", "Conserve-Se � Direita",
                    new List<string> { "Siga em Frente", "Proibido Mudan�a de Faixa ou Pista da Direita para a Esquerda", "Passagem Obrigatoria" }),

                new QuizQuestion("Resources/Images/Reg/r24a.jpg", "Sentido De Circula��o Da Via Ou Pista",
                    new List<string> { "Conserve-Se � Direita", "Siga em Frente", "Passagem Obrigatoria" }),

                new QuizQuestion("Resources/Images/Reg/r24b.jpg", "Passagem Obrigat�ria ",
                    new List<string> { "Sentido De Circula��o Da Via Ou Pista", "Siga em Frente", "Conserve-Se � Direita" }),

                new QuizQuestion("Resources/Images/Reg/r25a.jpg", "Vire � Esquerda",
                    new List<string> { "Sentido De Circula��o Da Via Ou Pista", "Siga em Frente", "Conserve-Se � Direita" }),

                new QuizQuestion("Resources/Images/Reg/r25b.jpg", "Vire � Direita ",
                    new List<string> { "Vire � Esquerda", "Siga em Frente", "Sentido De Circula��o Da Via Ou Pista"  }),

                new QuizQuestion("Resources/Images/Reg/r25c.jpg", "Siga Em Frente Ou � Esquerda ",
                    new List<string> { "Vire � Esquerda", "Siga em Frente", "Sentido De Circula��o Da Via Ou Pista" }),

                new QuizQuestion("Resources/Images/Reg/r25d.jpg", "Siga Em Frente Ou � Direita",
                    new List<string> { "Siga Em Frente Ou � Esquerda", "Siga em Frente", "Sentido De Circula��o Da Via Ou Pista" }),

                new QuizQuestion("Resources/Images/Reg/r26.jpg", "Siga Em Frente ",
                    new List<string> { "Proibido Retornar", "D� a Preferencia ", "Curva Fechada � Esquerda"}),

                new QuizQuestion("Resources/Images/Reg/r27.jpg", "�nibus Caminh�es Mantenham-Se � Direita ",
                    new List<string> { "Conserve-Se � Direita", "Siga em Frente", "Passagem Obrigatoria"  }),

                new QuizQuestion("Resources/Images/Reg/r28.jpg", "Duplo Sentido De Circula��o",
                    new List<string> { "Vire � Esquerda", "Siga em Frente", "Sentido De Circula��o Da Via Ou Pista"}),

                new QuizQuestion("Resources/Images/Reg/r29.jpg", "Proibido Tr�nsito De Pedestres ",
                    new List<string> {  "Proibido Tr�nsito De Ve�culos De Tra��o Animal", "Proibido Tr�nsito De Caminh�es", "Proibido Tr�nsito De Ve�culos Automotores" }),

                new QuizQuestion("Resources/Images/Reg/r30.jpg", " Pedestre Ande Pela Esquerda ",
                    new List<string> {  "Proibido Retornar", "D� a Preferencia ", "Curva Fechada � Esquerda"}),

                new QuizQuestion("Resources/Images/Reg/r31.jpg", "Pedestre Ande Pela Direita ",
                    new List<string> { "Pedestre Ande Pela Esquerda",  "Vire � Esquerda", "Siga em Frente" }),

                new QuizQuestion("Resources/Images/Reg/r32.jpg", "Circula��o Exclusiva De �nibus",
                    new List<string> { "Proibido Tr�nsito De Ve�culos De Tra��o Animal", "Proibido Tr�nsito De Caminh�es", "Proibido Tr�nsito De Ve�culos Automotores" }),

                new QuizQuestion("Resources/Images/Reg/r33.jpg", "Sentido De Circula��o Na Rotat�ria ",
                    new List<string> { "Vire � Esquerda", "Siga em Frente", "Sentido De Circula��o Da Via Ou Pista" }),

                new QuizQuestion("Resources/Images/Reg/r34.jpg", "Circula��o Exclusiva De Bicicletas",
                    new List<string> {  "Proibido Retornar", "D� a Preferencia ", "Curva Fechada � Esquerda" }),

                new QuizQuestion("Resources/Images/Reg/r35a.jpg", "Ciclista Transite � Esquerda ",
                    new List<string> { "Circula��o Exclusiva De Bicicletas","Siga em Frente", "Sentido De Circula��o Da Via Ou Pista" }),

                new QuizQuestion("Resources/Images/Reg/r35b.jpg", "Ciclista Transite � Direita",
                    new List<string> { "Ciclista Transite � Esquerda ", "Vire � Esquerda", "Siga em Frente"}),

                new QuizQuestion("Resources/Images/Reg/r36a.jpg", "Ciclistas � Esquerda Pedestres � Direita",
                    new List<string> { "Ciclista Transite � Esquerda ", "Vire � Esquerda", "Siga em Frente" }),

                new QuizQuestion("Resources/Images/Reg/r36b.jpg", "Pedestres � Esquerda Ciclista � Direita",
                    new List<string> { "Ciclista Transite � Esquerda ", "Sentido De Circula��o Na Rotat�ria ", "Pedestre Ande Pela Direita" }),

                new QuizQuestion("Resources/Images/Reg/r37.jpg", "Proibido Tr�nsito De Motocicletas",
                    new List<string> { "Proibido Tr�nsito De Caminh�es", "Proibido Tr�nsito De Ve�culos Automotores", "D� a Prefer�ncia"  }),

                new QuizQuestion("Resources/Images/Reg/r38.jpg", "Proibido Tr�nsito De �nibus ",
                    new List<string> { "Proibido Tr�nsito De Ve�culos De Tra��o Animal", "Proibido Tr�nsito De Caminh�es", "Proibido Tr�nsito De Ve�culos Automotores" }),

                new QuizQuestion("Resources/Images/Reg/r39.jpg", "Circula��o Exclusiva De Caminh�o ",
                    new List<string> { "Ciclista Transite � Esquerda", "Sentido De Circula��o Na Rotat�ria", "Proibido Tr�nsito De �nibus" }),

                new QuizQuestion("Resources/Images/Reg/r40.jpg", "Tr�nsito Proibido � Carros De M�o ",
                    new List<string> { "Proibido Tr�nsito De Ve�culos De Tra��o Animal", "Proibido Tr�nsito De Caminh�es", "Proibido Tr�nsito De Ve�culos Automotores" }),





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

        // Exibe a pergunta aleat�ria e mistura as alternativas
        private void DisplayRandomQuestion()
        {
            if (questions == null || questions.Count == 0) return;

            // Escolhe uma pergunta aleat�ria
            var randomIndex = random.Next(questions.Count);
            currentQuestion = questions[randomIndex];

            // Mistura a resposta correta com as alternativas erradas
            var allAnswers = currentQuestion.WrongAnswers
                                        .Concat(new List<string> { currentQuestion.CorrectAnswer })
                                        .OrderBy(x => random.Next())
                                        .ToList();

            // Atualiza as alternativas para exibi��o
            Alternatives = allAnswers;

            // Atualiza a imagem e as alternativas no UI
            QuizImage.Source = currentQuestion.ImagePath;
            Alternativa_1.Text = Alternatives[0];
            Alternativa_2.Text = Alternatives[1];
            Alternativa_3.Text = Alternatives[2];
            Alternativa_4.Text = Alternatives[3];
        }


   
        // Verifica se a resposta escolhida est� correta
        private void AlternativaCheck(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            var selectedAnswer = button.Text;

            // Verifica se a resposta est� correta
            if (selectedAnswer == currentQuestion.CorrectAnswer)
            {
                // Popup de sucesso
                counterAcerto++;
                var popup = new RespostaPop("Parab�ns!!");
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

            // Exibe a pr�xima pergunta ap�s a resposta
            DisplayRandomQuestion();
        }

        // Fun��o para ir para a pr�xima pergunta
        private void NextButton_Clicked(object sender, EventArgs e)
        {
            DisplayRandomQuestion();
        }

        private void Label_BindingContextChanged(object sender, EventArgs e)
        {

        }
    }
}
