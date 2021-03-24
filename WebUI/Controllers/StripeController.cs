using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace GovernmentSystem.WebUI.Controllers
{
    public class StripeController : ApiControllerBase
    {
        [HttpPost]
        public IActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new CustomerService();
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken
            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = 500,
                Description = "Sample Charge",
                Currency = "usd",
                Customer = customer.Id
            });

            return Ok();
        }
    }
}
