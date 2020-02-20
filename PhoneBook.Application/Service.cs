using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Application
{
    // base class which contains all the shared functionality of services
    public abstract class Service
    {
        // DTO validation functionaliy
        public bool Validate(object model)
        {
            var context = new ValidationContext(model, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(model, context, results);
            if (!isValid)
                throw new ValidationException("Model is not valid because " + string.Join(", ", results.Select(s => s.ErrorMessage).ToArray()));
            return isValid;
        }
    }
}
