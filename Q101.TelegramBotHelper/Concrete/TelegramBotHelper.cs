using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Q101.TelegramBotHelper.Abstract;
using Q101.TelegramBotHelper.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Q101.TelegramBotHelper.Config.Abstract;

namespace Q101.TelegramBotHelper.Concrete
{
    /// <summary>
    /// Telegram bot helper
    /// </summary>
    public class TelegramBotHelper : ITelegramBotHelper
    {
        /// <summary>
        /// Configuration
        /// </summary>
        private readonly ITelegramBotHelperConfig _telegramBotHelperConfig;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="telegramBotHelperConfig"></param>
        public TelegramBotHelper(ITelegramBotHelperConfig telegramBotHelperConfig)
        {
            _telegramBotHelperConfig = telegramBotHelperConfig 
                                       ?? throw new ArgumentNullException(nameof(telegramBotHelperConfig));

            if (string.IsNullOrEmpty(_telegramBotHelperConfig.Token))
            {
                throw new ArgumentException("Missing bot token");
            }

            _telegramBotHelperConfig.BaseUrl = telegramBotHelperConfig.BaseUrl ?? "https://api.telegram.org/bot";
        }

        /// <inheritdoc />
        public async Task<ApiResponseDtoModel<MessageDtoModel>> SendHtmlMessage(string chatId, 
                                                                                string text, 
                                                                                int? replyToMessageId = null, 
                                                                                bool? disableNotification = null)
        {
            var message = GetSendMessageDtoModel(chatId, text, "HTML", replyToMessageId, disableNotification);

            return await SendMessage(message);
        }

        /// <inheritdoc />
        public async Task<ApiResponseDtoModel<MessageDtoModel>> SendMarkupMessage(string chatId,
            string text,
            int? replyToMessageId = null,
            bool? disableNotification = null)
        {
            var message = GetSendMessageDtoModel(chatId, text, "Markup", replyToMessageId, disableNotification);

            return await SendMessage(message);
        }

        /// <inheritdoc />
        public async Task<ApiResponseDtoModel<MessageDtoModel>> SendMessage(SendMessageDtoModel message)
        {
            using (var httpClient = GetHttpClient())
            {
                var requestUri = new Uri(
                    $"{_telegramBotHelperConfig.BaseUrl}{_telegramBotHelperConfig.Token}/sendmessage");

                var jsonContent = JsonConvert.SerializeObject(
                    message,
                    Newtonsoft.Json.Formatting.None,
                    new JsonSerializerSettings
                    {
                        NullValueHandling = NullValueHandling.Ignore
                    });

                var requestContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                using (var request = await httpClient.PostAsync(requestUri, requestContent))
                {
                    var responseContent = request.Content.ReadAsStringAsync().Result;

                    if (!request.IsSuccessStatusCode)
                    {
                        throw new Exception(
                            $"Server error response:\n{request.StatusCode} {request.ReasonPhrase}\n{responseContent}");
                    }

                    var responseObject = 
                        JsonConvert.DeserializeObject<ApiResponseDtoModel<MessageDtoModel>>(
                            responseContent,
                            new UnixDateTimeConverter());

                    return responseObject;
                }
            }
        }
        
        /// <inheritdoc />
        public async Task<ApiResponseDtoModel<MessageDtoModel>> SendSimpleMessage(string chatId,
                                                                                  string text,
                                                                                  int? replyToMessageId = null,
                                                                                  bool? disableNotification = null)
        {
            var message = GetSendMessageDtoModel(chatId, text, null, replyToMessageId, disableNotification);

            return await SendMessage(message);
        }


        private SendMessageDtoModel GetSendMessageDtoModel(string chatId,
                                                           string text,
                                                           string parseMode,
                                                           int? replyToMessageId = null,
                                                           bool? disableNotification = null)
        {
            var message = new SendMessageDtoModel
            {
                ChatId = chatId,
                Message = text,
                ParseMode = parseMode,
                ReplyToMessageId = replyToMessageId,
                DisableNotification = disableNotification
            };

            return message;
        }

        private HttpClient GetHttpClient()
        {
            var proxy =
                string.IsNullOrEmpty(_telegramBotHelperConfig.HttpProxyHost)
                    ? null
                    : new WebProxy
                    {
                        Address = new Uri(
                            $"http://{_telegramBotHelperConfig.HttpProxyHost}:{_telegramBotHelperConfig.HttpProxyPort}"),
                        BypassProxyOnLocal = false,
                        UseDefaultCredentials = false,
                        Credentials = string.IsNullOrEmpty(_telegramBotHelperConfig.HttpProxyUserName)
                            ? null
                            : new NetworkCredential(
                                userName: _telegramBotHelperConfig.HttpProxyUserName, 
                                password:_telegramBotHelperConfig.HttpProxyUserPassword)
                    };

            var httpClient = proxy == null
                ? new HttpClient()
                : new HttpClient(new HttpClientHandler { Proxy = proxy });

            return httpClient;
        }
    }
}
