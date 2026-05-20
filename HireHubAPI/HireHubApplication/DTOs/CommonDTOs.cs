namespace HireHubApplication.DTOs
{
    // ── Pagination ────────────────────────────────────────────────────────────────

    /// <summary>
    /// Generic paginated response wrapper. Used on all list endpoints.
    /// </summary>
    public record PagedResponse<T>(
        IEnumerable<T> Items,
        int Page,
        int PageSize,
        int TotalCount
    )
    {
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public bool HasNextPage => Page < TotalPages;
        public bool HasPreviousPage => Page > 1;
    }

    // ── API Envelope ──────────────────────────────────────────────────────────────

    /// <summary>
    /// Standard success envelope. All endpoints return this shape.
    /// </summary>
    public record ApiResponse<T>(
        bool Success,
        T? Data,
        string? Message = null
    )
    {
        public static ApiResponse<T> Ok(T data, string? message = null)
            => new(true, data, message);

        public static ApiResponse<T> Fail(string message)
            => new(false, default, message);
    }

    // ── Error ─────────────────────────────────────────────────────────────────────

    public record ErrorResponse(
        string Message,
        Dictionary<string, string[]>? ValidationErrors = null
    );
}
