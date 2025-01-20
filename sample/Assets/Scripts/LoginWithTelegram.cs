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

    [Header("Openfort Configuration")]
    [SerializeField]
    string projectPublishableKey;

    [SerializeField]
    string shieldPublishableKey;

    [SerializeField]
    string shieldEncryptionShare;

    [Header("Loading")]
    public GameObject loadingPanel;

    [Header("LoggedIn")]
    public GameObject loggedinPanel;
    public GameObject openLinkButton;
    public Text playerLabel;
    public Button mintButton;
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
        openfort = await OpenfortSDK.Init(
            projectPublishableKey,
            shieldPublishableKey,
            shieldEncryptionShare
        );

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
        // If we are not on WebGL, we can log in as a guest for testing
        Debug.LogWarning(
            "Telegram auth is only available on WebGL. Please run this on a telegram mini app"
        );

        loadingPanel.SetActive(true);
        statusTextLabel.text = $"Logging In As Guest ...";
        try
        {
            AuthResponse authResponse = await openfort.SignUpGuest();
            accessToken = authResponse.Token;
            await SetAutomaticRecoveryMethod();
            var embeddedState = await openfort.GetEmbeddedState();
            Debug.Log("Logged In as guest: " + accessToken);
            Debug.Log("Embedded state: " + embeddedState);
            statusTextLabel.text = $"Logged In As Guest";
            loggedinPanel.SetActive(true);
        }
        catch (System.Exception)
        {
            Debug.LogError("Error logging in as guest");
        }
        loadingPanel.SetActive(false);
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

    public class RootObject
    {
        public TransactionIntentResponse data { get; set; }
    }

    public async void OnMintClicked()
    {
        loadingPanel.SetActive(true);
        mintButton.interactable = false;
        statusTextLabel.text = "Requesting encoded transaction";

        // set up your api url. In this example we are using a the sample telegram backend:
        // https://github.com/openfort-xyz/sample-telegram/tree/main/backend
        // You can use this backend to mint a token with the unity webGL build
        // in backend/src/public folder, and tunneling it with ngrok

        var apiUrl = "";

        var webRequest = UnityWebRequest.PostWwwForm(apiUrl + "/api/protected-collect", "");
        webRequest.SetRequestHeader("Authorization", "Bearer " + accessToken);
        webRequest.SetRequestHeader("Content-Type", "application/json");
        webRequest.SetRequestHeader("Accept", "application/json");

        Debug.Log("Sending Mint request");
        Debug.Log("Authorization: " + "Bearer " + accessToken);

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
        var responseJson = JsonConvert.DeserializeObject<RootObject>(responseText).data;
        statusTextLabel.text = "Signing and broadcasting transaction";
        SignatureTransactionIntentRequest request = new SignatureTransactionIntentRequest(
            responseJson.Id,
            responseJson.NextAction.Payload.UserOperationHash
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
