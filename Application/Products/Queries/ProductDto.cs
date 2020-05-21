namespace Application.Products.Queries
{
    public class ProductDto
    {
        public ProductDto(int productId, string productName, string supplierSiteName)
        {
            ProductId = productId;
            ProductName = productName;
            SupplierSiteName = supplierSiteName;
        }

        public int ProductId { get; }
        public string ProductName { get; }
        public string SupplierSiteName { get; }
    }
}
