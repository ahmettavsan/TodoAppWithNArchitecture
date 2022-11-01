using ABC.TODOAPP.BUSİNESS.Interfaces;
using ABC.TODOAPP.COMMON.CustomResponse;
using ABC.TODOAPP.DTOs.WorkDTOs;
using ABC.TODOAPP.PL.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace ABC.TODOAPP.PL.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWorkService _service;

        public HomeController(IWorkService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _service.GetAll();
            

            return View(response.Data);
        }
        public IActionResult Error(int code)
        {
            return View();
        }
        public IActionResult Create()
        {
            return View(new WorkCreateDto());
        }
        [HttpPost]
        public async Task<IActionResult> Create(WorkCreateDto dto)
        {
           
           var response= await _service.Create(dto);
            return this.ResponseRedirectToAction(response, "Home", "Index");
            #region Notes
            //if (response.ResponseType==ResponseType.ValidationError)
            //{
            //    foreach (var item in response.CustomValidationErrors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //    return View(dto);


            //}
            //else
            //{
            //    return RedirectToAction("Index");
            //}

            #endregion


        }

        public async Task<IActionResult> Update(int id)
        {
          var response= await _service.GetById<WorkUpdateDTos>(id);
            return this.ResponseView(response);

            #region MyRegion
            //if (response.ResponseType==ResponseType.NotFound)
            //{
            //    return NotFound();

            //}

            // return View(response.Data);
            #endregion

        }
        [HttpPost]
        public async Task<IActionResult> Update(WorkUpdateDTos updateDTos)
        {
          
            
            var response= await _service.Update(updateDTos);
            return this.ResponseRedirectToAction(response, "Home", "Index");

            #region return
            //if (response.ResponseType==ResponseType.ValidationError)
            //{
            //    foreach (var error in response.CustomValidationErrors)
            //    {
            //        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            //    }
            //    return View(updateDTos);
            //}
            //return RedirectToAction("Index", "Home");

            #endregion



        }

        public async Task<IActionResult> Delete(int id)
        {
            #region MyRegion
            //var entity= await _service.GetById(id);
            // var entitydto = new WorkDTO()
            // {
            //     Id = id,
            //     Defination = entity.Defination,
            //     IsCompleted = entity.IsCompleted
            // };
            #endregion

            #region notes
            //if (response.ResponseType == ResponseType.NotFound)
            //{
            //    return NotFound();

            //}
            //return RedirectToAction("Index");
            #endregion

            var response =  await _service.Remove(id);
            return this.ResponseRedirectToAction(response, "Index", "Home");

        }
    }
}
