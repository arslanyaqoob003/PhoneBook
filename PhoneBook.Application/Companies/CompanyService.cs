using AutoMapper;
using PhoneBook.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Application.Companies
{
    public class CompanyService : Service, ICompanyService
    {
        // used for mapping values of two objects
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(IMapper mapper, ICompanyRepository companyRepository)
        {
            _mapper = mapper;
            _companyRepository = companyRepository;
        }
        public async Task<CompanyDto> Create(CompanyDto dto)
        {
            Validate(dto);
            var company = _mapper.Map<Core.Domain.Company>(dto);
            company.CreatedOn = DateTime.Now;
            company.UpdatedOn = DateTime.Now;
            company = await _companyRepository.Insert(company);
            return _mapper.Map<CompanyDto>(company);
        }

        public Task Delete(int id)
        {
            return _companyRepository.Delete(id);
        }

        public Task<List<CompanyDto>> GetAll()
        {
            var comapanies = new List<CompanyDto>();

            // itrator pattern on companies collection
            using var itrator = _companyRepository
                                .Get()
                                .GetEnumerator();

            while (itrator.MoveNext())
            {
                var company = itrator.Current;
                var dto = _mapper.Map<CompanyDto>(company);
                comapanies.Add(dto);
            }
            return Task.FromResult(comapanies);
        }

        public async Task<CompanyDto> GetById(int id)
        {
            var company = await _companyRepository.Get(id);
            return _mapper.Map<CompanyDto>(company);
        }

        public async Task<CompanyDto> Update(CompanyDto dto)
        {
            var company = await _companyRepository.Get(dto.Id);

            // custom exception so that it can be consumed by Api Layer
            if (company == null) throw new NotFoundException($"No Person found with Id: {dto.Id}");
            company = _mapper.Map(dto, company);
            await _companyRepository.Update(company);
            return dto;
        }
    }
}
