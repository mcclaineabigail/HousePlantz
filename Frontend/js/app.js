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
    fetch(`https://plantcatalog.azurewebsites.net/api/plants/${deleteDropdown.value}`,{
        method: "DELETE",
        headers: {
            "Content-Type": "application/json",
        },
    })
    .then(response => response.json())
    .then(deletedPlant => deleteCard(deletedPlant))
    .catch(error => console.console.log(error));
})












