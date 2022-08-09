public class MutationType: ObjectType<Mutation>
{
    protected override void Configure(
        IObjectTypeDescriptor<Mutation> descriptor)
    {
        descriptor.Field(f => f.InsertBook(default!, default!));
        descriptor.Field(f => f.UpdateBook(default!, default!));
        
    }
}