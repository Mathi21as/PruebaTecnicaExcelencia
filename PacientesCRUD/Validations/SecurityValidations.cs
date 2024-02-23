using Microsoft.AspNetCore.Mvc;

namespace PacientesCRUD.Validations
{
    public class SecurityValidations
    {
        public bool IsSqli(string input)
        {
            if (input.Contains("-"))
            {
                return true;
            }
            return false;
        }
    }
}
