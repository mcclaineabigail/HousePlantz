import { makeCard } from "/js/generateInfo.js"

const addPlantToCatalog = function(chosenPlant, nickname){
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

const fetchAddPlant = function(plantId, nickName){
    fetch(`https://plantcatalog.azurewebsites.net/api/plants/${plantId}`, {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
    },
  })
  .then(response => response.json())
  .then(chosenPlant => addPlantToCatalog(chosenPlant, nickName))
  .catch(error => console.log(error));
};

const deleteCard = function(deletedPlant){
    console.log("deletedPlant: " + deletedPlant)
    var cardToDelete = document.getElementById(deletedPlant.nickName);
    cardToDelete.remove();
    let changePlantOption = document.getElementById("change-room-" + deletedPlant.id);
    changePlantOption.remove(); 
    console.log("changePlantOption.id: " + changePlantOption.id);
}




export { addPlantToCatalog, deleteCard, fetchAddPlant }