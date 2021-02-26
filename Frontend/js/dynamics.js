import { fillAddDropDown, 
    fillDeleteDropDown, 
    makeCard
} from "/js/generateInfo.js"

const deleteDropdown = document.getElementById("delete-dropdown");

const addPlantToCatalog = function(chosenPlant){
    const postJson = {
        "id" : chosenPlant.id,
        "name" : chosenPlant.name,
        "sun" : chosenPlant.sun,
        "image" : chosenPlant.image,
        "water" : chosenPlant.water,
        "notes" : chosenPlant.notes
    };

    fetch("https://localhost:44313/api/text", {
    //fetch("https://plantcatalog.azurewebsites.net/api/text", {   
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(postJson)
        })
        .then(response => response.json())
        .then(postJson => makeCard(postJson))
        .catch(err => console.error(err));

            let option = document.createElement("option");
            option.classList.add("choose-plant");
            option.innerText= chosenPlant.name;
            option.value = chosenPlant.id;
            option.value = plant.id;
            deleteDropdown.appendChild(option);
};

const deleteCard = function(deletedPlantId){
    console.log(deletedPlantId)
    var cardToDelete = document.getElementById(deletedPlantId);
    cardToDelete.remove();
}




export { addPlantToCatalog, deleteCard }