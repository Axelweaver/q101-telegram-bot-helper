using System.Runtime.Serialization;

namespace Q101.TelegramBotHelper.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class MessageEntityDtoModel
    {
        /// <summary>
        /// Offset
        /// </summary>
        [DataMember(Name = "offset")]
        public int Offset { get; set; }

        /// <summary>
        /// Length
        /// </summary>
        [DataMember(Name = "length")]
        public int Length { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        [DataMember(Name = "url")]
        public string Url { get; set; }
    }
}
