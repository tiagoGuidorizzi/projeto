using System.Text.Json;
using SharedLibrary.Domain;

public class PlayerDataService
{
    private readonly HttpClient _httpClient;

    public PlayerDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Player>> FetchPlayersAsync()
    {
        var json = await _httpClient.GetStringAsync("https://api.cartola.globo.com/atletas/mercado");
        var jsonData = JsonDocument.Parse(json);

        var players = jsonData.RootElement.EnumerateArray()
            .Select(element => new Player
            {
                Id = element.GetProperty("atleta_id").GetInt32(),
                Name = element.GetProperty("nome").GetString(),
                ShortName = element.GetProperty("apelido_abreviado").GetString(),
                Team = element.GetProperty("clube_id").ToString(),
                Position = element.GetProperty("posicao_id").ToString(), 
                GamesPlayed = element.GetProperty("jogos_num").GetInt32(),
                AveragePoints = element.GetProperty("media_num").GetDouble(),
                CurrentPoints = element.GetProperty("pontos_num").GetDouble(),
                Price = element.GetProperty("preco_num").GetDouble(),
                PhotoUrl = element.GetProperty("foto").GetString(),
            }).ToList();

        return players;
    }
}
