using System;

namespace Birds.Models.Birds
{
    public sealed class BirdsSearchQuery
    {
        public BirdsSearchQuery(int offset = 0, int limit = 100)
        {
            if (offset < 0 || limit > 1000)
            {
                throw new ArgumentException();
            }

            this.Offset = offset;
            this.Limit = limit;
        }
        
        public int Offset { get; }
        
        public int Limit { get; }
        
        public string Name { get; set; }
    }
}