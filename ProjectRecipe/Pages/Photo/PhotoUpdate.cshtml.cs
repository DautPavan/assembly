using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using ProjectRecipe.Model;
using ProjectRecipe.Service;
using ProjectRecipe.Repository;


//using ProjectRecipeBack.Domain;
//using ProjectRecipeBack.Repository.Interface;
//using ProjectRecipeBack.Repository.Repository;
//using ProjectRecipeBack.Services.Interface;
//using ProjectRecipeBack.Services.Services;

using System.Text;

namespace ProjectRecipe.Pages.Photo
{
    public class PhotoUpdateModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IRecipes _Repository;
        private readonly IRecipesServices _Service;

        public PhotoUpdateModel(IWebHostEnvironment webHostEnvironment, IRecipes recipesRepository, IRecipesServices recipeService )
        {
            _webHostEnvironment = webHostEnvironment;
            _Repository = recipesRepository;
            _Service = recipeService;
        }


//        public PhotoUpdateModel(IWebHostEnvironment webHostEnvironment, IRecipes Repository, IRecipesServices Service)
//        {
//            _webHostEnvironment = webHostEnvironment;
//            _Repository = Repository;
//            _Service = Service;
//        }

        public int receitaAtiva { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }
   
        public void OnGet(int Id)
        {
            TempData["ValorDaReceita"] = Id;
        }

        public async Task<ActionResult> OnPostAsync()
        {
            string nomeArquivoGerado = "";
            try
            {
                object fileObj = Request.Form.Files[0];
                string fileName = ((FormFile)fileObj).FileName;
                string fileExtention = Path.GetExtension(fileName);
                string newFileName = Guid.NewGuid().ToString() + fileExtention;
                string fileDestination = Path.Combine(_webHostEnvironment.WebRootPath, "images", newFileName);


                if (ImageFile != null && ImageFile.Length > 0)
                {
                    using (Stream stream = new FileStream(fileDestination, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream); // Save file in folders

                        // Obtém o nome do arquivo gerado
                        FileInfo fileInfo = new FileInfo(fileDestination);
                        nomeArquivoGerado = fileInfo.Name;
                    }

                    if (TempData["ValorDaReceita"] is int valorReceita)
                    {

                        int receitaAtual = valorReceita;
                        Recipes dadosReceita = new Recipes();

                        dadosReceita = _Service.Get(receitaAtual);
                        if( dadosReceita != null)
                        {
                            dadosReceita.Photo = nomeArquivoGerado;
                            _Service.Update(dadosReceita);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                // formulario erro
            }
            return new RedirectToPageResult("/Recipe/Recipes");
        }
    }
}
