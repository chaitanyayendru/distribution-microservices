using System;

namespace ProductService.Domain
 {
    public class Product : BaseEntity
     {
        public string Code { get; private set; }
        public string Name { get; private set; }
        public ProductStatus Status { get; private set; }
        public string Image { get; private set; }
        public string Description { get; private set; }
        public double MaxRetailPrice { get; private set; }
        
        public string ProductIcon { get; private set; }

        private Product()
        { }

        private Product(string code, string name,ProductStatus productStatus, string image, string description, double maxRetailPrice, string productIcon)
        {
            Id = Guid.NewGuid();
            Code = code;
            Name = name;
            Status = productStatus;
            Image = image;
            Description = description;
            MaxRetailPrice = maxRetailPrice;
            ProductIcon = productIcon;
        }

         public static Product CreateProduct(string code, string name, string image, string description, double maxRetailPrice, string productIcon)
         {
             return new Product(code,name,ProductStatus.Available,image,description,maxRetailPrice,productIcon);
         }

        public void Edit(int status)
        {
            Status = (ProductStatus)status;
        }
    }

    public enum ProductStatus
    {
        UpComing,
        Available,
        NotAvailable
    }
 }
