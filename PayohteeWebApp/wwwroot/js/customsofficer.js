var accountcount = 0;
var accountarr = [];
var accountarrobj = [];

document.addEventListener('DOMContentLoaded', function (e) {

    var form = document.getElementById("customsofficer");
    var output = document.getElementById("output");

    $(".success-checkmark").hide();

    $('#AddAccount').on('click', function () {

        var accountrec = [];
        var accountjson = {};

        var accountnameval = $('#BankName').val();
        var accountnumber = $('#AccountNumber').val();


        var pillcontainer = document.getElementById('pillcontainer');
        var pillwrapper = document.getElementById('pillwrapper');

        //create instance of list elements
        var pill = document.createElement("li");
        var accounticon = document.createElement("i");
        var contacticon = document.createElement("i");

        pill.setAttribute("id", "accountcount" + accountcount);
        pill.setAttribute("class", "chip");
        accounticon.setAttribute("class", "fa fa-id-card");
        contacticon.setAttribute("class", "fa fa-id-card");

        var removeicon = document.createElement("span");
        removeicon.setAttribute("class", "fa fa-minus");

        var elemspan = document.createElement("span");

        elemspan.appendChild(removeicon);
        elemspan.appendChild(accounticon);
        elemspan.appendChild(document.createTextNode(accountnumber));
        elemspan.appendChild(contacticon);

        elemspan.appendChild(document.createTextNode(accountnameval));

        pill.appendChild(elemspan);
        pillwrapper.appendChild(pill);
        pillcontainer.appendChild(pillwrapper);
        accountrec.push("account" + accountcount);
        accountrec.push(accountnameval);
        accountjson["BankName"] = accountnameval;
        accountrec.push(accountnumber);
        accountjson["AccountNumber"] = accountnumber;

        accountarr.push(accountrec);

        accountarrobj.push(accountjson);

        accountcount++;
    });

    $(document).on('dblclick', '.pillwrapper li', function (event) {

        var key = this.id.toString();
        var elem = document.getElementById(this.id.toString());
        elem.parentNode.removeChild(elem);
        RemoveInfo(key);
    });

    $(document).on('click', '.resultoffcr p', function () {

        var result = document.getElementById('searchmodel').value = $(this).text();
        if (result == "") {
            document.getElementById("txtHintOffcr").innerHTML = "";
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

            xmlhttp.open("GET", "/CustomsOfficer/DetailsName?officername=" + result, false);
            xmlhttp.send();

            $(document).on('click', '#btnUpdate', function (e) {
                e.preventDefault();
                var form_edit = document.getElementById("account_edit");
                var json = toJSONString(form_edit);
                var id = document.getElementById("accountId").value;
                output.innerHTML = json;
                $.post("/CustomsOfficer/Update", { customsofficerjson: json, id: id }, function (data) {
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
                var form_edit = document.getElementById("account_edit");
                var json = toJSONString(form_edit);
                var id = document.getElementById("CustomsOfficerId").value;
                output.innerHTML = json;
                $.post("/CustomsOfficer/Delete", { id: id }, function (data) {

                });
            });

        }
        $(this).parent(".result").empty();
    });

    $('#searchmodel').on('keyup input', function () {

        /* Get input value on change */
        var inputVal = $(this).val();
        var resultdropdown = $(this).siblings(".resultoffcr");
        var isnum = /[0-9]/;
        var isalpha = /[a-zA-Z]/;

        if (inputVal.length) {
            if (isalpha.test(inputVal)) {
                $.get("/CustomsOfficer/Lookup", { charinput: inputVal }, function (data) {
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

    $(document).on('click', '#btnSubmit', function (e) {
        //e.preventDefault();
        var json = toJSONString(form);
        output.innerHTML = json;
        //$.post("/CustomsOfficer/Register", { customsofficerjson: json }, function (data, status) {
        //    if (data == "success") {
        //        $(".success-checkmark").hide();
        //        setTimeout(function () {
        //            $(".success-checkmark").show();
        //        }, 10);
        //    }
        //    else {
        //        errors = JSON.parse(data);
        //        alert(data);
        //    }
        //});

    });

});

function RemoveInfo(key) {

    var indextoremove;
    for (i = 0; i < accountarr.length; i++) {

        if (accountarr[i][0] === key) {

            indextoremove = i;
        }
    }
    accountarrobj.splice(indextoremove, 1);
    accountarr.splice(indextoremove, 1);
}

function toJSONString(form) {

    var obj = {};

    var accountelements = form.querySelectorAll("input, select, textarea");

    for (var i = 0; i < accountelements.length; ++i) {
        var accountelement = accountelements[i];
        var name = accountelement.name;
        var value = accountelement.value;

        if (name) {
            obj[name] = value;
        }
    }
    obj["BankAccounts"] = accountarrobj;

    return JSON.stringify(obj);
}