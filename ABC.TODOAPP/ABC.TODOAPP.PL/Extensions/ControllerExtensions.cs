using ABC.TODOAPP.COMMON.CustomResponse;
using Microsoft.AspNetCore.Mvc;

namespace ABC.TODOAPP.PL.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult ResponseRedirectToAction<T>(this Controller controller,IDataResponse<T> response,string controllerName,string actionName)
        {
            if (response.ResponseType==ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            if (response.ResponseType==ResponseType.ValidationError)
            {
                foreach (var error in response.CustomValidationErrors)
                {
                    controller.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return controller.View(response.Data);
            }
            return controller.RedirectToAction(actionName, controllerName);


        }
        public static IActionResult ResponseView<T>(this Controller controller,IDataResponse<T> response)
        {
            if (response.ResponseType==ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            return controller.View(response.Data);
        }
        public static IActionResult ResponseRedirectToAction(this Controller controller,IResponse response,string actionName,string controllerName)
        {
            if (response.ResponseType==ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            return controller.RedirectToAction(actionName, controllerName);

        }
    }
}
