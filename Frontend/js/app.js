import { deleteCard, fetchPlantFromRepository, patch} from "/js/dynamic.js"
import { toggleDark} from "/js/menu.js"
import { Room } from "/js/room.js"


const addDropdown = document.getElementById("add-dropdown");
const submitButton = document.getElementById("submit");


submitButton.addEventListener("click", () => {
  let nickName = document.getElementById("add-input").value
  fetchPlantFromRepository(addDropdown.value, nickName);
  let submitInput = document.getElementById("add-input");
  submitInput.value= "";
});

const deleteDropdown = document.getElementById("delete-dropdown");
const deleteButton = document.getElementById("delete");

deleteButton.addEventListener("click", () => {
    let plantToDeleteNickName = deleteDropdown.value;
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


const addRoom = function() {
  let newRoom = new Room(roomDD.value, roomDD.value, colorDD.value);
  rooms.push(newRoom);
  let addedRoom = document.createElement("li");
  addedRoom.innerText = roomDD.value;
  addedRoom.classList.add(colorDD.value);
  roomList.appendChild(addedRoom);
  let roomToAdd = document.createElement("option");
  roomToAdd.innerText= roomDD.value;
  roomToAdd.id= roomDD.value;
  roomToAdd.value = roomDD.value + "-" + colorDD.value;
  roomsChange.appendChild(roomToAdd);
  let optionToRemove = document.getElementById(roomDD.value);
  optionToRemove.remove();
}

addRoomButton.addEventListener("click", addRoom);

const changeRoomButton = document.getElementById("change-room-button");
const plantToChange = document.getElementById("change-dropdown-plant");
var roomToChange = document.getElementById("change-dropdown-room");

changeRoomButton.addEventListener("click", () => {
  let roomArray = roomToChange.value.split("-");
  let room = roomArray[0]
  let color = roomArray[1]

  console.log(room + " + " + color );
  const colorPatch = [{
    "path": "/color",
    "op": "replace",
    "value": color
}];
  patch(plantToChange.value, colorPatch);
  console.log(plantToChange.value);

  let changedCard = document.getElementById("card-front-" + plantToChange.value);
  changedCard.className = '';
  changedCard.classList.add("flip-card-front");
  changedCard.classList.add(color);
  let roomIcon = document.getElementById("room-icon-" + plantToChange.value);
    roomIcon.src = ("/rooms/" + room + "-" + color + ".png")
});













