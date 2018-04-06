using StructureMap.Configuration.DSL;
using StructureMap.Graph;

namespace ProgrammingChallenge
{
    /// <summary>
    ///  ComponentRegistry class
    /// </summary>
    public class ComponentRegistry : Registry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComponentRegistry" /> class
        /// </summary>
        public ComponentRegistry()
        {
            Scan(assemblyScanner =>
            {
                assemblyScanner.AssembliesFromApplicationBaseDirectory();
                assemblyScanner.WithDefaultConventions();
            });
        }
    }
}