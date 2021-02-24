import { addPlantToCatalog} from "/js/dynamics.js"

const addDropdown = document.getElementById("add-dropdown");

const addButton = document.getElementById("submit")
const deleteButton = document.getElementById("delete")

addButton.addEventListener("click", () => {
    fetch(`https://plantcatalog.azurewebsites.net/api/plants/${addDropdown.value}`, {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
        },
    })
.then((response) => response.json())
.then((chosenPlant) => addPlantToCatalog(chosenPlant))
.catch((error) => console.log(error));
});












