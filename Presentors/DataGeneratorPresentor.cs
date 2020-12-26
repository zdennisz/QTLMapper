using CenterSpace.NMath.Core;
using QTLProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static QTLProject.Types;

namespace QTLProject
{
    public class DataGeneratorPresentor
    {
        #region Fields
        public GenomeOrganization go = null;

        private int nChr;
        private OrganismType type;
        public Individ mother;
        public Individ father;
        public Individ offSpring;
        public Population pop;
        private Database database;
        private List<Dictionary<int, string>> rawGeneticData;

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
        public DataGeneratorPresentor(int _nChr = 3, OrganismType _type = OrganismType.Drosophila)
        {
            go = new GenomeOrganization();
            nChr = _nChr;
            type = _type;
            database = DatabaseProvider.GetDatabase();
            database.GenomeOrganization = go;

        }
        public DataGeneratorPresentor(int _nChr = 3, OrganismType _type = OrganismType.Drosophila, List<Dictionary<int, string>> data = null) :
            this(_nChr, _type)
        {
            rawGeneticData = data;
        }
        #endregion Constructor

        #region Public Methods

        public void DefineChromosomePositions(double dBetweenMarkers = 0.5, long numberOfLocii = 11)
        {
            List<int> numberOfLoci=null;
            //go over all chromosome and define the position according to each marker dBetweenMarkers=0.5 . ex: 0 , 0.5, 1.5 ...
            //each chromosome begin at 0 cm the position of loci
            if (OrganismType.Random == this.type)
            {
                numberOfLoci = new List<int>();
                foreach (Dictionary<int, string> dic in rawGeneticData)
                {
                    numberOfLoci.Add(Convert.ToInt32(dic[2]));
                }
            }

            int idLocus = 0;
            for (int iChr = 0; iChr < nChr; iChr++)
            {
                if (OrganismType.Random == this.type)
                {
                    numberOfLocii = numberOfLoci[iChr];
                }
                double posPrev = -0.5;
                for (int jOnChr = 0; jOnChr < numberOfLocii; jOnChr++)
                {
                    if (posPrev < go.Chromosome[iChr].LenGenetcM)
                    {
                        Position pos = new Position();
                        pos.Chromosome = go.Chromosome[iChr];
                        pos.PositionChrGenetic = posPrev;
                        pos.PositionChrGenetic += dBetweenMarkers;
                        posPrev = pos.PositionChrGenetic;
                        Locus locus = new Locus(jOnChr, pos);
                        idLocus++;
                        locus.Id = idLocus;
                        go.Chromosome[iChr].Locus.Add(locus);

                    }
                }

            }
        }

        /// <summary>
        /// This method defines the length of the chromosomes
        /// difine global parameters:
        ///    go=Genome organisation
        ///    nChr=number of chromosoms
        /// </summary>
        public void DefineChromosomeLength()
        {
            go.Chromosome = new List<Chromosome>();
            switch (type)
            {
                case OrganismType.Drosophila:
                    go = genereateDrosophila(go, nChr);
                    break;
                default:
                    go = randomOrganism(go, nChr);
                    break;
            }
        }

        /// <summary>
        /// Defines the parental haplotypes according to the recombination type
        /// </summary>
        /// <param name="recType"></param>
        public void DefineParentalHaplotypes(RecombinationType experimentDesign = RecombinationType.Backcross, double strengthOfNoise = 0.2)
        {
            /*
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
            */
        }

        //dRec=expectation of number of recombination events in the interval (1 cM=0.01 recombination event)
        //Independent recombination or start from he begin of chromosome => exponential distribution of distance to the next recombination
        //E{exp(lambda)}=1/lambda=100 cM => lambda=1/100
        //density: p(x)=lambda e^{- lambda*x}
        //comulative distribution function: P(x)=P(exp(lambda)<x)=1 - e^{- lambda*x} ~ U[0,1] => e^{- lambda*x}=1-U[0,1] => - lambda*x=ln(1-U[0,1]) => x=(-1/lambda)*ln(1-U[0,1]) = -100*ln(1-U[0,1])  

        /// <summary>
        /// Simulates the recombination events for the production of the children from two parents
        /// </summary>
        /// <param name="amountOfIndivids"></param>
        public void SimulateRecombination(int amountOfIndivids = 200)
        {
            Random rand = new Random();
            double p, previousPosition, currentPosition = 0.0, l, lambda = 0.01;

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
                        Position pos = new Position();
                        pos.Chromosome = go.Chromosome[j];
                        pos.PositionChrGenetic = 0.0;
                        offSpring.RecEventsParent0.Add(pos);
                    }
                    previousPosition = 0.0;

