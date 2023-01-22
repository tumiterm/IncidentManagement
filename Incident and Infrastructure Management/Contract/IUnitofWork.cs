namespace Incident_and_Infrastructure_Management.Models.Contract
{
    public interface IUnitofWork<T> where T : class
    {
        Task<T> OnGetRecordAsync(Guid Id);
        Task<IEnumerable<T>> OnGetRecordsAsync();
        Task<T> RegisterRecordAsync(T t);
        Task<T> ModifyRecordAsync(T t);
        void RemoveRecordAsync(Guid Id);
        void SaveRecordAsync();
    }
}
