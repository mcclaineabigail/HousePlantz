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

fetch("https://plantcatalog.azurewebsites.net/api/plants", {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
        },
    })
.then((response) => response.json())
.then((plantOptions) => fillAddDropDown(plantOptions))
.catch((error) => console.log(error));

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


const displayPlants = function(plants) {
    plants.forEach((plant) => {
        makeCard(plant);
    });
    return ownedSection;
}

let makeCard = function(plant){
    let flipCardOuter = document.createElement("div");
    flipCardOuter.classList.add("flip-card");
    let flipCardInner = document.createElement("div");
    flipCardInner.classList.add("flip-card-inner")

    let cardFront = document.createElement("div");
    cardFront.classList.add("flip-card-front")
    cardFront.classList.add(plant.color);
    cardFront.id = (plant.id);
    
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
    let flipIcon = document.createElement("img");
        flipIcon.src = ("https://static.thenounproject.com/png/267318-200.png");
        flipIcon.alt = ("flip card");
        flipIcon.classList.add("flip-icon");
    infoAside.appendChild(photo);
    infoAside.appendChild(water);
    infoAside.appendChild(notes);
    infoAside.appendChild(flipIcon);

    let cardBack = document.createElement("div");
    cardBack.classList.add("flip-card-back");
    let flipIcon2 = document.createElement("img");
        flipIcon2.src = ("https://static.thenounproject.com/png/267318-200.png");
        flipIcon2.alt = ("flip card");
        flipIcon2.classList.add("flip-icon");
    cardBack.appendChild(flipIcon2);
    
    cardFront.appendChild(titleAside);
    cardFront.appendChild(infoAside);
    flipCardInner.appendChild(cardFront);
    flipCardInner.appendChild(cardBack);
    flipCardOuter.appendChild(flipCardInner);
    ownedSection.appendChild(flipCardOuter);

    fillChangeRoomDropdown(plant)
    fillDeletePlantDropdown(plant)
    
    flipIcon.addEventListener("click", () =>{
        flipCardOuter.classList.toggle("clicked")
    });
    flipIcon2.addEventListener("click", () =>{
        flipCardOuter.classList.toggle("clicked")
    });
}

const fillChangeRoomDropdown = function(plant){
let addOption = document.createElement("option");
        addOption.classList.add("choose-plant");
        addOption.innerText= plant.name;
        addOption.value = plant.id;
        addOption.id = "change-room-" + plant.id;
        changeRoomDropdown.appendChild(addOption);    
}

const fillDeletePlantDropdown = function(plant){
    let deleteOption = document.createElement("option");
    deleteOption.classList.add("choose-plant");
    deleteOption.innerText= plant.name;
    deleteOption.value = plant.id;
    deleteOption.id = "choose-plant"+ plant.id;
    deleteDropdown.appendChild(deleteOption);
}


export { makeCard , fillAddDropDown, displayPlants}