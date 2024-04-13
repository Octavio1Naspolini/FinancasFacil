using Dominio.Entidades;
using Newtonsoft.Json;

namespace FinancasFacil;

public partial class ShareDetails : ContentPage
{
    private string _shareSymbol;
    private readonly BaseClient _client = new BaseClient();

    public ShareDetails(string shareSymbol)
    {
        InitializeComponent();
        _shareSymbol = shareSymbol;
        ShowShareDetails(_shareSymbol);
    }

    public async Task ShowShareDetails(string shareSymbol)
    {
        try
        {
            HttpResponseMessage respostaAPI = await _client.GetShare(shareSymbol);
            string conteudo = await respostaAPI.Content.ReadAsStringAsync();
            Acao acao = JsonConvert.DeserializeObject<Acao>(conteudo);

            MainThread.BeginInvokeOnMainThread(() =>
            {
                Logotipo.Source = acao.Logourl;
                Produto1.Text = $"{acao.ShortName} Valor: {acao.RegularMarketPrice}";
                Preco1.Text = $"{acao.ShortName} Valor: {acao.RegularMarketPrice}";
                Produto2.Text = $"{acao.ShortName} Valor: {acao.RegularMarketPrice}";
                Preco2.Text = $"{acao.ShortName} Valor: {acao.RegularMarketPrice}";
                Produto3.Text = $"{acao.ShortName} Valor: {acao.RegularMarketPrice}";
                Preco3.Text = $"{acao.ShortName} Valor: {acao.RegularMarketPrice}";
            });
        }
        catch (Exception ex)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Alerta", "Voce clicou no botao", "OK");
            });
        }
    }
}