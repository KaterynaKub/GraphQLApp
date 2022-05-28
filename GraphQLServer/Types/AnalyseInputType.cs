using GraphQL.Types;
using GraphQLServer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLServer.Types
{
    public class AnalyseInputType : InputObjectGraphType<AnalysisResults>
    {
        public AnalyseInputType()
        {
            Name = "AnalyseInput";
            Description = "Analyse Input Type";
            Field(a => a.Name, nullable: false, type: typeof(StringGraphType)).Description("Name");
            Field(a => a.Type, nullable: false, type: typeof(StringGraphType)).Description("Type");
        }

    }
}
