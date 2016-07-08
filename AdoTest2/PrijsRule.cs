using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AdoTest2
{
    public class PrijsRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            decimal getal;
            NumberStyles style = NumberStyles.Currency;

            if (value == null || value.ToString() == string.Empty)
            {
                return new ValidationResult(false, "Prijs moet ingevuld zijn");
            }
            if (!decimal.TryParse(value.ToString(), style, cultureInfo, out getal))
                if (!decimal.TryParse(value.ToString(), out getal))
                {
                    return new ValidationResult(false, "Prijs moet een getal zijn");
                }
            if (getal <= 0)
            {
                return new ValidationResult(false, "Prijs moet groter zijn dan nul");
            }
            return ValidationResult.ValidResult;
        }
    }
}
