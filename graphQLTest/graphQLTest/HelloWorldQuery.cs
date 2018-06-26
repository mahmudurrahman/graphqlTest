using GraphQL.Types;
using graphQLTest.Models;

public class HelloWorldQuery : ObjectGraphType
{
    public HelloWorldQuery()
    {
        Field<StringGraphType>(
            name: "hello",
            resolve: context => "world"
        );

        Field<StringGraphType>(
            name: "test",
            resolve: context => "Babu"
        );

        Field<ItemType>(
        "item",
        resolve: context =>
        {
            return new Item
            {
                Barcode = "123",
                Title = "Headphone",
                SellingPrice = 12.99M
            };
        }
        );
                Field<ItemType>(
            "item",
            arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "barcode" }),
            resolve: context =>
            {
                var barcode = context.GetArgument<string>("barcode");
                return new DataSource().GetItemByBarcode(barcode);
            }
        );
    }

    public class GraphQLRequest
    {
        public string Query { get; set; }
    }

    public class HelloWorldSchema : Schema
    {
        public HelloWorldSchema(HelloWorldQuery query)
        {
            Query = query;
        }
    }
}