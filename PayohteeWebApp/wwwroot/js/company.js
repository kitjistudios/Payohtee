var contactcount = 0;
var contactarr = [];

$('#AddContact').on('click', function () {
    //alert("hello");
    var contactrec = [];
    var contactemail = $('#ContactEmail').val();
    var contactname = $('#ContactName').val();
    var contactnumber = $('#ContactNumber').val();

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

    emailanchor.setAttribute("href", "mailto:" + contactemail);
    emailanchor.appendChild(document.createTextNode(contactemail));

    phoneanchor.setAttribute("href", "tel:" + contactnumber);
    phoneanchor.appendChild(document.createTextNode(contactnumber));

    elemspan.appendChild(removeicon);
    elemspan.appendChild(contacticon);
    elemspan.appendChild(document.createTextNode(contactname));
    elemspan.appendChild(emailicon);
    elemspan.appendChild(emailanchor);
    elemspan.appendChild(mobileicon);
    elemspan.appendChild(phoneanchor);



    pill.appendChild(elemspan);
    pillwrapper.appendChild(pill);
    pillcontainer.appendChild(pillwrapper);
    contactrec.push("preaccount" + contactcount);
    // acctrec.push(acctid);
    //acctrec.push(OperationalSupportTotal);
    // acctrec.push(document.getElementById("AccountNumber").value);
    contactarr.push(contactrec);

    contactcount++;

});

$('#searchmodel').on('keyup input', function () {
    /* Get input value on change */
    //alert('search');
    var inputVal = $(this).val();
    var resultdropdown = $(this).siblings(".resultcomp");

    var isnum = /[0-9]/;
    var isalpha = /[a-zA-Z]/;

    if (inputVal.length) {
        if (isalpha.test(inputVal)) {
            $.get("/Company/Lookup", { charinput: inputVal }, function (data) {
                var htmlresult = '';
                for (var i = 0; i < data.length; i++) {
                    htmlresult = htmlresult + '<p><strong>' + data[i] + '</strong></p>';
                }
                resultdropdown.html(htmlresult);
            });
        } else
            if (isnum.test(inputVal)) {
            }

    } else {
        resultdropdown.empty();
    }
});

$(document).on("click", ".resultcomp p", function () {
    var result = document.getElementById('searchcomp').value = $(this).text();
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
        $.post("Admin/Details", { companyname: result }, function (data) {

        });
        //xmlhttp.open("GET", "../Views/Shared/Controls/CompanySearch/getuserwm.php?q=" + $test, true);
        //xmlhttp.send();
    }
});

$(document).on("dblclick", ".pillwrapper li", function (event) {

    var key = this.id.toString();
    var elem = document.getElementById(this.id.toString());
    elem.parentNode.removeChild(elem);
    RemoveInfo(key);
});

function RemoveInfo(key) {

    var indextoremove;
    for (i = 0; i < contactarr.length; i++) {

        if (contactarr[i][0] === key) {
            alert(contactarr[i][1]);
            indextoremove = i;
        }
    }
    contactarr.splice(indextoremove, 1);
}