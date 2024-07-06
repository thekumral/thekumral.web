using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using thekumral.Core.DTOs;
using thekumral.Service.Exceptions;

namespace thekumral.Api.MiddleWares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCostumException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    // Hata durumuna göre uygun HTTP durum kodunu belirler.
                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400, // İstemci tarafı istisnası, HTTP 400 döner.
                        NotFoundException => 404, // Bulunamayan öğe istisnası, HTTP 404 döner.
                        _ => 500 // Diğer tüm istisna durumlarında HTTP 500 döner.
                    };

                    context.Response.StatusCode = statusCode;

                    // Hata durumuna göre özel bir yanıt nesnesi oluşturur ve JSON formatında yanıtı gönderir.
                    var response = CustomResponseDto<NoContentDto>.Fail(
                        statusCode,
                        exceptionFeature.Error.Message
                    );
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
