using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {//bidaha nelememek için static
        public static void Validate(IValidator validator,object entity)//object hepsinin basesi 
        {//bana bir Ivalidator ver mesela productvaldiato ve doğrulamam için bir varlık ver
            var context = new ValidationContext<object>(entity);
            // ProductValidator productValidator = new ProductValidator();  (IValidator validator) ekkleyince bu satıra gerek kalmadı
            var result = validator.Validate(context);
            if (!result.IsValid)//sonuç geçerli değilse hata fırlat
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
