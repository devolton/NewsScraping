let wordsCollection = [];
let jsonResponse = {"First":100,"Heiis":67,"OpenGamer":54,"Hololo":23,"Beta":12};
for (let jsonResponseKey in jsonResponse) {
    wordsCollection.push({word: jsonResponseKey, count: jsonResponse[jsonResponseKey]});
};



