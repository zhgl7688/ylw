/* global jQuery */
/*eslint-disable*/

'use strict';

// API Url

var apiUrl = 'https://localhost:8089/PPSignSDK/';

// initialize device web api

var initUrl = apiUrl + 'InitialDevice?id=5&width=580&height=380';
// uninitialize device web api
var uninitUrl = apiUrl + 'UninitialDevice?id=2';
// get ink web api
var getInkUrl = apiUrl + 'GetInks';
// clear ink api
var clrInkUrl = apiUrl + 'Clear';
// open & close LCD api
var oplcdUrl = apiUrl + 'OpenLCD';
var cllcdUrl = apiUrl + 'CloseLCD';
// get pen width api
var penwidthUrl = apiUrl + 'SetPenWidth?Width=';
// get pen style api
var penstyUrl = apiUrl + 'SetPenStyle?Style=';
// get save drawing api
var savedrawUrl = apiUrl + 'SaveDrawingImage?';
// get size api
var getsizeUrl = apiUrl + 'GetSize';
// get point api
var getpointUrl = apiUrl + 'GetPointer';
// get about api
var aboutUrl = apiUrl + 'About';
// get Version ID api ( for L398 & E560 )
var veridUrl = apiUrl + 'VersionID';
// get pen ID api ( for L398 & E560 )
var penidUrl = apiUrl + 'PenID';
// get pad ID api ( for L398 & E560 )
var padidUrl = apiUrl + 'PadID';
// Display device information in LCD api ( only for L398 )
var diilUrl = apiUrl + 'DisplayDeviceInfoInLCD?show=';
// Get device information api
var devinfoUrl = apiUrl + 'GetDeviceInfo?type=';
// get Encode api
var encodeUrl = apiUrl + 'Encode?type=';
// get Decode api
var decodeUrl = apiUrl + 'Decode?type=';
// get Set clip api
var setclipUrl = apiUrl + 'SetClip';
// get valid api
var validUrl = apiUrl + 'IsValid';
// save device data api
var savedataUrl = apiUrl + 'SaveDeviceData';
// read device data api
var readdataUrl = apiUrl + 'ReadDeviceData';
// save device data api
var cleardataUrl = apiUrl + 'ClearDeviceData';
// Get Decode File Path
var decodepathUrl = apiUrl + 'GetDecodeFilePath';

var canvas;
var context;

var isPolling = false;

// initialize device
function initDevice() {
    //event.preventDefault();

    $.ajax({
        url: initUrl,
        type: 'GET'
    }).done(function (response) {
        if (response === true) {
            isPolling = true;

            getInk();
            $('.init').removeAttr('disabled');
            $('#initBtn').attr('disabled', 'disabled');
        };
    });
}

// uninitialize device
function uninitDevice() {
    //event.preventDefault();

    $.ajax({
        url: uninitUrl,
        type: 'GET'
    }).done(function (response) {
        if (response === true) {
            isPolling = false;
            $('.init').attr('disabled', 'disabled');
            $('#initBtn').removeAttr('disabled');
        };
    });
}

// switch initialize
$('#initSwitch').click(function () {

    if ($(this).prop('checked')) {
        initDevice();
    } else {
        uninitDevice();
    }

    console.log($(this));
    console.log($(this).prop('checked'));
});

// initialize canvas and setup context
window.onload = function () {
    canvas = document.getElementById('ppCanvas');

    if (canvas.getContext) {
        context = canvas.getContext('2d');
    }
};

function getInk() {
    // 用polling的方式向self-host發送request取得簽名板畫面(base64格式)
    (function poll() {
        var timeId = setTimeout(function () {

            clearTimeout(timeId);

            $.ajax({
                url: getInkUrl,
                type: 'GET'
            }).done(function (data) {
                var dataInfos = JSON.parse(data);

                dataInfos.forEach(function (value) {
                    if (value.EventType === 0) {
                        drawImage(value.Image);
                    }
                });
            }).always(function () {
                if (isPolling) {
                    poll();
                } else {}
            });
        }, 20);
    })();
};

