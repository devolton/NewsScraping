let wordsCollection = [];
let jsonResponse = {"Beta":12,"Heiis":67,"Hello":10,"Hololo":23,"Name":4,"OpenGamer":54,"World":2};
for (let jsonResponseKey in jsonResponse) {
    wordsCollection.push({word: jsonResponseKey, count: jsonResponse[jsonResponseKey]});
};



