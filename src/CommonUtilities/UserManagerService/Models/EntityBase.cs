using System.ComponentModel.DataAnnotations;

namespace UserManagerService.Models;

public abstract class EntityBase
{
    [Key]
    public Guid Uid { get; set; }
    public EntityBase()
    {
        Uid = Guid.NewGuid();
    }
    
    public EntityBase(Guid p_uid)
    {
        Uid = p_uid;
    }
}