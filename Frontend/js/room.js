class Room {
    constructor(display, room, color) {
        this._display = display;
        this._room = room;
        this._color = color; 
    }

    setDisplay(roomName) {
        display = roomName;
    }
    getDisplay() {
        return _display;
    }

    setRoom(roomName) {
    room = roomName;
    }

    getColor(){
        return color;
    }

    setColor(chosenColor) {
        color = chosenColor;
    }


}

export {Room}

