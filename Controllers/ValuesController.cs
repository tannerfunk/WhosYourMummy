using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.OnnxRuntime;
using Microsoft.ML.OnnxRuntime.Tensors;
using WhosYourMummy.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace WhosYourMummy.Controllers
{
    [ApiController]
    [Route("/score")]
    public class InferenceController : ControllerBase
    {
        //C:\Users\Elizabeth Zundel\AppData\Local\Temp\5B2750CAEF2901BDF0019880F31CE0F971DA\2\WhosYourMummy\Models\model.onnx
        private InferenceSession _session;
        public InferenceController(InferenceSession session)
        {
            _session = session;
        }
        [HttpPost]
        public IActionResult Score(APIData data)
        {

            var result = _session.Run(new List<NamedOnnxValue>() //()
            {
                NamedOnnxValue.CreateFromTensor<float>("float_input", data.AsTensor()) //<float>
            });
            Tensor<string> score = result.First().AsTensor<string>();
            var prediction = new Prediction { PredictedValue = score.First() };
            result.Dispose();
            return new JsonResult(prediction);
            //return RedirectToAction("Supervised", "Home");
        }
    }
    //public class ValuesController : Controller
    //{
    //    public IActionResult Supervised()
    //    {
    //        {
    //            // Initialize the dictionary with all keys set to 0
    //            Dictionary<string, int> selectedValues = new Dictionary<string, int>
    //        {
    //            { "squarenorthsouth_150", 0 },
    //            { "squarenorthsouth_160", 0 },
    //            { "squarenorthsouth_190", 0 },
    //            { "squarenorthsouth_200", 0 },
    //            { "squarenorthsouth_Other", 0 },
    //            { "headdirection_E", 0 },
    //            { "headdirection_Other", 0 },
    //            { "headdirection_W", 0 },
    //            { "sex_F", 0 },
    //            { "sex_M", 0 },
    //            { "depth_Other", 0 },
    //            { "eastwest_W", 0 },
    //            { "adultsubadult_A", 0 },
    //            { "adultsubadult_C", 0 },
    //            { "adultsubadult_Other", 0 },
    //            { "preservation_W", 0 },
    //            { "preservation_poorly_preserved", 0 },
    //            { "preservation_wrapped", 0 },
    //            { "squareeastwest_10", 0 },
    //            { "squareeastwest_20", 0 },
    //            { "squareeastwest_30", 0 },
    //            { "squareeastwest_40", 0 },
    //            { "squareeastwest_50", 0 },
    //            { "text_Other", 0 },
    //            { "haircolor_B", 0 },
    //            { "haircolor_Other", 0 },
    //            { "samplescollected_false", 0 },
    //            { "samplescollected_true", 0 },
    //            { "area_NW", 0 },
    //            { "area_Other", 0 },
    //            { "area_SE", 0 },
    //            { "area_SW", 0 },
    //            { "length_Other", 0 },
    //            { "ageatdeath_A", 0 },
    //            { "ageatdeath_C", 0 },
    //            { "ageatdeath_I", 0 },
    //            { "ageatdeath_N", 0 },
    //            { "ageatdeath_Other", 0 },
    //            { "fieldbookexcavationyear_1987B", 0 },
    //            { "fieldbookexcavationyear_1994B", 0 },
    //            { "fieldbookexcavationyear_1998", 0 },
    //            { "fieldbookexcavationyear_2005", 0 },
    //            { "fieldbookexcavationyear_2009", 0 },
    //            { "fieldbookexcavationyear_Other", 0 }
    //        };

    //            // Process the form input
    //            if (Request.Form != null)
    //            {
    //                foreach (KeyValuePair<string, StringValues> formValue in Request.Form)
    //                {
    //                    string key = formValue.Key;
    //                    string value = formValue.Value.ToString();

    //                    // Update the dictionary if a value is provided in the form
    //                    if (!string.IsNullOrEmpty(value))
    //                    {
    //                        int intValue;
    //                        if (int.TryParse(value, out intValue))
    //                        {
    //                            selectedValues[key] = intValue;
    //                        }
    //                    }
    //                }
    //            }

    //            // Pass the dictionary to the view
    //            return View("Supervised", selectedValues);
    //        }

    //        return View("Supervised", selectedValues);
    //    }
    //}
}
