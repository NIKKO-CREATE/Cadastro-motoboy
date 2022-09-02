using CadastroMotoboy.Context;
using CadastroMotoboy.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CadastroMotoboy.Controller
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FuncionarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: FuncionarioController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return (IActionResult)await _context.Funcionarios.ToListAsync();
        }

        // GET: FuncionarioController/Details/5
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
           if(id == null)
                return NotFound();

           var funcionario = await _context.Funcionarios.
                FirstOrDefaultAsync(f => f.Id == id);

            return Ok(funcionario);
        }


        // POST: FuncionarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return Ok(funcionario);
        }

        //// GET: FuncionarioController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        // POST: FuncionarioController/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Update(funcionario);
                await _context.SaveChangesAsync();
            }
            return Ok(funcionario);
        }

        // POST: FuncionarioController/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
             var funcionario = _context.Funcionarios.FirstOrDefault(f => f.Id == id);
              _ = _context.Remove(funcionario);
                await _context.SaveChangesAsync();

            return Ok(funcionario);
        }
    }
}
