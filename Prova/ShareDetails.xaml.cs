using Dominio.Entidades;
using Integracao;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace Prova;

public partial class ShareDetails : ContentPage
{
    private string _shareSymbol;
    private readonly BaseClient _client = new BaseClient();

    public ShareDetails(string shareSymbol)
    {
        InitializeComponent(); // Isso deve vir primeiro
        _shareSymbol = shareSymbol;
        ShowShareDetails(_shareSymbol);
    }

    private async Task ShowShareDetails(String shareSymbol)
    {
        HttpResponseMessage respostaApi = await _client.GetShare(shareSymbol);
        string conteudo = await respostaApi.Content.ReadAsStringAsync();
        Acao acao = JsonConvert.DeserializeObject<Acao>(conteudo);


        Long.Text = $"{acao.LongName}";
        Name.Text = $"{acao.ShortName}";
        Price.Text = $"{acao.RegularMarketPrice}";
        Change.Text = $"{acao.RegularMarketChange}";
        ChangePercent.Text = $" {acao.RegularMarketChangePercent}%";
    }
}