namespace TASKORDER.Models
{
    public class AddOrderViewModel
    {
        public string OrderId { get; set; }
        public string OrderName { get; set; }
        public int Qty { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
