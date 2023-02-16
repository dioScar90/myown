using Microsoft.AspNetCore.Mvc;
using myown.Context;
using myown.Models;

namespace myown.Controllers;

public class SerpentController : ControllerBase
{
    private readonly SerpentariumDbContext _context;
    public SerpentController(SerpentariumDbContext context)
    {
        _context = context;
    }
    
    public IActionResult GetAll()
    {
        var serpents = _context.Serpents.Where(s => s.Id > 0).ToList();

        return Ok(serpents);
    }
    
    public IActionResult GetById(int id)
    {
        // var derpent = _context.Derpents.SingleOrDefault(d => d.Id == id);
        // Comentei o código acima e troquei para Where para poder trazer mais de um resultado.
        var serpent = _context.Serpents.Where(s => s.Id == id);

        // Teste de fazer print_r. Não é exatamente o print_r do PHP porém me retorna
        // o conteúdo da variável em formato JSON, já indentado, o que é muito bom pois
        // já dá para ter uma ideia do conteúdo e do tipo. A função está declarada nesse
        // mesmo controller. Não é uma boa prática mas isso é apenas para fins de estudo.
        // if (derpent is IEnumerable)
        // {
        //     this.print_r(new[] { new { Nome = "Diogo", Idade = 32 }, new { Nome = "Bruna", Idade = 30 } });
        //     this.print_r("Esse é um texto muito do bom.");
        //     this.print_r(new[] { "A", "B", "C" });
        //     this.print_r(new List<dynamic> { "sim", "isso", new[] { 12, 13 } });
        //     this.print_r(derpent);
        //     this.VarDump(new List<dynamic> { 1, 2, new[] { "A", "B", "C" }, 4 });
        //     this.VarDump(new[] { new { Nome = "Diogo", Idade = 32 }, new { Nome = "Bruna", Idade = 30 } });
        // }
        
        if (serpent == null)
            return NotFound();
        
        return Ok(serpent);
    }
    
    public IActionResult Post(Serpent serpent)
    {
        var isThereAlready = _context.Serpents.SingleOrDefault(d => d.Id == serpent.Id);
        if (isThereAlready != null)
            return BadRequest("Já existe um registro com esse id.");
        
        _context.Serpents.Add(serpent);

        return CreatedAtAction(nameof(GetById), new { id = serpent.Id }, serpent);
    }
    
    public IActionResult Update(int id, Serpent input)
    {
        var serpent = _context.Serpents.SingleOrDefault(d => d.Id == id);

        if (serpent == null)
            return NotFound();
        
        serpent.Update(input.Title, input.Description, input.StartDate, input.EndDate);

        return NoContent();
    }

    public IActionResult Editar(int id)
    {
        var serpent = _context.Serpents.Find(id);

        if (serpent == null)
            return NotFound();
        
        return View(serpent);
    }

    [HttpPost]
    public IActionResult Editar(Serpent serpent)
    {
        var serpentFromSerpentarium = _context.Serpents.SingleOrDefault(s => s.Id == serpent.Id);

        serpentFromSerpentarium.PopularName = serpent.PopularName;
        serpentFromSerpentarium.CientificName = serpent.CientificName;
        serpentFromSerpentarium.Family = serpent.Family;

        _context.Serpents.Update(serpentFromSerpentarium);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
    
    public IActionResult Delete(int id)
    {
        var serpent = _context.Serpents.SingleOrDefault(d => d.Id == id);

        if (serpent == null)
            return NotFound();
        
        serpent.Delete();

        return NoContent();
    }
    
    // public SerpentController(SerpentContext context)
    // {
    //     _context = context;
    // }

    // public IActionResult Index()
    // {
    //     var contatos = _context.Serpents.ToList();
    //     return View(contatos);
    // }

    // public IActionResult Criar()
    // {
    //     return View();
    // }

    // [HttpPost]
    // public IActionResult Criar(Serpent serpent)
    // {
    //     if (ModelState.IsValid)
    //     {
    //         _context.Serpents.Add(serpent);
    //         _context.SaveChanges();
    //         return RedirectToAction(nameof(Index));
    //     }
    //     return View(serpent);
    // }

    // public IActionResult Editar(int id)
    // {
    //     var serpent = _context.Serpents.Find(id);

    //     if (serpent == null)
    //         return NotFound();
        
    //     return View(serpent);
    // }

    // [HttpPost]
    // public IActionResult Editar(Serpent serpent)
    // {
    //     var serpentFromSerpentarium = _context.Serpents.Find(serpent.Id);

    //     serpentFromSerpentarium.PopularName = serpent.PopularName;
    //     serpentFromSerpentarium.CientificName = serpent.CientificName;
    //     serpentFromSerpentarium.Family = serpent.Family;

    //     _context.Serpents.Update(serpentFromSerpentarium);
    //     _context.SaveChanges();

    //     return RedirectToAction(nameof(Index));
    // }

    // public IActionResult Detalhes(int id)
    // {
    //     var serpent = _context.Serpents.Find(id);

    //     if (serpent == null)
    //         return RedirectToAction(nameof(Index));
        
    //     return View(serpent);
    // }

    // public IActionResult Deletar(int id)
    // {
    //     var serpent = _context.Serpents.Find(id);

    //     if (serpent == null)
    //         return RedirectToAction(nameof(Index));
        
    //     return View(serpent);
    // }

    // [HttpPost]
    // public IActionResult Deletar(Serpent serpent)
    // {
    //     var serpentFromSerpentarium = _context.Serpents.Find(serpent.Id);

    //     _context.Serpents.Remove(serpentFromSerpentarium);
    //     _context.SaveChanges();

    //     return RedirectToAction(nameof(Index));
    // }
}