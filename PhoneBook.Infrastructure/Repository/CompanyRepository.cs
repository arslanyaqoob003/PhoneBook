using PhoneBook.Core.Domain;

namespace PhoneBook.Infrastructure.Repository
{
    public class CompanyRepository : Repository<Company>,ICompanyRepository 
    {
        public CompanyRepository(PhoneBookContext context) : base(context){}
    }
}
