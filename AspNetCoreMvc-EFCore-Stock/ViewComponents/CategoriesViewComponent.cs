using AspNetCoreMvc_EFCore_Stock.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc_EFCore_Stock.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        CategoryRepository _categoryRepo = new CategoryRepository();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = _categoryRepo.GetAll();
            return View(categories);
        }
    }
}
