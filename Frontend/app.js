fetch("https://plantcatalog.azurewebsites.net/api/catalog", {
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
.then((plantOptions) => fillDropDown(plantOptions))
.catch((error) => console.log(error));

const ownedSection = document.getElementById("owned");
const dropdown = document.getElementById("dropdown");
const button = document.getElementById("submit")

let makeCard = function(plant){
    let card = document.createElement("div");
    card.classList.add("plant");
        
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



const displayPlants = function(plants) {
    plants.forEach((plant) => {
        makeCard(plant);
    });
    return ownedSection;
}



const fillDropDown = function(plants) {
    plants.forEach((plant) => {
        let option = document.createElement("option");
        option.classList.add("choose-plant");
        option.innerText= plant.name;
        option.value = plant.id;
        dropdown.appendChild(option);
    });
    return dropdown;
}




button.addEventListener("click", () => {
    console.log("click, before fetch")
    
    fetch(`https://plantcatalog.azurewebsites.net/api/plants/${dropdown.value}`, {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
        },
    })
.then((response) => response.json())
.then((chosenPlant) => addPlantToCatalog(chosenPlant))
.catch((error) => console.log(error));

console.log(`click, after fetch ${dropdown.value}`)
});


const addPlantToCatalog = function(chosenPlant){
    console.log("addPlant Method initialization")

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
        

    console.log("create json");
};




