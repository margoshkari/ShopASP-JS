var products = JSON.parse(document.getElementById('products').innerHTML);
var categories = JSON.parse(document.getElementById('categories').innerHTML);
var categoryinput = document.getElementById('categoryinput');
var submitbtn = document.getElementById('delbtn');
var catbtn = document.getElementById('catbtn');

window.onload = funonload;
function funonload() {
    AddCard();
    AddCategory();
}

function AddCard() {
    for (var i = 0; i < products.length; i++) {
        let element = document.createElement("div");
        element.setAttribute('class', `elem`);

        //Картинка товара
        let image = document.createElement("img");
        image.setAttribute('src', `/img/${products[i]["ImageName"]}`);
        image.setAttribute('draggable', `false`);
        image.style = "width: 200px; height:200px; object-fit:cover";
        element.appendChild(image);

        //Название товара
        let name = document.createElement("h2");
        let text = document.createTextNode(`${products[i]["ProductName"]}`);
        name.appendChild(text);
        element.appendChild(name);

        //Кнопка "удалить"
        let deletebtn = document.createElement("div");
        deletebtn.setAttribute('class', `deletebtn`);
        deletebtn.setAttribute('name', `${products[i]["ProductName"]}`);
        deletebtn.innerHTML = `Delete`;
        deletebtn.style = "cursor:pointer; font-size: 20px; border-radius: 5px; background-color:rgb(204, 44, 44, 0.3);width: 100px;";
        element.appendChild(deletebtn);

        let container = document.getElementById("form-content");
        container.appendChild(element);
    }
    $('.deletebtn').on('click', function () {
        inputprod.value = $(this).attr('name');
        submitbtn.click();
    });
}

function AddCategory() {
    for (var i = 0; i < categories.length; i++) {
        let li = document.createElement("li");
        li.style = "height: 90px; display: flex; align-items: center; list-style: none;";

        //Кнопка категории
        let btn = document.createElement("div");
        btn.setAttribute('class', `categorybtn`);
        btn.setAttribute('name', `${categories[i]["idCategory"]}`);
        btn.innerHTML = `${categories[i]["CategoryName"]}`;
        btn.style = "cursor:pointer; font-size: 30px; text-decoration: none; width: 100%;" +
            "word-wrap: break-word; background-color: white; text-align: left;";
        li.appendChild(btn);

        let container = document.getElementById("categoryid");
        container.appendChild(li);
    }
    $('.categorybtn').on('click', function () {
        categoryinput.value = $(this).attr('name');
        catbtn.click();
    });
}