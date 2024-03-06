using AutoMapper;
using BookManager.API.Entities;
using BookManager.API.Models;
using BookManager.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookManager.API.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookDbContext _context;
        private readonly IMapper _mapper;
        public BooksController(
            BookDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        /// <summary>
        /// Obter todos os livros
        /// </summary>
        /// <returns>Coleção de Livros</returns>
        /// <response code="200">Sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var book = _context.Books.Where(b => !b.IsDeleted).ToList();
            var viewModel = _mapper.Map<List<BookViewModel>>(book);

            return Ok(viewModel);
        }
        /// <summary>
        /// Obter um Livro
        /// </summary>
        /// <param name="id">Identificador do Livro</param>
        /// <returns>Dados do Livro</returns>
        /// <response code="200">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<BookViewModel>(book);

            return Ok(viewModel);
        }
        /// <summary>
        /// Cadastrar um Livro
        /// </summary>
        /// <remarks>
        /// objeto JSON
        /// </remarks>
        /// <param name="input">Dados do Livro</param>
        /// <returns>Objeto recém-criado</returns>
        /// <response code="201">Sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(BookInputModel input)
        {
            var book = _mapper.Map<Book>(input);

            _context.Books.Add(book);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }
        /// <summary>
        /// Atualizar um Livro
        /// </summary>
        /// <remarks>
        /// objeto JSON
        /// </remarks>
        /// <param name="id">Identificador do Livro</param>
        /// <param name="input">Dados do Livro</param>
        /// <returns>Nada.</returns>
        /// <response code="204">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(Guid id, BookInputModel input)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }
            book.Update(input.Title, input.Autor, input.ISBN, input.YearOfPublication);
            _context.Books.Update(book);
            _context.SaveChanges();

            return NoContent();
        }
        /// <summary>
        /// Deletar um Livro
        /// </summary>
        /// <param name="id">Identificador do Livro</param>
        /// <returns>Nada.</returns>
        /// <response code="204">Sucesso</response>
        /// <response code="404">Não Encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(Guid id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }
            book.Delete();
            _context.SaveChanges();

            return NoContent();
        }
    }

}
