namespace ECW.ApplicationCore.DTOs.Brand;

public class DeleteBrandRequest
{
    public int BrandId { get; init; }

    public DeleteBrandRequest(int brandId)
    {
        BrandId = brandId;
    }
}