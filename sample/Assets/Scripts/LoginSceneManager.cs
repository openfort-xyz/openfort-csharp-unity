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

        string publishable_key_openfort;
#if UNITY_WEBGL && !UNITY_EDITOR
        publishable_key_openfort = "pk_test_4cbab7f5-e100-5a0c-ac4c-440ebbe8b4be";
#else
        publishable_key_openfort = "pk_test_b9ffe6eb-ce05-5c93-b7d4-26f6616218b7";
#endif
        openfort = await OpenfortSDK.Init(
            publishableKey: publishable_key_openfort,
            shieldPublishableKey: "41d616bd-8886-4387-a1ea-a66c94b88760",
            shieldDebug: true
        );

        // Check if user is already logged in
        try
        {
            User user = await openfort.GetUser();
            if (user != null)
            {
                // User is logged in, now set up wallet
                try
                {
                    await SetAutomaticRecoveryMethod();
                    registerPanel.SetActive(false);
                    loginPanel.SetActive(false);
                    openLinkButton.SetActive(false);
                    loadingPanel.SetActive(false);
                    loggedinPanel.SetActive(true);
                    statusTextLabel.text = "Already logged in";
                    return;
                }
                catch (Exception ex)
                {
                    Debug.LogError($"Wallet setup failed on auto-login: {ex.Message}");
                    statusTextLabel.text = "Wallet setup failed. Please log in again.";
                    await LogoutSilently();
                }
            }
        }
        catch (Exception)
        {
            // User is not logged in, continue with normal flow
        }

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

    public async void OnSignUpGuest()
    {
        loadingPanel.SetActive(true);
        signinButton.interactable = false;
        statusTextLabel.text = "Logging In As Guest...";

        try
        {
            await openfort.SignUpGuest();
        }
        catch (Exception ex)
        {
            Debug.LogError($"Guest signup failed: {ex.Message}");
            statusTextLabel.text = "Guest login failed. Please try again.";
            signinButton.interactable = true;
            loadingPanel.SetActive(false);
            return;
        }

        try
        {
            statusTextLabel.text = "Setting up wallet...";
            await SetAutomaticRecoveryMethod();
            loginPanel.SetActive(false);
            statusTextLabel.text = "Logged In As Guest";
            loggedinPanel.SetActive(true);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Wallet setup failed: {ex.Message}");
            statusTextLabel.text = "Wallet setup failed. Please try again.";
            await LogoutSilently();
        }
        finally
        {
            signinButton.interactable = true;
            loadingPanel.SetActive(false);
        }
    }
    private async Task SetAutomaticRecoveryMethod()
    {
        int chainId = 80002;

        // Get encryption session for automatic embedded wallet recovery
        // Learn more about embedded wallet recovery methods: https://www.openfort.io/docs/configuration/recovery-methods#automatic-recovery
        // backend sample: https://github.com/openfort-xyz/openfort-backend-quickstart
        var webRequest = UnityWebRequest.PostWwwForm("https://openfort-js-auth-sample.vercel.app/api/protected-create-encryption-session", "");
        string accessToken = await openfort.GetAccessToken();
        webRequest.SetRequestHeader("Authorization", "Bearer " + accessToken);
        webRequest.SetRequestHeader("Content-Type", "application/json");
        webRequest.SetRequestHeader("Accept", "application/json");
        await SendWebRequestAsync(webRequest);

        if (webRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Failed to get encryption session: " + webRequest.error);
            throw new Exception("Failed to get encryption session");
        }

        var responseText = webRequest.downloadHandler.text;
        var responseJson = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseText);
        var encryptionSession = responseJson["session"];
        Debug.Log("Encryption session: " + encryptionSession);

        var recoveryParams = new AutomaticRecoveryParams(encryptionSession);

        ConfigureEmbeddedWalletRequest request = new ConfigureEmbeddedWalletRequest(
            recoveryParams: recoveryParams,
            chainId: chainId
        );
        await openfort.ConfigureEmbeddedWallet(request);
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

    private async Task OnLogoutClicked()
    {
        logoutButton.interactable = false;

        try
        {
            await openfort.Logout();
            statusTextLabel.text = "";
            loginPanel.SetActive(true);
            loggedinPanel.SetActive(false);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Logout failed: {ex.Message}");
            statusTextLabel.text = "Logout failed. Please try again.";
        }
        finally
        {
            logoutButton.interactable = true;
            loadingPanel.SetActive(false);
        }
    }

    private async Task LogoutSilently()
    {
        try
        {
            await openfort.Logout();
        }
        catch (Exception ex)
        {
            Debug.LogError($"Silent logout failed: {ex.Message}");
        }
    }

    public async void OnLoginClicked()
    {
        loadingPanel.SetActive(true);
        signinButton.interactable = false;

        if (string.IsNullOrEmpty(email.text) || string.IsNullOrEmpty(password.text))
        {
            statusTextLabel.text = "Please provide a valid email and password";
            signinButton.interactable = true;
            loadingPanel.SetActive(false);
            return;
        }

        statusTextLabel.text = $"Logging In As {email.text}...";

        try
        {
            await openfort.LogInWithEmailPassword(email.text, password.text);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Login failed: {ex.Message}");
            statusTextLabel.text = "Login failed. Check your credentials and try again.";
            signinButton.interactable = true;
            loadingPanel.SetActive(false);
            return;
        }

        try
        {
            statusTextLabel.text = "Setting up wallet...";
            await SetAutomaticRecoveryMethod();
            loginPanel.SetActive(false);
            statusTextLabel.text = $"Logged In As {email.text}";
            loggedinPanel.SetActive(true);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Wallet setup failed: {ex.Message}");
            statusTextLabel.text = "Wallet setup failed. Please try again.";
            await LogoutSilently();
        }
        finally
        {
            signinButton.interactable = true;
            loadingPanel.SetActive(false);
        }
    }

    /// <summary>
    /// No account was found, and they have selected to register a email (email) / password combo.
    /// </summary>
    public async void OnRegisterButtonClicked()
    {
        loadingPanel.SetActive(true);
        registerButton.interactable = false;

        if (string.IsNullOrEmpty(email.text) || string.IsNullOrEmpty(password.text))
        {
            statusTextLabel.text = "Please provide a valid email and password";
            registerButton.interactable = true;
            loadingPanel.SetActive(false);
            return;
        }

        if (password.text != confirmPassword.text)
        {
            statusTextLabel.text = "Passwords do not match";
            registerButton.interactable = true;
            loadingPanel.SetActive(false);
            return;
        }

        statusTextLabel.text = $"Registering User {email.text}...";

        try
        {
            await openfort.SignUpWithEmailPassword(email.text, password.text);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Registration failed: {ex.Message}");
            statusTextLabel.text = "Registration failed. Please try again.";
            registerButton.interactable = true;
            loadingPanel.SetActive(false);
            return;
        }

        try
        {
            statusTextLabel.text = "Setting up wallet...";
            await SetAutomaticRecoveryMethod();
            statusTextLabel.text = $"Logged In As {email.text}";
            registerPanel.SetActive(false);
            loggedinPanel.SetActive(true);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Wallet setup failed: {ex.Message}");
            statusTextLabel.text = "Wallet setup failed. Please try again.";
            await LogoutSilently();
        }
        finally
        {
            registerButton.interactable = true;
            loadingPanel.SetActive(false);
        }
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

        try
        {
            // Create a transaction intent and respond with payload to sign
            // https://github.com/openfort-xyz/openfort-js/blob/main/examples/apps/auth-sample/src/pages/api/protected-collect.ts
            var webRequest = UnityWebRequest.PostWwwForm("https://openfort-js-auth-sample.vercel.app/api/protected-collect", "");
            string accessToken = await openfort.GetAccessToken();
            webRequest.SetRequestHeader("Authorization", "Bearer " + accessToken);
            webRequest.SetRequestHeader("Content-Type", "application/json");
            webRequest.SetRequestHeader("Accept", "application/json");
            await SendWebRequestAsync(webRequest);

            Debug.Log("Mint request sent");
            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Mint request failed: {webRequest.error}");
                statusTextLabel.text = "Mint request failed. Please try again.";
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
        }
        catch (Exception ex)
        {
            Debug.LogError($"Mint failed: {ex.Message}");
            statusTextLabel.text = "Mint failed. Please try again.";
        }
        finally
        {
            mintButton.interactable = true;
            loadingPanel.SetActive(false);
        }
    }
    public async void OnSignMessageClicked()
    {
        loadingPanel.SetActive(true);
        signMessageButton.interactable = false;

        try
        {
            SignMessageRequest signMessageRequest = new SignMessageRequest("Hello World!");
            var signature = await openfort.SignMessage(signMessageRequest);
            statusTextLabel.text = $"Signature: {signature}";
        }
        catch (Exception ex)
        {
            Debug.LogError($"Sign message failed: {ex.Message}");
            statusTextLabel.text = "Failed to sign message. Please try again.";
        }
        finally
        {
            signMessageButton.interactable = true;
            loadingPanel.SetActive(false);
        }
    }
    public async void OnGetUserClicked()
    {
        loadingPanel.SetActive(true);
        getUserButton.interactable = false;

        try
        {
            User user = await openfort.GetUser();
            statusTextLabel.text = $"User: {user}";
        }
        catch (Exception ex)
        {
            Debug.LogError($"Get user failed: {ex.Message}");
            statusTextLabel.text = "Failed to get user info. Please try again.";
        }
        finally
        {
            getUserButton.interactable = true;
            loadingPanel.SetActive(false);
        }
    }
    public async void OnSignTypedDataMessageClicked()
    {
        loadingPanel.SetActive(true);
        signTypedDataButton.interactable = false;

        try
        {
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
        }
        catch (Exception ex)
        {
            Debug.LogError($"Sign typed data failed: {ex.Message}");
            statusTextLabel.text = "Failed to sign typed data. Please try again.";
        }
        finally
        {
            signTypedDataButton.interactable = true;
            loadingPanel.SetActive(false);
        }
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