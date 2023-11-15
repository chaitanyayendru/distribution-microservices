using System.Collections.Generic;

namespace ProductService.Api.Commands.Dtos
{
    public class ProductAdditionDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public double MaxRetailPrice { get; set; }
        
        public string Icon { get; set; }
    }
}