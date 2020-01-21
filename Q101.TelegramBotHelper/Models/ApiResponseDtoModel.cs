using System.Runtime.Serialization;

namespace Q101.TelegramBotHelper.Models
{
    /// <summary>
    /// DTO of API response
    /// </summary>
    [DataContract]
    public class ApiResponseDtoModel<T>
    {
        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "ok")]
        public bool IsSuccess { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "result")]
        public T Result { get; set; }
    }
}