function drawImage(base64) {
    var dataUrl = 'data:image/png;base64,';

    dataUrl = dataUrl + base64;

    // 在image中載入圖檔，再畫到canvas呈現
    var img = new Image();

    img.addEventListener('load', function () {
        context.drawImage(this, 0, 0, canvas.width, canvas.height);
    }, false);

    img.src = dataUrl;
};

// clear Ink
function clearInk() {

    $.ajax({
        url: clrInkUrl,
        type: 'GET',
        success: function success() {
            var canvas = document.getElementById('ppCanvas');

            context.clearRect(0, 0, canvas.width, canvas.height);
        }
    });
};

// open lcd
function openLcd() {

    $.ajax({
        url: oplcdUrl,
        type: 'GET'
    });
    $('.shutdown').fadeOut('fast');
};
// close lcd
function closeLcd() {

    $.ajax({
        url: cllcdUrl,
        type: 'GET'
    });
    $('.shutdown').fadeIn('fast');
};

// pen width change case
function pwChange() {
    var pwVal = $('#penWidth').val();

    $.ajax({
        url: penwidthUrl + pwVal,
        type: 'GET'
    });

    // alert( penwidthUrl + pwVal );
};

//  pen style change case
function psChange() {
    var psVal = $('#penStyle').val();

    $.ajax({
        url: penstyUrl + psVal,
        type: 'GET'
    });

    // alert(penstyUrl + psVal);
};

// save drawing images
function saveDrawing() {
    var getsdType = $('#sdType').val();
    var getsdDpi = $('#sdDpi').val();
    var localPath = 'DrawImage.';
    var sdT, sdD;

    switch (getsdType) {
        case '1':
            sdT = 'BMP';
            break;
        case '2':
            sdT = 'JPG';
            break;
        case '3':
            sdT = 'PNG';
            break;
        case '4':
            sdT = 'GIF';
            break;
        case '5':
            sdT = 'TIFF';
            break;
    };

    if (getsdDpi == '0') {
        sdD = '150';
    } else {
        sdD = '300';
    };

    $.ajax({
        url: savedrawUrl + 'type=' + getsdType + '&dpi=' + getsdDpi + '&path=' + localPath + sdT,
        type: 'GET'
    }).done(function (resp) {
        if (navigator.userAgent.indexOf("WOW64") != -1 || navigator.userAgent.indexOf("Win64") != -1) {
            alert('檔案：' + resp + ' 已儲存\nDpi：' + sdD);
        } else {
            alert('檔案：' + resp + ' 已儲存\nDpi：' + sdD);
        }
    });
};

// Set clip
function setClip() {

    var scWidth = $('#scWidth').val();
    var scHeight = $('#scHeight').val();

    if (!scWidth || scWidth < 0) {
        alert('Insert Width!');
        return;
    };
    if (!scHeight || scHeight < 0) {
        alert('Insert height!');
        return;
    };

    $.ajax({
        url: setclipUrl + '?width=' + scWidth + '&height=' + scHeight,
        type: 'GET'
    });
};

// get size
function getSize() {

    $.ajax({
        url: getsizeUrl,
        type: 'GET',
        success: function success(data) {
            if (data == '-8') {
                alert('Ink Empty.');
            } else {
                alert(data);
            }
        },
        error: function error() {
            alert('Get size fail!');
        }
    });
};

// get pointer
function getPointer() {
    var pointContant = $('#pointContant');

    pointContant.empty();
    $.ajax({
        url: getpointUrl,
        type: 'GET',
        dataType: 'JSON',
        success: function success(resp) {
            var oJson = jQuery.parseJSON(resp);
            var dataLength = oJson.length;

            if (dataLength === 0) {
                alert('Point information is empty.');
            } else {
                $('#myModal').modal('show');
                for (var i = 0; i < dataLength; i++) {
                    pointContant.append('<tr><td>' + oJson[i].x + '</td><td>' + oJson[i].y + '</td><td align="right">' + oJson[i].pressure + '</td><td align="right">' + oJson[i].bStrokeEnd + '</td><td align="right">' + oJson[i].Time + '</td></tr>');
                }
            }
        },
        error: function error() {
            alert('Get point information fail!');
        }
    });
};

