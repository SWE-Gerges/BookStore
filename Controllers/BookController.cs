using BookStore.Models;
using BookStore.Models.Repositories;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace BookStore.Controllers;

public class BookController : Controller
{
    private readonly IBookStoreRepository<Book> book;
    private readonly IBookStoreRepository<Author> author;
    private readonly IWebHostEnvironment hosting;

    public BookController(IBookStoreRepository<Book> book, IBookStoreRepository<Author> author,
    IWebHostEnvironment hosting)
    {
        this.book = book;
        this.author = author;
        this.hosting = hosting;
    }


    //GET: localhost/Books/index  --> All Books
    public ActionResult Index()
    {
        var books = book.List();

        return View(books);
    }


    //GET: Books/Details/id? --> Sepecific Book
    public ActionResult Details(int id)
    {
        var _book = book.Find(id);
        return View(_book);
    }

    //GET: Delete
    public ActionResult Delete(int id)
    {
        var _book = book.Find(id);
        return View(_book);
    }
    
    //POST: 
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, Book _book)
    {
        try
        {
            book.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }



    //GET: Book/Create --> view the form
    public ActionResult Create()
    {
        var model = new BookAuthorViewModel
        {
            Authors = FillSelectList()
        };
        return View(model);
    }


    //POST: Book/Create  --> submit the form

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(BookAuthorViewModel model)
    {
        try
        {
            string fileName = uploadFile(model.file) ?? string.Empty;

            
         if(model.authorID == -1){
            ViewBag.Message = "Please Select an author!";

        var vmodel = new BookAuthorViewModel
        {
            Authors = FillSelectList()
        };

            return View(vmodel);
         }
         var _author = author.Find(model.authorID);
        Book _book = new Book
        {
            bookId = model.bookId,
            bookDescription = model.bookDescription,
            bookName = model.bookName,
           imgURL = fileName,
            Author = _author
        };

            book.Add(_book);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    //GET: Book/Edit/id?
    public ActionResult Edit(int id)
    {
        try{
        var _book = book.Find(id);
        var authorId = _book.Author == null ? _book.Author.authourId = 0 : _book.Author.authourId;
        var model = new BookAuthorViewModel
        {
            bookId = _book.bookId,
            bookName = _book.bookName,
            bookDescription = _book.bookDescription,
            authorID = _book.Author.authourId,
            Authors = author.List().ToList(),
            imgURL = _book.imgURL

        };

        return View(model);
        }

        catch(Exception ex)
        {
            return View();
        }
    }

    //POST: Book/Edit/id?
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(BookAuthorViewModel model)
    {
        try{
       string fileName = uploadFile(model.file, model.imgURL);

         
        Book _book = new Book
        {
            bookId = model.bookId,
            bookDescription = model.bookDescription,
            bookName = model.bookName,
            Author = author.Find(model.authorID),
            imgURL = fileName
        };


        
        
            book.Update(model.bookId,_book);
            return RedirectToAction(nameof(Index));
        }
        catch(Exception ex)
        {
            return View();
        }


    }


    //Search
    
    public ActionResult Search(string term)
    {
       var result =  book.Search(term);
        return View("Index",result);
    }


    List<Author> FillSelectList()
    {
        var authors = author.List();
        authors.Insert(0, new Author{authourId=-1, authorName="---Please select an author---"});
        

        return authors.ToList();
    }

    string uploadFile(IFormFile file)
    {
         if(file!=null){
                string uploads = Path.Combine(hosting.WebRootPath, "uploads");
                string fullPath = Path.Combine(uploads, file.FileName);
               file.CopyTo(new FileStream(fullPath, FileMode.Create));

               return file.FileName;

            }
        else
        return null;

    }


    string uploadFile(IFormFile file, string imageUrl)
    {
        if (imageUrl == null){
            imageUrl =string.Empty+"Empty";
        }
        if(file!=null){
                string uploads = Path.Combine(hosting.WebRootPath, "uploads");
                string newPath = Path.Combine(uploads, file.FileName);

                //Delte old image
                string oldPath = Path.Combine(uploads, imageUrl);

                if(newPath != oldPath)
                {
                    System.IO.File.Delete(oldPath); 


                //save new image
               file.CopyTo(new FileStream(newPath, FileMode.Create));
                }
                
                return file.FileName;
            }
        else
            return imageUrl;
    }
  


}