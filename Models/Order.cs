namespace TASKORDER.Models
{
    public class Order
    {
        public int Id { get; set; } 
        public string OrderId{ get; set; }    
        public string OrderName { get; set; }    
        public int Qty { get; set; }    
        public DateTime OrderDate { get; set; }    
    }
}
