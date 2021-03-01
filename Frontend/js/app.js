import { addPlantToCatalog, deleteCard} from "/js/add+delete.js"
import { toggle } from "/js/menu.js"
import { Room } from "/js/room.js"


const addDropdown = document.getElementById("add-dropdown");
const submitButton = document.getElementById("submit");

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

const deleteDropdown = document.getElementById("delete-dropdown");
const deleteButton = document.getElementById("delete");

deleteButton.addEventListener("click", () => {
    let plantToDelete = deleteDropdown.value;
    console.log("choose-plant" + plantToDelete);
    let optionToDelete = document.getElementById("choose-plant" + plantToDelete);
    optionToDelete.remove();

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


const slider = document.getElementById("slider");
slider.addEventListener("change", () => {
    toggle();
});


const rooms = [];
const roomDD = document.getElementById("room-name");
const colorDD = document.getElementById("room-color");
const roomList = document.getElementById("rooms-list");
const roomsChange = document.getElementById("change-dropdown-room");

const addRoomButton = document.getElementById("add-room-button");
addRoomButton.addEventListener("click", () => {
let newRoom = new Room(roomDD.value, colorDD.value);
rooms.push(newRoom);
let addedRoom = document.createElement("li");
addedRoom.innerText = roomDD.value;
addedRoom.classList.add(colorDD.value);
roomList.appendChild(addedRoom);
let roomToAdd = document.createElement("option");
roomToAdd.innerText= roomDD.value;
roomToAdd.value = colorDD.value;
roomsChange.appendChild(roomToAdd);
let optionToRemove = document.getElementById(roomDD.value);
optionToRemove.remove();
});

const changeRoomButton = document.getElementById("change-room-button");
let plantToChange = document.getElementById("change-dropdown-plant");
let roomToChange = document.getElementById("change-dropdown-room");

changeRoomButton.addEventListener("click", () => {
  const postJson = [{
    "path": "/color",
    "op": "replace",
    "value": roomToChange.value
}];

  fetch(`https://localhost:44313/api/text/${plantToChange.value}`,{
        method: 'PATCH',
        body: JSON.stringify(postJson),
        headers: {
          'Content-Type': 'application/json-patch+json'
        }
        
    })
    .then(response => response.json())
    .catch(error => console.log(error));   

    let changedCard = document.getElementById(plantToChange.value)
    changedCard.className = '';
    changedCard.classList.add(roomToChange.value)

  });











