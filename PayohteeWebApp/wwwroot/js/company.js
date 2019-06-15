var contactcount = 0;
var contactarr = [];
var contactarrobj = [];
var geoarr = [];
var geoarrobj = [];
var lat;
var lon;
var coords = document.getElementById("demo");

function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition);
    } else {
        coords.innerHTML = "Geolocation is not supported by this browser.";
    }
}

function showPosition(position) {
    coords.innerHTML = "Latitude: " + position.coords.latitude +
        "<br>Longitude: " + position.coords.longitude;
    lat = position.coords.latitude;
    lon = position.coords.longitude;
    var coordrec = [];
    var coordjson = {};

    coordrec.push(lat);
    coordjson["Latitude"] = lat.toString();
    coordjson["Lat"] = lat;
    coordrec.push(lon);
    coordjson["Longitude"] = lon.toString();
    coordjson["Lon"] = lon;

    geoarr.push(coordrec);
    geoarrobj.push(coordjson);

}

document.addEventListener('DOMContentLoaded', function (e) {
    var form = document.getElementById("company");
    var output = document.getElementById("output");
    $(".success-checkmark").hide();

    $(document).on('click', '#btnSubmit', function (e) {
        //e.preventDefault();

        var json = toJSONString(form);
        output.innerHTML = json;
        $.post("/Company/Register", { companyjson: json }, function (data, status) {
            if (data == "success") {
                $(".success-checkmark").hide();
                setTimeout(function () {
                    $(".success-checkmark").show();
                }, 10);
            }
            else {
                errors = JSON.parse(data);
                alert(data);
            }
        });

    });
});

$('#AddContact').on('click', function () {

    var contactrec = [];
    var contactjson = {};

    var contactnameval = $('#ContactName').val();
    var contactemailval = $('#ContactEmail').val();
    var contactmobileval = $('#ContactMobile').val();
    var contacttitleval = $('#ContactTitle').val();

    var pillcontainer = document.getElementById('pillcontainer');
    var pillwrapper = document.getElementById('pillwrapper');

    //create instance of list elements
    var pill = document.createElement("li");
    var contacticon = document.createElement("i");
    var emailicon = document.createElement("i");
    var mobileicon = document.createElement("i");
    pill.setAttribute("id", "contactcount" + contactcount);
    pill.setAttribute("class", "chip");
    contacticon.setAttribute("class", "fa fa-id-card");
    emailicon.setAttribute("class", "fa fa-envelope");
    mobileicon.setAttribute("class", "fa fa-mobile");

    var removeicon = document.createElement("span");
    removeicon.setAttribute("class", "fa fa-minus");

    var elemspan = document.createElement("span");
    var emailanchor = document.createElement("a");
    var phoneanchor = document.createElement("a");

    emailanchor.setAttribute("href", "mailto:" + contactemailval);
    emailanchor.appendChild(document.createTextNode(contactemailval));

    phoneanchor.setAttribute("href", "tel:" + contactmobileval);
    phoneanchor.appendChild(document.createTextNode(contactmobileval));

    elemspan.appendChild(removeicon);
    elemspan.appendChild(contacticon);
    elemspan.appendChild(document.createTextNode(contactnameval));
    elemspan.appendChild(emailicon);
    elemspan.appendChild(emailanchor);
    elemspan.appendChild(mobileicon);
    elemspan.appendChild(phoneanchor);

    pill.appendChild(elemspan);
    pillwrapper.appendChild(pill);
    pillcontainer.appendChild(pillwrapper);
    //contactrec.push("contact" + contactcount);
    contactrec.push(contactnameval);
    contactjson["ContactName"] = contactnameval;
    contactrec.push(contactemailval);
    contactjson["ContactEmail"] = contactemailval;
    contactrec.push(contactmobileval);
    contactjson["ContactMobile"] = contactmobileval;
    contactrec.push(contacttitleval);
    contactjson["ContactTitle"] = contacttitleval;

    contactarr.push(contactrec);

    contactarrobj.push(contactjson);

    contactcount++;
});

