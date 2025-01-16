using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Openfort.OpenfortSDK;
using Openfort.OpenfortSDK.Model;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoginWithTelegram : MonoBehaviour
{
    // Reference to our Authentication service
    private string accessToken;
    private OpenfortSDK openfort;

    [Header("Loading")]
    public GameObject loadingPanel;

    [Header("LoggedIn")]
    public GameObject loggedinPanel;
    public GameObject openLinkButton;
    public Text playerLabel;
    public Button mintButton;
    public Button logoutButton;
    public Button getUserButton;
    public Button signMessageButton;
    public Button signTypedDataButton;
    private string transactionHash;

    [Header("General")]
    public Text statusTextLabel;

    #region UNITY_LIFECYCLE


    [DllImport("__Internal")]
    private static extern string InitTelegramApp();

    private async void Start()
    {
        if (OpenfortSDK.Instance != null)
        {
            openfort = OpenfortSDK.Instance;
        }
        openfort = await OpenfortSDK.Init( // Embedded signer
            "pk_test_505bc088-905e-5a43-b60b-4c37ed1f887a",
            "a4b75269-65e7-49c4-a600-6b5d9d6eec66",
            "/cC/ElEv1bCHxvbE/UUH+bLIf8nSLZOrxj8TkKChiY4="
        );
        // openfort = await OpenfortSDK.Init(
        //     "pk_test_723b5e8f-3d14-5ee9-a6ca-55da56782097",
        //     "78e5f750-4b64-4c5a-bca9-23710cad8e3c",
        //     "Au2zQ+aE+1WXxAt08c6BTummUBulVTy9NKhgSrhYDEVU"
        // );

        Debug.Log("Embedded state: " + await openfort.GetEmbeddedState());
        // Hide all our panels until we know what UI to display
        loggedinPanel.SetActive(false);
        openLinkButton.SetActive(false);
        loadingPanel.SetActive(true);

#if UNITY_WEBGL && !UNITY_EDITOR
        var telegramAuth = InitTelegramApp();
        if (string.IsNullOrEmpty(telegramAuth))
        {
            Debug.LogError("Telegram auth is empty, open in a telegram mini app ");
            return;
        }

        Debug.Log("Login with telegram auth: " + telegramAuth);
        ThirdPartyOAuthRequest request = new ThirdPartyOAuthRequest(
            ThirdPartyOAuthProvider.TelegramMiniApp,
            telegramAuth,
            TokenType.IdToken
        );

        try
        {
            Debug.Log("Login with telegram auth: " + telegramAuth);
            await openfort.AuthenticateWithThirdPartyProvider(request);
            Debug.Log("Legged in! Getting user");
            AuthPlayerResponse authPlayerResponse = await openfort.GetUser();

            Debug.Log("User: " + authPlayerResponse);

            // Debug.Log("Sending Mint request");
            // Debug.Log("Authorization: " + "Bearer " + accessToken);
            // Debug.Log("access token: " + await openfort.GetAccessToken());

            accessToken = telegramAuth;
            statusTextLabel.text = $"Logged In With Telegram";
            Debug.Log("Logged In With Telegram: " + accessToken);
            await SetAutomaticRecoveryMethod();
            loggedinPanel.SetActive(true);
            loadingPanel.SetActive(false);
        }
        catch (System.Exception)
        {
            statusTextLabel.text = $"Error logging in with Telegram";
            Debug.LogError("Error logging in with Telegram");
        }
#else
        // Create a custom object as a context
        Debug.LogWarning(
            "Telegram auth is only available on WebGL. Please run this on a telegram mini app"
        );
#endif
    }
    #endregion


    private async Task SetAutomaticRecoveryMethod()
    {
        int chainId = 80002;
        ShieldAuthentication shieldConfig = new ShieldAuthentication(
            ShieldAuthType.Openfort,
            accessToken
        );
        EmbeddedSignerRequest request = new EmbeddedSignerRequest(chainId, shieldConfig);
        await openfort.ConfigureEmbeddedSigner(request);
    }

    #region PUBLIC_BUTTON_METHODS
    public void LogoutClicked()
    {
        loadingPanel.SetActive(true);
        var logoutTask = OnLogoutClicked();
        HandleTask(logoutTask);
    }

    private async void HandleTask(Task task)
    {
        try
        {
            // Await the task, allowing any exceptions to propagate.
            await task;
        }
        catch (Exception ex)
        {
            // Log or handle the exception as appropriate.
            Debug.LogError($"Error during logout: {ex.Message}");
        }
    }

    private Task OnLogoutClicked()
    {
        Debug.Log("Logging out");
        throw new NotImplementedException();
    }

    public class RootObject
    {
        public string transactionIntentId { get; set; }
        public string userOperationHash { get; set; }
    }

    public async void OnMintClicked()
    {
        loadingPanel.SetActive(true);
        mintButton.interactable = false;
        statusTextLabel.text = "Requesting encoded transaction";
        var webRequest = UnityWebRequest.PostWwwForm(
            "https://openfort-auth-non-custodial.vercel.app/api/protected-collect",
            ""
        );
        webRequest.SetRequestHeader("Authorization", "Bearer " + accessToken);
        webRequest.SetRequestHeader("Content-Type", "application/json");
        webRequest.SetRequestHeader("Accept", "application/json");

        Debug.Log("Sending Mint request");
        Debug.Log("Authorization: " + "Bearer " + accessToken);
        Debug.Log("access token: " + await openfort.GetAccessToken());

        await SendWebRequestAsync(webRequest);

        Debug.Log("Mint request sent");
        if (webRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Mint Failed: " + webRequest.error);
            statusTextLabel.text = "Mint Failed";
            mintButton.interactable = true;
            loadingPanel.SetActive(false);
            return;
        }

        var responseText = webRequest.downloadHandler.text;
        Debug.Log("Mint Response: " + responseText);
        var responseJson = JsonConvert.DeserializeObject<RootObject>(responseText);
        statusTextLabel.text = "Signing and broadcasting transaction";
        SignatureTransactionIntentRequest request = new SignatureTransactionIntentRequest(
            responseJson.transactionIntentId,
            responseJson.userOperationHash
        );
        TransactionIntentResponse intentResponse =
            await openfort.SendSignatureTransactionIntentRequest(request);
        statusTextLabel.text = $"{intentResponse.Response.TransactionHash}";
        transactionHash = intentResponse.Response.TransactionHash;
        openLinkButton.SetActive(true);
        mintButton.interactable = true;
        loadingPanel.SetActive(false);
    }

    public async void OnSignMessageClicked()
    {
        loadingPanel.SetActive(true);
        signMessageButton.interactable = false;
        SignMessageRequest signMessageRequest = new SignMessageRequest("Hello World!");
        var signature = await openfort.SignMessage(signMessageRequest);
        statusTextLabel.text = $"Signature: {signature}";
        signMessageButton.interactable = true;
        loadingPanel.SetActive(false);
    }

    public async void OnGetUserClicked()
    {
        Debug.Log("Getting user");
        Debug.Log("Embedded state: " + await openfort.GetEmbeddedState());
        loadingPanel.SetActive(true);
        getUserButton.interactable = false;
        AuthPlayerResponse user = await openfort.GetUser();
        statusTextLabel.text = $"User: {user}";
        getUserButton.interactable = true;
        loadingPanel.SetActive(false);
    }

    public async void OnSignTypedDataMessageClicked()
    {
        loadingPanel.SetActive(true);
        signMessageButton.interactable = false;

        var domain = new TypedDataDomain(
            name: "Openfort",
            version: "0.5",
            chainId: 80002,
            verifyingContract: "0x9b5AB198e042fCF795E4a0Fa4269764A4E8037D2"
        );

        var types = new Dictionary<string, List<TypedDataField>>
        {
            {
                "Mail",
                new List<TypedDataField>
                {
                    new TypedDataField("from", "Person"),
                    new TypedDataField("to", "Person"),
                    new TypedDataField("content", "string"),
                }
            },
            {
                "Person",
                new List<TypedDataField>
                {
                    new TypedDataField("name", "string"),
                    new TypedDataField("wallet", "address"),
                }
            },
        };

        var message = new Dictionary<string, object>
        {
            {
                "from",
                new Dictionary<string, object>
                {
                    { "name", "Alice" },
                    { "wallet", "0x2111111111111111111111111111111111111111" },
                }
            },
            {
                "to",
                new Dictionary<string, object>
                {
                    { "name", "Bob" },
                    { "wallet", "0x3111111111111111111111111111111111111111" },
                }
            },
            { "content", "Hello!" },
        };

        var signTypedDataRequest = new SignTypedDataRequest(domain, types, message);

        var signature = await openfort.SignTypedData(signTypedDataRequest);

        statusTextLabel.text = $"Signature: {signature}";
        signMessageButton.interactable = true;
        loadingPanel.SetActive(false);
    }

    public void OpenLink()
    {
        Application.OpenURL("https://www.oklink.com/amoy/tx/" + transactionHash);
    }

    private Task SendWebRequestAsync(UnityWebRequest webRequest)
    {
        TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
        webRequest.SendWebRequest().completed += _ =>
        {
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.Success:
                    tcs.SetResult(true);
                    break;
                default:
                    tcs.SetException(new Exception(webRequest.error));
                    break;
            }
        };
        return tcs.Task;
    }

    #endregion
}
