var category = document.getElementById('category').value;

window.addEventListener('load', validateForm, false);
function validateForm() {
    if (category != "required") {
        if (category == "notexist") {
            alert("Category is not exist");
            return false;
        }
        else if (category == "exist") {
            window.location.href = '/Index';
        }
    }
}