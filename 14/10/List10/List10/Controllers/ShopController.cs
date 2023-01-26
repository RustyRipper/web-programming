using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using List10.CartModels;
using List10.Data;
using List10.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace List10.Controllers
{
    public class ShopController : Controller
    {
        private readonly MyDbContext _context;
        private Dictionary<int, CartItem> _cart;

        private const int COOKIES_TIME = 7;

        public ShopController(MyDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.Category = _context.Category.ToList();
            var myDbContext = await _context.Article
                .Include(a => a.Category).Take(2)
                .ToListAsync();
            return View(myDbContext);
        }

        public async Task<IActionResult> List(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Category = _context.Category.ToList();
            var articles = await _context.Article
                .Include(a => a.Category)
                .Where(a => a.CategoryId == id)
                .ToListAsync();
            return View("Index", articles);
        }

        public async Task<IActionResult> Cart()
        {
            _cart = GetCart();
            ViewBag.Total = GetTotal(_cart);

            List<CartItem> clientList = new List<CartItem>();

            var keys = _cart.Keys.ToList();
            var articles = await _context.Article
                .Include(a => a.Category)
                .Where(a => keys.Contains(a.Id))
                .ToListAsync();

            foreach (var article in articles)
            {
                clientList.Add(new CartItem
                {
                    Article = article,
                    Amount = _cart[article.Id].Amount
                });
            }

            return View(clientList);
        }
        private Dictionary<int, CartItem> GetCart()
        {
            string cartString;
            Request.Cookies.TryGetValue("cart", out cartString);
            if (cartString != null)
            {
                _cart = JsonConvert.DeserializeObject<Dictionary<int, CartItem>>(Request.Cookies["cart"]);
                var keys = _cart.Keys.ToList();
                foreach(int key in keys)
                {
                    if (!ArticleExists(key))
                    {
                        _cart.Remove(key);
                    }
                }
                SaveCart(_cart);
            }
            else
            {
                _cart = new Dictionary<int, CartItem>();
            }
            return _cart;
        }
        private decimal GetTotal(Dictionary<int, CartItem> cart)
        {
            decimal? total = 0;
            if (cart == null)
            {
                return decimal.Zero;
            }
            foreach (KeyValuePair<int, CartItem> item in cart)
            {
                total += (decimal?)item.Value.Article.Price * item.Value.Amount;
            }
            return (decimal)total;
        }

        [HttpPost]
        public void AddToCart(int id)
        {
            _cart = GetCart();
            if (CartItemExists(_cart, id))
            {
                _cart[id].Amount++;
            }
            else
            {
                CartItem cartItem = new CartItem
                {
                    Article = _context.Article
                    .SingleOrDefault(a => a.Id == id),
                    Amount = 1
                };
                _cart.Add(id, cartItem);
            }
            SaveCart(_cart);
            //return Redirect(HttpContext.Request.Headers["Referer"].ToString());
        }

        private bool CartItemExists(Dictionary<int, CartItem> cart, int id)
        {
            if (cart == null)
                return false;
            return cart.ContainsKey(id);
        }

        private void SaveCart(Dictionary<int, CartItem> cart)
        {
            string cartToString = JsonConvert.SerializeObject(cart);
            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddDays(COOKIES_TIME);
            Response.Cookies.Append("cart", cartToString, options);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ReduceCartItem(int id)
        {
            _cart = GetCart();

            if (CartItemExists(_cart, id))
            {
                if (_cart[id].Amount <= 1)
                    _cart.Remove(id);
                else
                    _cart[id].Amount--;

                SaveCart(_cart);
            }
            return Redirect(HttpContext.Request.Headers["Referer"].ToString());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCartItem(int id)
        {
            _cart = GetCart();

            if (CartItemExists(_cart, id))
            {
                _cart.Remove(id);
                SaveCart(_cart);
            }
            return Redirect(HttpContext.Request.Headers["Referer"].ToString());
        }
        private bool ArticleExists(int id)
        {
            return _context.Article.Any(e => e.Id == id);
        }

        [Authorize]
        public async Task<IActionResult> Order()
        {
            _cart = GetCart();
            ViewBag.Total = GetTotal(_cart);
            List<CartItem> clientList = new List<CartItem>();
            var keys = _cart.Keys.ToList();
            var articles = await _context.Article
                .Include(a => a.Category)
                .Where(a => keys.Contains(a.Id))
                .ToListAsync();

            foreach (var article in articles)
            {
                clientList.Add(new CartItem
                {
                    Article = article,
                    Amount = _cart[article.Id].Amount
                });
            }

            OrderModel order = new OrderModel();
            order.Items = clientList;

            return View(order);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> ConfirmOrderAsync([Bind("Name, Surname, Phone, Address, PaymentMethod")] OrderModel order)
        {
            _cart = GetCart();
            ViewBag.Total = GetTotal(_cart);
            List<CartItem> clientList = new List<CartItem>();

            var keys = _cart.Keys.ToList();
            var articles = await _context.Article
                .Include(a => a.Category)
                .Where(a => keys.Contains(a.Id))
                .ToListAsync();

            foreach (var article in articles)
            {
                clientList.Add(new CartItem
                {
                    Article = article,
                    Amount = _cart[article.Id].Amount
                });
                _cart.Remove(article.Id);
            }
            order.Items = clientList;
            SaveCart(_cart);


            return View(order);
        }
    }
}
