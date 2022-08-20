namespace ECW.ApplicationCore;

public class JwtConfig
{
    public string JwtSecret { get; set; } = string.Empty;
    public int ExpireDate { get; set; }
}