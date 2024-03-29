using Dominio.Entidades;
using Newtonsoft.Json;

namespace FinancasFacil;

public partial class NewPage1 : ContentPage
{
    private readonly BaseClient _client = new BaseClient();
    private string _simboloAcao;
    public NewPage1(string simboloAcao)
	{
        InitializeComponent();
        _simboloAcao = simboloAcao;
        CarregarDados();



    }

	private async void CarregarDados()
	{
        HttpResponseMessage respostaAPI = await _client.GetShare(_simboloAcao);
        string conteudo = await respostaAPI.Content.ReadAsStringAsync();
        Acao acao = JsonConvert.DeserializeObject<Acao>(conteudo);

        NomeAcao.Text = $"{acao.ShortName} Valor: {acao.RegularMarketPrice}";
        await DisplayAlert("Alerta", "Você clicou no botão", "ON");

		
	}
}