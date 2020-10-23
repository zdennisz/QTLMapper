using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QTLProject.Types;

namespace QTLProject
{
    public class DataGeneratorController
    {
        #region Fields
        public GenomeOrganization go = null;

        private int nChr;
        private OrganismType type;
        public Individ mother;
        public Individ father;
        public Individ offSpring;
        public Population pop;

        #endregion Fields
        /*Notes - 
         * DefineChromosomeLength - Should be run first to define the length since the next method assumes that the length was already defined (DefineChromosomePositions).
         * 
         */

        #region Constructor
        /// <summary>
        /// The default nChr is 3 and the organism type is drosophila
        /// </summary>
        /// <param name="_nChr"></param>
        /// <param name="_type"></param>
        public DataGeneratorController(int _nChr = 3, OrganismType _type = OrganismType.Drosophila)
        {
            go = new GenomeOrganization();
            nChr = _nChr;
            type = _type;

        }
        #endregion Constructor

        #region Public Methods

        public void DefineChromosomePositions(double dBetweenMarkers=0.5, long nOnChr=11)
        {
            //go over all chromosome and define the position according to each marker dBetweenMarkers=0.5 . ex: 0 , 0.5, 1.5 ...
            //each chromosome begin at 0 cm the position of loci

            for (int i = 0; i < nChr; i++)
            {

                for (int j = 0; j < nOnChr; j++)
                {

                    Locus loci = new Locus();
                    //default location
                    if (j == 0)
                    {
                        loci.Position.PositionChrGenetic = 0;
                    }
                    else
                    {
                        loci.Position.PositionChrGenetic = loci.Position.PositionChrGenetic+ dBetweenMarkers;
                    }
                  

                    loci.Name = "loc_" + j;
                    loci.Id = i;
                    
                    go.Chromosome[i].Locus.Add(loci);
                }
            }
        }
        /// <summary>
        /// This method defines the length of the chromosomes
        /// </summary>
        public void DefineChromosomeLength()
        {

            switch (type)
            {
                case OrganismType.Drosophila:
                    go = genereateDrosophila(go, nChr);
                    break;


                case OrganismType.PseudoWheat:
                    go = generatePseudoWheat(go, nChr);
                    break;



                default:
                    //error organisim is not supported
                    break;

            }


        }

        /// <summary>
        /// Defines the parental haplotypes according to the recombination type
        /// </summary>
        /// <param name="recType"></param>
        public void DefineParentalHaplotypes(RecombinationType experimentDesign, double strengthOfNoise = 0.2)
        {

            mother = new Individ();
            father = new Individ();
            Random s_Random = new Random();
            switch (experimentDesign)
            {
                case RecombinationType.Backcross:
                    for (int i = 0; i < mother.Haplotype0.Length; i++)
                    {
                        mother.Haplotype0[i] = 0;
                        mother.Haplotype1[i] = 1;
                    }
                    for (int i = 0; i < father.Haplotype0.Length; i++)
                    {
                        father.Haplotype0[i] = 1;
                        father.Haplotype1[i] = 1;
                    }
                    break;

                case RecombinationType.BackcrossWithNoise:

                    for (int i = 0; i < mother.Haplotype0.Length; i++)
                    {

                        if (s_Random.NextDouble() < strengthOfNoise)
                        {
                            mother.Haplotype0[i] = 1;
                        }
                        else
                        {
                            mother.Haplotype0[i] = 0;
                        }

                        if (s_Random.NextDouble() < strengthOfNoise)
                        {
                            mother.Haplotype1[i] = 0;
                        }
                        else
                        {
                            mother.Haplotype1[i] = 1;
                        }

                    }
                    for (int i = 0; i < father.Haplotype0.Length; i++)
                    {
                        if (s_Random.NextDouble() < strengthOfNoise)
                        {
                            father.Haplotype0[i] = 0;
                        }
                        else
                        {
                            father.Haplotype0[i] = 1;
                        }
                        if (s_Random.NextDouble() < strengthOfNoise)
                        {
                            father.Haplotype1[i] = 0;
                        }
                        else
                        {
                            father.Haplotype1[i] = 1;
                        }

                    }


                    break;
            }

        }

