using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mercado_Do_zé.DTO;
using Mercado_Do_zé.Data;

namespace Mercado_Do_zé.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosDTOController : ControllerBase
    {
        private readonly Context _context;

        public ProdutosDTOController(Context context)
        {
            _context = context;
        }

        // GET: api/ProdutosDTO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> GetProdutoDTO()
        {
            return await _context.ProdutoDTO.ToListAsync();
        }

        // GET: api/ProdutosDTO/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDTO>> GetProdutoDTO(int id)
        {
            var produtoDTO = await _context.ProdutoDTO.FindAsync(id);

            if (produtoDTO == null)
            {
                return NotFound();
            }

            return produtoDTO;
        }

        // PUT: api/ProdutosDTO/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProdutoDTO(int id, ProdutoDTO produtoDTO)
        {
            if (id != produtoDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(produtoDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoDTOExists(id))
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

        // POST: api/ProdutosDTO
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> PostProdutoDTO(ProdutoDTO produtoDTO)
        {
            _context.ProdutoDTO.Add(produtoDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProdutoDTO", new { id = produtoDTO.Id }, produtoDTO);
        }
        private bool ProdutoDTOExists(int id)
        {
            return _context.ProdutoDTO.Any(e => e.Id == id);
        }
    }
}
