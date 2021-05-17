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
    public class FornecedoresDTOController : ControllerBase
    {
        private readonly Context _context;

        public FornecedoresDTOController(Context context)
        {
            _context = context;
        }

        // GET: api/FornecedoresDTO
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FornecedorDTO>>> GetFornecedorDTO()
        {
            return await _context.FornecedorDTO.ToListAsync();
        }

        // GET: api/FornecedoresDTO/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FornecedorDTO>> GetFornecedorDTO(int id)
        {
            var fornecedorDTO = await _context.FornecedorDTO.FindAsync(id);

            if (fornecedorDTO == null)
            {
                return NotFound();
            }

            return fornecedorDTO;
        }

        // PUT: api/FornecedoresDTO/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFornecedorDTO(int id, FornecedorDTO fornecedorDTO)
        {
            if (id != fornecedorDTO.Id)
            {
                return BadRequest();
            }

            _context.Entry(fornecedorDTO).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FornecedorDTOExists(id))
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

        // POST: api/FornecedoresDTO
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FornecedorDTO>> PostFornecedorDTO(FornecedorDTO fornecedorDTO)
        {
            _context.FornecedorDTO.Add(fornecedorDTO);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFornecedorDTO", new { id = fornecedorDTO.Id }, fornecedorDTO);
        }
        private bool FornecedorDTOExists(int id)
        {
            return _context.FornecedorDTO.Any(e => e.Id == id);
        }
    }
}
