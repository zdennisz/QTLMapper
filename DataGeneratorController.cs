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
        public GenomeOrganization go = null;
        
        private int nChr;
        private OrganismType type;

        /*Notes - 
         * DefineChromosomeLength - Should be run first to define the length since the next method assumes that the length was already defined (DefineChromosomePositions).
         * 
         */

        public DataGeneratorController(int _nChr, OrganismType _type)
        {
            go = new GenomeOrganization();
            nChr = _nChr;
            type = _type;
           
        }
        
        /// <summary>
        /// This is  method defines the location of the loci on the chromosome
        /// </summary>
        /// <param name="dBetweenMarkers_set"></param>
        /// <param name="nMarkersGrouped"></param>
        /// <param name="dMarkersGrouped"></param>
        /// <param name="indexAnimal"></param>
        public void DefineChromosomePositions(double dBetweenMarkers_set ,long nMarkersGrouped , double dMarkersGrouped , int indexAnimal )
        {
            int index=1;

            double coorPrev=0.0, d, coorStartOnCurrentChr=0.0, dBetweenMarkers = 2.0;
            long j, nMarkersMax, nOnChr=11;

            if (dBetweenMarkers_set > 0)
            {
                //distance between markers
                dBetweenMarkers = dBetweenMarkers_set;
            }

            if (index == 0)
            {
                //amount of markers
                nMarkersMax = nChr * nOnChr;
            }
            else
            {
                //amount of markers
                nMarkersMax = nChr * (int)(500 / dBetweenMarkers);
            }

            for(int i = 0; i < nChr; i++)
            {
                if (index == 0)
                {
                    d = go.Chromosome[i].LenGenetcM / (nOnChr - 1);
                }
                else
                {
                    d = dBetweenMarkers;
                    nOnChr=(int)(go.Chromosome[i].LenGenetcM/d)+1;
                }
                //Line 195 is this correct
                if (go.Chromosome[i].Id > 1)
                {
                    coorPrev = coorPrev + 1000 - d;
                }
                else
                {
                    coorPrev = -d;
                }
                for (j = 0; j < nOnChr; j++)
                {

                    Locus loci = new Locus();
                    //default location
                    loci.Position.Chromosome = go.Chromosome[i];
                    loci.Position.PositionChrGenetic = coorPrev + d;

                    if(j>1 && j<= dMarkersGrouped)
                    {
                        loci.Position.PositionChrGenetic = coorPrev + dMarkersGrouped;
                    }
                    if (j == 1)
                    {
                        coorStartOnCurrentChr = loci.Position.PositionChrGenetic;
                    }
                    if (j == nOnChr)
                    {
                        loci.Position.PositionChrGenetic = coorStartOnCurrentChr + go.Chromosome[i].LenGenetcM;
                    }
                    //Line 215 not clear
                    // go.Chromosome[i]loci.Position.PositionChrGenetic - coorStartOnCurrentChr;

                    loci.Name = "loc_" + j;
                    loci.Id = i;
                    coorPrev = loci.Position.PositionChrGenetic;

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
                    go = genereateDrosophila(go,nChr);
                    break;


                case OrganismType.PseudoWheat:
                    go = generatePseudoWheat(go,nChr);
                    break;



                default:
                    //error organisim is not supported
                    break;

            }
            

        }


        private GenomeOrganization genereateDrosophila(GenomeOrganization go,int nChr)
        {
            double coef = 1;
            int drosophilaConst1 = 75, drosophilaConst2 = 107, drosophilaConst3 = 110;
            Chromosome ch = new Chromosome
            {
                Id=0,
                LenGenetcM = drosophilaConst1 * coef,
                BRecInFemales=true,
                BGender=true
            };

            go.Chromosome.Add(ch);

            Chromosome ch1 = new Chromosome
            {
                Id=1,
                LenGenetcM = drosophilaConst2 * coef,
                BRecInFemales = true,
                BGender = true
            };

            go.Chromosome.Add(ch1);

            Chromosome ch2 = new Chromosome
            {
                Id=3,
                LenGenetcM = drosophilaConst3 * coef,
                BRecInFemales = true,
                BGender = true
            };

            go.Chromosome.Add(ch2);

            

            return go;
        }


        private GenomeOrganization generatePseudoWheat(GenomeOrganization go,int nChr)
        {
          
            
            
            return go;
        }

        public void DefineParentalHalotypes()
        {

        }

        public void SimulateRecombination()
        {

        }

    }

}
