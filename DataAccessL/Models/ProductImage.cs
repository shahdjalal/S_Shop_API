﻿
namespace Shahd_DataAccessL.Models
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }


    }
}
