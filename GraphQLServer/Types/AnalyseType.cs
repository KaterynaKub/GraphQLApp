using GraphQL.Types;
using GraphQLServer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
