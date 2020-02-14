using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Application
{
    public abstract class Service
    {
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
