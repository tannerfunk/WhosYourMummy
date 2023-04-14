using System;
using Microsoft.ML.OnnxRuntime.Tensors;
namespace WhosYourMummy.Data
{
    public class APIData
    {
        public float squarenorthsouth_150 { get; set; }
        public float squarenorthsouth_160 { get; set; }
        public float squarenorthsouth_190 { get; set; }
        public float squarenorthsouth_200 { get; set; }
        public float squarenorthsouth_Other { get; set; }
        public float headdirection_E { get; set; }
        public float headdirection_Other { get; set; }
        public float headdirection_W { get; set; }
        public float sex_F { get; set; }
        public float sex_M { get; set; }
        public float depth_Other { get; set; }
        public float eastwest_W { get; set; }
        public float adultsubadult_A { get; set; }
        public float adultsubadult_C { get; set; }
        public float adultsubadult_Other { get; set; }
        public float preservation_W { get; set; }
        public float preservation_poorly_preserved { get; set; }
        public float preservation_wrapped { get; set; }
        public float squareeastwest_10 { get; set; }
        public float squareeastwest_20 { get; set; }
        public float squareeastwest_30 { get; set; }
        public float squareeastwest_40 { get; set; }
        public float squareeastwest_50 { get; set; }
        public float text_Other { get; set; }
        public float haircolor_B { get; set; }
        public float haircolor_Other { get; set; }
        public float samplescollected_false { get; set; }
        public float samplescollected_true { get; set; }
        public float area_NW { get; set; }
        public float area_Other { get; set; }
        public float area_SE { get; set; }
        public float area_SW { get; set; }
        public float length_Other { get; set; }
        public float ageatdeath_A { get; set; }
        public float ageatdeath_C { get; set; }
        public float ageatdeath_I { get; set; }
        public float ageatdeath_N { get; set; }
        public float ageatdeath_Other { get; set; }
        public float fieldbookexcavationyear_1987B { get; set; }
        public float fieldbookexcavationyear_1994B { get; set; }
        public float fieldbookexcavationyear_1998 { get; set; }
        public float fieldbookexcavationyear_2005 { get; set; }
        public float fieldbookexcavationyear_2009 { get; set; }
        public float fieldbookexcavationyear_Other { get; set; }
        public Tensor<float> AsTensor()
        {
            float[] data = new float[]
            {
                squarenorthsouth_150, squarenorthsouth_160, squarenorthsouth_190,
                squarenorthsouth_200,squarenorthsouth_Other, headdirection_E, headdirection_Other, headdirection_W, sex_F, sex_M, depth_Other,
                eastwest_W, adultsubadult_A, adultsubadult_C, adultsubadult_Other, preservation_W, preservation_poorly_preserved,
                preservation_wrapped, squareeastwest_10, squareeastwest_20, squareeastwest_30, squareeastwest_40, squareeastwest_50,
                text_Other, haircolor_B, haircolor_Other, samplescollected_false, samplescollected_true, area_NW, area_Other, area_SE,
                area_SW, length_Other, ageatdeath_A, ageatdeath_C, ageatdeath_I, ageatdeath_N, ageatdeath_Other,
                fieldbookexcavationyear_1987B, fieldbookexcavationyear_1994B, fieldbookexcavationyear_2005, fieldbookexcavationyear_1998,
                fieldbookexcavationyear_2009, fieldbookexcavationyear_Other
                };
            int[] dimensions = new int[] { 1, 44 };
            return new DenseTensor<float>(data, dimensions);
        }
    }
}
