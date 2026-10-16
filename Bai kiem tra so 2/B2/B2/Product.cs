using System;
using System.Collections.Generic;
using System.Text;

namespace B2
{
    internal class Product
    {
        // 1. Khai báo lớp đối tượng Product
       
            public string ProductId { get; set; }
            public string ProductName { get; set; }
            public string Category { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public string ImagePath { get; set; } // Lưu đường dẫn ảnh
    
    }
}
