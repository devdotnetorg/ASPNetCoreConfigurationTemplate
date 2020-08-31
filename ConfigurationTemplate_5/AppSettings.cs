using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigurationTemplate_5
{
    /// <summary>
    /// Настройки приложения.
    /// </summary>
    public class AppSettings: IValidatableObject
    {        
        public string Parameter1 { get; set; }
        public string Parameter2 { get; set; }        
        public ClientConfig clientConfig;
        public void ClientConfigBuild()
        {
            clientConfig = new ClientConfig(new ClientConfigOptions()
            {
                Parameter1 = this.Parameter1,
                Parameter2 = this.Parameter2
            }
            );
        }        

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.Parameter1))
            {
                errors.Add(new ValidationResult("Не указан параметр Parameter1. Задано " +
                    "значение по умолчанию DefaultParameter1 ABC"));
                this.Parameter1 = "DefaultParameter1 ABC";
            }

            if (string.IsNullOrWhiteSpace(this.Parameter2))
            {
                errors.Add(new ValidationResult("Не указан параметр Parameter2. Задано " +
                    "значение по умолчанию DefaultParameter2 ABC"));
                this.Parameter2 = "DefaultParameter2 ABC";
            }
            return errors;
        }
    }
}