namespace Music4All.Infraestructure.Models;

public abstract class BaseModel
{
    public DateTime DateCreated { get; set; }
    public DateTime? DateUpdated { get; set; }
    public int? Quantity { get; set; }
    //   public bool IsActive { get; set; }
}