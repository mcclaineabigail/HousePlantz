const body = document.getElementById("container");
const menu = document.getElementById("menu-content");
const modals = document.getElementsByClassName("middle")
const inputs = document.getElementsByTagName("INPUT");
const selects = document.getElementsByTagName("SELECT");

var _body = "body-darkMode"
var _switch = "color-switch"
var _accent = "dark-accent"

const toggleDark = function(){
    body.classList.toggle(_body);
    menu.classList.toggle(_switch)
    tagNameLoop(inputs, _accent);
    tagNameLoop(selects, _accent);
    tagNameLoop(modals, _switch);
    
}

const tagNameLoop = function(elements, _color){
    for (var i=0; i<elements.length; i++){
        elements[i].classList.toggle(_color)
        };
}

export {toggleDark};