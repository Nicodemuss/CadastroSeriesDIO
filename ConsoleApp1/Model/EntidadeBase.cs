using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
  public abstract class EntidadeBase
    {
        public int id { get; set; }

        public EntidadeBase(int id)
        {
            this.id = id;
        }

        protected EntidadeBase()
        {
        }
    }
}
