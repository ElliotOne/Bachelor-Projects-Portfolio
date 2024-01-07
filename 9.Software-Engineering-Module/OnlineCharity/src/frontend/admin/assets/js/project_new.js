document.getElementById("btnFileUploader").addEventListener("click", function () {
    document.getElementById("hiddenFileUploader").click();
})
document.getElementById("frmRegisterProject").addEventListener("submit", function (e) {
    e.preventDefault();




    var txttittle = document.getElementById("txttittle");
    txttittle.style.backgroundColor = "white";

    var txtdescription = document.getElementById("txtdescription");
    txtdescription.style.backgroundColor = "white";


    if (txttittle.value.toString().trim() == "") {
        txttittle.style.backgroundColor = "var(--dark)";
        txttittle.style.color = "white";
    } else {
        txttittle.style.color = "black";
    }

    if (txtdescription.value.toString().trim() == "") {
        txtdescription.style.backgroundColor = "var(--dark)";
        txtdescription.style.color = "white";
    } else {
        txtdescription.style.color = "black";
    }

    if (txtdescription.value.toString().trim() == "" && txttittle.value.toString().trim() == "") {
        e.preventDefault();
    } else {
        document.getElementById("submitAlert").setAttribute("class", "showAlert");
    }


})
document.getElementById("btnCloseSubmitAlert").addEventListener("click", function () {
    document.getElementById("submitAlert").removeAttribute("class");
})