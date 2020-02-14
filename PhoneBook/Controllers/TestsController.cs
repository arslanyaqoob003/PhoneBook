using Microsoft.AspNetCore.Mvc;
using PhoneBook.Application.Companies;
using System.Threading.Tasks;

namespace PhoneBook.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestsController:Controller
    {
        private readonly ICompanyService _companyService;
        public TestsController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _companyService.GetAll());
        }
        [HttpPost]
        public async Task<IActionResult> Insert(CompanyDto dto)
        {
           var model = await  _companyService.Create(dto);
            return Ok(model);
        }
    }
}
