

using Api.DotNet.Domain.Validations;

namespace Api.DotNet.Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string CodErp { get; private set; }
        public decimal Price { get; private set; }
        public ICollection<Purchase> Purchases { get; set; }

        public Product(string name,string codErp, decimal price)
        {
            Validation(name, codErp, price); 
        }

        public Product(int id, string name, string codErp, decimal price)
        {
            DomainValidationException.when(id < 0, "Id do produto deve ser informado");
             
            Id = id;
            Validation(name, codErp, price);
        }

        private void Validation(string name,string codErp, decimal price)
        {
            DomainValidationException.when(string.IsNullOrEmpty(name), "Nome deve ser informado");
            DomainValidationException.when(string.IsNullOrEmpty(codErp), "Código Erp deve ser informado");
            DomainValidationException.when(price <0, "Preço deve ser informado");

            Name = name;
            CodErp = codErp;
            Price = price;
        }
    }
}
