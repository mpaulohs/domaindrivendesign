using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using demo1.Domain.AggregatesModel.BookAggregate;
using MediatR;
using demo1.Domain.Commands;

namespace demo1.UI.Controllers
{
    public class BooksController : Controller
    {
        
        private readonly IBookRepository _bookRepository;
        private readonly IMediator _mediator;

        public BooksController(IBookRepository bookRepository, IMediator mediator)
        {           
            _bookRepository = bookRepository;
            _mediator = mediator;
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            return View(await _bookRepository.ListAllAsync());
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = await _bookRepository.GetByIdAsync((int)id);
            //var book = await _context.Book
            //    .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookCommand command)
        {
            var response = await _mediator.Send(command).ConfigureAwait(false);
            if (response.Errors.Any())
            {
                return BadRequest(response.Errors);
            }

            return RedirectToAction(nameof(Index), "Books", new { response = response.Result });
            //if (ModelState.IsValid)
            //{
            //    await _bookRepository.AddAsync(book);
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookRepository.GetByIdAsync((int)id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Id")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _bookRepository.UpdateAsync(book);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = await _bookRepository.GetByIdAsync((int)id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            await _bookRepository.DeleteAsync(book);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult CrudApi()
        {
            return View();
        }

        private bool BookExists(int id)
        {
            return _bookRepository.ListAll().Any(e => e.Id == id);
        }
    }
}
