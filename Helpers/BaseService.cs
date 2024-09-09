using System.Net.Http;
using System.Threading.Tasks;

namespace Maui.Blazor.Boilerplate.Helpers;

public abstract class BaseService
{
    protected readonly HttpClient _httpClient;

    // Iniettiamo l'HttpClient tramite costruttore
    public BaseService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Puoi aggiungere qui metodi comuni per i servizi, come gestione errori o autenticazione
    protected async Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
    {
        return await _httpClient.PostAsync(url, content);
    }
}
