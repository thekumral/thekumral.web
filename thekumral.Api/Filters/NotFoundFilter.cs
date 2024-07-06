using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using thekumral.Core.DTOs;
using thekumral.Core.Entities;
using thekumral.Core.Services;

namespace thekumral.Api.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter
        where T : BaseEntity
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service)
        {
            _service = service;
        }

        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next
        )
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();
            if (idValue == null)
            {
                await next.Invoke();
                return;
            }
            var id = (Guid)idValue;
            var anyEntity = await _service.AnyAsync(x => x.Id == id);

            if (anyEntity)
            {
                await next.Invoke();
            }
            else
            {
                context.Result = new NotFoundObjectResult(
                    CustomResponseDto<NoContentResult>.Fail(
                        404,
                        $"{typeof(T).Name}({id}) Bulunamadı."
                    )
                );
            }
        }
    }
}
