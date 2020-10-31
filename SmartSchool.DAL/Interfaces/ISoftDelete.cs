namespace SmartSchool.DAL.Interfaces
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}