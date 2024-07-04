using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Openfort.OpenfortSDK;
using Openfort.OpenfortSDK.Model;
using Newtonsoft.Json;
using System.Collections.Generic;


public class LoginSceneManager : MonoBehaviour
{
    // Reference to our Authentication service
    private string accessToken;
    private OpenfortSDK openfort;

    [Header("Loading")]
    public GameObject loadingPanel;

    [Header("Login")]
    public GameObject loginPanel;
    public InputField email;
    public InputField password;
    public Button signinButton;
    public Button googleButton;

    [Header("Register")]
    public GameObject registerPanel;
    public InputField confirmPassword;
    public Button registerButton;

    [Header("Forgot Password")]
    public GameObject ForgotPasswordPanel;
    public InputField emailRecover;
    public Button requestButton;

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


    private async void Start()
    {
        if (OpenfortSDK.Instance != null)
        {
            openfort = OpenfortSDK.Instance;
        }
        openfort = await OpenfortSDK.Init("pk_test_505bc088-905e-5a43-b60b-4c37ed1f887a", "a4b75269-65e7-49c4-a600-6b5d9d6eec66", "/cC/ElEv1bCHxvbE/UUH+bLIf8nSLZOrxj8TkKChiY4=");
        // Hide all our panels until we know what UI to display
        registerPanel.SetActive(false);
        loggedinPanel.SetActive(false);
        openLinkButton.SetActive(false);
        loadingPanel.SetActive(false);
        loginPanel.SetActive(true);

    }
    #endregion

    #region PUBLIC_BUTTON_METHODS
    /// <summary>
    /// Login Button means they've selected to submit a email (email) / password combo
    /// Note: in this flow if no account is found, it will ask them to register.
    /// </summary>

    public async void OnGoogleClicked()
    {
        googleButton.interactable = false;
        loadingPanel.SetActive(true);

        OAuthInitRequest request = new OAuthInitRequest()
        {
#if UNITY_WEBGL || UNITY_STANDALONE_WIN
            Provider = OAuthProvider.Google,
            UsePooling = true,
#else
            Provider = OAuthProvider.Google,
            UsePooling = false,
            Options = new OAuthInitRequestOptions()
            {
                RedirectTo = "mygame://callback"
            },
#endif
        };
        try
        {
            await openfort.AuthenticateWithOAuth(request);
            AuthPlayerResponse authPlayerResponse = await openfort.GetUser();
            accessToken = await openfort.GetAccessToken();
            statusTextLabel.text = $"Logged In With Google";
            await SetAutomaticRecoveryMethod();
            loginPanel.SetActive(false);
            registerPanel.SetActive(false);
            loggedinPanel.SetActive(true);
            loadingPanel.SetActive(false);
            googleButton.interactable = false;
        }
        catch (System.Exception)
        {

        }
        googleButton.interactable = true;
        loadingPanel.SetActive(false);
    }

    private async Task SetAutomaticRecoveryMethod()
    {
        int chainId = 80002;
        ShieldAuthentication shieldConfig = new ShieldAuthentication(ShieldAuthType.Openfort, accessToken);
        EmbeddedSignerRequest request = new EmbeddedSignerRequest(chainId, shieldConfig);
        await openfort.ConfigureEmbeddedSigner(request);
    }

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

    // This remains your async Task method which should not be directly used with UI event listeners.
    private async Task OnLogoutClicked()
    {
        logoutButton.interactable = false;
        await openfort.Logout();
        statusTextLabel.text = "";
        logoutButton.interactable = true;
        loginPanel.SetActive(true);
        loggedinPanel.SetActive(false);
        loadingPanel.SetActive(false);
    }

