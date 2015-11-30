using System;
using System.Collections.Generic;
using System.Text;

namespace French_Conjugations
{
    /// <summary>
    /// Model of Irregular Verbs
    /// </summary>
    public class Irregular
    {
        #region Members
        string[] _irregVerbs =
        {
            "aller", "appeller",
            "avoir", "conduire", "courir", "dire", 
            "dormir", "être", "faire", 
            "mettre", "partir", "préférer", 
            "prendre", "rire", "sortir", 
            "traduire", "apprendre", "atteindre", 
            "acquérir", "boire", "battre", "comprendre", 
            "connaître", "construire", "couvrir", 
            "craindre", "croire", 
            "décevoir", "découvrir", "devoir", 
            "écrire", "instruire", "joindre", 
            "lire", "offrir", "ouvrir", 
            "paraître", "peindre", "pouvoir", 
            "recevoir", "savoir", "souffrir",
            "surprendre", "suivre", "tenir", 
            "venir", "vivre", "voir", "vouloir"
        };

        #endregion

        #region Properties
        public string this[int index]
        {
            get { return _irregVerbs[index]; }
        }

        public string[] getIrregularVerbs
        {
            get { return _irregVerbs; }
        }

        public List<string> IrregularVerbs
        {
            get { return new List<string>(getIrregularVerbs); }
        }
        #endregion
    }
}
