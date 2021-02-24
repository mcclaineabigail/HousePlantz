const ownedSection = document.getElementById("owned");
const addDropdown = document.getElementById("add-dropdown");
const deleteDropdown = document.getElementById("delete-dropdown");

fetch("https://localhost:44313/api/text", {
// fetch("https://plantcatalog.azurewebsites.net/api/catalog", {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
        },
    })
.then((response) => response.json())
.then((plants) => displayPlants(plants))
.catch((error) => console.log(error));

fetch("https://localhost:44313/api/text", {
// fetch("https://plantcatalog.azurewebsites.net/api/catalog", {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
        },
    })
.then((response) => response.json())
.then((plants2) => fillDeleteDropDown(plants2))
.catch((error) => console.log(error));

fetch("https://plantcatalog.azurewebsites.net/api/plants", {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
        },
    })
.then((response) => response.json())
.then((plantOptions) => fillAddDropDown(plantOptions))
.catch((error) => console.log(error));

const displayPlants = function(plants) {
    plants.forEach((plant) => {
        makeCard(plant);
    });
    return ownedSection;
}


let makeCard = function(plant){
    let card = document.createElement("div");
    card.classList.add("plant");
    card.classList.add(plant.id);

    let titleAside = document.createElement("aside");
    titleAside.classList.add("plant-header")
    

    let plantName = document.createElement("h2");
    plantName.classList.add("plant-name");
    plantName.innerText = plant.name;
    let sun = document.createElement("img");
    sun.src = plant.sun;
    sun.alt= "light needs";
    sun.classList.add("sun");
    titleAside.appendChild(plantName);
    titleAside.appendChild(sun);

    let infoAside = document.createElement("aside");
    infoAside.classList.add("plant-info");
    let photo = document.createElement("img");
    photo.classList.add("image");
    photo.alt= ("Plant Image");
    photo.src = plant.image;
    let water = document.createElement("p")
    water.classList.add("water");
    water.innerText= plant.water;
    let notes = document.createElement("p")
    notes.classList.add("notes");
    notes.innerText= plant.notes;
    infoAside.appendChild(photo);
    infoAside.appendChild(water);
    infoAside.appendChild(notes);
       
    card.appendChild(titleAside);
    card.appendChild(infoAside);
    ownedSection.appendChild(card);
}

const fillAddDropDown = function(plants) {
    plants.forEach((plant) => {
        let option = document.createElement("option");
        option.classList.add("choose-plant");
        option.innerText= plant.name;
        option.value = plant.id;
        addDropdown.appendChild(option);
    });
    return addDropdown;
}

const fillDeleteDropDown = function(plants2) {
    plants2.forEach((plant2) => {
        let option = document.createElement("option");
        option.classList.add("choose-plant");
        option.innerText= plant2.name;
        option.value = plant2.id;
        deleteDropdown.appendChild(option);
    });
    return deleteDropdown;
}

    export { makeCard , fillAddDropDown, fillDeleteDropDown, displayPlants}