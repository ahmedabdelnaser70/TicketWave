﻿using Microsoft.EntityFrameworkCore;
using ticketWave.Models;

namespace ticketWave.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;
        public OrdersService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId , string userRolr)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Movie)
                        .Include(n => n.User).ToListAsync();

            if(userRolr != "Admin")
                orders = orders.Where(n => n.UserId == userId).ToList();

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    OrderId = order.Id,
                    Amount = item.Amount,
                    MovieId = item.Movie.Id,
                    Price = item.Movie.Price,
                };
                await _context.orderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
