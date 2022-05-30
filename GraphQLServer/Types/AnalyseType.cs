using GraphQL.Types;
using GraphQLServer.Repositories;

namespace GraphQLServer.Types
{
    public class AnalyseType : ObjectGraphType<AnalysisResults>
    {
        public AnalyseType()
        {
            Name = "Analyse";
            Description = "Analyse Type";
            Field(a => a.Name, nullable: false).Description("Analyse name");
            Field(a => a.Type, nullable: false).Description("Type");
        }
    }
}
