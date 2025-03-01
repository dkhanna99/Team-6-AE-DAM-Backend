// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Microsoft.AspNetCore.Mvc;
// using DAMBackend.Data;
// using DAMBackend.Model.FileModel;

// namespace DAMBackend.Controllers
// {
//     [Route("api/[controller]")]
//     [ApiController]
//     public class FilesController : ControllerBase
//     {
//         private readonly AppDbContext _context;

//         public FilesController(AppDbContext context)
//         {
//             _context = context;
//         }

//         // GET: api/Files
//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<FileClass>>> GetFiles()
//         {
//             return await _context.Files.ToListAsync();
//         }

//         // GET: api/Files/5
//         [HttpGet("{id}")]
//         public async Task<ActionResult<FileClass>> GetFile(int id)
//         {
//             var @file = await _context.Files.FindAsync(id);

//             if (@file == null)
//             {
//                 return NotFound();
//             }

//             return @file;
//         }

//         // PUT: api/Files/5
//         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//         [HttpPut("{id}")]
//         public async Task<IActionResult> PutFile(int id, FileClass @file)
//         {
//             // if (id != @file.Id) // type missmatch
//             // {
//             //     return BadRequest();
//             // }

//             _context.Entry(@file).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!FileExists(id))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }

//             return NoContent();
//         }

//         // POST: api/Files
//         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//         [HttpPost]
//         public async Task<ActionResult<FileClass>> PostFile(FileClass @file)
//         {
//             _context.Files.Add(@file);
//             await _context.SaveChangesAsync();

//             return CreatedAtAction("GetFile", new { id = @file.Id }, @file);
//         }

//         // DELETE: api/Files/5
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteFile(int id)
//         {
//             var @file = await _context.Files.FindAsync(id);
//             if (@file == null)
//             {
//                 return NotFound();
//             }

//             _context.Files.Remove(@file);
//             await _context.SaveChangesAsync();

//             return NoContent();
//         }

//         private bool FileExists(int id)
//         {
//             // return _context.Files.Any(e => e.Id == id); // type missmatch
//             return false;
//         }
//     }
// }
