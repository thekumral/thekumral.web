using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace thekumral.Core.Entities.BaseEntities
{
    public class CustomResponseDto<T>
    {
        /// <summary>
        /// Yanıt verisini alır veya ayarlar.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Oluşan hataları alır veya ayarlar.
        /// </summary>
        public List<string> Errors { get; set; }

        /// <summary>
        /// Yanıt durumu kodunu alır veya ayarlar.
        /// </summary>
        [JsonIgnore]
        public int StatusCode { get; set; }

        /// <summary>
        /// Başarılı bir yanıt oluşturur.
        /// </summary>
        /// <param name="statusCode">Yanıt durumu kodu</param>
        /// <param name="data">Yanıt verisi</param>
        /// <returns>Başarılı bir yanıt nesnesi</returns>
        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T> { Data = data, StatusCode = statusCode, Errors = null };
        }

        /// <summary>
        /// Başarılı bir yanıt oluşturur.
        /// </summary>
        /// <param name="statusCode">Yanıt durumu kodu</param>
        /// <returns>Başarılı bir yanıt nesnesi</returns>
        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode };
        }

        /// <summary>
        /// Başarısız bir yanıt oluşturur.
        /// </summary>
        /// <param name="statusCode">Yanıt durumu kodu</param>
        /// <param name="errors">Oluşan hataların listesi</param>
        /// <returns>Başarısız bir yanıt nesnesi</returns>
        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors };
        }

        /// <summary>
        /// Başarısız bir yanıt oluşturur.
        /// </summary>
        /// <param name="statusCode">Yanıt durumu kodu</param>
        /// <param name="error">Oluşan hata</param>
        /// <returns>Başarısız bir yanıt nesnesi</returns>
        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}
