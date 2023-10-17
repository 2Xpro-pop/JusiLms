using System.Runtime.Serialization;

namespace JusiLms.Models;

public abstract class TimeStampedModel : ITimeStampedModel
{
    [IgnoreDataMember]
    public DateTime CreatedAt
    {
        get; set;
    }
    [IgnoreDataMember]
    public DateTime? LastModified
    {
        get; set;
    }
}