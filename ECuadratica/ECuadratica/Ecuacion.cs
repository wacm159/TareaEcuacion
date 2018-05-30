using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECuadratica
{
    public class Ecuacion
    {
        [PrimaryKey, AutoIncrement]
        public int IdOperacion { get; set; }
        public decimal DatoA { get; set; }
        public decimal DatoB { get; set; }
        public decimal DatoC { get; set; }
        public decimal Res1 { get; set; }
        public decimal Res2 { get; set; }

        public string VariablesIn
        {
            get
            {
                return string.Format("A: {0} B: {1} C: {2}", this.DatoA, this.DatoB, this.DatoC);
            }
        }

        public string VariablesOut
        {
            get
            {
                return string.Format(" X1: {0} X2: {1}", this.Res1, this.Res2);
            }
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", VariablesIn, VariablesOut);
        }

    }
}