        /// <summary>
        /// Simulates the recombination events for the production of the children from two parents
        /// </summary>
        /// <param name="amountOfIndivids"></param>
        public void SimulateRecombination(int amountOfIndivids = 200)
        {
            Random rand = new Random();
            double p, previousPosition, currentPosition = 0.0, l, lambda = (1 / 100);

            //create population of  200 children -individulas
            pop = new Population();
            for (int i = 0; i < amountOfIndivids; i++)
            {
                //the same parents
                Individ offSpring = new Individ();
                offSpring.Parent0 = mother;
                offSpring.Parent1 = father;
                //define recombination events positions H0 haplotyes for children
                for (int j = 0; j < go.Chromosome.Count; j++)
                {
                    //genereate random number P = 0 to 1 
                    p = rand.NextDouble();
                    if (p < 0.5)
                    {
                        //begin with grandmother (copy haplotpes H0)
                        //first recombination happens at coordinate 0
                        offSpring.Genotype[0] = mother.Haplotype0[0];
                    }
                    else
                    {
                        //begin with grandfather(copy haplotpes H1)
                        //first recombination happens at coordinate 0
                        offSpring.Genotype[0] = mother.Haplotype1[0];
                    }
                    previousPosition = 0.0;

                    while (go.Chromosome[j].LenGenetcM > currentPosition)
                    {
                        // l=generate random number with exponantional distribution with lambda = 1/100
                        l = generateRandExponantionalDist(go.Chromosome[j].LenGenetcM, 0, lambda);
                        currentPosition = previousPosition + l;
                        Position pos = new Position();
                        pos.PositionChrGenetic = currentPosition;
                        offSpring.RecEventsParent0.Add(pos);

                        previousPosition = currentPosition;
                    }

                    for(int h = 0; h < offSpring.RecEventsParent0.Count; h++)
                    {
                        offSpring.Genotype[h] = mother.Haplotype0[h];
                    }


                }
                //reset all the values 
                p = 0.0;
                previousPosition = 0.0;
                currentPosition = 0.0;
                l = 0.0;

                //define recombination events positions H1 haplotyes for children
                for (int k = 0; k < go.Chromosome.Count; k++)
                {
                    //genereate random number P = 0 to 1 
                    p = rand.NextDouble();
                    if (p < 0.5)
                    {
                        //begin with grandmother (copy haplotpes H0)
                        //first recombination happens at coordinate 0
                        offSpring.Genotype[0] = father.Haplotype0[0];
                        
                    }
                    else
                    {
                        //begin with grandfather(copy haplotpes H1)
                        //first recombination happens at coordinate 0
                        offSpring.Genotype[0] = father.Haplotype1[0];
                    }
                    previousPosition = 0.0;

                    while (go.Chromosome[k].LenGenetcM > currentPosition)
                    {
                        // l=generate random number with exponantional distribution with lambda = 1/100
                        l = generateRandExponantionalDist(go.Chromosome[k].LenGenetcM, 0, lambda);
                        currentPosition = previousPosition + l;
                        Position pos = new Position();
                        pos.PositionChrGenetic = currentPosition;
                        offSpring.RecEventsParent1.Add(pos);

                        previousPosition = currentPosition;
                    }

                    

                    for (int h = 0; h < offSpring.RecEventsParent1.Count; h++)
                    {
                        offSpring.Genotype[h] = father.Haplotype1[h];
                    }

                    pop.Individ.Add(offSpring);

                }

            }
        }


        #endregion Public Methods

        #region Private Methods
        /// <summary>
        /// Generate a random value within max and min boundrys with an exponential distibution
        /// </summary>
        /// <param name="maxValue"></param>
        /// <param name="minValue"></param>
        /// <param name="lambda"></param>
        /// <returns></returns>
        private double generateRandExponantionalDist(double maxValue,double minValue,double lambda)
        {
            Random rand = new Random();
            double u,t, increment, res=0.0 ;
            double result = maxValue;
            do
            {
                 u = rand.NextDouble();
                 t = -Math.Log(u) / lambda;
                 increment =
                  (maxValue - minValue) / 6.0;
                result = minValue + (t * increment);
            } while (result >= maxValue);

            return res;
        }

        private GenomeOrganization genereateDrosophila(GenomeOrganization go, int nChr)
        {
            double coef = 1;
            int drosophilaConst1 = 75, drosophilaConst2 = 107, drosophilaConst3 = 110;
            Chromosome ch = new Chromosome
            {
                Id = 0,
                Name = "1",
                LenGenetcM = drosophilaConst1 * coef,
                BRecInFemales = true,
                BGender = false
            };

            go.Chromosome.Add(ch);

            Chromosome ch1 = new Chromosome
            {
                Id = 1,
                Name = "2",
                LenGenetcM = drosophilaConst2 * coef,
                BRecInFemales = true,
                BGender = false
            };

            go.Chromosome.Add(ch1);

            Chromosome ch2 = new Chromosome
            {
                Id = 2,
                Name = "3",
                LenGenetcM = drosophilaConst3 * coef,
                BRecInFemales = true,
                BGender = false
            };

            go.Chromosome.Add(ch2);



            return go;
        }


        private GenomeOrganization generatePseudoWheat(GenomeOrganization go, int nChr)
        {



            return go;
        }
        #endregion Private Methods
    }

}