                    while (go.Chromosome[j].LenGenetcM > currentPosition)
                    {
                        // l=generate random number with exponantional distribution with lambda = 1/100
                        l = generateRandExponantionalDist(go.Chromosome[j].LenGenetcM, 0, lambda);
                        currentPosition = previousPosition + l;
                        Position pos = new Position();
                        pos.Chromosome = go.Chromosome[j];
                        pos.PositionChrGenetic = currentPosition;
                        offSpring.RecEventsParent0.Add(pos);

                        previousPosition = currentPosition;
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
                        Position pos = new Position();
                        pos.Chromosome = go.Chromosome[k];
                        pos.PositionChrGenetic = 0.0;
                        offSpring.RecEventsParent1.Add(pos);

                    }
                    previousPosition = 0.0;

                    while (go.Chromosome[k].LenGenetcM > currentPosition)
                    {
                        // l=generate random number with exponantional distribution with lambda = 1/100
                        l = generateRandExponantionalDist(go.Chromosome[k].LenGenetcM, 0, lambda);
                        currentPosition = previousPosition + l;
                        Position pos = new Position();
                        pos.Chromosome = go.Chromosome[k];
                        pos.PositionChrGenetic = currentPosition;
                        offSpring.RecEventsParent1.Add(pos);

                        previousPosition = currentPosition;
                    }

                }
                pop.Individ.Add(offSpring);

            }
        }
        public void allelInheritance()
        {
            /*
            for (int g = 0; g < offSpring.RecEventsParent0.Count; g++)
            {
                Locus locusOfRecombination = new Locus();
                Position positionOfRecombination = new Position();
                positionOfRecombination = offSpring.RecEventsParent0[g];
                locusOfRecombination.Position = positionOfRecombination;
                offSpring.LocusKnownHaplotype.Add(locusOfRecombination);
            }


            for (int r = 0; r < offSpring.RecEventsParent1.Count; r++)
            {

                Locus locusOfRecombination = new Locus();
                Position positionOfRecombination = new Position();
                positionOfRecombination = offSpring.RecEventsParent1[r];
                locusOfRecombination.Position = positionOfRecombination;
                offSpring.LocusKnownHaplotype.Add(locusOfRecombination);
            }
        */
        }

        public void DefineQTL()
        {
            /*
             Calculate the children (population) traits and children qtl genotypes
              according to the position on the map the effects and parents alleles.
                 positions on map:
                 QTL1:  Chromosome 1, x=30 cM
                 QTL2:  Chromosome 1, x=70 cM
                 QTL3:  Chromosome 3, x=40 cM
                 effect on trait: Example: single trait:
                 QTL1: d=1, h=1
                 QTL2: d=0.8, h=1
                 QTL3: d=0.4, h=1
                 sigma^2=1 

             In simple case, QTL genotypes of parents are
             QTL                mother     father
             haplotype        h0   h1    h0   h1
             QTL1                0    1       1     1
             QTL2                0    1       1     1
             QTL3                0    1       1     1

             QTL genotypes of children are defined based on the same position of recombination events (analogiously to genotypes of markers)
             Children traits are random values with normal distribution with average T and variance sigma^2, where T is defined by genotypes in QTL loci. 
             Example:
            
            
             */

            foreach (Individ offspring in pop.Individ)
            {
                //create array of this procedure
                QTL_SingleLocusEffectOnSingleTrait effectOfQ1 = new QTL_SingleLocusEffectOnSingleTrait();
                effectOfQ1.AdditiveEffect_d = 1;
                effectOfQ1.AdditiveEffect_h = AdditiveEffect_h.Dominant;

                QTL_SingleLocusEffectOnSingleTrait effectOfQ2 = new QTL_SingleLocusEffectOnSingleTrait();
                effectOfQ2.AdditiveEffect_d = 0.8;
                effectOfQ2.AdditiveEffect_h = AdditiveEffect_h.Dominant;

                QTL_SingleLocusEffectOnSingleTrait effectOfQ3 = new QTL_SingleLocusEffectOnSingleTrait();
                effectOfQ3.AdditiveEffect_d = 0.4;
                effectOfQ3.AdditiveEffect_h = AdditiveEffect_h.Dominant;
                /*
                // 0  T(father)=2*d1+2*d2+2*d3=2*1+2*0.8+2*0.4
                offspring.TraitValue[0]= (float)(2 * effectOfQ1.AdditiveEffect_d + 2 * effectOfQ2.AdditiveEffect_d + 2 * effectOfQ3.AdditiveEffect_d);
                // 1  T(mother)=h1*d1+h2*d2+h3*d3=1*1+1*0.8+1*0.4
                offspring.TraitValue[1] = (float)(effectOfQ1.AdditiveEffect_d * effectOfQ1.AdditiveEffect_h + effectOfQ2.AdditiveEffect_d * effectOfQ2.AdditiveEffect_h + effectOfQ3.AdditiveEffect_d * effectOfQ3.AdditiveEffect_h);
                */
                //define the genotype of children - which is the combinations of all genes at a particular locus
                //for(int i=0;i<offspring.Genotype.Length;i++)
                // {
                //     int locationOfRecomb;
                //     for (int g = 0; g < offspring.RecEventsParent0.Count; g++)
                //     {
                //         locationOfRecomb = (int)offspring.RecEventsParent0[g].PositionChrGenetic;
                //         if (locationOfRecomb < offspring.Genotype.Length)
                //         {
                //             offspring.Genotype[i] = mother.Haplotype0[g];
                //         }

                //     }


                //     for (int r = 0; r < offspring.RecEventsParent1.Count; r++)
                //     {
                //         locationOfRecomb = (int)(offSpring.RecEventsParent1[r].PositionChrGenetic);
                //         if (locationOfRecomb < offspring.Genotype.Length)
                //         {
                //             offspring.Genotype[i] = mother.Haplotype1[r];
                //         }
                //     }
                // }
            }

        }
        /// <summary>
        /// Save the genotype to file 
        /// </summary>
        /// <param name="path"></param>
        public bool SaveGeneticMap(string path)
        {
            Database db = DatabaseProvider.GetDatabase();
            string header = "marker" + "\t" + "LG" + "\t" + "coorOnLG";
            string chNum = "";
            using (var writer = new StreamWriter(path))
            {

                writer.WriteLine(header);

                foreach (Chromosome ch in db.GenomeOrganization.Chromosome)
                {
                    chNum = "LG" + ch.Id;
                    foreach (Locus l in ch.Locus)
                    {
                        writer.WriteLine(l.Name + "\t" + chNum + "\t" + l.Position.PositionChrGenetic);
                    }
                }

            }
            return true;
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
        private double generateRandExponantionalDist(double maxValue, double minValue, double lambda)
        {
            Random rand = new Random();
            double res = 0.0;
            var exponentionalDIst = new RandomNumberGenerator.UniformRandomNumber(rand.NextDouble);
            var expRand = new RandGenExponential(lambda);
            do
            {
                res = expRand.NextDouble();
            } while (res > maxValue && res > minValue);

            return res;
        }

        private GenomeOrganization genereateDrosophila(GenomeOrganization go, int nChr)
        {
            //see https://en.wikipedia.org/wiki/Drosophila_melanogaster
            //we consider only siple case (like in human): 
            //    diploid, 
            //    first chromosome is X (male has only one, he has also Y), 
            //    no recombination in males, 
            //    three chromosomes: X, 2, 3 (short fouth is ignored)
            //indeed, drosophyla can be triploid and tetraploid (with XXX and XXXX (may also 1 or more Y) for females; X and XX)
            double coef = 1;
            int drosophilaConst1 = 75, drosophilaConst2 = 107, drosophilaConst3 = 110;
            Chromosome ch = new Chromosome
            {
                Name = "1",
                LenGenetcM = drosophilaConst1 * coef,
                BRecInFemales = true,
                BGender = false
            };

            go.addChr(ch);

            Chromosome ch1 = new Chromosome
            {
                Id = 1,
                Name = "2",
                LenGenetcM = drosophilaConst2 * coef,
                BRecInFemales = true,
                BGender = false
            };

            go.addChr(ch1);

            Chromosome ch2 = new Chromosome
            {
                Id = 2,
                Name = "3",
                LenGenetcM = drosophilaConst3 * coef,
                BRecInFemales = true,
                BGender = false
            };

            go.addChr(ch2);



            return go;
        }

        private GenomeOrganization randomOrganism(GenomeOrganization go, int nChr)
        {
            double coef = 1;
            List<int> chrLength = new List<int>();
            foreach (Dictionary<int, string> dic in rawGeneticData)
            {
                chrLength.Add(Convert.ToInt32(dic[1]));
            }

            for (int i = 0; i < nChr; i++)
            {
                Chromosome ch = new Chromosome();
                ch.Name = Convert.ToString(i);
                ch.LenGenetcM = coef * chrLength[i];
                go.addChr(ch);
            }

            return go;
        }

        #endregion Private Methods
    }

}
