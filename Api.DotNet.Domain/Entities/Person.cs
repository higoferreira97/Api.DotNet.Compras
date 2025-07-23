

using Api.DotNet.Domain.Validations;

namespace Api.DotNet.Domain.Entities
{
    public sealed class Person
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }

        public Person(string name, string document, string phone)
        {
            Validation(name, document, phone);
        }

        public Person(int id, string name, string document, string phone)
        {
            DomainValidationException.when(id < 0, "Id deve ser maior que zero");
            Id = id;
            Validation(name, document, phone);
        }

        private void Validation(string name, string document, string phone)
        {
            DomainValidationException.when(string.IsNullOrEmpty(name), "Nome deve ser informado!");
            DomainValidationException.when(string.IsNullOrEmpty(document), "Documento deve ser informado!");
            DomainValidationException.when(string.IsNullOrEmpty(phone), "Celular deve ser informado!");

            Name = name;
            Document = document;
            Phone = phone;
        }

    }
}
