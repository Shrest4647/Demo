[ExtendObjectType(OperationTypeNames.Query)]
public sealed class AuthorQuery {
    public IQueryable<Author>? GetAuthors([Service] MyDBContext context) => context.Authors;
}