$('#AddLocation').on('click', function () {
    getLocation();
});

$(document).on('dblclick', '.pillwrapper li', function (event) {

    var key = this.id.toString();
    var elem = document.getElementById(this.id.toString());
    elem.parentNode.removeChild(elem);
    RemoveInfo(key);
});

$(document).on('click', '.resultcomp p', function () {

    var result = document.getElementById('searchmodel').value = $(this).text();
    if (result == "") {
        document.getElementById("txtHintcomp").innerHTML = "";
        return;
    } else {
        if (window.XMLHttpRequest) {
            // code for IE7+, Firefox, Chrome, Opera, Safari
            xmlhttp = new XMLHttpRequest();
        } else {
            // code for IE6, IE5
            xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
        }
        xmlhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                document.getElementById("txtHintcomp").innerHTML = this.responseText;
            }
        };

        xmlhttp.open("GET", "/Company/DetailsName?companyname=" + result, false);
        xmlhttp.send();

        $(document).on('click', '#btnUpdate', function (e) {
            e.preventDefault();
            var form_edit = document.getElementById("company_edit");
            var json = toJSONString(form_edit);
            var id = document.getElementById("CompanyId").value;
            output.innerHTML = json;
            $.post("/Company/Update", { companyjson: json, id: id }, function (data) {
                if (data == "Success") {
                    $(".check-icon").hide();
                    setTimeout(function () {
                        $(".check-icon").show();
                    }, 10);
                }
                else {

                }
            });
        });

        $(document).on('click', '#btnDelete', function (e) {
            e.preventDefault();
            var form_edit = document.getElementById("company_edit");
            var json = toJSONString(form_edit);
            var id = document.getElementById("CompanyId").value;
            output.innerHTML = json;
            $.post("/Company/Delete", { id: id }, function (data) {

            });
        });

    }
    $(this).parent(".result").empty();
});

$('#searchmodel').on('keyup input', function () {
    /* Get input value on change */
    var inputVal = $(this).val();
    var resultdropdown = $(this).siblings(".resultcomp");
    var isnum = /[0-9]/;
    var isalpha = /[a-zA-Z]/;

    if (inputVal.length) {
        if (isalpha.test(inputVal)) {
            $.get("/Company/Lookup", { charinput: inputVal }, function (data) {
                var htmlresult = '';
                var listul;
                for (var i = 0; i < data.length; i++) {
                    htmlresult = htmlresult + '<li><p><strong>' + data[i] + '</strong></p></li>';
                }
                listul = '<ul style="list-style:none;">' + htmlresult + '</ul>';
                resultdropdown.html(listul);
            });
        } else
            if (isnum.test(inputVal)) {
            }

    } else {
        resultdropdown.empty();
    }
});

function RemoveInfo(key) {

    var indextoremove;
    for (i = 0; i < contactarr.length; i++) {

        if (contactarr[i][0] === key) {

            indextoremove = i;
        }
    }
    contactarrobj.splice(indextoremove, 1);
    contactarr.splice(indextoremove, 1);
}

function RemoveCoord(key) {
    var indextoremove;
    for (i = 0; i < geoarr.length; i++) {

        if (geoarr[i][0] === key) {

            indextoremove = i;
        }
    }
    geoarrobj.splice(indextoremove, 1);
    geoarr.splice(indextoremove, 1);
}

function toJSONString(form) {

    var obj = {};

    var companyelements = form.querySelectorAll("input, select, textarea");

    for (var i = 0; i < companyelements.length; ++i) {
        var companyelement = companyelements[i];
        var name = companyelement.name;
        var value = companyelement.value;

        if (name) {
            obj[name] = value;
        }
    }
    obj["Contacts"] = contactarrobj;
    obj["Coordinates"] = geoarrobj;

    return JSON.stringify(obj);
}

