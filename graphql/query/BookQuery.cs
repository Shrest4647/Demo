[ExtendObjectType(OperationTypeNames.Query)]
public sealed class BookQuery {
    public IQueryable<Book>? GetBooks([Service] MyDBContext context) => context.Books;
}