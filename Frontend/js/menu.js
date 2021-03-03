const body = document.getElementById("container");
const modal1 = document.getElementById("middle-add");
const modal2 = document.getElementById("middle-change");
const modal3 = document.getElementById("middle-display");
const menu = document.getElementById("menu-content");


const toggleDark = function(){
    body.classList.toggle("body-darkMode");
    modal1.classList.toggle("color-switch");
    modal2.classList.toggle("color-switch");
    modal3.classList.toggle("color-switch");
    menu.classList.toggle("color-switch")
}

export {toggleDark};