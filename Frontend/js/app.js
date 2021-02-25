import { addPlantToCatalog, deleteCard} from "/js/dynamics.js"

const addDropdown = document.getElementById("add-dropdown");
const deleteDropdown = document.getElementById("delete-dropdown");

const submitButton = document.getElementById("submit")
const deleteButton = document.getElementById("delete")

submitButton.addEventListener("click", () => {
    fetch(`https://plantcatalog.azurewebsites.net/api/plants/${addDropdown.value}`, {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
        },
    })
    .then(response => response.json())
    .then(chosenPlant => addPlantToCatalog(chosenPlant))
    .catch(error => console.log(error));
});

deleteButton.addEventListener("click", () => {
    let plantToDelete = deleteDropdown.value
    
    fetch(`https://localhost:44313/api/text/${plantToDelete}`,{
        method: 'DELETE'
    })
    .then(response => response.json())
    .then(deleteCard(plantToDelete))
    .catch(error => console.log(error));
})


var addModal = document.getElementById("outer-add");
var addButton = document.getElementById("button-add");
var addSpan = document.getElementById("close-add");

addButton.onclick = function() {
  addModal.style.display = "block";
}
addSpan.onclick = function() {
    addModal.style.display = "none";
}
window.onclick = function(event) {
  if (event.target == addModal) {
    addModal.style.display = "none";
  }
}

var changeModal = document.getElementById("outer-change");
var changeButton = document.getElementById("button-change");
var changeSpan = document.getElementById("close-change");

changeButton.onclick = function() {
  changeModal.style.display = "block";
}
changeSpan.onclick = function() {
    changeModal.style.display = "none";
}
window.onclick = function(event) {
  if (event.target == changeModal) {
    changeModal.style.display = "none";
  }
}

var displayModal = document.getElementById("outer-display");
var displayButton = document.getElementById("button-display");
var displaySpan = document.getElementById("close-display");

displayButton.onclick = function() {
  displayModal.style.display = "block";
}
displaySpan.onclick = function() {
    displayModal.style.display = "none";
}
window.onclick = function(event) {
  if (event.target == displayModal) {
    displayModal.style.display = "none";
  }
}









