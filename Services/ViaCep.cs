namespace Desafio_Fullstack_Accenture.Services
{
    public class ViaCep
    {
        public async Task<HttpResponseMessage> ValidaCep(string cep)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            HttpClient httpClient = new HttpClient(clientHandler);
            var result = await httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json");

            return result;
        }
    }
}
