using Dominio.Entidades;
using Newtonsoft.Json;

namespace FinancasFacil;

public partial class ShareDetails : ContentPage
{
    private readonly BaseClient _client = new BaseClient();
    private string _simboloAcao;
    public ShareDetails(string simboloAcao)
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

        Produto1.Text = $"{acao.ShortName} Valor: {acao.RegularMarketPrice}";
        Preço1.Text = $"{acao.ShortName} Valor: {acao.RegularMarketPrice}";
        Produto2.Text = $"{acao.ShortName} Valor: {acao.RegularMarketPrice}";
        Preço2.Text = $"{acao.ShortName} Valor: {acao.RegularMarketPrice}";
        Produto3.Text = $"{acao.ShortName} Valor: {acao.RegularMarketPrice}";
        Preço3.Text = $"{acao.ShortName} Valor: {acao.RegularMarketPrice}";
        await DisplayAlert("Alerta", "Voce clicou no botao", "ON");


    }
}