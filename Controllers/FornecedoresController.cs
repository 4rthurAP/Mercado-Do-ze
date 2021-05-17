using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mercado_Do_zé.Data;
using Mercado_Do_zé.Models;

namespace Mercado_Do_zé.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private readonly Context _context;

        public FornecedoresController(Context context)
        {
            _context = context;
        }

        // GET: api/Fornecedores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> GetFornecedores()
        {
            return await _context.Fornecedores.Include("Produtos").ToListAsync();
        }

        // GET: api/Fornecedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fornecedor>> GetFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedores.Include("Produtos").FirstOrDefaultAsync(predicate: x => x.Id == id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            return fornecedor;
        }

        // PUT: api/Fornecedores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFornecedor(int id, Fornecedor fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return BadRequest();
            }

            _context.Entry(fornecedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FornecedorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Fornecedores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fornecedor>> PostFornecedor(Fornecedor fornecedor)
        {
            if (fornecedor.NomeFornecedor.Length < 10 || fornecedor.NomeFornecedor.Length > 50)
            {
                return BadRequest("O campo NomeFornecedor deve ter entre 10 à 50 caracteres.");
            }

            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFornecedor", new { id = fornecedor.Id }, fornecedor);
        }

        // GET: api/Fornecedores/search
      //  [HttpGet("Search")]
      //  public async Task<IActionResult> SearchAsync(Fornecedor fornecedor)
      //  {
      //      if (fornecedor == null)
      //     {
      //          return BadRequest("não há fornecedores");
      //      }
      //       return Ok();
      //   }

        // DELETE: api/Fornecedores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFornecedor(int id)
        {

            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }

            var listarProdutos = await _context.Fornecedores.Include("Produtos").FirstOrDefaultAsync(predicate: x => x.Id == id);
            
            _context.Fornecedores.Remove(fornecedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FornecedorExists(int id)
        {
            return _context.Fornecedores.Any(e => e.Id == id);
        }
    }
}
