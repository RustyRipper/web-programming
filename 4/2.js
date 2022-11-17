var canvases2 = document.getElementsByTagName('canvas');

let canvases = document.querySelectorAll("canvas");
canvases.forEach(function (elem) {
    elem.addEventListener("mousemove", function (e) {
        ctx = elem.getContext('2d');
        var cRect = elem.getBoundingClientRect(); // Gets CSS pos, and width/height
        var canvasX = Math.round(e.clientX - cRect.left); // Subtract the 'left' of the canvas 
        var canvasY = Math.round(e.clientY - cRect.top); // from the X/Y positions to make  
        ctx.clearRect(0, 0, elem.width, elem.height); // (0,0) the top left of the canvas

        ctx.beginPath();
        ctx.moveTo(0, 0);
        ctx.lineTo(canvasX, canvasY);
        ctx.stroke();
        ctx.moveTo(elem.width, 0);
        ctx.lineTo(canvasX, canvasY);
        ctx.stroke();
        ctx.moveTo(0, elem.height);
        ctx.lineTo(canvasX, canvasY);
        ctx.stroke();
        ctx.moveTo(elem.width, elem.height);
        ctx.lineTo(canvasX, canvasY);
        ctx.stroke();
        console.log(elem.width);
    });
});
canvases.forEach(function (elem) {
    elem.addEventListener("mouseleave", mouseLeave);
});


function mouseLeave() {

    ctx.clearRect(0, 0, canvases[0].width, canvases[0].height); // (0,0) the top left of the canvas
    ctx.beginPath();
}