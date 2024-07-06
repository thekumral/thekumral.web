using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using thekumral.Api.Controllers.Bases;
using thekumral.Api.Filters;
using thekumral.Core.DTOs.Companies;
using thekumral.Core.DTOs;
using thekumral.Core.Entities;
using thekumral.Core.Services;
using Microsoft.AspNetCore.Authorization;

namespace thekumral.Api.Controllers
{
    public class CompanyController : CustomBaseController
    {
        private readonly ICompanyService _service;
        private readonly IMapper _mapper;
        

        public CompanyController(ICompanyService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [ServiceFilter(typeof(NotFoundFilter<Company>))]
        [HttpGet("[action]/{companyId}")]
        public async Task<IActionResult> GetPostsByCompanyId(Guid companyId)
        {
            var response = await _service.GetPostsByCompanyIdAsync(companyId);
            return CreateActionResult(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> All()
        {
            var companies = await _service.GetAllAsync();
            var companiesDtos = _mapper.Map<List<CompanyDto>>(companies.ToList());
            return CreateActionResult(CustomResponseDto<List<CompanyDto>>.Success(200, companiesDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Company>))]
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var companies = await _service.GetByIdAsync(id);
            var companiesDtos = _mapper.Map<CompanyDto>(companies);
            return CreateActionResult(CustomResponseDto<CompanyDto>.Success(200, companiesDtos));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Save(AddCompanyDto companyDto)
        {
            var entity = _mapper.Map<Company>(companyDto);
            var companies = await _service.AddAsync(entity);
            var companiesDtos = _mapper.Map<AddCompanyDto>(companies);
            return CreateActionResult(CustomResponseDto<AddCompanyDto>.Success(201, companiesDtos));
        }
        [HttpPut("[action]")]
        public async Task<IActionResult> Update(CompanyDto companyDto)
        {
            await _service.UpdateAsync(_mapper.Map<Company>(companyDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        [ServiceFilter(typeof(NotFoundFilter<Company>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            var companies = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(companies);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
        
    }
}
