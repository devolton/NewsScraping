let wordsCollection = [];
let jsonResponse = {"libel":6,"year":6,"journalists":6,"times":6,"bid":6,"reach":6,"harry":7,"\u2013":7,"online":8,"uk":8,"bbc":8,"mirror":9,"mail":9,"revenue":10,"telegraph":10,"over":11,"new":13,"diary":15,"media":18,"news":38};
for (let jsonResponseKey in jsonResponse) {
    wordsCollection.push({word: jsonResponseKey, count: jsonResponse[jsonResponseKey]});
};



