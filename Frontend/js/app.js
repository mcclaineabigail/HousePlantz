import { addPlantToCatalog, deleteCard} from "/js/dynamics.js"

const addDropdown = document.getElementById("add-dropdown");
const deleteDropdown = document.getElementById("delete-dropdown");

const addButton = document.getElementById("submit")
const deleteButton = document.getElementById("delete")

addButton.addEventListener("click", () => {
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

deleteButton.addEventListener("click", () => {
    let plantToDelete = deleteDropdown.value
    
    fetch(`https://localhost:44313/api/text/${plantToDelete}`,{
        method: 'DELETE'
    })
    .then(response => response.json())
    .then(deleteCard(plantToDelete))
    .catch(error => console.log(error));
})












