using Microsoft.AspNetCore.Mvc;
using MvcAwsCubos.Models;
using MvcAwsCubos.Repositories;

namespace MvcAwsCubos.Controllers
{
    public class CubosController : Controller
    {
        private RepositoryCubos repo;

        public CubosController(RepositoryCubos repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Cubo> cubos = await this.repo.GetCubosAsync();
            return View(cubos);
        }

        public async Task<IActionResult> Details(int id)
        {
            Cubo cubo = await this.repo.FindCuboAsync(id);
            return View(cubo);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cubo cubo)
        {
            await this.repo.CreateCuboAsync
                (cubo.Nombre, cubo.Marca, cubo.Imagen, cubo.Precio);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Cubo cubo = await this.repo.FindCuboAsync(id);
            return View(cubo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Cubo cubo)
        {
            await this.repo.UpdateCuboAsync
                (cubo.IdCubo, cubo.Nombre, cubo.Marca, cubo.Imagen, cubo.Precio);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.repo.DeleteCuboAsync(id);
            return RedirectToAction("index");
        }
    }
}
