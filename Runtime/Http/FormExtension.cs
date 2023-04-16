using UnityEngine;
using System.Collections.Generic;
using System.Text;
using UnityEngine.Networking;

public static class WWWFormExtensions
{
    public static void DebugLogContents(this WWWForm form)
    {
        if (form == null)
        {
            Debug.LogError("The WWWForm is null.");
            return;
        }

        var formHeaders = form.headers;
        var keys = GetFormFieldKeys(form);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("Form Fields:");
        foreach (string key in keys)
        {
            sb.AppendLine($"{key}: {form.GetFieldValue(key)}");
        }

        sb.AppendLine("Form Headers:");
        foreach (var header in formHeaders)
        {
            sb.AppendLine($"{header.Key}: {header.Value}");
        }

        Debug.Log(sb.ToString());
    }

    private static List<string> GetFormFieldKeys(WWWForm form)
    {
        List<string> keys = new List<string>();

        string formString = Encoding.UTF8.GetString(form.data);
        string[] fieldPairs = formString.Split('&');

        foreach (string fieldPair in fieldPairs)
        {
            string[] fieldComponents = fieldPair.Split('=');
            if (fieldComponents.Length > 0)
            {
                keys.Add(UnityWebRequest.UnEscapeURL(fieldComponents[0]));
            }
        }

        return keys;
    }

    public static string GetFieldValue(this WWWForm form, string key)
    {
        string formString = Encoding.UTF8.GetString(form.data);
        string[] fieldPairs = formString.Split('&');

        foreach (string fieldPair in fieldPairs)
        {
            string[] fieldComponents = fieldPair.Split('=');
            if (fieldComponents.Length == 2 && UnityWebRequest.UnEscapeURL(fieldComponents[0]) == key)
            {
                return UnityWebRequest.UnEscapeURL(fieldComponents[1]);
            }
        }

        return null;
    }
}
