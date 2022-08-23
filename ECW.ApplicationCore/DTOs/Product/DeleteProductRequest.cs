namespace ECW.ApplicationCore.DTOs.Product;

public class DeleteProductRequest
{
    public int Id { get; init; }

    public DeleteProductRequest(int id)
    {
        Id = id;
    }
}