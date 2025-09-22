namespace ShopDB.Entities
{
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Discount { get; set; }
        public Category Category { get; set; }
        public int CategoriesID { get; set; }
        public int Quantity { get; set; }
        public bool IsinStock { get; set; }
        public ICollection<Shop> Shops { get; set; }
    }
}
