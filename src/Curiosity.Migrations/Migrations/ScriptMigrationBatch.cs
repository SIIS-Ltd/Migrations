using System;

namespace Curiosity.Migrations
{
    /// <summary>
    /// Batch of single migration
    /// </summary>
    /// <remarks>
    /// Script migration is splitted into batches by text "--BATCH:"
    /// </remarks>
    public class ScriptMigrationBatch
    {
        /// <summary>
        /// Batch order in a migration
        /// </summary>
        public int OrderIndex { get; }
            
        /// <summary>
        /// Batch name (shown at logs, name is a text after --BATCH:)
        /// </summary>
        public string? Name { get; }
        
        /// <summary>
        /// SQL
        /// </summary>
        public string Script {
            get => _script;
            internal set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(Script));

                _script = value;
            }
        }

        private string _script;

        public ScriptMigrationBatch(
            int orderIndex,
            string? name,
            string script)
        {
            if (orderIndex < 0) throw new ArgumentOutOfRangeException(nameof(orderIndex));
            if (String.IsNullOrWhiteSpace(script)) throw new ArgumentNullException(nameof(orderIndex));
            
            OrderIndex = orderIndex;
            Name = name;
            Script = script;
        }
    }
}