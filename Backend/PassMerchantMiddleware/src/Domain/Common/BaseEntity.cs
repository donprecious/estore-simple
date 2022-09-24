using System.ComponentModel.DataAnnotations.Schema;

namespace PassMerchantMiddleware.Domain.Common;

public abstract class BaseEntity
{
    

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    
    
    
    

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public virtual int Id
    {
        get;
        private set; 
    }

  

    
    public bool IsTransient()
    {
        return this.Id == default(Int32);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || !(obj is BaseEntity))
            return false;

        if (Object.ReferenceEquals(this, obj))
            return true;

        if (this.GetType() != obj.GetType())
            return false;

        BaseEntity item = (BaseEntity)obj;

        if (item.IsTransient() || this.IsTransient())
            return false;
        else
            return item.Id == this.Id;
    }

   
    public static bool operator ==(BaseEntity left, BaseEntity right)
    {
        if (Object.Equals(left, null))
            return (Object.Equals(right, null)) ? true : false;
        else
            return left.Equals(right);
    }

    public static bool operator !=(BaseEntity left, BaseEntity right)
    {
        return !(left == right);
    }
}