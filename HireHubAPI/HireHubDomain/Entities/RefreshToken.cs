namespace HireHubDomain.Entities
{
    /// <summary>
    /// Persisted audit log of issued refresh tokens.
    /// Active session management lives in Redis; this table supports revocation history.
    /// </summary>
    public class RefreshToken
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        /// <summary>SHA-256 hash of the raw token string.</summary>
        public string TokenHash { get; set; } = default!;

        public DateTime ExpiresAt { get; set; }

        public bool IsRevoked { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? RevokedAt { get; set; }

        // ── Navigation ────────────────────────────────────────────────
        public User User { get; set; } = default!;
    }
}
