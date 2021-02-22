import {makeCard} from "/js/generateInfo.js"

const addPlantToCatalog = function(chosenPlant){
    const postJson = {
        "id" : chosenPlant.id,
        "name" : chosenPlant.name,
        "sun" : chosenPlant.sun,
        "image" : chosenPlant.image,
        "water" : chosenPlant.water,
        "notes" : chosenPlant.notes
    };

    fetch("https://plantcatalog.azurewebsites.net/api/catalog", {
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




export { addPlantToCatalog }