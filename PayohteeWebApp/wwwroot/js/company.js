
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