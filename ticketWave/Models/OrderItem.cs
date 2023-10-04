﻿namespace ticketWave.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }


        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
