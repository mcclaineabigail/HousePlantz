import { put } from "/js/dynamic.js"

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

fetch("https://localhost:44313/api/plants", {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
        },
    })
.then((response) => response.json())
.then((plantOptions) => fillAddDropDown(plantOptions))
.catch((error) => console.log(error));

fetch("https://localhost:44313/api/rooms", {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
        },
    })
.then((response) => response.json())
.then((rooms) => fillRoomDropDown(rooms))
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
    flipCardOuter.id = plant.nickName;
    let flipCardInner = document.createElement("div");
    flipCardInner.classList.add("flip-card-inner");

    createCardFront(plant, flipCardInner, flipCardOuter)
    createCardBack(plant, flipCardInner, flipCardOuter);
       
    flipCardOuter.appendChild(flipCardInner);
    ownedSection.appendChild(flipCardOuter);

    fillChangeRoomDropdown(plant)
    fillDeletePlantDropdown(plant)
    
}

let createCardFront = function (plant, flipCardInner, flipCardOuter) {
    let cardFront = document.createElement("div");
    cardFront.classList.add("flip-card-front")
    cardFront.classList.add("standard");
    cardFront.id = ("card-front-" + plant.nickName);
    
    let titleAside = document.createElement("aside");
    titleAside.classList.add("plant-header")
    let names = document.createElement("div")
        names.classList.add("names");
    let plantName = document.createElement("h2");
        plantName.classList.add("plant-name");
        plantName.innerText = plant.nickName;
    let plantType = document.createElement("p");
        plantType.classList.add("plant-type");
        plantType.innerText = "(" + plant.name + ")";
    let sun = document.createElement("img");
        sun.src = plant.sun;
        sun.alt= "light needs";
        sun.classList.add("sun");
    names.appendChild(plantName);
    names.appendChild(plantType);
    titleAside.appendChild(names);
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
        flipIcon.addEventListener("click", () =>{
            flipCardOuter.classList.toggle("clicked")
        });
    infoAside.appendChild(photo);
    infoAside.appendChild(water);
    infoAside.appendChild(notes);
    infoAside.appendChild(flipIcon);
    cardFront.appendChild(titleAside);
    cardFront.appendChild(infoAside);
    flipCardInner.appendChild(cardFront);
}


let createCardBack = function (plant, flipCardInner, flipCardOuter) {
    let cardBack = document.createElement("div");
        cardBack.classList.add("flip-card-back");
    let cardBackInner = document.createElement("div");
        cardBackInner.classList.add("back-div");
    let changeNickNameLabel = document.createElement("label");
        changeNickNameLabel.for = "change-" + plant.nickName;
        changeNickNameLabel.innerText = "Change Nickname: "
    let changeNickName = document.createElement("input");
        changeNickName.classList.add("change-nickname");
        changeNickName.id = "change-" + plant.nickName;
        changeNickName.value = plant.nickName
    let changeNotesLabel = document.createElement("label");
        changeNotesLabel.for = "change-" + plant.notes;
        changeNotesLabel.innerText = "Change Notes: "
    let changeNotes = document.createElement("input");
        changeNotes.classList.add("change-notes");
        changeNotes.id = "change-" + plant.notes;
        changeNotes.value = plant.notes;
    let updateCardButton = document.createElement("button")
        updateCardButton.innerText = "Make Changes"
        updateCardButton.classList.add("button");
    let roomIcon = document.createElement("img");
        roomIcon.classList.add("room-icon");
        roomIcon.id = "room-icon-" + plant.nickName;
        roomIcon.alt = "Room"
        roomIcon.src = "/rooms/standard.png"

    updateCardButton.addEventListener("click", () => {
        const cardUpdates ={
                "id": plant.id,
                "name": plant.name,
                "sun": plant.sun,
                "image": plant.image,
                "water": plant.water,
                "notes": changeNotes.value,
                "color": plant.color,
                "nickName": changeNickName.value
              };
        put(cardUpdates, plant.id);
      });

    let flipIcon2 = document.createElement("img");
        flipIcon2.src = ("https://static.thenounproject.com/png/267318-200.png");
        flipIcon2.alt = ("flip card");
        flipIcon2.classList.add("flip-icon");
        flipIcon2.addEventListener("click", () =>{
            flipCardOuter.classList.toggle("clicked")
        });

    cardBackInner.appendChild(changeNickNameLabel);
    cardBackInner.appendChild(changeNickName);
    cardBackInner.appendChild(changeNotesLabel);
    cardBackInner.appendChild(changeNotes);
    cardBackInner.appendChild(updateCardButton);
    cardBackInner.appendChild(roomIcon);
    cardBack.appendChild(cardBackInner);
    cardBack.appendChild(flipIcon2);
    flipCardInner.appendChild(cardBack);
}



const fillChangeRoomDropdown = function(plant){
let addOption = document.createElement("option");
        addOption.classList.add("choose-plant");
        addOption.innerText= plant.nickName;
        addOption.value = plant.nickName;
        addOption.id = ("change-room-" + plant.id);
        changeRoomDropdown.appendChild(addOption);    
}


const fillDeletePlantDropdown = function(plant){
    let deleteOption = document.createElement("option");
    deleteOption.classList.add("choose-plant");
    deleteOption.innerText= plant.nickName;
    deleteOption.value = plant.nickName;
    deleteOption.id = ("delete-" + plant.nickName);
    deleteDropdown.appendChild(deleteOption);
}

const fillRoomDropDown = function(rooms){
    rooms.forEach(room => {
        fillSetRoomColorModal(room);
        fillSetPlantRoomModal(room);
    })
}

const fillSetRoomColorModal = function(room){
    let setRoomColorDiv = document.getElementById("set-room-color")
    let labelWrapper = document.createElement("label")
    let roomRadioInput = document.createElement("input")
        roomRadioInput.id = room.id;
        roomRadioInput.value = room.roomName;
        roomRadioInput.name = "room-choice";
        roomRadioInput.type = "radio"
    let setRoomImage = document.createElement("img");
        setRoomImage.classList.add("set-room-icon")
        setRoomImage.alt = room.roomName;
        setRoomImage.src = `/rooms/${room.roomName}-${room.color}.png`;
        
    labelWrapper.appendChild(roomRadioInput)
    labelWrapper.appendChild(setRoomImage)
    setRoomColorDiv.appendChild(labelWrapper)
}

const fillSetPlantRoomModal = function(room){
let assignroomDD = document.getElementById("change-dropdown-room")
let roomOption = document.createElement("option")
    roomOption.innerText = room.roomName;
    roomOption.value = room.id;
assignroomDD.appendChild(roomOption)
}


export { makeCard , fillAddDropDown, displayPlants}