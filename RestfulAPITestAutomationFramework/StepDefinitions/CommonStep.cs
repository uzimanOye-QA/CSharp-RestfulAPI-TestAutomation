using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Reqnroll;
using RestfulAPITestAutomationFramework.Model;
using RestfulAPITestAutomationFramework.SetUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestfulAPITestAutomationFramework.StepDefinitions

{

    [Binding]
    public class CommonStep
    {
        Context context;
        public CommonStep(Context _context)
        {
            context = _context;
        }

        [Given("that RestfulBooker web services with resource (.*) is loaded for GET call")]
        public void GivenThatRestfulBookerWebServicesIsLoadedForGETCall(string resource)
        {
            context.GetMethod(resource);
        }

        [Given("that RestfulBooker web services with resource (.*) is loaded for POST call")]
        public void GivenThatRestfulBookerWebServicesIsLoadedForPOSTCall(string resource)
        {
           
            //context.PostMethod(resource );
        }

        [Given("that RestfulBooker web services with resource (.*) is loaded for PUT call")]
        public void GivenThatRestfulBookerWebServicesIsLoadedForPUTCall(string resource)
        {

            
        }

        [Given("that RestfulBooker web services with resource (.*) is loaded for DELETE call")]
        public void GivenThatRestfulBookerWebServicesIsLoadedForDELETECall(string resource)
        {

            context.DeleteMethod(resource);
        }

        [Then("the status code must be equal to (.*)")]
        public void ThenTheStatusCodeMustBeEqualToCreated(string statusCode)
        {
            Assert.IsTrue(statusCode.Equals(context.statusCode), $"Expected status code: {statusCode} but found: {context.statusCode}");

        }

    }
}
