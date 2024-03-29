using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using bookstore_nathanck.infrastructure;
using bookstore_nathanck.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace bookstore_nathanck.Pages
{
    public class BuyModel : PageModel
    {
        private iBookStoreRepository repo { get; set; }
        public BuyModel (iBookStoreRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }
        
        public Basket basket { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost( int bookId, string returnUrl)
        {
            Book b = repo.Books.FirstOrDefault(x => x.BookId == bookId);
            basket.AddItem(b, 1);


            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(int bookid, string returnUrl)
        {
            basket.RemoveItem(basket.Items.First(x => x.Book.BookId == bookid).Book);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
