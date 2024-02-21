let wordsCollection = [];
let jsonResponse = {"bid":6,"court":6,"trial":7,"covid":7,"journalists":7,"libel":8,"harry":8,"year":8,"\u2013":8,"bbc":8,"revenue":9,"mail":9,"uk":10,"mirror":10,"telegraph":12,"new":13,"over":13,"diary":17,"media":18,"news":40};
for (let jsonResponseKey in jsonResponse) {
    wordsCollection.push({word: jsonResponseKey, count: jsonResponse[jsonResponseKey]});
};



