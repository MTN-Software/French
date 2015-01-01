using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Threading.Tasks;

namespace French_Conjugations
{
    public class VerbViewModel : ObservableCollection<int>, INotifyPropertyChanged 
    {
        #region Construction
        /// <summary>
        /// Constructs the default instance of the view model
        /// </summary>
        public VerbViewModel()
        {
            _verb = new Verb { VerbInfinitive = "Verb", VerbSubject = "Enter",
                VerbInput = "Enter Verb", VerbEnding = "unknown",
                VerbFinalForm = "unkown", VerbTense = 0,
                };

            for (int i = 0; i < 4; i++)
            {
                _verb.VerbCurrentTense.Add(i);
            }
        }
        #endregion

        #region Members
        Verb _verb;
        
        #endregion

        #region Properties
        public Verb Verb
        {
            get
            { return _verb; }
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
                    Verb.VerbInfinitive = VerbInput.Substring(indexOfSpace, Verb.VerbInput.Length - indexOfSpace);
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
        public int VerbTense
        {
            get { return Verb.VerbTense; }
            set
            {
                try
                {
                    // TODO: Add verb tense logic
                    RaisePropertyChanged("VerbTense");
                }
                catch (Exception ex)
                {
                    RaisePropertyChanged("VerbTense");
                }
            }
        }

        public string[] VerbListTense
        {
            get { return Verb.VerbTenseArray; }
            set
            {
                try
                {
                    RaisePropertyChanged("VerbListTense");
                }
                catch (Exception ex)
                {
                    RaisePropertyChanged("VerbListTense");
                }
            }
        }

        private ObservableCollection<int> verbCurrentTense = new ObservableCollection<int>();
        public ObservableCollection<int> VerbCurrentTense
        {
            get { return Verb.VerbCurrentTense; }
            set
            {
                try
                {
                    Verb.VerbCurrentTense = value;
                    RaisePropertyChanged("VerbCurrentTense");
                }
                catch (Exception ex)
                {
                    RaisePropertyChanged("VerbCurrentTense");
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

                    switch (Verb.VerbTense)
                    {
                        case 0:
                            append = PresentConj(append);
                            break;
                        case 1:
                            append = PasseConj(append);
                            break;
                        case 2:
                            append = ImperfectConj(append);
                            break;
                        case 3:
                            helping = ProcheConj(append);
                            root = Verb.VerbInfinitive;
                            append = string.Empty;
                            break;
                        case 4:
                            append = FuturSimpleConj(append);
                            break;
                        case 5:
                            append = ConditionalConj(append);
                            break;
                        default:
                            append = PresentConj(append);
                            break;
                    }

                    if (helping == string.Empty)
                    {
                        carryOutVerb = string.Concat(Verb.VerbSubject, " ", root, append);
                    }
                    else
                    {
                        carryOutVerb = string.Concat(Verb.VerbSubject, " ", helping, " ", root, append);
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
                    QuickConjugate();
                }
            }
        }

        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        private void RaisePropertyChanged(string propertyName)
        {
            // take a copy to prevent thread issues
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string CalcVerbEnding(Verb Verb)
        {
            int length = Verb.VerbInput.Length;
            return Verb.VerbInput.Substring(length - 2, 2);
        }

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

        private string PasseConj(string append)
        {
            return append;
        }

        private string ImperfectConj(string append)
        {
            return append;
        }

        private string ProcheConj(string append)
        {
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
            return append;
        }

        private string ConditionalConj(string append)
        {
            return append;
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

        void UpdateVerbTenseExecute()
        {
            VerbTense = _verb.VerbTense;
            VerbCurrentTense = _verb.VerbCurrentTense;
        }

        // All this does now is update the properties
        void ConjugateVerbExecute()
        {
            UpdateVerbInfinitiveExecute();
            UpdateVerbSubjectExecute();
            UpdateVerbInputExecute();
            UpdateVerbEndingExecute();
            UpdateVerbTenseExecute();
            CalcVerbEnding(Verb);
            UpdateVerbFinalFormExecute();
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
        #endregion
        #region ICommands
        public ICommand UpdateVerbSubject { get { return new RelayCommand(UpdateVerbSubjectExecute, CanUpdateVerbSubjectExecute); } }
        public ICommand UpdateVerbInfinitive { get { return new RelayCommand(UpdateVerbInfinitiveExecute, CanUpdateVerbInfinitiveExecute); } }
        public ICommand UpdateVerbInput { get { return new RelayCommand(UpdateVerbInputExecute, CanUpdateVerbInputExecute); } }
        public ICommand UpdateVerbEnding { get { return new RelayCommand(UpdateVerbEndingExecute, CanUpdateVerbEndingExecute); } }
        public ICommand UpdateVerbFinalForm { get { return new RelayCommand(UpdateVerbFinalFormExecute, CanUpdateVerbFinalFormExecute); } }
        public ICommand UpdateVerbTense { get { return new RelayCommand(UpdateVerbTenseExecute, CanUpdateVerbTenseExecute); } }
        public ICommand ConjugateVerb { get { return new RelayCommand(ConjugateVerbExecute, CanConjugateVerbExecute); } }
        #endregion
        #endregion
    }
}
