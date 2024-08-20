using AutoMapper;
using BookAuthor.Data.Data.Repository.IRepository;
using BookAuthor.Data.Data.Repository.IUnitOfWork;
using BookAuthor.Models.Dto;
using BookAuthor.Models.Exceptions;
using BookAuthor.Models.Models;
using BookAuthor.Service.Service.IService;
using Models.models;

namespace BookAuthor.Service.Service
{
    public class BookService : IBookService
    {
        public readonly IUnitOfWorkBook _unit;
        private readonly IAuthorRepository _authorRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public BookService (IUnitOfWorkBook unit, IMapper mapper, IAuthorRepository author, IGenreRepository genreRepository)
        {
            _unit = unit;
            _mapper = mapper;
            _authorRepository = author;
            _genreRepository = genreRepository;
        }

        public BookDTO mapperBook(Book book)
        {
            return _mapper.Map<BookDTO>(book);
        }
        public async Task<BookDTO> CreateBook(CreateBookDTO dto)
        {
            // We need to check if the author and the genre are in the DB
            var author = await _authorRepository.GetById(dto.Author);

            if (author == null)
            {
                throw new NotFoundException("Author with id '" +  dto.Author + "' doesn't exist");
            }

            var genre = await _genreRepository.GetById(dto.Genre);

            if (genre == null)
            {
                throw new NotFoundException("Genre with id '" + dto.Genre + "' doesn't exist");
            }
            var date = new DateTime();
            var newBook = new Book();
            newBook.Author = author;
            newBook.Genre = genre;
            newBook.Description = dto.Description;
            newBook.Title = dto.Title;
            newBook.Price = dto.Price;
            newBook.CreatedAt = date;
            newBook.UpdatedAt = date;

            await _unit.Books.Add(newBook);
            await _unit.CompleteAsync();
            return mapperBook(newBook);
        }

        public async Task<Boolean> DeleteBook(int id)
        {
            // We need to check if the books is in the DB
            var book = await _unit.Books.GetById(id);
            if (book == null)
            {
                throw new NotFoundException("Book with id '" + id + "' doesn't exist");
            }
            var result = await _unit.Books.Delete(id);
            if (!result)
            {
                throw new CustomException("Error deleting book with id '" + id + "', try it later"); 
            }
            return result;
        }

        public async Task<List<BookDTO>> FilterBooksByAuthor(int authorId, int pageNumber, int pageSize, Boolean orderByAsc)
        {
            var books = await _unit.Books.GetBooksWithDetails();

            if (books == null)
            {
                throw new NotFoundException("There are no books in DB");
            }

            var result = books.Where(book => book.Author.Id == authorId).Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (result.Count() == 0)
            {
                throw new NotFoundException("There are no books related with the author with id '" + authorId + "'");
            }

            var final = result;

            if (orderByAsc)
            {
                final = result.OrderBy(book => book.Id);
            } 
            else
            {
                final = result.OrderByDescending(book => book.Id);
            }
            return _mapper.Map<List<Book>, List<BookDTO>>(final.ToList());
        }

        public async Task<List<BookDTO>> FilterBooksByGenre(int genreId, int pageNumber, int pageSize, Boolean orderByAsc)
        {
            var books = await _unit.Books.GetBooksWithDetails();
            if (books == null)
            {
                throw new NotFoundException("There are no books in DB");
            }

            var result = books.Where(book => book.Genre.Id == genreId).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            if (result.Count() == 0)
            {
                throw new NotFoundException("There are no books related with the genre with id '" + genreId + "'");
            }

            var final = result;

            if (orderByAsc)
            {
                final = result.OrderBy(book => book.Genre.Id);
            }
            else
            {
                final = result.OrderByDescending(book => book.Genre.Id);
            }
            return _mapper.Map<List<Book>, List<BookDTO>>(final.ToList());
        }

        public async Task<List<BookDTO>> FilterBooksByPriceRange(int startPrice, int endPrice, int pageNumber, int pageSize, Boolean orderByAsc)
        {
            var books = await _unit.Books.GetAll();
            var result = books.Where(book => book.Price >= startPrice && book.Price <= endPrice).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            var final = result;

            if (orderByAsc)
            {
                final = result.OrderBy(book => book.Price);
            }
            else
            {
                final = result.OrderByDescending(book => book.Price);
            }
            return _mapper.Map<List<Book>, List<BookDTO>>(final.ToList());
        }

        public async Task<BookDTO> GetBookById(int id)
        {
            var book = await _unit.Books.GetById(id);
            if (book == null)
            {
                throw new NotFoundException("Book with id '" + id + "' doesn't exist");
            }
            return mapperBook(book);
        }

        public async Task<List<BookDTO>> GetBooks(int pageNumber, int pageSize, Boolean orderByAsc)
        {
            var books = await _unit.Books.GetAll();
            if (books == null)
            {
                throw new NotFoundException("There are no books in DB");
            }
            var result = books.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return _mapper.Map<List<Book>, List<BookDTO>>(result.ToList());
        }

        public async Task<BookDTO> GetTheCheapestBook()
        {
            var books = await _unit.Books.GetAll();
            var book = books.Where(book => book.Price > 0).OrderBy(book => book.Price).First();
            return mapperBook(book);
        }

        public async Task<BookDTO> GetTheMostExpensiveBook()
        {
            var books = await _unit.Books.GetAll();
            var book = books.OrderByDescending(book => book.Price).First();
            return mapperBook(book);
        }

        public async Task<BookDTO> UpdateBook(UpdateBookDTO dto)
        {
            var book = await _unit.Books.GetById(dto.Id);

            if (book == null)
            {
                throw new NotFoundException("Book with id '" + dto.Id + "' doesn't exist");
            }

            //var author = Author ?? null;
            var genre = (Genre?) null;

            var author = new Author();
;
            // We need to check if the author and the genre are in the DB

            if (dto.Author > 0)
            {
                author = await _authorRepository.GetById(dto.Author);

                if (author == null)
                {
                    throw new NotFoundException("Author with id '" + dto.Author + "' doesn't exist");
                }
            }

            if (dto.Genre > 0)
            {

                genre = await _genreRepository.GetById(dto.Genre);

                if (genre == null)
                {
                    throw new NotFoundException("Genre with id '" + dto.Genre + "' doesn't exist");
                }
            }

            book.Title = dto.Title != null && dto.Title != "" ? dto.Title : book.Title;
            book.Description = dto.Description != null && dto.Description != "" ? dto.Description : book.Description;
            book.Price = dto.Price > 1 ? dto.Price : book.Price;
            book.Author = author != null ? author : book.Author;
            book.Genre = genre != null ? genre : book.Genre;
            book.UpdatedAt = new DateTime();

            var result = await _unit.Books.Update(book);
            return mapperBook(result);
        }
    }
}
