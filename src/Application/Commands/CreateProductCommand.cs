using MediatR;

namespace Application.Commands;

/// <summary>
/// Create Product Command - CQRS Pattern
/// C# 11 Features: Record types, Required members
/// </summary>
public record CreateProductCommand(
    string Name,
    decimal Price,
    int Stock,
    int CategoryId
) : IRequest<ProductDto>;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ProductDto>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // C# 11: Raw string literals
        var productJson = """
            {
                "name": "Product",
                "status": "creating"
            }
            """;

        var product = new Product
        {
            Name = request.Name,
            Price = request.Price,
            Stock = request.Stock,
            CategoryId = request.CategoryId,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(product, cancellationToken);

        return _mapper.Map<ProductDto>(product);
    }
}

public class ProductDto
{
    public required int Id { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public required int Stock { get; init; }
}
