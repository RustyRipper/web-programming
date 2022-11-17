var max = 99;
var defaultSize = 10;
var minS = 5;
var maxS = 20;


function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min)) + min;
}

function tableCreate(sizeT) {
    var iList = [];
    var jList = [];
    const body = document.body,
        tbl = document.createElement('table');
    tbl.setAttribute("id", "myTable");
    var header = tbl.createTHead();
    var bodyT = tbl.createTBody();

    for (let i = 0; i <= sizeT; i++) {
        let tr;
        if (i === 0) {
            tr = header.insertRow();
        } else {
            tr = bodyT.insertRow();
        }

        for (let j = 0; j <= sizeT; j++) {


            if (i === 0 || j === 0) {
                var th = document.createElement('th');

                if (i === 0 && j === 0) {
                    iList[i] = 0;
                    jList[j] = 0;
                    th.appendChild(document.createTextNode(''));
                } else {
                    var number = getRandomInt(1, 99);
                    if (i === 0) {
                        iList[j] = number;
                    } else if (j === 0) {
                        jList[i] = number;
                    }
                    th.appendChild(document.createTextNode(number));
                }

                tr.appendChild(th);

            } else {
                var td = tr.insertCell();
                var result = iList[j] * jList[i];
                td.appendChild(document.createTextNode(result));
                if (result % 2 == 0) {
                    td.setAttribute('class', 'even');
                } else {
                    td.setAttribute('class', 'odd');
                }
            }
        }
    }
    body.appendChild(tbl);
}

document.getElementById("b").onclick = function () {
    size = parseInt(document.getElementById('size').value, 10);
    if (size >= minS && size <= maxS) {
        tableCreate(size);
    } else {
        var p = document.createElement('p');
        var text = document.createTextNode('zly parametr, przyjeto size = ' + defaultSize);
        p.appendChild(text);
        const body = document.body;
        body.appendChild(p);
        tableCreate(defaultSize);
    }
}