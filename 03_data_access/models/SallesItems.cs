using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_data_access.models
{
    public class SallesItems
    {
        public int Id { get; set; }
        public int ProductID { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int EmployeeID { get; set; }
        public int ClientID { get; set; }
        public DateTime Date { get; set; }
        override public string ToString()
        {
            return $"Id: {Id,5}, ProductID: {ProductID,5}, Price: {Price,20}, Quantity: {Quantity,5}, EmployeeID: {EmployeeID,5}, ClientID: {ClientID,5}, Date: {Date,15}";
        }
    }
}
