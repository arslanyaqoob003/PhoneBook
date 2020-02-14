using AutoMapper;
using PhoneBook.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Application.Persons
{
    public class PersonService: Service,IPersonService
    {
        // used for mapping values of two objects
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;
        public PersonService(IMapper mapper, IPersonRepository personRepository)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }
        public async Task<PersonDto> Create(PersonDto dto)
        {
            Validate(dto);
            var person = _mapper.Map<Core.Domain.Person>(dto);
            person.CreatedOn = DateTime.Now;
            person.UpdatedOn = DateTime.Now;
            person = await _personRepository.Insert(person);
            return _mapper.Map<PersonDto>(person);
        }

        public Task Delete(int id)
        {
            return _personRepository.Delete(id);
        }

        public Task<List<PersonDto>> GetAll()
        {
            var persons = new List<PersonDto>();

            // itrator pattern on companies collection
            using var itrator = _personRepository
                                .Get()
                                .GetEnumerator();

            while (itrator.MoveNext())
            {
                var person = itrator.Current;
                var dto = _mapper.Map<PersonDto>(person);
                persons.Add(dto);
            }
            return Task.FromResult(persons);
        }

        public async Task<PersonDto> GetById(int id)
        {
            var person = await _personRepository.Get(id);
            return _mapper.Map<PersonDto>(person);
        }

        public async Task<PersonDto> Update(PersonDto dto)
        {
            var person = await _personRepository.Get(dto.Id);

            // custom exception so that it can be consumed by Api Layer
            if (person == null) throw new NotFoundException($"No person found with Id: {dto.Id}");
            person = _mapper.Map(dto, person);
            person.UpdatedOn = DateTime.Now;
            await _personRepository.Update(person);
            return dto;
        }
    }
}
