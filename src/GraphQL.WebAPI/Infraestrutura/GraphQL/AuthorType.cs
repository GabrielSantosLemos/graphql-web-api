using GraphQL.WebAPI.Dominio;

namespace GraphQL.WebAPI.Infraestrutura.GraphQL
{
    public class AuthorType : ObjectType<Author>
    {
        protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
        {
            descriptor.Field(x => x.Id).Type<IdType>();
            descriptor.Field(x => x.FirstName).Type<StringType>();
            descriptor.Field(x => x.LastName).Type<StringType>();
            descriptor.Field<AuthorResolver>(t => t.GetAuthor(default, default));
        }
    }
}
