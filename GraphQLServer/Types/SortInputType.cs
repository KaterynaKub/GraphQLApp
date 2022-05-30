using GraphQL.Types;
using GraphQLServer.Models;

namespace GraphQLServer.Types;

class SortInputType : InputObjectGraphType<Sort>
{
    public SortInputType()
    {
        Name = "Sort";
        Description = "Sort Type";
        Field(d => d.Field, false, typeof(StringGraphType)).Description("Field");
        Field(d => d.Order, false, typeof(StringGraphType)).Description("Order");
      
    }
}
