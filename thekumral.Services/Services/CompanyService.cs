using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using thekumral.Core.DTOs;
using thekumral.Core.DTOs.Companies;
using thekumral.Core.Entities;
using thekumral.Core.Repositories;
using thekumral.Core.Services;
using thekumral.Core.UnitOfWork;

namespace thekumral.Service.Services
{
    public class CompanyService : Service<Company>, ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(
            IGenericRepository<Company> repository,
            IUnitOfWork unitOfWork,
            ICompanyRepository companyRepository,
            IMapper mapper
        )
            : base(repository, unitOfWork)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<List<CompanyDto>>> GetPostCompanyWithUsers()
        {
            try
            {
                var companies = await _companyRepository.GetPostCompanyWithUsers();
                var companyDtos = _mapper.Map<List<CompanyDto>>(companies);
                return CustomResponseDto<List<CompanyDto>>.Success(200, companyDtos);
            }
            catch (Exception ex)
            {
                return CustomResponseDto<List<CompanyDto>>.Fail(500, "Internal Server ErRRor");
            }
        }

        public async Task<CustomResponseDto<List<PostDtoForCompany>>> GetPostsByCompanyIdAsync(
            Guid companyId
        )
        {
            try
            {
                var posts = await _companyRepository.GetPostsByCompanyIdAsync(companyId);
                var postsDto = _mapper.Map<List<PostDtoForCompany>>(posts);
                return CustomResponseDto<List<PostDtoForCompany>>.Success(200, postsDto);
            }
            catch (Exception ex)
            {
                return CustomResponseDto<List<PostDtoForCompany>>.Fail(500, "Hata! CompanyService ! içinde");
            }
        }
    }
}
