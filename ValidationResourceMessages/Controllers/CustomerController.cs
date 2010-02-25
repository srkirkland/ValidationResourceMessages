using System.Web.Mvc;
using NHibernate.Validator.Engine;
using ValidationResourceMessages.Models;

namespace ValidationResourceMessages.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit()
        {
            var customer = new Customer();

            return View(customer);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Customer customer)
        {
            //Validate customer
            var valid = ValidationEngineFactory.ValidatorEngine.IsValid(customer);

            var validationResults = ValidationEngineFactory.ValidatorEngine.Validate(customer);

            validationResults.ToModelState(ModelState);
            
            TempData["Message"] = "Customer Valid? " + valid;

            return View(customer);
        }
    }

    public static class ValidationExtensions
    {
        public static void ToModelState(this InvalidValue[] invalidValues, ModelStateDictionary modelState)
        {
            foreach (var invalidValue in invalidValues)
            {
                modelState.AddModelError(invalidValue.PropertyName, invalidValue.Message);
            }
        }
    }

    public static class ValidationEngineFactory
    {
        public static ValidatorEngine ValidatorEngine
        {
            get { return NHibernate.Validator.Cfg.Environment.SharedEngineProvider.GetEngine(); }
        }
    }
}
