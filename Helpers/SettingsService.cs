using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui.Blazor.Boilerplate.Helpers;

public class SettingsService
{
    private int NumKeySaved;

    public SettingsService()
    {
        NumKeySaved = Preferences.Get("NumeroChiaviSalvate", 0);
    }

    public void SaveSetting(string key, string value)
    {
        Preferences.Set(key, value);
    }

    public string GetSetting(string key, string defaultValue = "")
    {
        return Preferences.Get(key, defaultValue);
    }

    public void RemoveSetting(string key)
    {
        Preferences.Remove(key);
    }

    public void ClearAllSettings()
    {
        Preferences.Clear();
    }

    public void SetKeyFidelityCard(string value)
    {
        Preferences.Set($"chiave-{NumKeySaved}", value);
        NumKeySaved++;
        Preferences.Set("NumeroChiaviSalvate", NumKeySaved);
    }

    public List<string> GetKeysFidelityCard()
    {
        List<string> keys = new List<string>();
        for (int i = 0; i < NumKeySaved; i++)
        {
            keys.Add(Preferences.Get($"chiave-{i}", ""));
        }
        return keys;
    }

    public void RemoveKeyFidelityCard(string key)
    {
        for (int i = 0; i < NumKeySaved; i++)
        {
            if (Preferences.Get($"chiave-{i}", "") == key)
            {
                Preferences.Remove($"chiave-{i}");
                NumKeySaved--;
                Preferences.Set("NumeroChiaviSalvate", NumKeySaved);
                return;
            }
        }
    }

    public void ClearAllKeysFidelityCard()
    {
        for (int i = 0; i < NumKeySaved; i++)
        {
            Preferences.Remove($"chiave-{i}");
        }
        NumKeySaved = 0;
        Preferences.Set("NumeroChiaviSalvate", NumKeySaved);
    }

    public void SaveCustomer(string value)
    {
        Preferences.Set("Customer", value);
    }

    public string GetCustomer()
    {
        return Preferences.Get("Customer", "");
    }
}