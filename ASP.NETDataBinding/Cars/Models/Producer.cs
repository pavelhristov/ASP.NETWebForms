using System.Collections.Generic;

namespace Cars.Models
{
    public class Producer
    {
        public Producer(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public ICollection<string> Models { get; set; }
    }
}