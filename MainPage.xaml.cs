namespace Transito
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        private void IniciarClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new QuizMain());// chama proxima pagina 

        }
    }

}
