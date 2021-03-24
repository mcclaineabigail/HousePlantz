const populateRoomInfo = function (){
    fetch("https://localhost:44313/api/rooms", {
        method: "GET",
        headers: {
            "Content-Type": "application/json",
        },
    })
.then((response) => response.json())
.then((rooms) => fillRoomSections(rooms))
.catch((error) => console.log(error));
};

const fillRoomSections = function(rooms){
    rooms.forEach(room => {
        fillSetRoomColorModal(room);
        fillSetPlantRoomModal(room);
    })
}

const fillSetRoomColorModal = function(room){
    let setRoomColorDiv = document.getElementById("select-room")
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

export { populateRoomInfo }