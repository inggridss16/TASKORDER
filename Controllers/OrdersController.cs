using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TASKORDER.Data;
using TASKORDER.Models;

namespace TASKORDER.Controllers
{
    public class OrdersController : Controller
    {
        private readonly TaskDbContext dbContext;

        public OrdersController(TaskDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await dbContext.Orders.ToListAsync();
            return View(orders);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddOrderViewModel createOrder)
        {
            var order = new Order()
            {
                OrderId = createOrder.OrderId,
                OrderName = createOrder.OrderName,
                OrderDate = createOrder.OrderDate,
                Qty = createOrder.Qty,
            };
            await dbContext.Orders.AddAsync(order);  
            await dbContext.SaveChangesAsync();    
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var order = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (order != null) 
            {
                var editViewModel = new EditOrderViewModel()
                {
                    Id = order.Id,
                    OrderId = order.OrderId,
                    OrderName = order.OrderName,
                    OrderDate = order.OrderDate,
                    Qty = order.Qty,
                };

                return View(editViewModel);
            }
            

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditOrderViewModel model)
        {
            var order = await dbContext.Orders.FindAsync(model.Id);

            if (order != null)
            {
                order.OrderName = model.OrderName;  
                order.OrderDate = model.OrderDate;  
                order.Qty = model.Qty;

                await dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await dbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (order != null)
            {
                dbContext.Orders.Remove(order);
                await  dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
          
        
    }
}
