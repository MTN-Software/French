using System;
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
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;

namespace French_Conjugations
{
    /// <summary>
    /// The Verb View Model
    /// </summary>
    public class VerbViewModel : ObservableObject
    {
        //TODO: Refactor

        #region Construction
        /// <summary>
        /// Constructs the default instance of the view model
        /// </summary>
        public VerbViewModel()
        {
            _verb = new Verb
            {
                VerbInfinitive = "Verb",
                VerbSubject = "Enter",
                VerbInput = "Enter Verb",
                VerbEnding = "unknown",
                VerbFinalForm = "unkown"
            };

            _sTenses = new List<string>();
            for (int i = 0; i < 6; i++)
            {
                _sTenses.Add(_database[i]);
            }

            _irregular = new Irregular();

            _EtreHelpingVerbs = new List<string>();
            foreach (var item in _etreInPC)
            {
                _EtreHelpingVerbs.Add(item);
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
        List<string> _EtreHelpingVerbs;
        private readonly NavigationHelper navigationHelper;     // why is this even here?
        Irregular _irregular;

        // Note to self: would using lists instead of primitive arrays be cleaner?

        // verbs that use etre in the passe compose
        string[] _etreInPC = {"devenir", "revenir", "monter", "rester", "sortir", "passer", "venir", 
                            "aller", "naître", "descendre", "entrer", "retourner","tomber", "rentrer",
                            "arriver", "mourir", "partir", "décéder"};

        // verbs that are conjugated irregularly in PC
        string[] _irregInPC = {"acquérir", "apprendre", "atteindre", "attendre", "avoir", "battre", 
                                "boire", "comprendre", "conduire", "connaître", "construire", "courir", 
                                "couvrir", "craindre", "croire", "décevoir", "découvrir", "devoir", "dire", 
                                "écrire", "être", "faire", "fondre", "instruire", "joindre", "lire", "mettre", 
                                "offrir", "ouvrir", "paraître", "peindre", "pouvoir", "prendre", "produire", 
                                "recevoir", "savoir", "souffrir", "surprendre", "suivre", "tenir", 
                                "venir", "vivre", "voir", "vouloir"};

        // corresponding conjugations
        string[] _irregPCConj = {"acquis", "appris", "atteint", "attendu", "eu", "battu", "bu", "compris", 
                                "conduit", "connu", "construit", "couru", "couvert", "craint", "cru", "déçu", 
                                "découvert", "dû", "dit", "écrit", "été", "fait", "fondu", "instruit", "joint", 
                                "lu", "mis", "offert", "ouvert", "paru", "peint", "pu", "pris", "produit", 
                                "reçu", "su", "souffert", "surpris", "suivi", "tenu", "venu", "vécu", "vu", 
                                "voulu" };

        // avoir conjugations
        string[] _avoir = { "ai", "as", "a", "avons", "avez", "ont" };

        // etre conjugations
        string etre = "être";   // never used, why is it here? Also, I don't recall if there is any reason why it is not declared constant
        string[] _etre = { "suis", "es", "est", "sommes", "êtes", "sont"};

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
                    // Shouldn't this be in the getter? why compute this when you set the string?
                    // Conjugation Logic
                    string root = Verb.VerbInfinitive.Substring(0, Verb.VerbInfinitive.Length - 2);
                    string helping = string.Empty;
                    string append = string.Empty;
                    string carryOutVerb = string.Empty;
                    string replaceInf = string.Empty;
                    switch (SelectTense)
                    {
                        case "Present":
                            PresentConj(ref append);
                            break;
                        case "Passé composé":
                            replaceInf = PasseConj(root).Item1;
                            helping = PasseConj(root).Item2;
                            break;
                        case "Imperfect":
                            replaceInf = ImperfectConj(Verb.VerbEnding.ToLower());
                            break;
                        case "Futur Proche":
                            ProcheConj(ref helping);
                            root = Verb.VerbInfinitive;
                            append = string.Empty;
                            break;
                        case "Futur Simple":
                            FuturSimpleConj(ref append);   
                            carryOutVerb = string.Concat(Verb.VerbSubject, " ", Verb.VerbInfinitive, append);
                            break;
                        case "Conditional":
                            ConditionalConj(ref append);
                            carryOutVerb = string.Concat(Verb.VerbSubject, " ", Verb.VerbInfinitive, append);
                            break;
                        default:
                            PresentConj(ref append);
                            break;
                    }

                    if (carryOutVerb == string.Empty)       // sets carryOutVerb's value if not already set
                    {
                        if (helping == string.Empty)        // if there isn't any helping verb
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
                        else                                // if there is a helping verb
                        {
                            if (replaceInf == string.Empty)
                            {
                                carryOutVerb = string.Concat(Verb.VerbSubject, " ", helping, root, append);
                            }
                            else
                            {
                                carryOutVerb = string.Concat(Verb.VerbSubject, " ", helping, " ", replaceInf);
                            }
                        }
                    }
                    Verb.VerbFinalForm = carryOutVerb;
                    RaisePropertyChanged("VerbFinalForm");
                }
                catch (Exception ex)
                {
                    msgBox(ex.Message, "Well, this isn't good");
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
                    //QuickConjugate();
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
        /// <obsolete/>
        [Deprecated("French Conjugator will no longer use this method because it breaks the UX", DeprecationType.Remove, 100859904)]
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
        private void PresentConj(ref string append)
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
        }

        /// <summary>
        /// Conjugates the input to match the passe compose form
        /// </summary>
        /// <param name="infinitive"></param>
        /// <returns></returns>
        private Tuple<string, string> PasseConj(string infinitive)
        {
            string newRoot = string.Empty;
            string append = string.Empty;
            string helping = string.Empty;
            string input = Verb.VerbInfinitive;

            bool isEtreIrreg = false;       // default value is false
            bool isVerbIrreg = false;       // default value is false
            

            for(int _index = 0; _index < _etreInPC.Length; _index++)
            {
                if (input == _etreInPC[_index])
                {
                    isEtreIrreg = true;
                    break;
                }

            }

            for (int _index = 0; _index < _irregInPC.Length; _index++)
            {
                if (input == _irregInPC[_index])
                {
                    isVerbIrreg = true;
                    newRoot = _irregPCConj[_index];
                    break;
                }
            }

            string[] helpingVerb = isEtreIrreg ? _etre : _avoir;
            Verb backupVerb = Verb;                                             // backs up the original verb
            string tempSub = Verb.VerbSubject;                                  // backs up the original verb subject (doesn't work w/o this, don't know why)
            Verb tempVerb = Verb;                                               // creates clone of the Verb
            tempVerb.VerbSubject = "je";                                        // changes subject to "je"
            tempVerb.VerbInput = "je " + Verb.VerbInfinitive;                   // changes input to "je " + the input infinitive
            SelectTense = "Present";                                            // changes tense to present 
            ConjugateVerbIn(tempVerb);                                          // conjugates tempVerb
            int indexOfSpace = tempVerb.VerbFinalForm.IndexOf(' ');             // gets position of ' ' in string tempVerb.FinalForm
            // creates a variable to store the returned conjugated verb to be used in later conjugation
            string tempInf = tempVerb.VerbFinalForm.Substring(indexOfSpace + 1, tempVerb.VerbFinalForm.Length - (indexOfSpace + 1));
            string tempRoot;
            switch (Verb.VerbEnding)
            {
                case "er":
                    tempRoot = tempInf.Substring(0, tempInf.LastIndexOf("e"));       // extracts root of conjugated verb
                    break;
                case "re":
                    tempRoot = tempInf.Substring(0, tempInf.LastIndexOf("s"));       // extracts root of conjugated verb
                    break;
                case "ir":
                    tempRoot = tempInf.Substring(0, tempInf.LastIndexOf("is"));       // extracts root of conjugated verb
                    break;
                default:
                    tempRoot = "err";                                                   // short for error? this should never happen
                    break;
            }
            
            SelectTense = "Passé composé";                                      // resets tense to infinitive
            tempVerb.VerbSubject = tempSub;                                     // resets subject to the orinial subject
            Verb = backupVerb;                                                  // restores verb
            switch (Verb.VerbEnding)
            {
                case "er":
                    // Damn nested switch statements! // Fix this
                    switch (Verb.VerbSubject.ToLower())
                    {
                        case "je":
                            append = "é";
                            helping = helpingVerb[0];
                            break;
                        case "tu":
                            append = "é";
                            helping = helpingVerb[1];
                            break;
                        case "il":  
                        case "on":
                            append = "é";
                            helping = helpingVerb[2];
                            break;
                        case "elle":
                            append = "ée";
                            helping = helpingVerb[2];
                            break;
                        case "nous":
                            append = "é(e)s";
                            helping = helpingVerb[3];
                            break;
                        case "vous":
                            append = "é(e)(s)";
                            helping = helpingVerb[4];
                            break;
                        case "ils":
                            append = "és";
                            helping = helpingVerb[5];
                            break;
                        case "elles":
                            append = "ées";
                            helping = helpingVerb[5];
                            break;
                        default:
                            break;
                    }
                    break;
                case "re":
                    // Foiled again by these nested switch statements! // Fix this.
                    switch (Verb.VerbSubject.ToLower())
                    {
                        case "je":
                            helping = helpingVerb[0];
                            break;
                        case "tu":
                            helping = helpingVerb[1];
                            break;
                        case "il":
                        case "elle":
                        case "on":
                            helping = helpingVerb[2];
                            break;
                        case "nous":
                            helping = helpingVerb[3];
                            break;
                        case "vous":
                            helping = helpingVerb[4];
                            break;
                        case "ils":
                        case "elles":
                            helping = helpingVerb[5];
                            break;
                        default:
                            break;
                    }
                    append = "u";
                    break;
                case "ir":
                    // Okay, this is going to come back to bite me in the ass later if I don't fix this... // So fix it.
                    switch (Verb.VerbSubject.ToLower())
                    {
                        case "je":
                            helping = helpingVerb[0];
                            break;
                        case "tu":
                            helping = helpingVerb[1];
                            break;
                        case "il":
                        case "elle":
                        case "on":
                            helping = helpingVerb[2];
                            break;
                        case "nous":
                            helping = helpingVerb[3];
                            break;
                        case "vous":
                            helping = helpingVerb[4];
                            break;
                        case "ils":
                        case "elles":
                            helping = helpingVerb[5];
                            break;
                        default:
                            break;
                    }
                    append = "i";
                    break;
                default:
                    break;
            }

            if (isVerbIrreg)
            {
                tempRoot = newRoot;
                append = string.Empty;
            }
            string strRet = string.Concat(tempRoot, append);
            var ret = Tuple.Create(strRet, helping);
            return ret;
        }

        /// <summary>
        /// Conjugates the input to match the imperfect past form
        /// </summary>
        /// <remarks>
        /// Has some bugs that could use fixing.
        /// Guess you could say this method is... Imperfect
        /// </remarks>
        /// <param name="append"> </param>
        /// <returns></returns>
        private string ImperfectConj(string infinitive)
        {
            string tempSub = Verb.VerbSubject;                                  // backs up the original verb subject
            Verb backupVerb = Verb;                                             // back up the original verb
            Verb tempVerb = Verb;                                               // creates clone of the Verb
            tempVerb.VerbSubject = "nous";                                      // changes subject to "nous"
            tempVerb.VerbInput = "nous " + Verb.VerbInfinitive;                 // changes input to "nous " + the input infinitive
            SelectTense = "Present";                                            // changes tense to present 
            ConjugateVerbIn(tempVerb);                                          // conjugates tempVerb
            int indexOfSpace = tempVerb.VerbFinalForm.IndexOf(' ');             // gets position of ' ' in string tempVerb.FinalForm
            // creates a variable to store the returned conjugated verb to be used in later conjugation
            string tempInf = tempVerb.VerbFinalForm.Substring(indexOfSpace + 1, tempVerb.VerbFinalForm.Length - (indexOfSpace + 1));
            string tempRoot = tempInf.Substring(0, tempInf.IndexOf("ons"));     // extracts root of conjugated verb
            SelectTense = "Imperfect";                                          // resets tense to infinitive
            tempVerb.VerbSubject = tempSub;                                     // resets subject to the orinial subject
            string append;                                                      // create string append
            Verb = backupVerb;
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
        /// <param name="helper"></param>
        /// <returns>what to append</returns>
        private void ProcheConj(ref string helper)
        {
            switch (Verb.VerbSubject.ToLower())
            {
                case "je":
                    helper = "vais";
                    break;
                case "tu":
                    helper = "vas";
                    break;
                case "il":
                case "elle":
                case "on":
                    helper = "va";
                    break;
                case "nous":
                    helper = "allons";
                    break;
                case "vous":
                    helper = "allez";
                    break;
                case "ils":
                case "elles":
                    helper = "vont";
                    break;
                default:
                    helper = "";
                    break;
            }
        }

        private void FuturSimpleConj(ref string append)
        {
            //msgShow();
            switch (Verb.VerbSubject.ToLower())
            {
                case "je":
                    append = "ai";
                    break;
                case "tu":
                    append = "as";
                    break;
                case "il":
                case "elle":
                case "on":
                    append = "a";
                    break;
                case "nous":
                    append = "avons";
                    break;
                case "vous":
                    append = "avez";
                    break;
                case "ils":
                case "elles":
                    append = "ont";
                    break;
                default:
                    break;
            }
            //return append;
        }

        private void ConditionalConj(ref string append)
        {

            // sets the append variable to a conditional verb ending
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

            //return append;
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

        /// <summary>
        /// If a feature is not yet fully implemented, use this as a band-aid to cover.
        /// </summary>
        /// <remarks>
        /// Use as sparingly as possible
        /// </remarks>
        private async void msgShow()
        {
            MessageDialog msg = new MessageDialog("Sorry, that operation is not supported yet!", "Yeah, about that...");
            await msg.ShowAsync();
        }

        /// <summary>
        /// Custom Message box
        /// </summary>
        /// <param name="message">The message you want to display</param>
        /// <param name="title">The title of the Message box</param>
        private async void msgBox(string message, string title)
        {
            MessageDialog msg = new MessageDialog(message, title);
            await msg.ShowAsync();
        }
        #endregion

        #region Commands
        #region Execute
        void UpdateVerbSubjectExecute() => VerbSubject = string.Format("{0}", _verb.VerbSubject);

        // This might not work
        void UpdateVerbInfinitiveExecute() => VerbInfinitive = string.Format("{0}", _verb.VerbInfinitive);

        void UpdateVerbInputExecute() => VerbInput = string.Format("{0}", _verb.VerbInput);

        void UpdateVerbEndingExecute() => VerbEnding = string.Format("{0}", _verb.VerbEnding);

        void UpdateVerbFinalFormExecute() => VerbFinalForm = string.Format("{0}", _verb.VerbFinalForm);

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

        void UpdateSelectedTenseExecute() => SelectedTense = _currentTense;

        #endregion
        #region CanExecute
        //Whats the point of having all of these methods if all they do is return true?

        bool CanUpdateVerbSubjectExecute() => true;

        bool CanUpdateVerbInfinitiveExecute() => true;

        bool CanUpdateVerbInputExecute() => true;

        bool CanUpdateVerbEndingExecute() => true;

        bool CanUpdateVerbFinalFormExecute() => true;

        bool CanUpdateVerbTenseExecute() => true;

        bool CanConjugateVerbExecute() => true;

        bool CanUpdateSelectedTenseExecute() => true;
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
