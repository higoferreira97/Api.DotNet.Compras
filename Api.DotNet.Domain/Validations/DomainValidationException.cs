

namespace Api.DotNet.Domain.Validations
{   //Classe de validação genérica
    public  class DomainValidationException : Exception
    {
        public DomainValidationException(string error) : base(error)
        {}    
       
        public static void when(bool hasError, string message)
        {
            if (hasError)
                throw new DomainValidationException(message);
        }
    }
}
