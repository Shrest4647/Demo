public class MutationType: ObjectType<BookMutation>
{
    protected override void Configure(
        IObjectTypeDescriptor<BookMutation> descriptor)
    {
        descriptor.Field(f => f.InsertBook(default!, default!));
        descriptor.Field(f => f.UpdateBook(default!, default!));
        
    }
}