using System.Runtime.Serialization;

namespace Q101.TelegramBotHelper.Models
{
    /// <summary>
    /// Model for send message
    /// </summary>
    [DataContract]
    public class SendMessageDtoModel
    {
        /// <summary>
        /// Unique identifier for the target chat or username
        /// of the target channel (in the format @channelusername
        /// </summary>
        [DataMember(Name = "chat_id")]
        public string ChatId { get; set; }

        /// <summary>
        /// Text of the message to be sent
        /// </summary>
        [DataMember(Name = "text")]
        public string Message { get; set; }

        /// <summary>
        /// Send Markdown or HTML, if you want Telegram apps to show bold, italic,
        /// fixed-width text or inline URLs in your bot's message.
        /// </summary>
        [DataMember(Name = "parse_mode")]
        public string ParseMode { get; set; }

        /// <summary>
        /// [Optional] Disables link previews for links in this message
        /// </summary>
        [DataMember(Name = "disable_web_page_preview")]
        public bool? DisableWebPagePreview { get; set; }

        /// <summary>
        /// [Optional] Sends the message silently. Users will receive a notification with no sound.
        /// </summary>
        [DataMember(Name = "disable_notification")]
        public bool? DisableNotification { get; set; }

        /// <summary>
        /// [Optional] If the message is a reply, ID of the original message
        /// </summary>
        [DataMember(Name = "reply_to_message_id")]
        public int? ReplyToMessageId { get; set; }

        /// <summary>
        /// [Optional] Additional interface options.
        /// A JSON-serialized object for an inline keyboard, custom reply keyboard,
        /// instructions to remove reply keyboard or to force a reply from the user.
        /// </summary>
        [DataMember(Name = "reply_markup")]
        public object ReplyMarkup { get; set; }
    }
}
