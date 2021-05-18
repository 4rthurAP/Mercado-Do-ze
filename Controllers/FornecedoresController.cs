using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mercado_Do_zé.Data;
using Mercado_Do_zé.Models;
using Mercado_Do_zé.DTO;

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
        public async Task<ActionResult<IEnumerable<FornecedorDTO>>> GetFornecedores()
        {
            return await _context.Fornecedores
                                .Select(x => new FornecedorDTO
                                {
                                  Id = x.Id,
                                  NomeFornecedor = x.NomeFornecedor
                                })
                .ToListAsync();
        }
        // GET: api/Fornecedores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FornecedorDTO>> GetFornecedor(int id)
        {
            var fornecedor = await _context.Fornecedores.Include("Produtos").Select(x => new FornecedorDTO
            {
                NomeFornecedor = x.NomeFornecedor,
                Id = x.Id,
                Produtos = x.Produtos
            })
                .FirstOrDefaultAsync(predicate: x => x.Id == id);

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

            if(fornecedor.NomeFornecedor.Length < 10 || fornecedor.NomeFornecedor.Length > 50)
            {
                return BadRequest("O campo fornecedor deve ter de 10 a 50 caracteres");
            }
            _context.Fornecedores.Add(fornecedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFornecedor", new { id = fornecedor.Id }, fornecedor);
        }

        // DELETE: api/Fornecedores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Fornecedor>>> DeleteFornecedor(int id)
        {

            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            var listarProdutos = await _context.Fornecedores
                                .Select(x => new Fornecedor
                                {
                                   Produtos = x.Produtos
                                }).ToListAsync();

            var produtosvinculados = fornecedor.Produtos;

            if(produtosvinculados != null)
            {
                return BadRequest("Há produtos vinculados a esse fornecedor");
            }

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
