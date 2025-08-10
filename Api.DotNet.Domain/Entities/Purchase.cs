

using Api.DotNet.Domain.Validations;

namespace Api.DotNet.Domain.Entities
{
    public sealed class Purchase
    {
        public int Id { get; private set; }
        public int ProductId { get; private set; }
        public int PersonId { get; private set; }
        public DateTime Date { get; private set; }
        public Person Person { get; set; }
        public Product Product { get; set; }

    
        public Purchase(int productId, int personId)
        {
            Validation(productId, personId); 
        }

        public Purchase(int id, int productId, int personId)
        {
          
            DomainValidationException.when(id <0,"Id deve ser informado!");
            Id = id;
            Validation(productId, personId);
        }

        private void Validation(int productId, int personId)
        {
            DomainValidationException.when(productId <= 0, "Id Produto deve ser informado!");
            DomainValidationException.when(personId <= 0 , "Id Pessoa deve ser informado!");
            
            ProductId = productId;
            PersonId = personId;
            Date = DateTime.UtcNow;

        }

    }
}
