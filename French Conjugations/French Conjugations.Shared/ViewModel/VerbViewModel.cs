﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using System.Reflection;
using Windows.UI.Popups;

namespace French_Conjugations
{
    public class VerbViewModel : ObservableObject
    {
        #region Construction
        /// <summary>
        /// Constructs the default instance of the view model
        /// </summary>
        public VerbViewModel()
        {
            _verb = new Verb { VerbInfinitive = "Verb", VerbSubject = "Enter",
                VerbInput = "Enter Verb", VerbEnding = "unknown",
                VerbFinalForm = "unkown"
                };

            _sTenses = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                _sTenses.Add( _database[i]);
            }
        }
        #endregion

        #region Members
        Verb _verb;
        //int _tense = 0;
        List<string> _sTenses;
        private TenseDatabase _database = new TenseDatabase();
        ObservableCollection<TenseViewModel> _tenses = new ObservableCollection<TenseViewModel>();
        TenseViewModel _currentTense;
        string _selectedTense;
        #endregion

        #region Properties
        public Verb Verb
        {
            get { return _verb; }
            set { _verb = value; }
        }

        public string VerbSubject
        {
            get { return Verb.VerbSubject; }
            set
            {
                // This should actually find the subject
                try
                {
                    Verb.VerbSubject = Verb.VerbInput.Substring(0, Verb.VerbInput.IndexOf(' '));
                    RaisePropertyChanged("VerbSubject");
                }
                catch (Exception ex)
                {
                    //Verb.VerbSubject = ex.Message;
                    RaisePropertyChanged("VerbSubject");
                }
            }
        }

        public string VerbInfinitive
        {
            get { return Verb.VerbInfinitive; }
            set
            {
                // This should find the infinitive
                try
                {
                    int indexOfSpace = Verb.VerbInput.IndexOf(' ');
                    Verb.VerbInfinitive = VerbInput.Substring(indexOfSpace + 1, Verb.VerbInput.Length - (indexOfSpace + 1));
                    RaisePropertyChanged("VerbInfinitive");
                }
                catch (Exception ex)
                {
                    //Verb.VerbInfinitive = ex.Message;
                    RaisePropertyChanged("VerbInfinitive");
                }
            }
        }
        public string VerbEnding
        {
            get { return Verb.VerbEnding; }
            set
            {
                try
                {
                    Verb.VerbEnding = CalcVerbEnding(Verb);
                    RaisePropertyChanged("VerbEnding");
                }
                catch (Exception ex)
                {
                    RaisePropertyChanged("VerbEnding");
                }
            }
        }


        public string VerbFinalForm
        {
            get { return Verb.VerbFinalForm; }
            set
            {
                try
                {
                    // TODO: Add conjugation logic
                    string root = Verb.VerbInfinitive.Substring(0, Verb.VerbInfinitive.Length - 2);
                    string helping = string.Empty;
                    string append = string.Empty;
                    string carryOutVerb = string.Empty;
                    string replaceInf = string.Empty;
                    switch (SelectTense)
                    {
                        case "Present":
                            append = PresentConj(Verb.VerbSubject.ToLower());
                            break;
                        case "Passé composé":
                            append = PasseConj(append);
                            break;
                        case "Imperfect":
                            replaceInf = ImperfectConj(Verb.VerbEnding.ToLower());
                            break;
                        case "Futur Proche":
                            helping = ProcheConj(append);
                            root = Verb.VerbInfinitive;
                            append = string.Empty;
                            break;
                        case "Futur Simple":
                            append = FuturSimpleConj(append);
                            break;
                        case "Conditional":
                            append = ConditionalConj(append);
                            break;
                        default:
                            append = PresentConj(append);
                            break;
                    }

                    if (helping == string.Empty)
                    {
                        if (replaceInf == string.Empty)
                        {
                            carryOutVerb = string.Concat(Verb.VerbSubject, " ", root, append);
                        }
                        else
                        {
                            carryOutVerb = string.Concat(Verb.VerbSubject, " ", replaceInf);
                        }
                    }
                    else
                    {
                        carryOutVerb = string.Concat(Verb.VerbSubject, " ", helping, root, append);
                    }
                    Verb.VerbFinalForm = carryOutVerb;
                    RaisePropertyChanged("VerbFinalForm");
                }
                catch (Exception ex)
                {
                    
                    RaisePropertyChanged("VerbFinalForm");
                }
            }
        }

       
        public string VerbInput
        {
            get { return Verb.VerbInput; }
            set
            {
                if (Verb.VerbInput != value)
                {
                    Verb.VerbInput = value;
                    RaisePropertyChanged("VerbInput");
                    //QuickConjugate(); // Obsolete
                }
            }
        }

        public ObservableCollection<TenseViewModel> Tenses
        {
            get { return _tenses; }
            set { _tenses = value; }
        }
        
        public List<string> VerbTenses
        {
            get { return _sTenses; }
        }
        public TenseViewModel SelectedTense
        {
            get { return _currentTense; }
            set
            {
                if (_currentTense != value)
                {
                    _currentTense = value;
                    RaisePropertyChanged("SelectedTense");
                }
            }
        }

