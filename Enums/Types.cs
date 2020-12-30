using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QTLProject
{
    public static class Types
    {
        /// <summary>
        ///  Complete dominance, Incomplete dominance, and Codominance
        /// 0 - allele 0 is dominant, 1 - allele 1 is dominant, 2 - codominant
        /// </summary>
        public enum LocusDominanceStatus
        {
          CompleteDominance=0,
          IncompleteDominance=1,
          Codominant=2
        }

        //0   - Allele 1 is recessive
        //1   - Allele 1 is dominant
        //0.5 - Allele 1 is codominant
        public static class AdditiveEffect_h 
        {
            public const double Recessive = 0.0;
            public const double Codominant = 0.5;
            public const double Dominant = 1.0;

        }

        /// <summary>
        /// Gender : 0 - Female, 1 - Male
        /// </summary>
        public enum Gender
        {
            Female=0,
            Male=1
        }
        /// <summary>
        ///MappingFunctionIndex  0=Haldane (independent recombinations), 1=Kossambi
        /// </summary>
        public enum MappingIndex
        {
            Haldane = 0,
            Kossambi=1
        }

        public enum OrganismType
        {
            Drosophila=1,
            PseudoWheat=2,
            Random=3
        }

        public enum RecombinationType
        {
            Backcross=0,
            BackcrossWithNoise=1
        }

        public enum SoftwareStep
        {
            None = 0,
            InputData =1,
            CalculateData=2,
            SimulateData=3,
            ViewResults=4,
            
        }

        public enum QTLTaritModels
        {
            NoQTL=0,
            OneQTL=1,
            OneDominantQTL=2,
            TwoLinkedQTL=3,
        }

        public enum TableRowType
        {
            InputDataRow=0,
            GeneticDataRow=1
        }

        public enum ErrorMessage
        {
            MissingPhenotype=0,
            MissingGenotype=1,
            BadGeneticMap=2,
            NoDataLoaded=3
        }

        public class State
        {
            private SoftwareStep currentStep;
            private SoftwareStep prevoiusStep;
            private bool goingForward = false;
         
            
            public event EventHandler<StateUpdate> StateChange;

            public void UpdateState(SoftwareStep nextStep, SoftwareStep prevStep,bool goingForward)
            {
                StateUpdate args = new StateUpdate();
                args.PrevoiusStep = prevStep;
                args.CurrentStep = nextStep;
                args.GoingForward = goingForward;
                OnStateChange(args);
            }
            public virtual void OnStateChange(StateUpdate e)
            {
                StateChange?.Invoke(this, e);
            }

           
            public class StateUpdate : EventArgs
            {
                public SoftwareStep CurrentStep { get; set; }
                public SoftwareStep PrevoiusStep { get; set; }
                public bool GoingForward { get; set; }
            }  
        }
        
        //public class ListOfValuesWithNA{
        //    
        //}


    }
    }
