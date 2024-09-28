
using CommunityToolkit.Maui.Views;

namespace Transito.Componente
{
    public partial class RespostaPop : Popup
    {
        public RespostaPop(string mensagem) // vai receber o texto da popup
        {
            InitializeComponent();
            MensagemPop.Text = mensagem;
        }


        public void MostraPopUp(Page atualPage)
        {
            atualPage.ShowPopup(this);
        }
        private void OnCloseButtonClicked(object sender, EventArgs e)
        {
            Close();
        }
    }
}