import { deletePlant, fetchAndAddPlantFromRepository, setRoomColor, resetRooms } from "/js/dynamic.js"
import { toggleDark, modalFunctions } from "/js/menu.js"
import { populateRoomInfo } from "/js/generateRooms.js"


populateRoomInfo();
modalFunctions();


const submitButton = document.getElementById("submit");
      submitButton.addEventListener("click", () => {
      fetchAndAddPlantFromRepository();
});

const deleteButton = document.getElementById("delete");
      deleteButton.addEventListener("click", () => {
      deletePlant()
})

const slider = document.getElementById("slider");
      slider.addEventListener("change", () => {
      toggleDark();
});

const addRoomButton = document.getElementById("add-room-button");
      addRoomButton.addEventListener("click", () => {
      setRoomColor()
      var addModal = document.getElementById("outer-add");
      addModal.style.display = "block";
}); 

const resetRoomsButton = document.getElementById("reset-rooms")
      resetRoomsButton.addEventListener("click", () => {
      resetRooms()
})






//This section needs to be updated when tables are connected

// const changeRoomButton = document.getElementById("change-room-button");
// const plantToChange = document.getElementById("change-dropdown-plant");
// var roomToChange = document.getElementById("change-dropdown-room");

// changeRoomButton.addEventListener("click", () => {
//   let roomArray = roomToChange.value.split("-");
//   let room = roomArray[0]
//   let color = roomArray[1]

//   const colorPatch = [{
//     "path": "/color",
//     "op": "replace",
//     "value": color
// }];

//   patchRoom(plantToChange.value, colorPatch);
//   console.log(plantToChange.value);

//   let changedCard = document.getElementById("card-front-" + plantToChange.value);
//   changedCard.className = '';
//   changedCard.classList.add("flip-card-front");
//   changedCard.classList.add(color);
//   let roomIcon = document.getElementById("room-icon-" + plantToChange.value);
//     roomIcon.src = ("/rooms/" + room + "-" + color + ".png")
// });













