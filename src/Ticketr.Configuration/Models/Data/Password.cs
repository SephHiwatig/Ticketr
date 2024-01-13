namespace Ticketr.Configuration.Models.Data
{
    public class Password
    {
        public bool RequireNonAlphanumeric { get; set; } = true;
        public bool RequireDigit { get; set; } = true;
        public bool RequireUppercase { get; set; } = true;
        public int RequiredLength { get; set; } = 6;
        public int RequiredUniqueChars { get; set; } = 1;
    }
}
