let wordsCollection = [];
let jsonResponse = {"Hello":2,"World":3,"Guuu":4,"Mortal":9,"Gogog":10,"Morta":12,"Salo":12,"yyyy":19,"Hell":21,"Holoo":22,"Worl":31,"Tao":33,"Gogg":45,"Guu":54,"Hololo":65,"Uppo":67,"Upopo":77,"Sal":85,"Tako":99,"Dictionay":111};
for (let jsonResponseKey in jsonResponse) {
    wordsCollection.push({word: jsonResponseKey, count: jsonResponse[jsonResponseKey]});
};



