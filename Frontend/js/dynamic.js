import { makeCard } from "/js/generatePlants.js"

const fetchAndAddPlantFromRepository = function(){
  var addDropdown = document.getElementById("add-dropdown");
  var nickName = document.getElementById("add-input").value
  var plantId = addDropdown.value
    fetch(`https://localhost:44313/api/plants/${plantId}`, {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
    },
  })
  .then(response => response.json())
  .then(chosenPlant => postPlantToCatalog(chosenPlant, nickName))
  .catch(error => console.log(error));
  
  var submitInput = document.getElementById("add-input");
  submitInput.value= "";
};


const postPlantToCatalog = function(chosenPlant, nickname){
  const postJson = {
    "id" : chosenPlant.id,
    "name" : chosenPlant.name,
    "sun" : chosenPlant.sun,
    "image" : chosenPlant.image,
    "water" : chosenPlant.water,
    "notes" : chosenPlant.notes, 
    "color" : "standard",
    "nickName" : nickname
  };
  fetch("https://localhost:44313/api/text", {  
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(postJson)
    })
    .then(response => response.json())
    .then(postJson => makeCard(postJson))
    .catch(err => console.error(err));
};

const deletePlant = function(){
  let plantToDeleteNickName = document.getElementById("delete-dropdown").value;
    let optionToDelete = document.getElementById("delete-" + plantToDeleteNickName);
    optionToDelete.remove();

    fetch(`https://localhost:44313/api/text/${plantToDeleteNickName}`,{
        method: 'DELETE'
    })
    .then(response => response.json())
    .then(plantToDelete => deleteCardFromPage(plantToDelete))
    .catch(error => console.log(error)); 
}

const deleteCardFromPage = function(deletedPlant){
  var cardToDelete = document.getElementById(deletedPlant.nickName);
      cardToDelete.remove();
  var changePlantOption = document.getElementById("change-room-" + deletedPlant.id);
      changePlantOption.remove();
}


const putRoom = function(selectedRoomId, roomJson){
  fetch(`https://localhost:44313/api/rooms/${selectedRoomId}`,{
    method: 'PUT',
    body: JSON.stringify(roomJson),
    headers: { 'Content-Type': 'application/json-patch+json' }   
  })
    .then(response => response.json())
    .catch(error => console.log(error));   
}

const setRoomColor = function() {
  var colorChoice = document.getElementById("room-color");
  var selectedRoomName = "";
  var selectedRoomId = ""
  var radioButtons = document.getElementsByName("room-choice");
    for(var i = 0; i < radioButtons.length; i++)
    {
      if(radioButtons[i].checked == true)
      {
        selectedRoomName = radioButtons[i].value
        selectedRoomId = radioButtons[i].id
      }
    }
  var roomJson = 
    {
      "id": selectedRoomId,
      "roomName": selectedRoomName,
      "color": colorChoice.value
    };
    putRoom(selectedRoomId, roomJson);
};


//TODO: Send this to the backend
let resetRooms = function(){
    fetch("https://localhost:44313/api/rooms", {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
        },
    })
.then((response) => response.json())
.then((rooms) => resetColorToStandard(rooms))
.catch((error) => console.log(error))
};

let resetColorToStandard = function(rooms){
  rooms.forEach(room => {
    let colorPatch = [{
        "path": "/color",
        "op": "replace",
        "value": "standard"
    }];

    fetch(`https://localhost:44313/api/rooms/${room.id}`,{
          method: 'PATCH',
          body: JSON.stringify(colorPatch),
          headers: {
            'Content-Type': 'application/json-patch+json'
          }   
        })
          .then(response => response.json())
          .catch(error => console.log(error));   
    })
}





export { postPlantToCatalog, deletePlant, fetchAndAddPlantFromRepository, putRoom, setRoomColor, resetRooms }

// let replaceCategoryPlant = function(changedPlant, id){
//   fetch(`https://localhost:44313/api/text/${id}`,{
//   method: 'PUT',
//   body: JSON.stringify(changedPlant),
//   headers: { 'Content-Type': 'application/json' }   
// })
//   .then(response => response.json())
//   .catch(error => console.log(error))
//   //.then(location.reload());  


// const patchText = function(patchPlantNickName, patchJson){
//     fetch(`https://localhost:44313/api/text/${patchPlantNickName}`,{
//     method: 'PATCH',
//     body: JSON.stringify(patchJson),
//     headers: {
//       'Content-Type': 'application/json-patch+json'
//     }   
//   })
//     .then(response => response.json())
//     .catch(error => console.log(error));   
// }