using System;
using System.Collections.Generic;
using System.Text;

namespace French_Conjugations
{
    public class TenseDatabase : ObservableObject
    {
        #region Members
        string[] _tenseDisp = { "Present", "Passé composé", "Imperfect", "Futur Proche", "Futur Simple", "Conditional" };
        string _select;
        #endregion

        #region Properties
        public string this[int index]
        {
            get { return _tenseDisp[index]; }
        }

        public string[] getTenses
        {
            get { return _tenseDisp; }
        }
        public string SelectedTense
        {
            get { return _select; }
            set
            {
                if (_select != value)
                {
                    _select = value;
                    RaisePropertyChanged("SelectedTense");
                }
            }
        }
        #endregion
    }
}
