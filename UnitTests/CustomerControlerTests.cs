using System;

namespace UnitTests
{
    public class BankAccountControllerTests
    {

        private readonly BankAccountController _bank;
        private readonly Mock<EFCoreRepository> _efCoreMock = new Mock<EFCoreRepository>();
        private readonly Mock<UserManager<Customer>> _customerManager = new Mock<UserManager<Customer>>();

        public BankAccountControllerTests() {
            _bank = new BankAccountController(_repo.Object, _customerManager.Object);
        }

        [Fact]
        public async Task GetById_ShouldReturnCustomer_WhenCustomerExists() {
            //Arrange
            //
            //Act

            var bankAccount = await _bank.GetAccountById();

            //Assert


        } 
    }
}
