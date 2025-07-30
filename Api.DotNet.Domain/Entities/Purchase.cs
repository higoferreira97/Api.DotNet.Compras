

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

        public Purchase(int productId, int personId, DateTime? date)
        {
            Validation(productId, personId, date); 
        }

        public Purchase(int id, int productId, int personId, DateTime? date)
        {
          
            DomainValidationException.when(id <0,"Id deve ser informado!");
            Id = id;
            Validation(productId, personId, date);
        }

        private void Validation(int productId, int personId, DateTime?  date)
        {
            DomainValidationException.when(productId <0, "Id Produto deve ser informado!");
            DomainValidationException.when(personId <0 , "Id Pessoa deve ser informado!");
            DomainValidationException.when(date.HasValue    , "Date da compra deve ser informada!");

            ProductId = productId;
            PersonId = personId;
            Date = date.Value;

        }

    }
}
