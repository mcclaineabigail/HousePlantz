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

const modalFunctions = function(){
    var addModal = document.getElementById("outer-add");
    var addButton = document.getElementById("button-add");
    var addSpan = document.getElementById("close-add");
    var displayModal = document.getElementById("outer-display");
    var displayButton = document.getElementById("button-display");
    var displaySpan = document.getElementById("close-display");
    var changeModal = document.getElementById("outer-change");
    var changeButton = document.getElementById("button-change");
    var changeSpan = document.getElementById("close-change");
    
    addButton.onclick = function() {
        addModal.style.display = "block";}
    addSpan.onclick = function() {
        addModal.style.display = "none";}
    window.onclick = function(event) {
      if (event.target == addModal) {
        addModal.style.display = "none";}}
    changeButton.onclick = function() {
      changeModal.style.display = "block";}
    changeSpan.onclick = function() {
        changeModal.style.display = "none";}
    window.onclick = function(event) {
      if (event.target == changeModal) {
        changeModal.style.display = "none";}}
    displayButton.onclick = function() {
      displayModal.style.display = "block";}
    displaySpan.onclick = function() {
        displayModal.style.display = "none";}
    window.onclick = function(event) {
      if (event.target == displayModal) {
        displayModal.style.display = "none";}
    };  
}

export { toggleDark, modalFunctions };