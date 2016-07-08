using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AdoTest2
{
    class ComboRequiredRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if ((int)value == 0)
            {
                return new ValidationResult(false, "Soort moet ingevuld zijn");

            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
