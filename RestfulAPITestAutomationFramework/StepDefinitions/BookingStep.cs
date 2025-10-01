using Newtonsoft.Json;
using NUnit.Framework;
using Reqnroll;
using Reqnroll.Assist;
using Reqnroll.Formatters.PayloadProcessing.Cucumber;
using RestfulAPITestAutomationFramework.Model;
using RestfulAPITestAutomationFramework.SetUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RestfulAPITestAutomationFramework.Model.BookingModel;

namespace RestfulAPITestAutomationFramework.StepDefinitions
{

    public class CreateBookingResponse
    {
        [JsonProperty("bookingid")]
        public int Bookingid { get; set; }
       // public BookingModel? booking { get; set; }
    }
    [Binding]
    public class BookingStep
    {
        Context context;
        private int _newBookingId;


        public BookingStep(Context _context)
        {
            context = _context;

        }


        [Then("the booking IDs must be retrieved from the booking resource")]
        public void ThenTheBookingIDsMustBeRetrievedFromTheBookingResource()
        {
            var bookingIds = JsonConvert.DeserializeObject<List<CreateBookingResponse>>(context.content ?? string.Empty);

            Assert.IsNotNull(bookingIds, "Booking IDs were not retrieved.");
            Assert.IsTrue(bookingIds!.Count > 0, "No booking IDs returned from API.");
        }

        [Then("the following records must be retrieved from Booking table")]
        public void ThenTheFollowingRecordsMustBeRetrieved(DataTable dataTable)
        {
            var actualResult = JsonConvert.DeserializeObject<BookingModel>(context.content ?? string.Empty);
            var expectedBooking = dataTable.CreateInstance<BookingModel>();
            Assert.IsNotNull(actualResult, "Failed to deserialize the API response. Response was null or empty.");
            Assert.IsNotNull(expectedBooking, "Failed to create expected booking from DataTable. Result was null.");

           
        }


        [Given("I have a valid API token")]
        public void GivenIHaveAValidAPIToken()
        {
            var credentials = new
            {
                username = "admin",
                password = "password123"
            };
            context.PostMethod("auth", credentials);
            var tokenResponse = JsonConvert.DeserializeObject<dynamic>(context.content ?? string.Empty);
            context.AuthToken = tokenResponse?.token;
            Assert.IsNotNull(context.AuthToken, "Failed to retrieve a valid API token.");
        }


        [When("I create a new booking with the following details")]
        public void WhenICreateANewBookingWithTheFollowingDetails(DataTable dataTable)
        {
            var booking = dataTable.CreateInstance<BookingModel>();
            var row = dataTable.Rows.First();
            string checkinDate = row["checkin"];
            string checkoutDate = row["checkout"];
           
            booking.bookingdates = new BookingModel.BookingDates
            {
              
                checkin = checkinDate,
                checkout = checkoutDate
            };
            context.PostMethod("booking", booking);



           
        }

        [Then("a new booking ID is generated")]
        public void ThenANewBookingIDIsGenerated()
        {
            var responseData = JsonConvert.DeserializeObject<CreateBookingResponse>(context.content ?? string.Empty);

            Assert.IsNotNull(responseData, "The API response could not be deserialized into a valid booking response.");
            Assert.AreNotEqual(0, responseData!.Bookingid, "Booking ID was not generated in the response.");

            _newBookingId = responseData.Bookingid;

        }

        [When("I retrieve the booking I just created")]
        public void WhenIRetrieveTheBookingIJustCreated()
        {
            Assert.AreNotEqual(0, _newBookingId, "No booking ID was stored to retrieve.");
            context.GetMethod($"booking/{_newBookingId}");
        }



        [Then("the following records must be not be displayed from Booking table")]
        public void ThenTheFollowingRecordsMustBeNotBeDisplayed(DataTable dataTable)
        {
            var deletedBookings = dataTable.CreateSet<BookingModel>();
            foreach (var booking in deletedBookings)
            {
                
                context.GetMethod($"booking/{booking.Id}"); 

                Assert.AreNotEqual("OK", context.statusCode,
                    $"Booking with ID {booking.Id} still exists after deletion.");
            }



        }

        public bool ObjectComparer(object expectedObject, object actualObject )
        {

            var objectOne = JsonConvert.SerializeObject(expectedObject);
            var objectTwo = JsonConvert.SerializeObject(actualObject);

            return objectOne == objectTwo;
        }


        [When("I update the booking with the following details")]
        public async Task WhenIUpdateTheBookingWithTheFollowingDetails(DataTable dataTable)
        {
            await context.CreateAuthToken();
            var updatedBooking = dataTable.CreateInstance<BookingModel>();
            var row = dataTable.Rows.First();
            string checkinDate = row["checkin"];
            string checkoutDate = row["checkout"];

            updatedBooking.bookingdates = new BookingModel.BookingDates
            {
                checkin = checkinDate,
                checkout = checkoutDate
            };
            context.PutMethod($"booking/{_newBookingId}", updatedBooking);
        }

        [When("I partially update the booking with the following details")]
        public async Task WhenIPartiallyUpdateTheBookingWithTheFollowingDetails(DataTable dataTable)
        {
            await context.CreateAuthToken();
            var updatedBooking = dataTable.CreateInstance<BookingModel>();
           
            context.PatchMethod($"booking/{_newBookingId}", updatedBooking);
        }

        [Then("the partially updated records must be retrieved from Booking table")]
        public void ThenThePartiallyUpdatedRecordsMustBeRetrievedFromBookingTable(DataTable dataTable)
        {
            var actualResult = JsonConvert.DeserializeObject<BookingModel>(context.content ?? string.Empty);
            var expectedBooking = dataTable.CreateInstance<BookingModel>();
            Assert.IsNotNull(actualResult, "Failed to deserialize the API response. Response was null or empty.");

        }

        [When("I delete the booking I just created")]
        public async Task WhenIDeleteTheBookingIJustCreated()
        {
            await context.CreateAuthToken();

            Assert.IsNotNull(_newBookingId, "Booking ID was not captured. Cannot delete the booking.");
            context.DeleteMethod($"booking/{_newBookingId}");
        }
        [When("I delete the booking I just created without Authetication token")]
        public void WhenIDeleteTheBookingIJustCreatedWithoutAutheticationToken()
        {
            Assert.IsNotNull(_newBookingId, "Booking ID was not captured. Cannot delete the booking.");
            context.DeleteMethodNoAuth($"booking/{_newBookingId}");
        }


        [Then("the booking I just created must not exist")]
        public void ThenTheBookingIJustCreatedMustNotExist()
        {
            context.GetMethod($"booking/{_newBookingId}");
        }



    }
}
