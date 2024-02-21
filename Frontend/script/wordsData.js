let wordsCollection = [];
let jsonResponse = {"covid":7,"prince":7,"libel":8,"says":8,"guardian":8,"\u2013":8,"journalists":9,"harry":9,"revenue":9,"year":9,"mirror":10,"uk":10,"mail":10,"bbc":11,"telegraph":12,"over":13,"new":14,"media":18,"diary":19,"news":46};
for (let jsonResponseKey in jsonResponse) {
    wordsCollection.push({word: jsonResponseKey, count: jsonResponse[jsonResponseKey]});
};



