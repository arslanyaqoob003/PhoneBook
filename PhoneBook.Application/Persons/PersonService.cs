using AutoMapper;
using PhoneBook.Core.Exceptions;
using PhoneBook.Core.Parser;
using PhoneBook.Core.Parser.Factory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhoneBook.Application.Persons
{
    // service implementation for persons according to requirement document
    public class PersonService: Service,IPersonService
    {
        // used for mapping values of two objects
        private readonly IMapper _mapper;
        private readonly IPersonRepository _personRepository;
        private readonly IStringParseFactory _stringParserFactory;
        public PersonService(IMapper mapper, IPersonRepository personRepository, IStringParseFactory stringParserFactory)
        {
            _mapper = mapper;
            _personRepository = personRepository;
            _stringParserFactory = stringParserFactory;
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

            // itrator pattern on person collection
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
        public Task<List<PersonDto>> Get(string name = null, string cityName = null, DateTime? dobStart = null, DateTime? dobEnd = null)
        {
            var persons = new List<PersonDto>();

            // itrator pattern on person collection
            using var itrator = _personRepository
                                .Get(name,cityName,dobStart,dobEnd)
                                .GetEnumerator();

            while (itrator.MoveNext())
            {
                var person = itrator.Current;
                var dto = _mapper.Map<PersonDto>(person);
                persons.Add(dto);
            }
            return Task.FromResult(persons);
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

        public Task<List<PersonDto>> CreateByCsv(string csvString)
        {
            // Here we make string fault tolerance,
            // Get the parser usign factory pattern
            // By passing streatigy pattern
            // Instead of passing string for validation, we pass this parser everywhere
            using var parser = _stringParserFactory.CreateInstance(new CsvParserStreatigy(csvString));
            var dto = parser.ToObjectList<PersonDto>();
            dto.ForEach(x => Validate(x));
            var tasks = new List<Task>();
            foreach (var person in dto)
            {
                var wait = Create(person);
                tasks.Add(wait);
            }
            Task.WhenAll(tasks);
            return Task.FromResult(dto);
        }

        public Task<List<PersonDto>> CreateByTsv(string tsvString)
        {
            using var parser = _stringParserFactory.CreateInstance(new TsvParserStreatigy(tsvString));
            var dto = parser.ToObjectList<PersonDto>();
            dto.ForEach(x => Validate(x));
            var tasks = new List<Task>();
            foreach (var person in dto)
            {
                var wait = Create(person);
                tasks.Add(wait);
            }
            Task.WhenAll(tasks);
            return Task.FromResult(dto);
        }
    }
}
