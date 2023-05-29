
namespace Dapper_Data_Access_Layer.Entities
{
    public abstract class BaseEntity
    {
        public Guid ID { get; set; } 

        public DateTime CreatedDateTime { get; set; } 

        public DateTime? UpdatedDateTime { get; set; }

        public BaseEntity()
        {
            ID = Guid.NewGuid();

            CreatedDateTime = DateTime.Now;
            
            UpdatedDateTime = null;
        }
    }
}
