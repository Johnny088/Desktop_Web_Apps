namespace ShopDB.Entities
{
    class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Position Position { get; set; }
        public int PositionID { get; set; }
        public Shop Shop { get; set; }
        public int ShopID { get; set; }
    }
}
