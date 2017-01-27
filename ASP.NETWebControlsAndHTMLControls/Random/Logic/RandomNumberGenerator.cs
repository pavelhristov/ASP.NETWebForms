using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Random.Logic
{
    public class RandomNumberGenerator
    {
        public int Generate(int min, int max)
        {
            System.Random rng = new System.Random();

            return rng.Next(min, max);
        }
    }
}