    public async void OnLoginClicked()
    {
        loadingPanel.SetActive(true);
        signinButton.interactable = false;
        if (string.IsNullOrEmpty(email.text) || string.IsNullOrEmpty(password.text))
        {
            statusTextLabel.text = "Please provide a correct email/password";
            return;
        }
        statusTextLabel.text = $"Logging In As {email.text} ...";

        try
        {
            AuthResponse authResponse = await openfort.LogInWithEmailPassword(email.text, password.text);
            accessToken = authResponse.Token;
            await SetAutomaticRecoveryMethod();
            loginPanel.SetActive(false);
            statusTextLabel.text = $"Logged In As {email.text}";

            loggedinPanel.SetActive(true);
        }
        catch (System.Exception)
        {
            loginPanel.SetActive(false);
            registerPanel.SetActive(true);
        }
        signinButton.interactable = true;
        loadingPanel.SetActive(false);
    }

    /// <summary>
    /// No account was found, and they have selected to register a email (email) / password combo.
    /// </summary>
    public async void OnRegisterButtonClicked()
    {
        loadingPanel.SetActive(true);
        registerButton.interactable = false;
        if (password.text != confirmPassword.text)
        {
            statusTextLabel.text = "Passwords do not Match.";
            return;
        }

        statusTextLabel.text = $"Registering User {email.text} ...";
        AuthResponse authResponse = await openfort.SignUpWithEmailPassword(email.text, password.text);
        accessToken = authResponse.Token;
        await SetAutomaticRecoveryMethod();
        statusTextLabel.text = $"Logged In As {email.text}";

        registerPanel.SetActive(false);
        loggedinPanel.SetActive(true);
        registerButton.interactable = true;
        loadingPanel.SetActive(false);
    }

    /// <summary>
    /// They have opted to cancel the Registration process.
    /// Possibly they typed the email address incorrectly.
    /// </summary>
    public void OnCancelRegisterButtonClicked()
    {
        ResetFormsAndStatusLabel();

        registerPanel.SetActive(false);
        loginPanel.SetActive(true);
    }

    public void OnBackToLoginClicked()
    {
        ResetFormsAndStatusLabel();
        loginPanel.SetActive(true);
    }

    private void ResetFormsAndStatusLabel()
    {
        // Reset all forms
        email.text = string.Empty;
        password.text = string.Empty;
        confirmPassword.text = string.Empty;
        // Reset logged in player label
        playerLabel.text = string.Empty;
        // Reset status text
        statusTextLabel.text = string.Empty;
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
        var webRequest = UnityWebRequest.PostWwwForm("https://descriptive-night-production.up.railway.app/mint", "");
        webRequest.SetRequestHeader("Authorization", "Bearer " + accessToken);
        webRequest.SetRequestHeader("Content-Type", "application/json");
        webRequest.SetRequestHeader("Accept", "application/json");
        await SendWebRequestAsync(webRequest);

        Debug.Log("Mint request sent");
        if (webRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("Mint Failed: " + webRequest.error);
            return;
        }


        var responseText = webRequest.downloadHandler.text;
        Debug.Log("Mint Response: " + responseText);
        var responseJson = JsonConvert.DeserializeObject<RootObject>(responseText);
        statusTextLabel.text = "Signing and broadcasting transaction";
        SignatureTransactionIntentRequest request = new SignatureTransactionIntentRequest(responseJson.transactionIntentId, responseJson.userOperationHash);
        TransactionIntentResponse intentResponse = await openfort.SendSignatureTransactionIntentRequest(request);
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
                "Mail", new List<TypedDataField>
                {
                    new TypedDataField("from", "Person"),
                    new TypedDataField("to", "Person"),
                    new TypedDataField("content", "string")
                }
            },
            {
                "Person", new List<TypedDataField>
                {
                    new TypedDataField("name", "string"),
                    new TypedDataField("wallet", "address")
                }
            }
        };

        var message = new Dictionary<string, object>
        {
            { "from", new Dictionary<string, object> { { "name", "Alice" }, { "wallet", "0x2111111111111111111111111111111111111111" } } },
            { "to", new Dictionary<string, object> { { "name", "Bob" }, { "wallet", "0x3111111111111111111111111111111111111111" } } },
            { "content", "Hello!" }
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