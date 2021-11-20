using Newtonsoft.Json;
using Swapi.Rest.SwapiModel;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Swapi.Rest
{
    public class SwapiHandler : IDisposable
    {
        HttpClient client;

        HttpRequestMessage request;

        public SwapiHandler()
        {
            client = new HttpClient();
        }

        public async Task<Film[]> GetFilms()
        {
            try
            {
                request = new HttpRequestMessage(HttpMethod.Get,$"{Constantes.SWAPI_BASE}{Constantes.FILM}");
                HttpResponseMessage response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    SwapiResponse filmsResponse = JsonConvert.DeserializeObject<SwapiResponse>(await response.Content.ReadAsStringAsync());
                    return filmsResponse.results;
                }
                else
                {
                    throw new ApplicationException($"Error: " + response.ReasonPhrase);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            request = null;
            client.Dispose();

        }
    }
}