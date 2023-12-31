﻿using AdresbeheerBL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdresbeheerBL.Model
{
    public class Gemeente
    {
        public Gemeente(int nIScode, string gemeentenaam)
        {
            ZetNIScode(nIScode);
            ZetGemeentenaam(gemeentenaam);
        }
        public int NIScode { get; private set; }
        public string Gemeentenaam { get; private set; }

        public override bool Equals(object? obj)
        {
            return obj is Gemeente gemeente &&
                   NIScode == gemeente.NIScode;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NIScode);
        }

        public void ZetGemeentenaam(string naam)
        {
            if ((string.IsNullOrWhiteSpace(naam)) || !char.IsUpper(naam[0]))
            {
                GemeenteException ex = new GemeenteException("naam niet correct");
                ex.Data.Add("Gemeentenaam", naam);
                throw ex;
            }
            Gemeentenaam = naam;
        }
        public void ZetNIScode(int code)
        {
            if (code <10000 || code > 99999)
            {
                GemeenteException ex = new GemeenteException("code niet correct");
                ex.Data.Add("NIScode",code);
                throw ex;
            }
            NIScode = code;
        }
    }
}
