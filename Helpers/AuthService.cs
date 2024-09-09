using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Blazor.Boilerplate.Helpers;

public class AuthService : BaseService
{
    public AuthService(HttpClient httpClient) : base(httpClient)
    {
    }

    public async Task<bool> LoginAsync(string username, string password)
    {

        string loginData = AuthHelper.CreateLoginData(username, password);


        var content = new StringContent(loginData, Encoding.UTF8, "application/x-www-form-urlencoded");

        try
        {
            HttpResponseMessage response = await PostAsync("Login", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        catch (Exception ex)
        {

            throw new Exception("Errore durante il login.", ex);
        }


    }

    public async Task<bool> VerificaLogin()
    {
        try
        {
            var content = new StringContent("", Encoding.UTF8, "application/x-www-form-urlencoded");

            HttpResponseMessage response = await PostAsync("Loggato", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Errore durante il logout.", ex);
        }
    }
}
