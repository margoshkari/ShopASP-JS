var isAdd = document.getElementById('isadd').value;
var categoryadd = document.getElementById("categoryadd").value;
var categorydelete = document.getElementById("categorydelete").value;

window.addEventListener('load', start, false);
function start() {
    if (isAdd != "required") {
        if (isAdd == "add") {
            document.getElementById("addform").style = "display:unset;";
        }
        else {
            document.getElementById("deleteform").style = "display:unset;";
        }
    }
    validateForm();
}
function validateForm() {
    if (categoryadd != "required") {
        if (categoryadd == "exist") {
            alert("Category is exist");
            return false;
        }
        else if (categoryadd == "notexist") {
            window.location.href = '/Index';
        }
    }
    if (categorydelete != "required") {
        if (categorydelete == "notexist") {
            alert("Category is not exist");
            return false;
        }
        else if (categorydelete == "exist") {
            window.location.href = '/Index';
        }
    }
}