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
    // fetch("https://plantcatalog.azurewebsites.net/api/catalog", {   Local Host sample with text file
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
            deleteDropdown.appendChild(option);
};

const deletePlantFromCatalog = function(chosenPlant){

}




export { addPlantToCatalog, deletePlantFromCatalog }