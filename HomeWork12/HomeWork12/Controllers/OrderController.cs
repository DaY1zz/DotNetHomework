using HomeWork12.Models;
using HomeWork5;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace HomeWork12.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly OrderContext orderDb;
        public OrderController(OrderContext ctx)
        {
            orderDb = ctx;
        }
        [HttpGet]
        public ActionResult<List<Order>> GetTodoItems(string clientname,string address,double? money)
        {
            var query = orderDb.Orders.Include("OrderDetails");
            if (clientname != null)
            {
                query = query.Include("OrderDetails").Where(o => o.OrderClient.Name.Equals(clientname));
            }
            if (address != null)
            {
                query = query.Include("OrderDetails").Where(o => o.DeliveryAddress.Equals(address));
            }
            if(money != null)
            {
                query = query.Include("OrderDetails").Where(o => o.TotalMoney == money);
            }
            return query.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Order> GetTodoItem(string id)
        {
            var query = orderDb.Orders.Include(o=>o.OrderClient).Include(o=>o.OrderDetails).ThenInclude(o => o.OrderGoods).FirstOrDefault();
            if (query == null)
            {
                return NotFound();
            }
            return query;
        }
        [HttpGet("pageQuery")]
        public ActionResult<List<Order>> queryTodoItem(string clientname, string address, double? money, int skip, int take)
        {
            var query = orderDb.Orders.Include(o => o.OrderClient).Include(o => o.OrderDetails).ThenInclude(o => o.OrderGoods);
            if (clientname != null)
            {
                query = query.Include(o => o.OrderClient).Include(o => o.OrderDetails).ThenInclude(o => o.OrderGoods);.Where(o => o.OrderClient.Name.Equals(clientname));
            }
            if (address != null)
            {
                query = query.Include(o => o.OrderClient).Include(o => o.OrderDetails).ThenInclude(o => o.OrderGoods);.Where(o => o.DeliveryAddress.Equals(address));
            }
            if (money != null)
            {
                query = query.Include(o => o.OrderClient).Include(o => o.OrderDetails).ThenInclude(o => o.OrderGoods);.Where(o => o.TotalMoney == money);
            }
            return query.Skip(skip).Take(take).ToList();
        }
        [HttpPost]
        public ActionResult<Order> PostTodoItem(Order order)
        {
            try
            {
                orderDb.Orders.Add(order);
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return order;
        }

        [HttpPut("{id}")]
        public ActionResult<Order> PutTodoItem(string id, Order order)
        {
            if (id != order.OrderID)
                return BadRequest("Id cannot be modified");
            try
            {
                orderDb.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                orderDb.SaveChanges();
            }
            catch (Exception e)
            {
                string error = e.Message;
                if (e.InnerException != null)
                    error = e.InnerException.Message;
                return BadRequest(error);
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTodoItem(string id)
        {
            try
            {
                var target = orderDb.Orders.Include(o => o.OrderClient).Include(o => o.OrderDetails).ThenInclude(o => o.OrderGoods).FirstOrDefault(t => t.OrderID == id);
                if (target != null)
                {
                    orderDb.OrderDetails.RemoveRange(target.OrderDetails);
                    orderDb.Remove(target);
                    orderDb.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
            return NoContent();
        }
    }

}
