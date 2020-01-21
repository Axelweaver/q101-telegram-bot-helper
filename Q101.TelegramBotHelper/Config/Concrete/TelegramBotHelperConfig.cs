using Q101.TelegramBotHelper.Config.Abstract;

namespace Q101.TelegramBotHelper.Config.Concrete
{
    /// <summary>
    /// Configure bot helper
    /// </summary>
    public class TelegramBotHelperConfig : ITelegramBotHelperConfig
    {
        /// <summary>
        /// The token looks something like 123456:ABC-DEF1234ghIkl-zyx57W2v1u123ew11
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Optional base url (Default https://api.telegram.org/bot )
        /// </summary>
        public string BaseUrl { get; set; }

        /// <summary>
        /// Optional proxy host
        /// </summary>
        public string HttpProxyHost { get; set; }

        /// <summary>
        /// Optional proxy
        /// </summary>
        public string HttpProxyPort { get; set; }

        /// <summary>
        /// Optional login
        /// </summary>
        public string HttpProxyUserName { get; set; }

        /// <summary>
        /// Optional password
        /// </summary>
        public string HttpProxyUserPassword { get; set; }
    }
}
