﻿namespace Mango.Services.CuponAPI.Models.DTO
{
    public class CuponDTO
    {
        public int CuponId { get; set; }
        public string CuponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
