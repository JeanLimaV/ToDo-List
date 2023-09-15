using ToDo.Domain.Entities;

namespace ToDo.Domain.Contracts.PaginatedSearch
{
    public enum OrderByColumn
    {
        Name, 
        DateCreated
    }

    public enum SortDirection
    {
        Ascending,
        Descending
    }
    public interface IPaginatedSearch<T> 
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public OrderByColumn OrderBy { get; set; }
        public SortDirection SortDirection { get; set; }
        
        public void ApplyFilters(ref IQueryable<T> query);
        public void ApplyOrdenation(ref IQueryable<T> query);
    }
}