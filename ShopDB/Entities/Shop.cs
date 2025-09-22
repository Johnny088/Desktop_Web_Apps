namespace ShopDB.Entities
{
    class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
        public int CitiID { get; set; }
        public int ParkingArea { get; set; }    //why int?
        public ICollection<Worker> Workers { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
