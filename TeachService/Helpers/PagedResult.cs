namespace TeachService.Helpers;

/// <summary>
/// Represents a paginated result set.
/// </summary>
/// <typeparam name="T">The type of the items in the result set.</typeparam>
public class PagedResult<T>
{
    /// <summary>
    /// Gets or sets the items in the current page.
    /// </summary>
    public List<T> Items { get; set; }

    /// <summary>
    /// Gets or sets the total count of items.
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// Gets or sets the size of the page.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Gets or sets the current page number.
    /// </summary>
    public int CurrentPage { get; set; }

    /// <summary>
    /// Gets the total number of pages.
    /// </summary>
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedResult{T}"/> class.
    /// </summary>
    /// <param name="items">The items in the current page.</param>
    /// <param name="count">The total count of items.</param>
    /// <param name="pageNumber">The current page number.</param>
    /// <param name="pageSize">The size of the page.</param>
    public PagedResult(List<T> items, int count, int pageNumber, int pageSize)
    {
        Items = items;
        TotalCount = count;
        PageSize = pageSize;
        CurrentPage = pageNumber;
    }
}