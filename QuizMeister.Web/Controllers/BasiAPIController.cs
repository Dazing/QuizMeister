using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace QuizMeister.Web.Controllers
{
    public abstract class BaseAPIController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (!ModelState.IsValid)
            {
                context.Result = BadRequest("Invalid data sent to the endpoint, please send the correct data model to the endpoint.");
            }
        }

        protected ActionResult<T> TryExecute<T>(Func<T> command)
        {
            try
            {
                return this.Ok(command());
            }
            catch (InvalidOperationException ex)
            {
                return this.BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return this.NotFound(ex.Message);
            }
            catch (Exception e)
            {
                return this.StatusCode(500, e.Message);
            }
        }

        protected ActionResult TryExecute(Action command)
        {
            try
            {
                command();
                return Ok();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return this.BadRequest(ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
