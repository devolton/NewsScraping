window.addEventListener('load', () => {
    var createDOMEElement = (tagName = '', options = {}, parent = null) => {
        var element = document.createElement(tagName);
        for (const key in options) {
            element.setAttribute(key, options[key]);
        }
        if (parent != null) parent.appendChild(element);
        return element;
    };
    const canvas = document.querySelector('#myNewsDiagramCanvas');
    const newsCountSelect = document.querySelector('.news-count');
    let topNumberArray=[20,10,5,3];

    topNumberArray.forEach((item) => {
        createDOMEElement('option', {class: 'count-option', value: item}, newsCountSelect).innerHTML = "Top "+item;
    })
    var ctx = canvas.getContext('2d');
    var loc_X = 50;
    var loc_Y = canvas.clientHeight - loc_X * 2;
    var wordsContainer = wordsCollection.slice();
    var scheduleBlockHeight = canvas.clientHeight - loc_X * 3;
    var step = 20;
    var lastCount;
    var drawArrows = () => {
        ctx.beginPath();
        ctx.moveTo(loc_X, loc_Y);
        ctx.lineTo(canvas.clientWidth - loc_X, loc_Y)
        ctx.moveTo(loc_X, loc_Y);
        ctx.lineTo(loc_X, loc_X - 10);
        ctx.moveTo(loc_X, loc_X - 35);
        ctx.lineTo(loc_X + 10, loc_X - 10);
        ctx.lineTo(loc_X - 10, loc_X - 10);
        ctx.lineTo(loc_X, loc_X - 35);
        ctx.stroke();
        ctx.closePath();
        ctx.font = ' bold 18px serif';
        ctx.fillText("0", loc_X - 25, loc_Y + 15);
    };
    var drawGraph = (wordsCollection) => {
        wordsCollection.forEach((oneWordData, index) => {
            var maxCount = wordsCollection.reduce((maxItem, current) => (current.count > maxItem.count ? current : maxItem), wordsCollection[0]).count;
            var blockHeight = scheduleBlockHeight * oneWordData.count / maxCount;
            var widthB = (canvas.clientWidth - loc_X * 2) / wordsCollection.length;
            widthB -= step;
            var wordCountXCoordinate = (~~(oneWordData.count / 1000) === 0) ? loc_X - 25 + scheduleBlockHeight - blockHeight : loc_X - 35 + scheduleBlockHeight - blockHeight;
            wordCountXCoordinate-=(wordsCollection.length>=6) ? 0 : 10;
            var wordCountYCoordinate = -(widthB / 2)+5 - step - loc_X - index * (widthB + step);
            var rectXCoordinate = step + loc_X + index * (widthB + step);
            var wordNameYCoordinate=-(widthB/2)+5 - step - loc_X - index * (widthB + step);
            var wordCountryXCoordinate=loc_X + scheduleBlockHeight +10;
            var wordNameLineXCoordinate=step + loc_X + index * (widthB + step) + widthB / 2;
            var wordCountLineYCoordinate=scheduleBlockHeight - blockHeight + loc_X;
            ctx.beginPath();
            ctx.fillStyle = `rgb(${255 - index * 255 / wordsCollection.length},${index * 255 / wordsCollection.length},0)`;
            ctx.fillRect(rectXCoordinate, loc_Y, widthB, -blockHeight);
            ctx.fill();
            ctx.fillStyle = 'black';
            ctx.font=(wordsCollection.length>=6)? '14px serif' : '20px serif';
            ctx.moveTo(wordNameLineXCoordinate, loc_Y);
            ctx.lineTo(wordNameLineXCoordinate, loc_Y + 5);
            ctx.stroke();
            ctx.closePath();
            ctx.beginPath();
            ctx.strokeStyle = 'black';
            ctx.rotate(Math.PI / 2);
            ctx.fillText(oneWordData.word,wordCountryXCoordinate,wordNameYCoordinate );
            ctx.fillText(oneWordData.count, wordCountXCoordinate, wordCountYCoordinate);
            ctx.rotate(-Math.PI / 2);
            ctx.closePath();
            if (Math.abs(oneWordData.count - lastCount) > 120 || index === 0) {
                ctx.beginPath();
                ctx.moveTo(loc_X,wordCountLineYCoordinate );
                ctx.lineTo(loc_X - 5, wordCountLineYCoordinate);
                ctx.lineTo(loc_X + 5, wordCountLineYCoordinate);
                ctx.stroke();
                ctx.strokeStyle = 'black';
                ctx.font = ' bold 18px serif';
                ctx.fillStyle = 'black';
                ctx.fillText(oneWordData.count, 5, canvas.clientHeight - 95 - blockHeight, 150);
                ctx.closePath();
                lastCount = oneWordData.count;
            }


        });
    };
    drawArrows();
    drawGraph(wordsContainer);
    newsCountSelect.addEventListener('change', () => {
        let startIndex =wordsCollection.length- newsCountSelect.value;
        wordsContainer.length=0;
        console.log("Start index:"+startIndex);
        console.log("Main container length: "+wordsCollection.length);
        for(let i=startIndex;i<wordsCollection.length;i++){
            wordsContainer.push(wordsCollection[i]);
        }
        ctx.clearRect(0, 0, canvas.width, canvas.height);
        drawArrows();
        drawGraph(wordsContainer);

    });

});