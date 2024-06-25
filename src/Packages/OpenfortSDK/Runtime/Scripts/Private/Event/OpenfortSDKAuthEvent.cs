namespace Openfort.OpenfortSDK.Event
{
    public delegate void OnAuthEventDelegate(OpenfortAuthEvent authEvent);

    public enum OpenfortAuthEvent
    {
        #region Authorization

        /// <summary>
        /// Started the login process
        /// </summary>
        LoggingIn,
        /// <summary>
        /// Failed to log in
        /// </summary>
        LoginFailed,
        /// <summary>
        /// Successfully logged in
        /// </summary>
        LoginSuccess,

        /// <summary>
        /// Started the log out process
        /// </summary>
        LoggingOut,
        /// <summary>
        /// Failed to log out
        /// </summary>
        LogoutFailed,
        /// <summary>
        /// Successfully logged out
        /// </summary>
        LogoutSuccess,

        #endregion

        #region Using saved credentials
        /// <summary>
        /// Started the re-login process using saved credentials
        /// </summary>
        ReloggingIn,
        /// <summary>
        /// Failed to re-login using saved credentials
        /// </summary>
        ReloginFailed,
        /// <summary>
        /// Successfully re-logged in using saved credentials
        /// </summary>
        ReloginSuccess,

        /// <summary>
        /// Started the reconnect process using saved credentials
        /// </summary>
        Reconnecting,
        /// <summary>
        /// Failed to reconnect using saved credentials
        /// </summary>
        ReconnectFailed,
        /// <summary>
        /// Successfully reconnected in using saved credentials
        /// </summary>
        ReconnectSuccess,

        #endregion

        /// <summary>
        /// Started to the process of checking whether there are any stored credentials
        /// (does not check if they're still valid or not)
        /// </summary>
        CheckingForSavedCredentials,
        /// <summary>
        /// Failed to check whether there are any stored credentials
        /// (does not check if they're still valid or not)
        /// </summary>
        CheckForSavedCredentialsFailed,
        /// <summary>
        /// Successfully checked whether there are any stored credentials
        /// (does not check if they're still valid or not)
        /// </summary>
        CheckForSavedCredentialsSuccess
    }
}