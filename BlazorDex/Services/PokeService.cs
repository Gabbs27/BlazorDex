namespace BlazorDex.Services;

using System.Net.Http.Json;
using System.Text.Json;

public class PokeService
{
    private readonly HttpClient _httpClient;

    public PokeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Pokemon?> GetPokemonAsync(string name)
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<Pokemon>($"https://pokeapi.co/api/v2/pokemon/{name}");
            return response;
        }
        catch (Exception)
        {
            return null;
        }
    }
}

public class Pokemon
{
    public string? Name { get; set; }
    public int Weight { get; set; }
    public int Height { get; set; }
    public Sprites? Sprites { get; set; }
    public List<TypeEntry>? Types { get; set; }
    public List<AbilityEntry>? Abilities { get; set; }
    public List<StatEntry>? Stats { get; set; }
}

public class Sprites
{
    public string? Front_Default { get; set; }
    public string? Back_Default { get; set; }
}

public class TypeEntry
{
    public TypeInfo? Type { get; set; }
}

public class TypeInfo
{
    public string? Name { get; set; }
}

public class AbilityEntry
{
    public AbilityInfo? Ability { get; set; }
}

public class AbilityInfo
{
    public string? Name { get; set; }
}

public class StatEntry
{
    public StatInfo? Stat { get; set; }
    public int Base_Stat { get; set; }
}

public class StatInfo
{
    public string? Name { get; set; }
}
