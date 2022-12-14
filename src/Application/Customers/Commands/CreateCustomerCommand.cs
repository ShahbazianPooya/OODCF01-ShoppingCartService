using CustomerBasketManagement.Domain.Customers;
using CustomerBasketManagement.Domain.Customers.Repository;
using MediatR;

namespace CustomerBasketManagement.Application.Customers.Commands
{
    public class CreateCustomerModel
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public DateTime CreditCardExpireDate { get; set; }
        public string CardNumber { get; set; }
    }

    public class CreateCustomerCommand : IRequest<bool>
    {
        public CreateCustomerModel CreateCustomerModel { get; }

        public CreateCustomerCommand(CreateCustomerModel createCustomerModel)
        {
            CreateCustomerModel = createCustomerModel;
        }
    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
    {
        private readonly ICustomerRepository _customerRepository;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Customer customer = new(request.CreateCustomerModel.FullName,
                                        request.CreateCustomerModel.Address,
                                        request.CreateCustomerModel.CardNumber,
                                        request.CreateCustomerModel.CreditCardExpireDate);

                await _customerRepository.AddAsync(customer);

                return true;
            }

            catch
            {
                return false;
            }
        }
    }
}
