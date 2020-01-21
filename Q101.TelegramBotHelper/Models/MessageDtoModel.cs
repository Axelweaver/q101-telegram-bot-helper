using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Q101.TelegramBotHelper.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public class MessageDtoModel
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "id")]
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "chat")]
        public ChatDtoModel Chat { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "text")]
        public string Text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "entities")]
        public IEnumerable<MessageEntityDtoModel> Entities { get; set; }


    }
}
