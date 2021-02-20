using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace Informatiz.ControleEstoque.API.Classes
{
    public class ValidateModel : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {

            if (actionContext.ModelState.IsValid == false)
            {
                System.Text.StringBuilder MennsagensErro = new System.Text.StringBuilder();


                for (int i = 0; i <= actionContext.ModelState.Count - 1; i++)
                {
                    if (actionContext.ModelState.ElementAt(i).Value != null && actionContext.ModelState.ElementAt(i).Value.Errors != null && actionContext.ModelState.ElementAt(i).Value.Errors.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(actionContext.ModelState.ElementAt(i).Value.Errors.FirstOrDefault().ErrorMessage))
                        {
                            MennsagensErro.AppendLine(actionContext.ModelState.ElementAt(i).Value.Errors.FirstOrDefault().ErrorMessage);
                        }
                        else if (actionContext.ModelState.ElementAt(i).Value.Errors.FirstOrDefault().Exception != null &&
                               !string.IsNullOrEmpty(actionContext.ModelState.ElementAt(i).Value.Errors.FirstOrDefault().Exception.Message))
                        {

                            MennsagensErro.AppendLine(actionContext.ModelState.ElementAt(i).Value.Errors.FirstOrDefault().Exception.Message);
                        }
                    }

                }

                actionContext.Response = actionContext.Request.CreateErrorResponse(
                HttpStatusCode.BadRequest, MennsagensErro.ToString());
            }
        }
    }
}