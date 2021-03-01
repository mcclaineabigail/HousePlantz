const ownedSection = document.getElementById("owned");
const addDropdown = document.getElementById("add-dropdown");
const deleteDropdown = document.getElementById("delete-dropdown");
const changeRoomDropdown = document.getElementById("change-dropdown-plant")

fetch("https://localhost:44313/api/text", {
//fetch("https://plantcatalog.azurewebsites.net/api/text", {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
        },
    })
.then((response) => response.json())
.then((plants) => displayPlants(plants))
.catch((error) => console.log(error));



fetch("https://localhost:44313/api/text", {
//fetch("https://plantcatalog.azurewebsites.net/api/text", {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
        },
    })
.then((response) => response.json())
.then((plants2) => fillDeleteDropDown(plants2))
.catch((error) => console.log(error));



fetch("https://localhost:44313/api/text", {
//fetch("https://plantcatalog.azurewebsites.net/api/text", {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
        },
    })
.then((response) => response.json())
.then((plants3) => fillChangeRoomDropDown(plants3))
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
    let card = document.createElement("figure");
    card.id = (plant.id);

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
        option.id = "choose-plant"+ plant2.id;
        deleteDropdown.appendChild(option);
    });
    return deleteDropdown;
}

const fillChangeRoomDropDown = function(plants3) {
    plants3.forEach((plant3) => {
        let option = document.createElement("option");
        option.classList.add("choose-plant");
        option.innerText= plant3.name;
        option.value = plant3.id;
        changeRoomDropdown.appendChild(option);
    });
    return changeRoomDropdown;
}

    export { makeCard , fillAddDropDown, fillDeleteDropDown, displayPlants}