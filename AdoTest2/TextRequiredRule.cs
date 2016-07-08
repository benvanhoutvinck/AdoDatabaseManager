using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AdoTest2
{
    class TextRequiredRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || value.ToString() == string.Empty)
            {
                return new ValidationResult(false, "Waarde moet ingevuld zijn");

            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
