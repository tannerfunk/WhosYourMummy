document.getElementById("submit").addEventListener("submit", function (event) {
    event.preventDefault();
    inputData();
});

function inputData() {
    var squarenorthsouth_150 = parseFloat(document.getElementById('squarenorthsouth_150').value);
    var squarenorthsouth_160 = parseFloat(document.getElementById('squarenorthsouth_160').value);
    var squarenorthsouth_190 = parseFloat(document.getElementById('squarenorthsouth_190').value);
    var squarenorthsouth_200 = parseFloat(document.getElementById('squarenorthsouth_200').value);
    var squarenorthsouth_Other = parseFloat(document.getElementById('squarenorthsouth_Other').value);
    var headdirection_E = parseFloat(document.getElementById('headdirection_E').value);
    var headdirection_Other = parseFloat(document.getElementById('headdirection_Other').value);
    var headdirection_W = parseFloat(document.getElementById('headdirection_W').value);
    var sex_F = parseFloat(document.getElementById('sex_F').value);
    var sex_M = parseFloat(document.getElementById('sex_M').value);
    var depth_Other = 0;
    var eastwest_W = 0;
    var adultsubadult_A = parseFloat(document.getElementById('adultsubadult_A').value);
    var adultsubadult_C = parseFloat(document.getElementById('adultsubadult_C').value);
    var adultsubadult_Other = parseFloat(document.getElementById('adultsubadult_Other').value);
    var preservation_W = parseFloat(document.getElementById('preservation_W').value);
    var preservation_poorly_preserved = parseFloat(document.getElementById('preservation_poorly_preserved').value);
    var preservation_wrapped = parseFloat(document.getElementById('preservation_wrapped').value);
    var squareeastwest_10 = parseFloat(document.getElementById('squareeastwest_10').value);
    var squareeastwest_20 = parseFloat(document.getElementById('squareeastwest_20').value);
    var squareeastwest_30 = parseFloat(document.getElementById('squareeastwest_30').value);
    var squareeastwest_40 = parseFloat(document.getElementById('squareeastwest_40').value);
    var squareeastwest_50 = parseFloat(document.getElementById('squareeastwest_50').value);
    var text_Other = 0;
    var haircolor_B = parseFloat(document.getElementById('haircolor_B').value);
    var haircolor_Other = parseFloat(document.getElementById('haircolor_Other').value);
    var samplescollected_false = parseFloat(document.getElementById('samplescollected_false').value);
    var samplescollected_true = parseFloat(document.getElementById('samplescollected_true').value), samplesCollectedTrueValue;
    var area_NW = parseFloat(document.getElementById('area_NW').value);
    var area_Other = parseFloat(document.getElementById('area_Other').value), areaOtherValue;
    var area_SE = parseFloat(document.getElementById('area_SE').value);
    var area_SW = parseFloat(document.getElementById('area_SW').value);
    var length_Other = 0;
    var ageatdeath_A = parseFloat(document.getElementById('ageatdeath_A').value);
    var ageatdeath_C = parseFloat(document.getElementById('ageatdeath_C').value);
    var ageatdeath_I = parseFloat(document.getElementById('ageatdeath_I').value);
    var ageatdeath_N = parseFloat(document.getElementById('ageatdeath_N').value);
    var ageatdeath_Other = parseFloat(document.getElementById('ageatdeath_Other').value);
    var fieldbookexcavationyear_1987B = parseFloat(document.getElementById('fieldbookexcavationyear_1987B').value);
    var fieldbookexcavationyear_1994B = parseFloat(document.getElementById('fieldbookexcavationyear_1994B').value);
    var fieldbookexcavationyear_1998 = parseFloat(document.getElementById('fieldbookexcavationyear_1998').value);
    var fieldbookexcavationyear_2005 = parseFloat(document.getElementById('fieldbookexcavationyear_2005').value);
    var fieldbookexcavationyear_2009 = parseFloat(document.getElementById('fieldbookexcavationyear_2009').value);
    var fieldbookexcavationyear_Other = parseFloat(document.getElementById('fieldbookexcavationyear_Other').value);


    const inputData = {
        "squarenorthsouth_150": squarenorthsouth_150,
        "squarenorthsouth_160": squarenorthsouth_160,
        "squarenorthsouth_190": squarenorthsouth_190,
        "squarenorthsouth_200": squarenorthsouth_200,
        "squarenorthsouth_Other": squarenorthsouth_Other,
        "headdirection_E": headdirection_E,
        "headdirection_Other": headdirection_Other,
        "headdirection_W": headdirection_W,
        "sex_F": sex_F,
        "sex_M": sex_M,
        "depth_Other": depth_Other,
        "eastwest_W": eastwest_W,
        "adultsubadult_A": adultsubadult_A,
        "adultsubadult_C": adultsubadult_C,
        "adultsubadult_Other": adultsubadult_Other,
        "preservation_W": preservation_W,
        "preservation_poorly_preserved": preservation_poorly_preserved,
        "preservation_wrapped": preservation_wrapped,
        "squareeastwest_10": squareeastwest_10,
        "squareeastwest_20": squareeastwest_20,
        "squareeastwest_30": squareeastwest_30,
        "squareeastwest_40": squareeastwest_40,
        "squareeastwest_50": squareeastwest_50,
        "text_Other": text_Other,
        "haircolor_B": haircolor_B,
        "haircolor_Other": haircolor_Other,
        "samplescollected_false": samplescollected_false,
        "samplescollected_true": samplescollected_true,
        "area_NW": area_NW,
        "area_Other": area_Other,
        "area_SE": area_SE,
        "area_SW": area_SW,
        "length_Other": length_Other,
        "ageatdeath_A": ageatdeath_A,
        "ageatdeath_C": ageatdeath_C,
        "ageatdeath_I": ageatdeath_I,
        "ageatdeath_N": ageatdeath_N,
        "ageatdeath_Other": ageatdeath_Other,
        "fieldbookexcavationyear_1987B": fieldbookexcavationyear_1987B,
        "fieldbookexcavationyear_1994B": fieldbookexcavationyear_1994B,
        "fieldbookexcavationyear_1998": fieldbookexcavationyear_1998,
        "fieldbookexcavationyear_2005": fieldbookexcavationyear_2005,
        "fieldbookexcavationyear_2009": fieldbookexcavationyear_2009,
        "fieldbookexcavationyear_Other": fieldbookexcavationyear_Other
    }
    CallAPI(inputData);
}

console.log(inputData);



async function CallAPI(inputData) {
    // serialize the JSON object to a string
    var jsonString = JSON.stringify(inputData);

    try {
        // send the POST request to the URL
        var response = await fetch("https://intexwinners.is404.net/score", {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: jsonString
        });

        // get the response content as a string
        var responseString = await response.text();

        // do something with the response
        console.log(responseString);

        let trimmedString = responseString.substring(19, responseString.length - 2);
        //console.log(trimmedString);

        document.getElementById("response").innerHTML = trimmedString
    } catch (error) {
        // handle the exception
        console.error(error);
    }
}