using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;

// this file is actually relatively useless
namespace French_Conjugations
{
    public class TenseViewModel 
    {
        #region Construction
        public TenseViewModel()
        {
            _tense = new TenseDatabase();
        }
        #endregion

        #region Members
        public TenseDatabase _database = new TenseDatabase();
        //ObservableCollection<VerbViewModel> _verbs = new ObservableCollection<VerbViewModel>();
        //int _index = 0;
        TenseDatabase _tense;
        #endregion

        #region Properties
        public string[] Tense
        {
            get { return _tense.getTenses; }
            //set { _database = value; }
        }

        public TenseDatabase Tenses
        {
            get { return _tense; }
            set { _tense = value; }
        }
        #endregion
    }
}
