import { makeCard } from "/js/generateInfo.js"

const fetchPlantFromRepository = function(plantId, nickName){
    fetch(`https://localhost:44313/api/plants/${plantId}`, {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
    },
  })
  .then(response => response.json())
  .then(chosenPlant => postPlantToCatalog(chosenPlant, nickName))
  .catch(error => console.log(error));
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
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(postJson)
        })
        .then(response => response.json())
        .then(postJson => makeCard(postJson))
        .catch(err => console.error(err));
};


const deleteCard = function(deletedPlant){
    console.log("deletedPlant: " + deletedPlant)
    var cardToDelete = document.getElementById(deletedPlant.nickName);
    cardToDelete.remove();
    let changePlantOption = document.getElementById("change-room-" + deletedPlant.id);
    changePlantOption.remove(); 
    console.log("changePlantOption.id: " + changePlantOption.id);
}


const patchText = function(patchPlantNickName, patchJson){
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

const putRoom = function(selectedRoomId, roomJson){
  fetch(`https://localhost:44313/api/rooms/${selectedRoomId}`,{
    method: 'PUT',
    body: JSON.stringify(roomJson),
    headers: {
      'Content-Type': 'application/json-patch+json'
    }   
  })
    .then(response => response.json())
    .catch(error => console.log(error));   
}


const put = function(changedPlant, id){
    fetch(`https://localhost:44313/api/text/${id}`,{
    method: 'PUT',
    body: JSON.stringify(changedPlant),
    headers: {
      'Content-Type': 'application/json'
    }   
  })
    .then(response => response.json())
    .catch(error => console.log(error))
    //.then(location.reload());  
}



export { postPlantToCatalog, deleteCard, fetchPlantFromRepository, patchText, putRoom, put }