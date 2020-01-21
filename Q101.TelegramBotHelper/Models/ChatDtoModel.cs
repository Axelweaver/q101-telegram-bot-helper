using System.Runtime.Serialization;

namespace Q101.TelegramBotHelper.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class ChatDtoModel
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "id")]
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "title")]
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "username")]
        public string UserName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}
