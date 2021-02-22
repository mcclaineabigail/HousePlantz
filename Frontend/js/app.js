import { addPlantToCatalog} from "/js/dynamics.js"



const button = document.getElementById("submit")
button.addEventListener("click", () => {
    fetch(`https://plantcatalog.azurewebsites.net/api/plants/${dropdown.value}`, {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
        },
    })
.then((response) => response.json())
.then((chosenPlant) => addPlantToCatalog(chosenPlant))
.catch((error) => console.log(error));
});





