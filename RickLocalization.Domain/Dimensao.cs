using System;
using System.Collections.Generic;
using System.Text;

namespace RickLocalization.Domain
{
    public class Dimensao
    {
        public int DimensaoId { get; private set; }
        public string DimensaoNome { get; private set; }

        public Dimensao(int dimensaoId, string dimensaoNome)
        {
            DimensaoId = dimensaoId;
            DimensaoNome = dimensaoNome;
        }

        public Dimensao()
        {

        }
    }

    
}
