using System;
using System.Collections.Generic;
using Moq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Xunit;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Web.Http.Results;
using BankingApp.Domain.Entities;
using BankingApp.API.Repositories.Interfaces;
using BankingApp.API.Controllers;
using BankingApp.API.Models.BankAccounts;

using System.Diagnostics;
namespace UnitTests
{
    public class BankAccountControllerTests
    {
        public BankAccountControllerTests() {
        }
        [Fact]
        public async Task BankAccountList_Null() {
            //Arrange

            var _efCoreMock = new Mock<IRepository>();
            _efCoreMock.Setup(x => x.GetAll<BankAccount>());
            var userStore = new Mock<IUserStore<Customer>>();

            var _customerManagerMock =  new Mock<UserManager<Customer>>(
            userStore.Object, null, null, null, null, null, null, null, null);

            var _mapperMock = new Mock<IMapper>();
            var bankController = new BankAccountController(_efCoreMock.Object,
                                                            _customerManagerMock.Object,
                                                            _mapperMock.Object);
            // //Act

            var response = await bankController.GetAccounts();
            var okResult = response as OkObjectResult;
            // // Assert
            Assert.NotNull(okResult);
            Assert.Equal(200, okResult.StatusCode);
        }

        [Fact]
        public async Task GetBankAccountById_Test() {
            var _efCoreMock = new Mock<IRepository>();
            _efCoreMock.Setup(x => x.GetById<BankAccount>(It.IsAny<int>()));
            var userStore = new Mock<IUserStore<Customer>>();

            var _customerManagerMock =  new Mock<UserManager<Customer>>(
            userStore.Object, null, null, null, null, null, null, null, null);

            var _mapperMock = new Mock<IMapper>();
            var bankController = new BankAccountController(_efCoreMock.Object,
                                                            _customerManagerMock.Object,
                                                            _mapperMock.Object);

            var response = await bankController.GetAccountById(1008);
            var ok = response as CreatedAtRouteNegotiatedContentResult<BankAccount>;
            Assert.NotNull(ok);
        }

        [Fact]
        public async Task AddBankAccount_Test() {
            var bankModel = new CreateBankAccountModel {
                AccountType = 1,
                InitialDeposit = 20.00m
            };

            var _efCoreMock = new Mock<IRepository>();
            _efCoreMock.Setup(x => x.Add<BankAccount>(It.IsAny<BankAccount>()));
            var userStore = new Mock<IUserStore<Customer>>();

            var _customerManagerMock =  new Mock<UserManager<Customer>>(
            userStore.Object, null, null, null, null, null, null, null, null);

            var _mapperMock = new Mock<IMapper>();
            var bankController = new BankAccountController(_efCoreMock.Object,
                                                            _customerManagerMock.Object,
                                                            _mapperMock.Object);
            //_efCoreMock.SetupGet(x => x.HttpContext.User.Identity.Name);
            var response = await bankController.CreateAccount(bankModel);
            var ok = response as OkObjectResult;
            Assert.Equal(201, ok.StatusCode);
        }
    }
}
