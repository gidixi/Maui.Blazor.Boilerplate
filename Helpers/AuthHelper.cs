using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Blazor.Boilerplate.Helpers;

public class AuthHelper
{
    public static string TransformPassword(string password)
    {
        // Converte la password in base64 e sostituisce '=' con '!'
        string base64Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
        string transformedPassword = base64Password.Replace("=", "!");

        // Trova la metà della lunghezza della password
        int halfLength = transformedPassword.Length / 2;

        // Divide la password in due parti
        string leftPart = transformedPassword.Substring(0, halfLength);
        string rightPart = transformedPassword.Substring(halfLength);

        // Inverte le due parti
        string finalPassword = rightPart + leftPart;

        return finalPassword;
    }

    public static string CreateLoginData(string username, string password)
    {
        // Trasforma la password utilizzando la logica FoxPro
        string transformedPassword = TransformPassword(password);

        // Crea la stringa di login nel formato richiesto
        return $"user={username}&passwd={transformedPassword}";
    }
}
