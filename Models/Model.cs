using System;
using System.Collections.Generic;
using System.Text;

namespace QTLProject
{
    public class Model
    {
       // 1 QTL in (chr1, 45.6), d=0.48, s=1.2
        public Locus[] QTL { get; set; }//[iQTL]
        public Trait[] Trait { get; set; }//[iSelectedTrait]
        public QTL_SingleLocusEffectOnSingleTrait[,] QTLeffect { get; set; }//[iSelectedTrait,iQTL]
        public float[] AverageTraitValue { get; set; }//[iSelectedTrait]
        public float[] VarianceTraitValue { get; set; }
        //[iSelectedTrait]
        //TraitValue[i,t]=AverageTraitValue[t]+Sum_q T[i,t,q]+e, e ~ N(0, VarianceTraitValue[t])
        //T[i,t,q]=0,     for G[i,q]=0=aa
        //         d*2*h, for G[i,q]=1=aA or Aa
        //         2d,    for G[i,q]=2=AA


        public int[] TraitDistributionIndex { get; set; }//[iSelectedTrait]; 0 - normal distribution; for this project only normal distribution
        
        
        
    
      

    }
}
