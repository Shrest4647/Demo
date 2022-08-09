public class Query
{
    public IQueryable<Book>? GetBooks([Service] MyDBContext context) => context.Books;
    public IQueryable<Author>? GetAuthors([Service] MyDBContext context) => context.Authors;
}