        public string SelectTense
        {
            get { return _selectedTense; }
            set
            {
                if (_selectedTense != value)
                {
                    _selectedTense = value;
                    RaisePropertyChanged("SelectTense");
                }
            }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Calculates the verb ending (i.e. er, re, ir)
        /// </summary>
        /// <param name="Verb">Verb to calculate the ending of</param>
        /// <returns>The last two letters of the Verb</returns>
        public string CalcVerbEnding(Verb Verb)
        {
            int length = Verb.VerbInput.Length;
            return Verb.VerbInput.Substring(length - 2, 2);
        }

        /// <summary>
        /// Quickly conjugates as user inputs string, worked well when only using one tense.
        /// MTN French Conjugations will not be implemented in future updates
        /// </summary>
        [Deprecated("French Conjugator will no longer use this method because it breaks the UX", DeprecationType.Deprecate, 100859904)]
        private void QuickConjugate()
        {
            VerbInfinitive = _verb.VerbInfinitive.ToLower();
            VerbSubject = _verb.VerbSubject.ToLower();
            if (Verb.VerbEnding == "er" | Verb.VerbEnding == "re" | Verb.VerbEnding == "ir")
            {
                VerbEnding = CalcVerbEnding(Verb);
            }
            else
            {
                VerbEnding = _verb.VerbEnding.ToLower();
            }
            VerbFinalForm = _verb.VerbFinalForm.ToLower();
        }

        /// <summary>
        /// Conjugate verb with respect to present tense
        /// </summary>
        /// <param name="append"></param>
        /// <returns></returns>
        private string PresentConj(string append)
        {
            switch (Verb.VerbEnding)
            {
                case "er":
                    // Damn nested switch statements!
                    switch (Verb.VerbSubject.ToLower())
                    {
                        case "je":
                            append = "e";
                            break;
                        case "tu":
                            append = "es";
                            break;
                        case "il":
                        case "elle":
                        case "on":
                            append = "e";
                            break;
                        case "nous":
                            append = "ons";
                            break;
                        case "vous":
                            append = "ez";
                            break;
                        case "ils":
                        case "elles":
                            append = "ent";
                            break;
                        default:
                            break;
                    }
                    break;
                case "re":
                    // Foiled again by these nested switch statements!
                    switch (Verb.VerbSubject.ToLower())
                    {
                        case "je":
                        case "tu":
                            append = "s";
                            break;
                        case "il":
                        case "elle":
                        case "on":
                            append = "";
                            break;
                        case "nous":
                            append = "ons";
                            break;
                        case "vous":
                            append = "ez";
                            break;
                        case "ils":
                        case "elles":
                            append = "ent";
                            break;
                        default:
                            break;
                    }
                    break;
                case "ir":
                    // Okay, this is going to come back to bite me in the ass later if I don't fix this...
                    switch (Verb.VerbSubject.ToLower())
                    {
                        case "je":
                        case "tu":
                            append = "is";
                            break;
                        case "il":
                        case "elle":
                        case "on":
                            append = "it";
                            break;
                        case "nous":
                            append = "issons";
                            break;
                        case "vous":
                            append = "issez";
                            break;
                        case "ils":
                        case "elles":
                            append = "issent";
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }

            return append;
        }

        private string PasseConj(string infinitive)
        {
            msgShow();
            string append = string.Empty;
            return append;
        }

        /// <summary>
        /// Conjugates the input to match the imperfect past form
        /// </summary>
        /// <remarks>
        /// Has some bugs that could use fixing
        /// </remarks>
        /// <param name="append"> </param>
        /// <returns></returns>
        private string ImperfectConj(string infinitive)
        {
            string tempSub = Verb.VerbSubject; // backs up the original verb subject
            Verb tempVerb = Verb;              // creates clone of the Verb
            tempVerb.VerbSubject = "nous";     // changes subject to "nous"
            tempVerb.VerbInput = "nous " + Verb.VerbInfinitive; // changes input to "nous " + the input infinitive
            SelectTense = "Present";            // changes tense to present 
            ConjugateVerbIn(tempVerb);          // conjugates tempVerb
            int indexOfSpace = tempVerb.VerbFinalForm.IndexOf(' '); // gets position of ' ' in string tempVerb.FinalForm
            // creates a variable to store the returned conjugated verb to be used in later conjugation
            string tempInf = tempVerb.VerbFinalForm.Substring(indexOfSpace + 1, tempVerb.VerbFinalForm.Length - (indexOfSpace + 1));
            string tempRoot = tempInf.Substring(0, tempInf.IndexOf("ons"));     // extracts root of conjugated verb
            SelectTense = "Imperfect";              // resets tense to infinitive
            tempVerb.VerbSubject = tempSub;         // resets subject to the orinial subject
            string append;                          // create string append

            // sets the append variable to an imperfect verb ending
            switch (Verb.VerbSubject.ToLower())
            {
                case "je":
                    append = "ais";
                    break;
                case "tu":
                    append = "ais";
                    break;
                case "il":
                case "elle":
                case "on":
                    append = "ait";
                    break;
                case "nous":
                    append = "ions";
                    break;
                case "vous":
                    append = "iez";
                    break;
                case "ils":
                case "elles":
                    append = "aient";
                    break;
                default:
                    append = "";
                    break;
            }

            string ret = string.Concat(tempRoot, append);   // concatenates the root and the ending
            Verb.VerbSubject = tempSub;                     // resets the subject to the original one
            return ret;                                     // return result
        }

        /// <summary>
        /// Injects the helper verb for futur proche verbs
        /// </summary>
        /// <param name="infinitive"></param>
        /// <returns></returns>
        private string ProcheConj(string infinitive)
        {
            string append;
            switch (Verb.VerbSubject.ToLower())
            {
                case "je":
                    append = "vais";
                    break;
                case "tu":
                    append = "vas";
                    break;
                case "il":
                case "elle":
                case "on":
                    append = "va";
                    break;
                case "nous":
                    append = "allons";
                    break;
                case "vous":
                    append = "allez";
                    break;
                case "ils":
                case "elles":
                    append = "vont";
                    break;
                default:
                    append = "";
                    break;
            }
            return append;
        }

        private string FuturSimpleConj(string append)
        {
            msgShow();
            return append;
        }

        private string ConditionalConj(string append)
        {
            msgShow();
            return append;
        }

        /// <summary>
        /// Conjugate the verb
        /// </summary>
        private void ConjugateVerbIn(Verb Verb)
        {
            UpdateVerbInfinitiveExecute();
            UpdateVerbSubjectExecute();
            UpdateVerbInputExecute();
            UpdateVerbEndingExecute();
            CalcVerbEnding(Verb);
            UpdateVerbFinalFormExecute();
        }

        private async void msgShow()
        {
            MessageDialog msg = new MessageDialog("Sorry, that operation is not supported yet!", "Yeah, about that...");
            await msg.ShowAsync();
        }
        #endregion

        #region Commands
        #region Execute
        void UpdateVerbSubjectExecute()
        {
            VerbSubject = string.Format("{0}", _verb.VerbSubject);
        }

        // This might not work
        void UpdateVerbInfinitiveExecute()
        {
            VerbInfinitive = string.Format("{0}", _verb.VerbInfinitive);
        }

        void UpdateVerbInputExecute()
        {
            VerbInput = string.Format("{0}", _verb.VerbInput);
        }

        void UpdateVerbEndingExecute()
        {
            VerbEnding = string.Format("{0}", _verb.VerbEnding);
        }

        void UpdateVerbFinalFormExecute()
        {
            VerbFinalForm = string.Format("{0}", _verb.VerbFinalForm);
        }


        /// <summary>
        /// Conjugate the verb
        /// </summary>
        void ConjugateVerbExecute()
        {
            UpdateVerbInfinitiveExecute();
            UpdateVerbSubjectExecute();
            UpdateVerbInputExecute();
            UpdateVerbEndingExecute();
            CalcVerbEnding(Verb);
            UpdateVerbFinalFormExecute();
        }

        void UpdateSelectedTenseExecute()
        {
            SelectedTense = _currentTense;
        }

        #endregion
        #region CanExecute
        bool CanUpdateVerbSubjectExecute()
        {
            return true;
        }

        bool CanUpdateVerbInfinitiveExecute()
        {
            return true;
        }
        
        bool CanUpdateVerbInputExecute()
        {
            return true;
        }

        bool CanUpdateVerbEndingExecute()
        {
            return true;
        }

        bool CanUpdateVerbFinalFormExecute()
        {
            return true;
        }

        bool CanUpdateVerbTenseExecute()
        {
            return true;
        }

        bool CanConjugateVerbExecute()
        {
            return true;
        }

        bool CanUpdateSelectedTenseExecute()
        {
            return true;
        }
        #endregion
        #region ICommands
        public ICommand UpdateVerbSubject { get { return new RelayCommand(UpdateVerbSubjectExecute, CanUpdateVerbSubjectExecute); } }
        public ICommand UpdateVerbInfinitive { get { return new RelayCommand(UpdateVerbInfinitiveExecute, CanUpdateVerbInfinitiveExecute); } }
        public ICommand UpdateVerbInput { get { return new RelayCommand(UpdateVerbInputExecute, CanUpdateVerbInputExecute); } }
        public ICommand UpdateVerbEnding { get { return new RelayCommand(UpdateVerbEndingExecute, CanUpdateVerbEndingExecute); } }
        public ICommand UpdateVerbFinalForm { get { return new RelayCommand(UpdateVerbFinalFormExecute, CanUpdateVerbFinalFormExecute); } }
        public ICommand ConjugateVerb { get { return new RelayCommand(ConjugateVerbExecute, CanConjugateVerbExecute); } }
        public ICommand UpdateSelectedTense { get { return new RelayCommand(UpdateSelectedTenseExecute, CanUpdateSelectedTenseExecute); } }
        #endregion
        #endregion
    }
}
