namespace Q101.TelegramBotHelper.Config.Abstract
{
    /// <summary>
    /// Configure bot helper
    /// </summary>
    public interface ITelegramBotHelperConfig
    {
        /// <summary>
        /// The token looks something like 123456:ABC-DEF1234ghIkl-zyx57W2v1u123ew11
        /// </summary>
        string Token { get; set; }

        /// <summary>
        /// Optional base url (Default https://api.telegram.org/bot )
        /// </summary>
        string BaseUrl { get; set; }

        /// <summary>
        /// Optional proxy host
        /// </summary>
        string HttpProxyHost { get; set; }

        /// <summary>
        /// Optional proxy
        /// </summary>
        string HttpProxyPort { get; set; }

        /// <summary>
        /// Optional login
        /// </summary>
        string HttpProxyUserName { get; set; }

        /// <summary>
        /// Optional password
        /// </summary>
        string HttpProxyUserPassword { get; set; }
    }
}
