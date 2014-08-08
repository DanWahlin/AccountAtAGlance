using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccountAtAGlance.Controllers;
using AccountAtAGlance.Repository.Fakes;
using System.Web.Mvc;
using AccountAtAGlance.Model;
using System.Web.Http;
using AccountAtAGlance.Repository;
using System.Net.Http;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Net;
using System.Web.Http.Results;

namespace AccountAtAGlance.Tests
{
    [TestClass]
    public class WebApiControllerTests
    {
        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void DataServiceController_NoAccountFound_ReturnsHttpResponseException()
        {
            //Arrange
            var controller = GetDataServiceController();

            //Act
            var result = controller.Account("1234");

            //Assert
            //Error should be thrown
            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void DataServiceController_NullAccountNumber_ReturnsHttpResponseException()
        {
            //Arrange
            var controller = GetDataServiceController();

            //Act
            var result = controller.Account(null);

            //Assert
            //Error should be thrown
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DataServiceController_AccountReturnedWithoutModification()
        {
            //Ensure that Web API method doesn't modify the brokerage account object
            //Arrange
            var acctNumber = "1234";
            var brokerageAccount = new BrokerageAccount { AccountNumber = "1234" };
            var acctRepo = new StubIAccountRepository
            {
                GetAccountString = (an) =>
                {
                    brokerageAccount.AccountNumber = an;
                    return brokerageAccount;
                }
            };

            var controller = GetDataServiceController(acct: acctRepo);

            //Act
            var result = controller.Account(acctNumber);

            //Assert
            Assert.AreSame(brokerageAccount, result);
            Assert.AreSame(acctNumber, result.AccountNumber);
        }

        [TestMethod]
        public void PostAccount_ReturnsCreatedStatusCode()
        {
            // Arrange
            var bAcct = new BrokerageAccount { AccountNumber = "1234" };
            var acctStub = new StubIAccountRepository
            {
                InsertAccountBrokerageAccount = (ba) =>
                {
                    return new OperationStatus { Status = true };
                }
            };
            var controller = GetDataServiceController(acct: acctStub);
            SetupController(controller);

            // Act
            var result = controller.PostAccount(bAcct) as CreatedAtRouteNegotiatedContentResult<BrokerageAccount>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(bAcct.AccountNumber, result.Content.AccountNumber);
        }

        private DataServiceController GetDataServiceController(IAccountRepository acct = null, ISecurityRepository sec = null, IMarketsAndNewsRepository markets = null)
        {
            var acctRepo = acct ?? new StubIAccountRepository();
            var securityRepo = sec ?? new StubISecurityRepository();
            var marketRepo = markets ?? new StubIMarketsAndNewsRepository();
            var controller = new DataServiceController(acctRepo, securityRepo, marketRepo);
            return controller;
        }

        private void SetupController(ApiController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/dataService");
            var route = config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "dataservice" } });
            request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;

            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
        }
    }
}
