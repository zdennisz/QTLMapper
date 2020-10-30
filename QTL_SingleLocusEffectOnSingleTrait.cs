using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static QTLProject.Types;

namespace QTLProject
{
    public class QTL_SingleLocusEffectOnSingleTrait
    {
       
        public double AdditiveEffect_d { get; set; }
        public double AdditiveEffect_h { get; set; }
        //Effect of QTL q on trait t: T[i,t,q] 
        //Let G[i,q] is genotype of individ i at QTL q, G[i,q]=aa,aA,Aa,AA
        //T[i,t,q]=0,     for G[i,q]=0=aa
        //         d*2*h, for G[i,q]=1=aA or Aa
        //         2d,    for G[i,q]=2=AA



    }
}
