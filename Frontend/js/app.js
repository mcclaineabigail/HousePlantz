import { addPlantToCatalog, deleteCard, fetchAddPlant} from "/js/add+delete.js"
import { toggleDark} from "/js/menu.js"
import { Room } from "/js/room.js"


const addDropdown = document.getElementById("add-dropdown");
const submitButton = document.getElementById("submit");


submitButton.addEventListener("click", () => {
  let nickName = document.getElementById("add-input").value
  fetchAddPlant(addDropdown.value, nickName);
});

const deleteDropdown = document.getElementById("delete-dropdown");
const deleteButton = document.getElementById("delete");

deleteButton.addEventListener("click", () => {
    let plantToDeleteNickName = deleteDropdown.value;  // = Nickname
    console.log("plantToDeleteId: " + plantToDeleteNickName);
    let optionToDelete = document.getElementById("delete-" + plantToDeleteNickName);
    optionToDelete.remove();

    fetch(`https://localhost:44313/api/text/${plantToDeleteNickName}`,{
        method: 'DELETE'
    })
    .then(response => response.json())
    .then(plantToDelete => deleteCard(plantToDelete))
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
  toggleDark();
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
  const colorPatch = [{
    "path": "/color",
    "op": "replace",
    "value": roomToChange.value
}];
  patch(plantToChange.value, colorPatch);

  let changedCard = document.getElementById("card-front-" + plantToChange.value)
  changedCard.className = '';
  changedCard.classList.add("flip-card-front")
  changedCard.classList.add(roomToChange.value)
});


const patch = function(patchPlantNickName, patchJson){
  fetch(`https://localhost:44313/api/text/${patchPlantNickName}`,{
  method: 'PATCH',
  body: JSON.stringify(patchJson),
  headers: {
    'Content-Type': 'application/json-patch+json'
  }   
})
  .then(response => response.json())
  .catch(error => console.log(error));   
}











