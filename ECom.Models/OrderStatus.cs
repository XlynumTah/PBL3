using System.ComponentModel.DataAnnotations;

namespace ECom.Models;

public class OrderStatus
{
    public enum OrderStatusType
    {
        Shipping,
        Completed,
        Cancelled,
        Returned
    }
    [Key]
    public int Id { get; set; }
    public OrderStatusType Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; }
}