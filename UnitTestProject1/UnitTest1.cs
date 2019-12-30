using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceReference1;
using System.Net;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest
    {
        private const string expected10 = "55";

        [TestMethod]
        [DataRow(10, "55")]
        [DataRow(5, "5")]
        [DataRow(22, "17711")]
        [DataRow(46, "1836311903")]
        [DataRow(74, "1304969544928657")]
        [DataRow(89, "1779979416004714189")]
        [DataRow(1, "1")]
        [DataRow(2, "1")]
        [DataRow(101, "-1")]
        [DataRow(0, "-1")]
        public void FiboTest(int input, string expectedResult)
        {


            WebClient webClient = new WebClient();

            FiboSoapClient.EndpointConfiguration config = FiboSoapClient.EndpointConfiguration.FiboSoap;
            FiboSoapClient client = new FiboSoapClient(config);

            Task<FibonacciResponse> result = client.FibonacciAsync(input);
            result.Wait();

            Assert.AreEqual(expectedResult, result.Result.Body.FibonacciResult);
        }
    }
}
