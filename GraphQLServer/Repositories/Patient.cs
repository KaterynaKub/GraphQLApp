using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphQLServer.Repositories
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }

        public List<AnalysisResults> Analyses { get; set; } = new();

    }

    public class AnalysisResults
    {
        public string Name { get; set; }
        public string Type { get; set; }
        
    }
}
