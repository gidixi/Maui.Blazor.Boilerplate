using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Blazor.Boilerplate.Helpers;

public class MessageService
{
    public event Action? OnMessageChanged;
    private string _message = string.Empty;
    private bool _showMessage;

    public string Message => _message;
    public bool ShowMessage => _showMessage;

    public async Task ShowMessageAsync(string message, int duration = 3000)
    {
        _message = message;
        _showMessage = true;
        OnMessageChanged?.Invoke();  // Notifica il layout del cambiamento

        await Task.Delay(duration);
        _showMessage = false;
        OnMessageChanged?.Invoke();  // Nascondi il messaggio dopo il tempo specificato
    }
}
