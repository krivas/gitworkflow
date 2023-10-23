//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace TestProject1
//{
//    using Microsoft.VisualStudio.TestTools.UnitTesting;
//    using NUnit.Framework;
//    using System;
//    using System.Net.Http;
//    using System.Threading.Tasks;

//    namespace CoffeeMachineTests
//    {

//        public class CoffeeMachineCheckerTests
//        {
//            [TestMethod]
//            public async Task GoodPause_WhenMachineIsFunctioningAndRefillWithinWeek_ReturnsTrue()
//            {
//                // Arrange
//                var checker = new CoffeeMachineChecker
//                {
//                    HttpClient = new FakeHttpClient()
//                };

//                // Set up a fake HTTP response with desired data
//                checker.HttpClient.ResponseContent = "{\"status\":{\"functioning\":true,\"last_refill\":5},\"queue\":{\"queue_length\":4,\"estimate_ttc\":180}}";

//                // Act
//                var result = await checker.GoodPause();

//                // Assert
//                Assert.IsTrue(result);
//            }

//            [TestMethod]
//            public async Task GoodPause_WhenMachineNotFunctioning_ReturnsFalse()
//            {
//                // Arrange
//                var checker = new CoffeeMachineChecker
//                {
//                    HttpClient = new FakeHttpClient()
//                };

//                // Set up a fake HTTP response indicating the machine is not functioning
//                checker.HttpClient.ResponseContent = "{\"status\":{\"functioning\":false,\"last_refill\":2},\"queue\":{\"queue_length\":2,\"estimate_ttc\":120}}";

//                // Act
//                var result = await checker.GoodPause();

//                // Assert
//                Assert.IsFalse(result);
//            }

//            [TestMethod]
//            public async Task GoodPause_WhenRefillOverWeekAgo_ReturnsFalse()
//            {
//                // Arrange
//                var checker = new CoffeeMachineChecker
//                {
//                    HttpClient = new FakeHttpClient()
//                };

//                // Set up a fake HTTP response with last refill over a week ago
//                checker.HttpClient.ResponseContent = "{\"status\":{\"functioning\":true,\"last_refill\":10},\"queue\":{\"queue_length\":3,\"estimate_ttc\":240}}";

//                // Act
//                var result = await checker.GoodPause();

//                // Assert
//                Assert.IsFalse(result);
//            }

//            [TestMethod]
//            public async Task GoodPause_WhenQueueOverLimit_ReturnsFalse()
//            {
//                // Arrange
//                var checker = new CoffeeMachineChecker
//                {
//                    HttpClient = new FakeHttpClient()
//                };

//                // Set up a fake HTTP response with too many people in the queue
//                checker.HttpClient.ResponseContent = "{\"status\":{\"functioning\":true,\"last_refill\":5},\"queue\":{\"queue_length\":6,\"estimate_ttc\":150}}";

//                // Act
//                var result = await checker.GoodPause();

//                // Assert
//                Assert.IsFalse(result);
//            }

//            [TestMethod]
//            public async Task GoodPause_WhenTtcOverLimit_ReturnsFalse()
//            {
//                // Arrange
//                var checker = new CoffeeMachineChecker
//                {
//                    HttpClient = new FakeHttpClient()
//                };

//                // Set up a fake HTTP response with a high estimated time-to-coffee
//                checker.HttpClient.ResponseContent = "{\"status\":{\"functioning\":true,\"last_refill\":5},\"queue\":{\"queue_length\":3,\"estimate_ttc\":360}}";

//                // Act
//                var result = await checker.GoodPause();

//                // Assert
//                Assert.IsFalse(result);
//            }

//            // Define a FakeHttpClient class to use for testing
//            private class FakeHttpClient : HttpClient
//            {
//                public string ResponseContent { get; set; }

//                protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
//                {
//                    var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
//                    response.Content = new StringContent(ResponseContent);
//                    return Task.FromResult(response);
//                }
//            }
//        }
//    }

//}
