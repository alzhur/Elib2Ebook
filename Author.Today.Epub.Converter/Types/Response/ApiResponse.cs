using System.Text.Json.Serialization;

namespace Author.Today.Epub.Converter.Types.Response {
    public class ApiResponse<T> {
        /// <summary>
        /// Успешно ли выполнился запрос
        /// </summary>
        [JsonPropertyName("isSuccessful")]
        public bool IsSuccessful { get; set; }
        
        /// <summary>
        /// Сообщение в случае ошибки
        /// </summary>
        [JsonPropertyName("messages")]
        public string[] Messages { get; set; }
        
        /// <summary>
        /// Контент
        /// </summary>
        public T Data { get; set; }
    }
}