// get about
function getAbout() {

    $.ajax({
        url: aboutUrl,
        type: 'GET'
    });
};

// get version id
function getVerid() {

    $.ajax({
        url: veridUrl,
        type: 'GET'
    }).done(function (data) {
        alert(data);
    });
};

// get pad id
function getPadid() {

    $.ajax({
        url: padidUrl,
        type: 'GET'
    }).done(function (data) {
        alert(data);
    });
};

// get pen id
function getPenid() {

    $.ajax({
        url: penidUrl,
        type: 'GET'
    }).done(function (data) {
        alert(data);
    });
};

// show device info in lcd
function showDiilcd() {

    $.ajax({
        url: diilUrl + '1',
        type: 'GET'
    });
};

// hide device info in lcd
function hideDiilcd() {

    $.ajax({
        url: diilUrl + '0',
        type: 'GET'
    });
};

// get device information
function getDevinf() {

    var diVal = $('#devInfo').val();

    $.ajax({
        url: devinfoUrl + diVal,
        type: 'GET'
    }).done(function (data) {
        if (diVal == 1) {
            if (data === "true") {
                alert('Connected');
            } else {
                alert('Disconnected');
            }
        } else {
            alert(data);
        }
    });
};

// Encode
function encode() {

    var encodeType = $('#encodeType').val();
    var encodeArea = $('#encode');

    $.ajax({
        url: encodeUrl + encodeType,
        type: 'GET'
    }).done(function (data) {
        encodeArea.html(data);
    });
};

// Decode
function decode() {
    var encodeContent = $('#encode').val();
    var encodeType = $('#encodeType').val();
    var decodeArea = $('#decode');
    var decodeFormat;

    switch (encodeType) {
        case '1':
            decodeFormat = 'BMP';
            break;
        case '2':
            decodeFormat = 'JPG';
            break;
        case '3':
            decodeFormat = 'PNG';
            break;
        case '4':
            decodeFormat = 'GIF';
            break;
        case '5':
            decodeFormat = 'TIFF';
            break;
    }

    if (encodeType == 6) {
        $.ajax({
            url: decodeUrl + encodeType,
            type: 'POST',
            data: encodeContent,
            success: function success(resp) {
                decodeArea.append('X\t\t\t\tY\t\t\t\tbStrokeEnd\n');
                var data = JSON.parse(resp);
                for (var i = 0; i < data.length; i++) {
                    var x = data[i].x,
                        y = data[i].y,
                        bStrokeEnd = data[i].bStrokeEnd;

                    decodeArea.append(x + '\t\t\t\t' + y + '\t\t\t\t' + bStrokeEnd + '\n');
                }
            }
        });
    } else {
        $.ajax({
            url: decodeUrl + encodeType + '&path=Decode_Image.' + decodeFormat,
            type: 'POST',
            data: encodeContent,
            success: function success() {
                $.ajax({
                    url: decodepathUrl,
                    type: 'GET',
                    success: function success(resp) {
                        alert('檔案：' + resp + '\n已儲存');
                    }
                });
            }
        });
    };
};

// Get Valid
function getValid() {

    $.ajax({
        url: validUrl,
        type: 'GET',
        success: function success(data) {
            if (data) {
                alert('Protect is Valid');
            } else {
                alert('Protect is Not Valid');
            }
        }
    });
};

// Save Device Data
function saveData() {
    var svData = $('#svData').val();
    var svPath = '?path=sample_save.txt';

    $.ajax({
        url: savedataUrl + svPath,
        type: 'GET',
        data: {
            index: svData
        }
    });
};

// Read Device Data
function readData() {
    var reData = $('#reData').val();
    var rePath = '?path=sample_read.txt';

    $.ajax({
        url: readdataUrl + rePath,
        type: 'GET',
        data: {
            index: reData
        }
    });
};

// Clear Device Data
function clearData() {
    var clData = $('#clData').val();

    $.ajax({
        url: cleardataUrl,
        type: 'GET',
        data: {
            index: clData
        }
    });
};
//# sourceMappingURL=l500.js.map
